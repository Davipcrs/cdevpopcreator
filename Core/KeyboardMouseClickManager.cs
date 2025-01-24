using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;




namespace cdevpopcreator
{
    internal class MouseClickManager
    {

        public Task Execute(System.Threading.CancellationToken token)
        {
            return Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {

                    if (System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.Left)
                    {

                        PrintScreenManager.getInstance().Execute(@"C:\temp\");
                    }

                    if (System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.Right)
                    {

                        PrintScreenManager.getInstance().Execute(@"C:\temp\");
                    }

                    if (System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.Middle)
                    {

                        PrintScreenManager.getInstance().Execute(@"C:\temp\");
                    }
                    Thread.Sleep(100); // Light delay to reduce CPU usage
                }

            });

        }

    }

    internal class KeyboardClickManager
    {
        private IntPtr _hookId = IntPtr.Zero;
        private LowLevelKeyboardProc _proc;
        private String writeHistory = "";

        public KeyboardClickManager()
        {
            _proc = HookCallback;
        }

        public void Start()
        {
            _hookId = SetHook(_proc);
            //Console.WriteLine("KeyboardClickManager started.");
        }

        public void Stop()
        {
            if (_hookId != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookId);
                Console.WriteLine(writeHistory);
                //Console.WriteLine("KeyboardClickManager stopped.");
            }
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                string keyChar = GetKeyCharacter(vkCode);
                //Console.WriteLine($"Key pressed: {keyChar}");
                


                //Console.WriteLine(keyChar);

                // Handle specific key actions here
                if (keyChar == "Enter")
                {
                    // Print, save writeHistory to md
                    writeHistory = "";
                    return CallNextHookEx(_hookId, nCode, wParam, lParam);
                }
                writeHistory = writeHistory + keyChar;
            }
            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        private string GetKeyCharacter(int vkCode)
        {
            StringBuilder sb = new StringBuilder(5);
            byte[] keyboardState = new byte[256];
            GetKeyboardState(keyboardState);

            int scanCode = MapVirtualKey((uint)vkCode, 0);
            int result = ToUnicode((uint)vkCode, (uint)scanCode, keyboardState, sb, sb.Capacity, 0);

            return result > 0 ? sb.ToString() : ((ConsoleKey)vkCode).ToString();
        }

        // Windows API imports
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern int GetKeyboardState(byte[] lpKeyState);

        [DllImport("user32.dll")]
        private static extern int MapVirtualKey(uint uCode, int uMapType);

        [DllImport("user32.dll")]
        private static extern int ToUnicode(uint wVirtKey, uint wScanCode, byte[] lpKeyState,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff, int cchBuff, uint wFlags);


        public async Task Execute(CancellationToken token)
        {

            /*
            return Task.Run(() =>
            {
                Start();
                while (!token.IsCancellationRequested)
                {
                    Thread.Sleep(100);
                }
                Stop();
            });
               */

            try
            {
                Start();
                await Task.Delay(Timeout.Infinite, token);
            }
            catch (TaskCanceledException)
            {
                // Task was canceled, stop the hook
            }
            finally
            {

            }

        }
    }

}
