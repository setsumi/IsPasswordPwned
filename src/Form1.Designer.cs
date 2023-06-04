namespace IsPasswordPwned
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSHA1 = new System.Windows.Forms.TextBox();
            this.tbNTLM = new System.Windows.Forms.TextBox();
            this.labPassInfo = new System.Windows.Forms.Label();
            this.tbApiSha1 = new System.Windows.Forms.TextBox();
            this.lbApiSha1 = new System.Windows.Forms.ListBox();
            this.lbApiNtlm = new System.Windows.Forms.ListBox();
            this.tbApiNtlm = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.labResult = new System.Windows.Forms.Label();
            this.sharpClipboard1 = new WK.Libraries.SharpClipboardNS.SharpClipboard(this.components);
            this.chkClipboard = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPassword.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(13, 31);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(559, 22);
            this.tbPassword.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tbPassword, "Esc - clear password");
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            this.tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPassword_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SHA1 hash";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "NTLM (NT) hash";
            // 
            // tbSHA1
            // 
            this.tbSHA1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSHA1.Location = new System.Drawing.Point(13, 87);
            this.tbSHA1.Name = "tbSHA1";
            this.tbSHA1.ReadOnly = true;
            this.tbSHA1.Size = new System.Drawing.Size(308, 22);
            this.tbSHA1.TabIndex = 2;
            this.tbSHA1.Text = "B1B3773A05C0ED0176787A4F1574FF0075F7521E";
            // 
            // tbNTLM
            // 
            this.tbNTLM.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNTLM.Location = new System.Drawing.Point(343, 87);
            this.tbNTLM.Name = "tbNTLM";
            this.tbNTLM.ReadOnly = true;
            this.tbNTLM.Size = new System.Drawing.Size(310, 22);
            this.tbNTLM.TabIndex = 3;
            this.tbNTLM.Text = "2D20D252A479F485CDF5E171D93985BF";
            // 
            // labPassInfo
            // 
            this.labPassInfo.AutoSize = true;
            this.labPassInfo.Location = new System.Drawing.Point(100, 15);
            this.labPassInfo.Name = "labPassInfo";
            this.labPassInfo.Size = new System.Drawing.Size(62, 13);
            this.labPassInfo.TabIndex = 6;
            this.labPassInfo.Text = "labPassInfo";
            // 
            // tbApiSha1
            // 
            this.tbApiSha1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApiSha1.Location = new System.Drawing.Point(12, 191);
            this.tbApiSha1.Name = "tbApiSha1";
            this.tbApiSha1.ReadOnly = true;
            this.tbApiSha1.Size = new System.Drawing.Size(309, 20);
            this.tbApiSha1.TabIndex = 4;
            this.tbApiSha1.Text = "https://api.pwnedpasswords.com/range/21BD1";
            // 
            // lbApiSha1
            // 
            this.lbApiSha1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbApiSha1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApiSha1.FormattingEnabled = true;
            this.lbApiSha1.HorizontalScrollbar = true;
            this.lbApiSha1.Location = new System.Drawing.Point(13, 229);
            this.lbApiSha1.Name = "lbApiSha1";
            this.lbApiSha1.Size = new System.Drawing.Size(308, 186);
            this.lbApiSha1.TabIndex = 6;
            // 
            // lbApiNtlm
            // 
            this.lbApiNtlm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbApiNtlm.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApiNtlm.FormattingEnabled = true;
            this.lbApiNtlm.HorizontalScrollbar = true;
            this.lbApiNtlm.Location = new System.Drawing.Point(343, 229);
            this.lbApiNtlm.Name = "lbApiNtlm";
            this.lbApiNtlm.Size = new System.Drawing.Size(310, 186);
            this.lbApiNtlm.TabIndex = 7;
            // 
            // tbApiNtlm
            // 
            this.tbApiNtlm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbApiNtlm.Location = new System.Drawing.Point(343, 191);
            this.tbApiNtlm.Name = "tbApiNtlm";
            this.tbApiNtlm.ReadOnly = true;
            this.tbApiNtlm.Size = new System.Drawing.Size(310, 20);
            this.tbApiNtlm.TabIndex = 5;
            this.tbApiNtlm.Text = "https://api.pwnedpasswords.com/range/DFCA7?mode=ntlm";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Location = new System.Drawing.Point(578, 31);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // labResult
            // 
            this.labResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labResult.Location = new System.Drawing.Point(12, 118);
            this.labResult.Name = "labResult";
            this.labResult.Size = new System.Drawing.Size(641, 62);
            this.labResult.TabIndex = 12;
            this.labResult.Text = "Oh no — pwned!\r\nThis password has been seen 11 times before\r\nThis password has pr" +
    "eviously appeared in a data breach and should never be used. If you\'ve ever used" +
    " it anywhere before, change it!";
            this.labResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sharpClipboard1
            // 
            this.sharpClipboard1.MonitorClipboard = false;
            this.sharpClipboard1.ObservableFormats.All = true;
            this.sharpClipboard1.ObservableFormats.Files = true;
            this.sharpClipboard1.ObservableFormats.Images = true;
            this.sharpClipboard1.ObservableFormats.Others = true;
            this.sharpClipboard1.ObservableFormats.Texts = true;
            this.sharpClipboard1.ObserveLastEntry = true;
            this.sharpClipboard1.Tag = null;
            this.sharpClipboard1.ClipboardChanged += new System.EventHandler<WK.Libraries.SharpClipboardNS.SharpClipboard.ClipboardChangedEventArgs>(this.sharpClipboard1_ClipboardChanged);
            // 
            // chkClipboard
            // 
            this.chkClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkClipboard.AutoSize = true;
            this.chkClipboard.Location = new System.Drawing.Point(461, 11);
            this.chkClipboard.Name = "chkClipboard";
            this.chkClipboard.Size = new System.Drawing.Size(111, 17);
            this.chkClipboard.TabIndex = 13;
            this.chkClipboard.Text = " Monitor Clipboard";
            this.toolTip1.SetToolTip(this.chkClipboard, "If window is not visible shows Windows notification");
            this.chkClipboard.UseVisualStyleBackColor = true;
            this.chkClipboard.CheckedChanged += new System.EventHandler(this.chkClipboard_CheckedChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 427);
            this.Controls.Add(this.chkClipboard);
            this.Controls.Add(this.labResult);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lbApiNtlm);
            this.Controls.Add(this.tbApiNtlm);
            this.Controls.Add(this.lbApiSha1);
            this.Controls.Add(this.tbApiSha1);
            this.Controls.Add(this.labPassInfo);
            this.Controls.Add(this.tbNTLM);
            this.Controls.Add(this.tbSHA1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "IsPasswordPwned?";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSHA1;
        private System.Windows.Forms.TextBox tbNTLM;
        private System.Windows.Forms.Label labPassInfo;
        private System.Windows.Forms.TextBox tbApiSha1;
        private System.Windows.Forms.ListBox lbApiSha1;
        private System.Windows.Forms.ListBox lbApiNtlm;
        private System.Windows.Forms.TextBox tbApiNtlm;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label labResult;
        private WK.Libraries.SharpClipboardNS.SharpClipboard sharpClipboard1;
        private System.Windows.Forms.CheckBox chkClipboard;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

