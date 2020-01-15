using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace open_console
{
    class Program
    {
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);
        [DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        const int SW_RESTORE = 9;
        public static bool TryBringToFront(string title)
        {
            // Get a handle to the Calculator application.
            IntPtr handle = FindWindow(null, title);

            // Verify that Calculator is a running process.
            if (handle == IntPtr.Zero)
            {
                return false;
            }
            if (IsIconic(handle))
            {
                ShowWindow(handle, SW_RESTORE);
            }

            Console.WriteLine("Founded ");
            SetForegroundWindow(handle);
            return true;
        }

        static void Main(string[] args)
        {

            if (args.Length > 0)
            {
                if (!TryBringToFront(args[0]))
                {
                    var psi = new ProcessStartInfo("powershell.exe");
                    psi.Arguments = $"-NoExit -Command \"$Host.UI.RawUI.WindowTitle='{args[0]}'\"";
                    psi.WorkingDirectory = args[0];
                    Process.Start(psi);
                }
            }
            else
            {
                Console.WriteLine("specify program window title");
            }

        }
    }
}
