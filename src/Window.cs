using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System;

public static class Window
{
    public static bool IsOverlapped(IWin32Window window)
    {
        if (window == null)
            throw new ArgumentNullException("window");
        if (window.Handle == IntPtr.Zero)
            throw new InvalidOperationException("Window does not yet exist");
        if (!IsWindowVisible(window.Handle))
            return false;

        IntPtr hWnd = window.Handle;
        HashSet<IntPtr> visited = new HashSet<IntPtr> { hWnd };

        // The set is used to make calling GetWindow in a loop stable by checking if we have already
        //  visited the window returned by GetWindow. This avoids the possibility of an infinate loop.

        RECT thisRect;
        GetWindowRect(hWnd, out thisRect);

        while ((hWnd = GetWindow(hWnd, GW_HWNDPREV)) != IntPtr.Zero && !visited.Contains(hWnd))
        {
            visited.Add(hWnd);
            RECT testRect, intersection;
            if (IsWindowVisible(hWnd) && GetWindowRect(hWnd, out testRect) && IntersectRect(out intersection, ref thisRect, ref testRect))
                return true;
        }

        return false;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetWindowRect(IntPtr hWnd, [Out] out RECT lpRect);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IntersectRect([Out] out RECT lprcDst, [In] ref RECT lprcSrc1, [In] ref RECT lprcSrc2);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool IsWindowVisible(IntPtr hWnd);

    private const int GW_HWNDPREV = 3;

    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
}
