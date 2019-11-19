using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using BMKeyBoard.Model;
using System.Runtime.InteropServices;

using BMKeyBoard.Annotations;
using BMKeyBoard.Utilities;
using BMKeyBoard.View.Pages;

namespace BMKeyBoard.ViewModel
{
    class PageVM:INotifyPropertyChanged
    {
        private ObservableCollection<My_Keys> _model_Eng = new ObservableCollection<My_Keys>();
        public ObservableCollection<My_Keys> Eng_Model
        {
            get => _model_Eng;
            set
            {
                _model_Eng = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<My_Keys> _model_Rus = new ObservableCollection<My_Keys>();
        public ObservableCollection<My_Keys> Rus_Model
        {
            get => _model_Rus;
            set
            {
                _model_Rus = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<My_Keys> _model_Key1 = new ObservableCollection<My_Keys>();
        public ObservableCollection<My_Keys> Key1_Model
        {
            get => _model_Key1;
            set
            {
                _model_Key1 = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<My_Keys> _model_Key2 = new ObservableCollection<My_Keys>();
        public ObservableCollection<My_Keys> Key2_Model
        {
            get => _model_Key2;
            set
            {
                _model_Key2 = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<My_Keys> _model_Key3 = new ObservableCollection<My_Keys>();
        public ObservableCollection<My_Keys> Key3_Model
        {
            get => _model_Key3;
            set
            {
                _model_Key3 = value;
                OnPropertyChanged();
            }
        }

        public PageVM()
        {
            ISendCommand =new RelayCommand(send_command);
            EngAlph();
            RusAlph();
            NumKeys();
        }

        private void EngAlph()
        {
            Eng_Model.Add(new My_Keys('q','Q', "../../Resource/q1.png", "../../Resource/Q.png", 1,1,"q","Q"));
            Eng_Model.Add(new My_Keys('w', 'W', "../../Resource/w1.png", "../../Resource/W.png", 1, 1, "w", "W"));
            Eng_Model.Add(new My_Keys('e', 'E', "../../Resource/e1.png", "../../Resource/E.png", 1, 1, "e", "E"));
            Eng_Model.Add(new My_Keys('r', 'R', "../../Resource/r1.png", "../../Resource/R.png", 1, 1, "r", "R"));
            Eng_Model.Add(new My_Keys('t', 'T', "../../Resource/t1.png", "../../Resource/T.png", 1, 1, "t", "T"));
            Eng_Model.Add(new My_Keys('y', 'Y', "../../Resource/y1.png", "../../Resource/Y.png", 1, 1, "y", "Y"));
            Eng_Model.Add(new My_Keys('u', 'U', "../../Resource/u1.png", "../../Resource/U.png", 1, 1, "u", "U"));
            Eng_Model.Add(new My_Keys('i', 'I', "../../Resource/i1.png", "../../Resource/I.png", 1, 1, "i", "I"));
            Eng_Model.Add(new My_Keys('o', 'O', "../../Resource/o1.png", "../../Resource/O.png", 1, 1, "o", "O"));
            Eng_Model.Add(new My_Keys('p', 'P', "../../Resource/p1.png", "../../Resource/P.png", 1, 1, "p", "P"));
            Eng_Model.Add(new My_Keys('!', '?', "../../Resource/!.png", "../../Resource/!!.png", 1, 1, "!", "?"));
            Eng_Model.Add(new My_Keys(' ', ' ', "../../Resource/del.png", "../../Resource/del.png", 1, 2.5, "DEL", "DEL"));
            Eng_Model.Add(new My_Keys('a', 'A', "../../Resource/a1.png", "../../Resource/A.png", 1, 1, "a", "A"));
            Eng_Model.Add(new My_Keys('s', 'S', "../../Resource/s1.png", "../../Resource/S.png", 1, 1, "s", "S"));
            Eng_Model.Add(new My_Keys('d', 'D', "../../Resource/d1.png", "../../Resource/D.png", 1, 1, "d", "D"));
            Eng_Model.Add(new My_Keys('f', 'F', "../../Resource/f1.png", "../../Resource/F.png", 1, 1, "f", "F"));
            Eng_Model.Add(new My_Keys('g', 'G', "../../Resource/g1.png", "../../Resource/G.png", 1, 1, "g", "G"));
            Eng_Model.Add(new My_Keys('h', 'H', "../../Resource/h1.png", "../../Resource/H.png", 1, 1, "h", "H"));
            Eng_Model.Add(new My_Keys('j', 'J', "../../Resource/j1.png", "../../Resource/J.png", 1, 1, "j", "J"));
            Eng_Model.Add(new My_Keys('k', 'K', "../../Resource/k1.png", "../../Resource/K.png", 1, 1, "k", "K"));
            Eng_Model.Add(new My_Keys('l', 'L', "../../Resource/l1.png", "../../Resource/L.png", 1, 1, "l", "L"));
            Eng_Model.Add(new My_Keys('*', '*', "../../Resource/!!!.png", "../../Resource/!!!.png", 1, 1, "*", "*"));
            Eng_Model.Add(new My_Keys(' ', ' ', "../../Resource/enter.png", "../../Resource/enter.png", 1, 2.5, "{ENTER}", "{ENTER}"));
            Eng_Model.Add(new My_Keys(' ', ' ', "../../Resource/shift.png", "../../Resource/shift.png", 1, 1, "SHIFT", "SHIFT"));
            Eng_Model.Add(new My_Keys('z', 'Z', "../../Resource/z1.jpg", "../../Resource/Z.png", 1, 1, "z", "Z"));
            Eng_Model.Add(new My_Keys('x', 'X', "../../Resource/x1.png", "../../Resource/X.png", 1, 1, "x", "X"));
            Eng_Model.Add(new My_Keys('c', 'C', "../../Resource/c1.png", "../../Resource/C.png", 1, 1, "c", "C"));
            Eng_Model.Add(new My_Keys('v', 'V', "../../Resource/v1.png", "../../Resource/V.png", 1, 1, "v", "V"));
            Eng_Model.Add(new My_Keys('b', 'B', "../../Resource/b1.png", "../../Resource/B.png", 1, 1, "b", "B"));
            Eng_Model.Add(new My_Keys('n', 'N', "../../Resource/n1.png", "../../Resource/N.png", 1, 1, "n", "N"));
            Eng_Model.Add(new My_Keys('m', 'M', "../../Resource/m1.png", "../../Resource/M.png", 1, 1, "m", "M"));
            Eng_Model.Add(new My_Keys(',', ',', "../../Resource/comma.png", "../../Resource/comma.png", 1, 1, ",", ","));
            Eng_Model.Add(new My_Keys('.', '.', "../../Resource/dot.png", "../../Resource/dot.png", 1, 1, ".", "."));
            Eng_Model.Add(new My_Keys(' ', ' ', "../../Resource/shift.png", "../../Resource/shift.png", 1, 1, "SHIFT", "SHIFT"));
            Eng_Model.Add(new My_Keys(' ', ' ', "../../Resource/num.png", "../../Resource/num.png", 1, 1, "NUM", "NUM"));
            Eng_Model.Add(new My_Keys(' ', ' ', "", "", 1, 6, "SPACE", "SPACE"));
            Eng_Model.Add(new My_Keys(' ', ' ', "../../Resource/eng.png", "../../Resource/eng.png", 1, 1, "ENG", "ENG"));
            //Eng_Model.Add(new My_Keys('', '', "../../Resource/1.png", "../../Resource/.png", 1, 1, "", ""));
        }

        private void RusAlph()
        {
        }

        private void NumKeys()
        {
        }

        public ICommand ISendCommand { get; private set; }
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public void send_command(object obj)
        {
            
            if (obj.ToString()== "SHIFT")
                foreach (var VARIABLE in Eng_Model)
                {
                    VARIABLE.reverce();
                }
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
            SendKeys.Send(obj.ToString());
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
