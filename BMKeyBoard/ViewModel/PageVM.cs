using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using BMKeyBoard.Model;
using System.Runtime.InteropServices;
using System.Threading;
using BMKeyBoard.Annotations;
using BMKeyBoard.Utilities;
using BMKeyBoard.View.Pages;

namespace BMKeyBoard.ViewModel
{
    class PageVM:INotifyPropertyChanged
    {
        private ObservableCollection<Pr> _proc = new ObservableCollection<Pr>();
        public ObservableCollection<Pr> Proc
        {
            get => _proc;
            set
            {
                _proc = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Alphabet> _model_Eng = new ObservableCollection<Alphabet>();
        public ObservableCollection<Alphabet> Eng_Model
        {
            get => _model_Eng;
            set
            {
                _model_Eng = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Alphabet> _model_Rus = new ObservableCollection<Alphabet>();
        public ObservableCollection<Alphabet> Rus_Model
        {
            get => _model_Rus;
            set
            {
                _model_Rus = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Alphabet> _model_Key = new ObservableCollection<Alphabet>();
        public ObservableCollection<Alphabet> Key_Model
        {
            get => _model_Key;
            set
            {
                _model_Key = value;
                OnPropertyChanged();
            }
        }
        

        public static bool sh
        {
            get;
            set;
        }
        public PageVM()
        {

            Process[] ProcessesList = Process.GetProcesses();
            foreach (var m in ProcessesList)
            {
                if (m.MainWindowTitle != "")
                    Proc.Add(new Pr(m.MainWindowTitle));
            }
            ISendCommand =new RelayCommand(send_command);
            sh = false;
            EngAlph();
            RusAlph();
            NumKeys();

        }

        private void EngAlph() 
        {
            Eng_Model.Add(new Alphabet());
            Eng_Model[0].StrList.Add(new OneStr());
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('q', 'Q', "../../Resource/q1.png", "../../Resource/Q.png", 1, 1, 81, 81));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('w', 'W', "../../Resource/w1.png", "../../Resource/W.png", 1, 1, 87, 87));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('e', 'E', "../../Resource/e1.png", "../../Resource/E.png", 1, 1, 69, 69));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('r', 'R', "../../Resource/r1.png", "../../Resource/R.png", 1, 1, 82, 82));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('t', 'T', "../../Resource/t1.png", "../../Resource/T.png", 1, 1, 84, 84));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('y', 'Y', "../../Resource/y1.png", "../../Resource/Y.png", 1, 1, 89, 89));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('u', 'U', "../../Resource/u1.png", "../../Resource/U.png", 1, 1, 85, 85));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('i', 'I', "../../Resource/i1.png", "../../Resource/I.png", 1, 1, 73, 73));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('o', 'O', "../../Resource/o1.png", "../../Resource/O.png", 1, 1, 79, 79));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('p', 'P', "../../Resource/p1.png", "../../Resource/P.png", 1, 1, 80, 80));
           Eng_Model[0].StrList[0].Str.Add(new My_Keys('!', '?', "../../Resource/!.png", "../../Resource/!!.png", 1, 1, 0, 0));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys(' ', ' ', "../../Resource/del.png", "../../Resource/del.png", 1, 2.5, 8, 8));
            Eng_Model[0].StrList.Add(new OneStr());
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('a', 'A', "../../Resource/a1.png", "../../Resource/A.png", 1, 1, 65, 65));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('d', 'D', "../../Resource/d1.png", "../../Resource/D.png", 1, 1, 68, 68));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('s', 'S', "../../Resource/s1.png", "../../Resource/S.png", 1, 1, 83, 83));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('f', 'F', "../../Resource/f1.png", "../../Resource/F.png", 1, 1, 70, 70));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('g', 'G', "../../Resource/g1.png", "../../Resource/G.png", 1, 1, 71, 71));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('h', 'H', "../../Resource/h1.png", "../../Resource/H.png", 1, 1, 72, 72));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('j', 'J', "../../Resource/j1.png", "../../Resource/J.png", 1, 1, 74, 74));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('k', 'K', "../../Resource/k1.png", "../../Resource/K.png", 1, 1, 75, 75));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('l', 'L', "../../Resource/l1.png", "../../Resource/L.png", 1, 1, 76, 76));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('*', '*', "../../Resource/!!!.png", "../../Resource/!!!.png", 1, 1, 0, 0));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys(' ', ' ', "../../Resource/enter.png", "../../Resource/enter.png", 1, 2.5, 13, 13));
            Eng_Model[0].StrList.Add(new OneStr());
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('z', 'Z', "../../Resource/z1.jpg", "../../Resource/Z.png", 1, 1, 90, 90));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('x', 'X', "../../Resource/x1.png", "../../Resource/X.png", 1, 1, 88, 88));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('c', 'C', "../../Resource/c1.png", "../../Resource/C.png", 1, 1, 67, 67));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('v', 'V', "../../Resource/v1.png", "../../Resource/V.png", 1, 1, 86, 86));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('b', 'B', "../../Resource/b1.png", "../../Resource/B.png", 1, 1, 66, 66));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('n', 'N', "../../Resource/n1.png", "../../Resource/N.png", 1, 1, 78, 78));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('m', 'M', "../../Resource/m1.png", "../../Resource/M.png", 1, 1, 77, 77));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys(',', ',', "../../Resource/comma.png", "../../Resource/comma.png", 1, 1, 0, 0));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('.', '.', "../../Resource/dot.png", "../../Resource/dot.png", 1, 1, 0, 0));
            Eng_Model[0].StrList.Add(new OneStr());
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/shift.png", "../../Resource/shift.png", 1, 1, 16, 16));
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/num.png", "../../Resource/num.png", 1, 1, -2, -2));
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "", "", 1, 6, 32, 32));
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/eng.png", "../../Resource/eng.png", 1, 1, -1, -1));
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/shift.png", "../../Resource/shift.png", 1, 1, 16, 16));

            //Eng_Model.Add(new My_Keys('', '', "../../Resource/1.png", "../../Resource/.png", 1, 1, "", ""));

        }
        public enum VKeys
        {
            VK_LBUTTON = 1,
            VK_RBUTTON = 2,
            VK_CANCEL = 3,
            VK_MBUTTON = 4,
            VK_BACK = 8,
            VK_TAB = 9,
            VK_CLEAR = 12,
            VK_RETURN = 13,
            VK_SHIFT = 16,
            VK_CONTROL = 17,
            VK_MENU = 18,
            VK_PAUSE = 19,
            VK_CAPITAL = 20,
            VK_ESCAPE = 27,
            VK_SPACE = 32,
            VK_PRIOR = 33,
            VK_NEXT = 34,
            VK_END = 35,
            VK_HOME = 36,
            VK_LEFT = 37,
            VK_UP = 38,
            VK_RIGHT = 39,
            VK_DOWN = 40,
            VK_SELECT = 41,
            VK_PRINT = 42,
            VK_EXECUTE = 43,
            VK_SNAPSHOT = 44,
            VK_INSERT = 45,
            VK_DELETE = 46,
            VK_HELP = 47,
            VK_0 = 48,
            VK_1 = 49,
            VK_2 = 50,
            VK_3 = 51,
            VK_4 = 52,
            VK_5 = 53,
            VK_6 = 54,
            VK_7 = 55,
            VK_8 = 56,
            VK_9 = 57,
            VK_A = 65,
            VK_B = 66,
            VK_C = 67,
            VK_D = 68,
            VK_E = 69,
            VK_F = 70,
            VK_G = 71,
            VK_H = 72,
            VK_I = 73,
            VK_J = 74,
            VK_K = 75,
            VK_L = 76,
            VK_M = 77,
            VK_N = 78,
            VK_O = 79,
            VK_P = 80,
            VK_Q = 81,
            VK_R = 82,
            VK_S = 83,
            VK_T = 84,
            VK_U = 85,
            VK_V = 86,
            VK_W = 87,
            VK_X = 88,
            VK_Y = 89,
            VK_Z = 90,
            VK_NUMPAD0 = 96,
            VK_NUMPAD1 = 97,
            VK_NUMPAD2 = 98,
            VK_NUMPAD3 = 99,
            VK_NUMPAD4 = 100,
            VK_NUMPAD5 = 101,
            VK_NUMPAD6 = 102,
            VK_NUMPAD7 = 103,
            VK_NUMPAD8 = 104,
            VK_NUMPAD9 = 105,
            VK_SEPARATOR = 108,
            VK_SUBTRACT = 109,
            VK_DECIMAL = 110,
            VK_DIVIDE = 111,
            VK_F1 = 112,
            VK_F2 = 113,
            VK_F3 = 114,
            VK_F4 = 115,
            VK_F5 = 116,
            VK_F6 = 117,
            VK_F7 = 118,
            VK_F8 = 119,
            VK_F9 = 120,
            VK_F10 = 121,
            VK_F11 = 122,
            VK_F12 = 123,
            VK_SCROLL = 145,
            VK_LSHIFT = 160,
            VK_RSHIFT = 161,
            VK_LCONTROL = 162,
            VK_RCONTROL = 163,
            VK_LMENU = 164,
            VK_RMENU = 165,
            VK_PLAY = 250,
            VK_ZOOM = 251,
            VK_LWinKey = 91,
            VK_RWinKey = 92,
            VK_OEM_MINUS = 0xBD,
            VK_OEM_PLUS = 187,
            VK_OEM_1 = 0xba,
            VK_OEM_COMMA = 0xbc,
            VK_OEM_PERIOD = 0xbe,
            VK_OEM_2 = 0xbf,
            VK_OEM3 = 0xc0,
            VK_OEM_4 = 0xdb,
            VK_OEM_5 = 0xdc,
            VK_OEM_6 = 0xdd,
            VK_OEM_7 = 0xde,
            VK_OEM_8 = 0xdf,
            VK_NONE = 255
        };

        private void RusAlph()
        {
        }

        private void NumKeys()
        {
        }

        public ICommand ISendCommand { get; private set; }
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]

        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int keyCode);
        [DllImport("User32.dll")]
        public static extern int GetKeyboardLayout(int dwLayout);
        [DllImport("User32.dll")]
        public static extern int GetWindowThreadProcessId(int hwnd, int lpdwProcessId);
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static int SendKey(int key)
        {
            keybd_event((byte)(key), 0x45, 0x01, 0);
            keybd_event((byte)(key), 0x45, 0x01 | 0x02, 0);

            return 0;
        }

        public static void Sh()
        {
            if (sh)
            {
                sh = false;
                keybd_event((byte) (16), 0x45, 0x01 | 0x02, 0);
            }
            else
            {
                keybd_event((byte)(16), 0x45, 0x01, 0);
                sh = true;
            }

        }

        public static void ch_lang()
        {
            if (sh)
            {
                keybd_event((byte)(18), 0x45, 0x01, 0);
                keybd_event((byte)(18), 0x45, 0x01 | 0x02, 0);


            }
            else
            {
                keybd_event((byte)(16), 0x45, 0x01, 0);
                keybd_event((byte)(18), 0x45, 0x01, 0);
                keybd_event((byte)(18), 0x45, 0x01 | 0x02, 0);
                keybd_event((byte)(16), 0x45, 0x01 | 0x02, 0);
               


            }
        } 
        public void send_command(object obj)
        {
            IntPtr hwnd1 = FindWindow(null, "Новый текстовый документ — Блокнот");
            SetForegroundWindow(hwnd1);

            const uint WM_KEYDOWN = 65;
            const uint WM_SYSCOMMAND = 0x018;
            if (obj.ToString() == "16")
            {
                foreach (var VARIABLE in Eng_Model)
                {
                    VARIABLE.reverce();
                }
                foreach (var VARIABLE in Rus_Model)
                {
                    VARIABLE.reverce();
                }

                Sh();
            }
            else if (obj.ToString() == "-1")
            {
                ch_lang();
            }
            else
                SendKey((Convert.ToInt32(obj.ToString())));
            //IntPtr result3 = SendMessage(hwnd1, WM_KEYDOWN, ((IntPtr)1), (IntPtr)0);
            //IntPtr calculatorHandle = FindWindow("CalcFrame", "Calculator");
            //if (calculatorHandle == IntPtr.Zero)
            //{
            //    MessageBox.Show("Calculator is not running.");
            //    return;
            //}

            //// Make Calculator the foreground application and send it 
            //// a set of calculations.
            //SetForegroundWindow(calculatorHandle);
            //SendKeys.SendWait("111");
            //SendKeys.SendWait("*");
            //SendKeys.SendWait("11");
            //SendKeys.SendWait("=");
            //OnPropertyChanged();
           // SendKeys.Send(obj.ToString());
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
