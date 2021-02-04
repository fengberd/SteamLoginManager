using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SteamLoginManager
{
    public static class NTAPI
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        public static string GetWindowText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            if (size > 0)
            {
                var builder = new StringBuilder(size + 1);
                GetWindowText(hWnd, builder, builder.Capacity);
                return builder.ToString();
            }
            return "";
        }

        [DllImport("User32.dll")]
        public static extern int SetForegroundWindow(IntPtr point);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public HARDWAREINPUT Hardware;
            [FieldOffset(0)]
            public KEYBDINPUT Keyboard;
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint Msg;
            public ushort ParamL;
            public ushort ParamH;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort Vk;
            public ushort Scan;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int X;
            public int Y;
            public uint MouseData;
            public uint Flags;
            public uint Time;
            public IntPtr ExtraInfo;
        }

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        public static void LeftClick(IntPtr handle, Point relative)
        {
            ClientToScreen(handle, ref relative);

            var oldPos = Cursor.Position;
            Cursor.Position = relative;

            var inputMouseDown = new INPUT
            {
                Type = 0
            };
            inputMouseDown.Data.Mouse.Flags = 0x0002;

            var inputMouseUp = new INPUT
            {
                Type = 0
            };
            inputMouseUp.Data.Mouse.Flags = 0x0004;

            SendInput(2, new INPUT[]
            {
                inputMouseDown,
                inputMouseUp
            }, Marshal.SizeOf(typeof(INPUT)));

            Cursor.Position = oldPos;
        }

        public static void SendString(string data)
        {
            var keyList = new List<INPUT>();

            void createInputs(ushort vk, uint flag, ushort scan)
            {
                INPUT keyDown = new INPUT
                {
                    Type = 1
                };
                keyDown.Data.Keyboard.Vk = vk;
                keyDown.Data.Keyboard.Flags = flag;
                keyDown.Data.Keyboard.Scan = scan;
                keyList.Add(keyDown);

                INPUT keyUp = new INPUT
                {
                    Type = 1
                };
                keyUp.Data.Keyboard.Vk = vk;
                keyUp.Data.Keyboard.Flags = flag | 0x0002;
                keyUp.Data.Keyboard.Scan = scan;
                keyList.Add(keyUp);
            }

            foreach (ushort c in data)
            {
                if (c == '\n')
                {
                    // Enter key
                    createInputs(13, 0, 0);
                }
                else
                {
                    createInputs(0, 0x0004, c);
                }
            }
            SendInput((uint)keyList.Count, keyList.ToArray(), Marshal.SizeOf(typeof(INPUT)));
        }
    }
}
