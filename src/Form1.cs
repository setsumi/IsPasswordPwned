using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Dispatcher.CurrentDispatcher.InvokeAsync(() =>
{
}, DispatcherPriority.Normal);
*/

namespace IsPasswordPwned
{
    public partial class FormMain : Form
    {
        private struct ApiTaskItem
        {
            public ListBox listboxData;
            public TextBox textboxUrl;
            public TextBox textboxHash;
        }

        string _exe_dir = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        int _taskWorkNumber = 0;
        ApiTaskItem[] _tasks;

        public FormMain()
        {
            InitializeComponent();

            tbPassword.MaxLength = int.MaxValue;

            ApiTaskItem[] tasks = {
                new ApiTaskItem {listboxData=lbApiSha1, textboxUrl=tbApiSha1, textboxHash=tbSHA1},
                new ApiTaskItem {listboxData=lbApiNtlm, textboxUrl=tbApiNtlm, textboxHash=tbNTLM}
            };
            _tasks = tasks;
        }

        private void Info()
        {
            string str = tbPassword.Text;
            string invis = "";
            bool loop = true;
            foreach (char ch in str)
            {
                var cat = char.GetUnicodeCategory(ch);
                switch (cat)
                {
                    case System.Globalization.UnicodeCategory.Control:
                    case System.Globalization.UnicodeCategory.Format:
                    case System.Globalization.UnicodeCategory.LineSeparator:
                    case System.Globalization.UnicodeCategory.NonSpacingMark:
                    case System.Globalization.UnicodeCategory.ParagraphSeparator:
                    case System.Globalization.UnicodeCategory.SpaceSeparator:
                    case System.Globalization.UnicodeCategory.SpacingCombiningMark:
                        invis = "   Warning: invisible characters";
                        loop = false;
                        break;
                }
                if (!loop) break;
            }
            labPassInfo.ForeColor = string.IsNullOrEmpty(invis) ? SystemColors.ControlText : Color.Red;
            labPassInfo.Text = $"chars: {str.Length}{invis}";
            if (_taskWorkNumber == 0) btnCheck.Enabled = str.Length > 0;
        }

        private void Calc()
        {
            var string_password = tbPassword.Text;
            var bytes_password = Encoding.UTF8.GetBytes(string_password); // UTF-8 for SHA1

            string string_sha1, api_sha1;
            string string_ntlm, api_ntlm;

            if (bytes_password.Length > 0)
            {
                var sha1 = System.Security.Cryptography.SHA1.Create();
                var bytes_sha1 = sha1.ComputeHash(bytes_password);
                var bytes_ntlm = string_password.MD4(); // UTF-16 LE always for NTLM

                string_sha1 = BitConverter.ToString(bytes_sha1).Replace("-", "").ToUpperInvariant();
                string_ntlm = BitConverter.ToString(bytes_ntlm).Replace("-", "").ToUpperInvariant();
                api_sha1 = $"https://api.pwnedpasswords.com/range/{string_sha1.Substring(0, 5)}";
                api_ntlm = $"https://api.pwnedpasswords.com/range/{string_ntlm.Substring(0, 5)}?mode=ntlm";
            }
            else
            {
                string_sha1 = "";
                string_ntlm = "";
                api_sha1 = "";
                api_ntlm = "";
            }

            tbSHA1.Text = string_sha1;
            tbNTLM.Text = string_ntlm;
            tbApiSha1.Text = api_sha1;
            tbApiNtlm.Text = api_ntlm;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            Info();
            Calc();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            tbPassword_TextChanged(null, null);
            ShowResults(labResult, "Results");
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            ShowResults(labResult, "Wait...");

            UpdateStatus(_tasks.Length);

            foreach (ApiTaskItem task in _tasks)
            {
                ListBoxSetText(task.listboxData, "Fetching data...");

                Task.Run(() =>
                {
                    ListBoxSetText(task.listboxData, GetPage(task.textboxUrl.Text));
                }).ContinueWith(t =>
                {
                    var ex = t.Exception?.GetBaseException();
                    if (ex != null) ListBoxSetText(task.listboxData, $"Error\n{ex.GetType()}\n{ex.Message}");
                    UpdateStatus(-1);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private void ListBoxSetText(ListBox lb, string text)
        {
            if (lb.InvokeRequired)
            {
                lb.Invoke(new Action<ListBox, string>(ListBoxSetText), lb, text);
            }
            else
            {
                lb.BeginUpdate();
                lb.Items.Clear();
                using (StringReader reader = new StringReader(text))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lb.Items.Add(line);
                    }
                }
                lb.EndUpdate();
            }
        }

        private void ShowResults(Label lab, string text)
        {
            if (lab.InvokeRequired)
            {
                lab.Invoke(new Action<Label, string>(ShowResults), lab, text);
            }
            else
            {
                lab.Text = text;
                if (text.StartsWith("Good news"))
                {
                    lab.BackColor = Color.LightGreen;
                    lab.ForeColor = Color.Black;
                }
                else if (text.StartsWith("Oh no"))
                {
                    lab.BackColor = Color.Red;
                    lab.ForeColor = Color.Yellow;
                }
                else
                {
                    lab.BackColor = SystemColors.Control;
                    lab.ForeColor = SystemColors.ControlText;
                }
            }
        }


        private void UpdateStatus(int n)
        {
            if (n >= 0)
            {
                _taskWorkNumber = n;
                btnCheck.Enabled = false;
                return;
            }
            _taskWorkNumber += n;
            if (_taskWorkNumber == 0)
            {
                btnCheck.Enabled = true;
                CheckResults();
            }
        }

        private void CheckResults()
        {
            int hitcount = 0;
            int errorcount = 0;
            bool error = false;

            foreach (ApiTaskItem task in _tasks)
            {
                try
                {
                    if (task.listboxData.Items[0].ToString().StartsWith("Error"))
                    {
                        error = true;
                    }
                    else
                    {
                        string hash2 = task.textboxHash.Text.Substring(5);
                        int index = task.listboxData.FindString(hash2);
                        task.listboxData.SelectedIndex = index;
                        if (index != -1)
                        {
                            string hitString = task.listboxData.SelectedItem.ToString().Split(':')[1];
                            int hit = int.Parse(hitString);
                            if (hit > hitcount) hitcount = hit;
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = true;
                    MessageBox.Show(ex.GetType() + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (error) errorcount++;
                error = false;
            }

            string results;
            if (errorcount == _tasks.Length)
            {
                results = $"Unable to get data.";
            }
            else
            {
                if (hitcount == 0)
                    results = $"Good news — no pwnage found!\r\nThis password wasn't found in any of the Pwned Passwords lists. That doesn't necessarily mean it's a good password, merely that it's not appeared in data breach.";
                else
                    results = $"Oh no — pwned!\r\nThis password has been seen {hitcount} times before\r\nThis password has previously appeared in a data breach and should never be used. If you've ever used it anywhere before, change it!";
            }
            ShowResults(labResult, results);
        }

        private string GetPage(string link)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            request.Method = "GET";
            request.UserAgent = UserAgent();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private string UserAgent()
        {
            string userAgent = "Mozilla/5.0 (X11; Linux i586; rv:31.0) Gecko/20100101 Firefox/70.0";
            List<string> userAgentList = new List<string>();
            try
            {
                // load useragents from file
                string input = File.ReadAllText(_exe_dir + Path.DirectorySeparatorChar + "useragent.ini");
                StringReader reader = new StringReader(input);
                string line = null;
                do
                {
                    line = reader.ReadLine();
                    if (line != null) // do something with the line
                    {
                        userAgentList.Add(line);
                    }
                } while (line != null);

                // get random useragent
                if (userAgentList.Count > 0)
                    userAgent = userAgentList[new Random().Next(0, userAgentList.Count)];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetType() + "\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return userAgent;
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // disable beep
                if (btnCheck.Enabled) btnCheck_Click(null, null);
            }
        }
    }
}
