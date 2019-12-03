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
using System.Windows.Markup;
using System.Windows.Data;
using System.Globalization;

namespace BMKeyBoard.ViewModel
{
    public  class YourConverter : IMultiValueConverter
    {

   
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
                return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    class PageVM:INotifyPropertyChanged
    {
        public static YourConverter YC = new YourConverter();
        private static IntPtr hwnd1;
        private static IntPtr hwnd2;
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
        private ObservableCollection<Alphabet> _model_curLang = new ObservableCollection<Alphabet>();
        public ObservableCollection<Alphabet> CurLang_Model
        {
            get => _model_curLang;
            set
            {
                _model_curLang = value;
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

        private static Thread MyT = null;
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
        public static string Lang { get; set; }

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
            Lang = "eng";
            CurLang_Model = Eng_Model;
            hwnd1 = FindWindow(null, "Новый текстовый документ.txt – Блокнот");
            if (MyT == null)
            {
                MyT = new Thread(currForeg);
                MyT.Start();
            }
        }

        public void currForeg()
        {
            
            IntPtr hwnd3 = (IntPtr) 0;
            hwnd3 = GetForegroundWindow();
            //Process[] ProcessesList = Process.GetProcesses();

            //foreach (var m in ProcessesList)
            //{

            //    if (m.MainWindowTitle == "Keyboard")
            //    {
            //        hwnd3 = m.Handle;
            //    }
            //}

            while (true)
            {
                hwnd2 = GetForegroundWindow();
                if (hwnd2 != hwnd1 && hwnd2 != hwnd3)
                    hwnd1 = hwnd2;
               

                Thread.Sleep(300);
            }
        }

        private void EngAlph() 
        {
            Eng_Model.Add(new Alphabet());
            Eng_Model[0].StrList.Add(new OneStr());
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('q', 'Q', "../../Resource/black/eng/small/q.png", "../../Resource/black/eng/caps/Q.png", 1, 1, 81, 81));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('w', 'W', "../../Resource/black/eng/small/w.png", "../../Resource/black/eng/caps/W.png", 1, 1, 87, 87));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('e', 'E', "../../Resource/black/eng/small/e.png", "../../Resource/black/eng/caps/E.png", 1, 1, 69, 69));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('r', 'R', "../../Resource/black/eng/small/r.png", "../../Resource/black/eng/caps/R.png", 1, 1, 82, 82));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('t', 'T', "../../Resource/black/eng/small/t.png", "../../Resource/black/eng/caps/T.png", 1, 1, 84, 84));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('y', 'Y', "../../Resource/black/eng/small/y.png", "../../Resource/black/eng/caps/Y.png", 1, 1, 89, 89));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('u', 'U', "../../Resource/black/eng/small/u.png", "../../Resource/black/eng/caps/U.png", 1, 1, 85, 85));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('i', 'I', "../../Resource/black/eng/small/i.png", "../../Resource/black/eng/caps/I.png", 1, 1, 73, 73));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('o', 'O', "../../Resource/black/eng/small/o.png", "../../Resource/black/eng/caps/O.png", 1, 1, 79, 79));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('p', 'P', "../../Resource/black/eng/small/p.png", "../../Resource/black/eng/caps/P.png", 1, 1, 80, 80));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys('!', '?', "../../Resource/black/symb/!.png", "../../Resource/black/symb/в.png", 1, 1, 49, 191));
            Eng_Model[0].StrList[0].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/del.png", "../../Resource/black/symb/del.png", 1, 2, 8, 8));
            Eng_Model[0].StrList.Add(new OneStr());
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('a', 'A', "../../Resource/black/eng/small/a.png", "../../Resource/black/eng/caps/A.png", 1, 1, 65, 65));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('d', 'D', "../../Resource/black/eng/small/d.png", "../../Resource/black/eng/caps/D.png", 1, 1, 68, 68));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('s', 'S', "../../Resource/black/eng/small/s.png", "../../Resource/black/eng/caps/S.png", 1, 1, 83, 83));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('f', 'F', "../../Resource/black/eng/small/f.png", "../../Resource/black/eng/caps/F.png", 1, 1, 70, 70));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('g', 'G', "../../Resource/black/eng/small/g.png", "../../Resource/black/eng/caps/G.png", 1, 1, 71, 71));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('h', 'H', "../../Resource/black/eng/small/h.png", "../../Resource/black/eng/caps/H.png", 1, 1, 72, 72));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('j', 'J', "../../Resource/black/eng/small/j.png", "../../Resource/black/eng/caps/J.png", 1, 1, 74, 74));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('k', 'K', "../../Resource/black/eng/small/k.png", "../../Resource/black/eng/caps/K.png", 1, 1, 75, 75));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('l', 'L', "../../Resource/black/eng/small/l.png", "../../Resource/black/eng/caps/L.png", 1, 1, 76, 76));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys('*', '*', "../../Resource/black/symb/з.png", "../../Resource/black/symb/з.png", 1, 1, 56, 56));
            Eng_Model[0].StrList[1].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/enter.png", "../../Resource/black/symb/enter.png", 1, 2, 13, 13));
            Eng_Model[0].StrList.Add(new OneStr());
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('z', 'Z', "../../Resource/black/eng/small/z.png", "../../Resource/black/eng/caps/Z.png", 1, 1, 90, 90));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('x', 'X', "../../Resource/black/eng/small/x.png", "../../Resource/black/eng/caps/X.png", 1, 1, 88, 88));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('c', 'C', "../../Resource/black/eng/small/c.png", "../../Resource/black/eng/caps/C.png", 1, 1, 67, 67));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('v', 'V', "../../Resource/black/eng/small/v.png", "../../Resource/black/eng/caps/V.png", 1, 1, 86, 86));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('b', 'B', "../../Resource/black/eng/small/b.png", "../../Resource/black/eng/caps/B.png", 1, 1, 66, 66));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('n', 'N', "../../Resource/black/eng/small/n.png", "../../Resource/black/eng/caps/N.png", 1, 1, 78, 78));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('m', 'M', "../../Resource/black/eng/small/m.png", "../../Resource/black/eng/caps/M.png", 1, 1, 77, 77));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys(',', ',', "../../Resource/black/symb/,.png", "../../Resource/black/symb/,.png", 1, 1, 188, 188));
            Eng_Model[0].StrList[2].Str.Add(new My_Keys('.', '.', "../../Resource/black/symb/т.png", "../../Resource/black/symb/т.png", 1, 1, 190, 190));
            Eng_Model[0].StrList.Add(new OneStr());
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/shift.png", "../../Resource/black/symb/shift.png", 1, 1, 16, 16));
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/nums.png", "../../Resource/black/symb/nums.png", 1, 1, -2, -2));
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "", "", 1, 6, 32, 32));
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/lang.png", "../../Resource/black/symb/lang.png", 1, 1, -1, -1));
            Eng_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/shift.png", "../../Resource/black/symb/shift.png", 1, 1, 16, 16));
        }

        private void RusAlph()
        {

            Rus_Model.Add(new Alphabet());
            Rus_Model[0].StrList.Add(new OneStr());
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('й', 'Й', "../../Resource/black/rus/small/й.png", "../../Resource/black/rus/caps/Й.png", 1, 1, 81, 81));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('ц', 'Ц', "../../Resource/black/rus/small/ц.png", "../../Resource/black/rus/caps/Ц.png", 1, 1, 87, 87));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('у', 'У', "../../Resource/black/rus/small/у.png", "../../Resource/black/rus/caps/У.png", 1, 1, 69, 69));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('к', 'К', "../../Resource/black/rus/small/к.png", "../../Resource/black/rus/caps/К.png", 1, 1, 82, 82));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('е', 'Е', "../../Resource/black/rus/small/е.png", "../../Resource/black/rus/caps/Е.png", 1, 1, 84, 84));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('н', 'Н', "../../Resource/black/rus/small/н.png", "../../Resource/black/rus/caps/Н.png", 1, 1, 89, 89));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('г', 'Г', "../../Resource/black/rus/small/г.png", "../../Resource/black/rus/caps/Г.png", 1, 1, 85, 85));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('ш', 'Ш', "../../Resource/black/rus/small/ш.png", "../../Resource/black/rus/caps/Ш.png", 1, 1, 73, 73));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('щ', 'Щ', "../../Resource/black/rus/small/щ.png", "../../Resource/black/rus/caps/Щ.png", 1, 1, 79, 79));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('з', 'З', "../../Resource/black/rus/small/з.png", "../../Resource/black/rus/caps/З.png", 1, 1, 80, 80));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('х', 'Х', "../../Resource/black/rus/small/х.png", "../../Resource/black/rus/caps/Х.png", 1, 1, 219, 219));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys('ъ', 'Ъ', "../../Resource/black/rus/small/ъ.png", "../../Resource/black/rus/caps/Ъ.png", 1, 1, 221, 221));
            Rus_Model[0].StrList[0].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/del.png", "../../Resource/black/symb/del.png", 1, 2, 8, 8));

            Rus_Model[0].StrList.Add(new OneStr());
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('ф', 'Ф', "../../Resource/black/rus/small/ф.png", "../../Resource/black/rus/caps/Ф.png", 1, 1, 65, 65));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('ы', 'Ы', "../../Resource/black/rus/small/ы.png", "../../Resource/black/rus/caps/Ы.png", 1, 1, 68, 68));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('в', 'В', "../../Resource/black/rus/small/в.png", "../../Resource/black/rus/caps/В.png", 1, 1, 83, 83));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('а', 'А', "../../Resource/black/rus/small/а.png", "../../Resource/black/rus/caps/А.png", 1, 1, 70, 70));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('п', 'П', "../../Resource/black/rus/small/п.png", "../../Resource/black/rus/caps/П.png", 1, 1, 71, 71));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('р', 'Р', "../../Resource/black/rus/small/р.png", "../../Resource/black/rus/caps/Р.png", 1, 1, 72, 72));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('о', 'О', "../../Resource/black/rus/small/о.png", "../../Resource/black/rus/caps/О.png", 1, 1, 74, 74));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('л', 'Л', "../../Resource/black/rus/small/л.png", "../../Resource/black/rus/caps/Л.png", 1, 1, 75, 75));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('д', 'Д', "../../Resource/black/rus/small/д.png", "../../Resource/black/rus/caps/Д.png", 1, 1, 76, 76));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('ж', 'Ж', "../../Resource/black/rus/small/ж.png", "../../Resource/black/rus/caps/Ж.png", 1, 1, 186, 186));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys('э', 'Э', "../../Resource/black/rus/small/э.png", "../../Resource/black/rus/caps/Э.png", 1, 1, 222, 222));
            Rus_Model[0].StrList[1].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/enter.png", "../../Resource/black/symb/enter.png", 1, 2, 13, 13));

            Rus_Model[0].StrList.Add(new OneStr());
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('я', 'Я', "../../Resource/black/rus/small/я.png", "../../Resource/black/rus/caps/Я.png", 1, 1, 90, 90));
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('ч', 'Ч', "../../Resource/black/rus/small/ч.png", "../../Resource/black/rus/caps/Ч.png", 1, 1, 88, 88));
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('с', 'С', "../../Resource/black/rus/small/с.png", "../../Resource/black/rus/caps/С.png", 1, 1, 67, 67));
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('м', 'М', "../../Resource/black/rus/small/м.png", "../../Resource/black/rus/caps/М.png", 1, 1, 86, 86));
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('и', 'И', "../../Resource/black/rus/small/и.png", "../../Resource/black/rus/caps/И.png", 1, 1, 66, 66));
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('т', 'Т', "../../Resource/black/rus/small/т.png", "../../Resource/black/rus/caps/Т.png", 1, 1, 78, 78));
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('ь', 'Ь', "../../Resource/black/rus/small/ь.png", "../../Resource/black/rus/caps/Ь.png", 1, 1, 77, 77));
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('б', 'Б', "../../Resource/black/rus/small/б.png", "../../Resource/black/rus/caps/Б.png", 1, 1, 188, 188));
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('ю', 'Ю', "../../Resource/black/rus/small/ю.png", "../../Resource/black/rus/caps/Ю.png", 1, 1, 190, 190));
            Rus_Model[0].StrList[2].Str.Add(new My_Keys('.', ',', "../../Resource/black/symb/т.png", "../../Resource/black/symb/,.png", 1, 1, 191, 191));

            Rus_Model[0].StrList.Add(new OneStr());
            Rus_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/shift.png", "../../Resource/black/symb/shift.png", 1, 1, 16, 16));
            Rus_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/nums.png", "../../Resource/black/symb/nums.png", 1, 1, -2, -2));
            Rus_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "", "", 1, 6, 32, 32));
            Rus_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/lang.png", "../../Resource/black/symb/lang.png", 1, 1, -1, -1));
            Rus_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/shift.png", "../../Resource/black/symb/shift.png", 1, 1, 16, 16));


        }

        private void NumKeys()
        {
            Key_Model.Add(new Alphabet());
            Key_Model[0].StrList.Add(new OneStr());
            Key_Model[0].StrList[0].Str.Add(new My_Keys('%', '%', "../../Resource/black/symb/п.png", "../../Resource/black/symb/п.png", 1, 1, 53, 53));
            Key_Model[0].StrList[0].Str.Add(new My_Keys(':', ':', "../../Resource/black/symb/ж.png", "../../Resource/black/symb/ж.png", 1, 1, 186, 186));
            Key_Model[0].StrList[0].Str.Add(new My_Keys('<', '<', "../../Resource/black/symb/б.png", "../../Resource/black/symb/б.png", 1, 1, 188, 188));
            Key_Model[0].StrList[0].Str.Add(new My_Keys('>', '>', "../../Resource/black/symb/ю.png", "../../Resource/black/symb/ю.png", 1, 1, 190, 190));
            Key_Model[0].StrList[0].Str.Add(new My_Keys('\"', '\"', "../../Resource/black/symb/2.png", "../../Resource/black/rus/caps/2.png", 1, 1, 222, 222));
            Key_Model[0].StrList[0].Str.Add(new My_Keys('&', '&', "../../Resource/black/symb/а.png", "../../Resource/black/rus/caps/а.png", 1, 1, 55, 55));
            Key_Model[0].StrList[0].Str.Add(new My_Keys('*', '*', "../../Resource/black/symb/з.png", "../../Resource/black/rus/caps/з.png", 1, 1, 56, 56));
            Key_Model[0].StrList[0].Str.Add(new My_Keys('=', '=', "../../Resource/black/symb/=.png", "../../Resource/black/rus/caps/=.png", 1, 1, 187, 187));
           
            Key_Model[0].StrList.Add(new OneStr());
            Key_Model[0].StrList[1].Str.Add(new My_Keys('~', '~', "../../Resource/black/symb/~.png", "../../Resource/black/symb/~.png", 1, 1, 192, 192));
            Key_Model[0].StrList[1].Str.Add(new My_Keys(';', ';', "../../Resource/black/symb/;.png", "../../Resource/black/symb/;.png", 1, 1, 186, 186));
            Key_Model[0].StrList[1].Str.Add(new My_Keys('{', '{', "../../Resource/black/symb/{.png", "../../Resource/black/symb/{.png", 1, 1, 219, 219));
            Key_Model[0].StrList[1].Str.Add(new My_Keys('}', '}', "../../Resource/black/symb/}.png", "../../Resource/black/symb/}.png", 1, 1, 221, 221));
            Key_Model[0].StrList[1].Str.Add(new My_Keys('(', '(', "../../Resource/black/symb/(.png", "../../Resource/black/symb/(.png", 1, 1, 57, 57));
            Key_Model[0].StrList[1].Str.Add(new My_Keys(')', ')', "../../Resource/black/symb/).png", "../../Resource/black/symb/).png", 1, 1, 48, 48));
            Key_Model[0].StrList[1].Str.Add(new My_Keys('_', '_', "../../Resource/black/symb/_.png", "../../Resource/black/symb/_.png", 1, 1, 189, 189));
            Key_Model[0].StrList[1].Str.Add(new My_Keys('-', '-', "../../Resource/black/symb/-.png", "../../Resource/black/symb/-.png", 1, 1, 189, 189));

            Key_Model[0].StrList.Add(new OneStr());
            Key_Model[0].StrList[2].Str.Add(new My_Keys('@', '@', "../../Resource/black/symb/@.png", "../../Resource/black/symb/@.png", 1, 1, 50, 50));
            Key_Model[0].StrList[2].Str.Add(new My_Keys('\\', '\\', "../../Resource/black/symb/й.png", "../../Resource/black/symb/й.png", 1, 1, 220, 220));
            Key_Model[0].StrList[2].Str.Add(new My_Keys('[', '[', "../../Resource/black/symb/х.png", "../../Resource/black/symb/х.png", 1, 1, 219, 219));
            Key_Model[0].StrList[2].Str.Add(new My_Keys(']', ']', "../../Resource/black/symb/ъ.png", "../../Resource/black/symb/ъ.png", 1, 1, 221, 221));
            Key_Model[0].StrList[2].Str.Add(new My_Keys('?', '?', "../../Resource/black/symb/в.png", "../../Resource/black/symb/в.png", 1, 1, 191, 191));
            Key_Model[0].StrList[2].Str.Add(new My_Keys('!', '!', "../../Resource/black/symb/!.png", "../../Resource/black/symb/!.png", 1, 1, 49, 49));
            Key_Model[0].StrList[2].Str.Add(new My_Keys('+', '+', "../../Resource/black/symb/+.png", "../../Resource/black/symb/+.png", 1, 1, 187, 187));
            Key_Model[0].StrList[2].Str.Add(new My_Keys('/', '/', "../../Resource/black/symb/с.png", "../../Resource/black/symb/с.png", 1, 1, 191, 191));
            
            Key_Model[0].StrList.Add(new OneStr());
            Key_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/lang.png", "../../Resource/black/symb/lang.png", 1, 1, -1, -1));
            Key_Model[0].StrList[3].Str.Add(new My_Keys(' ', ' ', "", "", 1, 7, 32, 32));

            Key_Model.Add(new Alphabet());
            Key_Model[1].StrList.Add(new OneStr());
            Key_Model[1].StrList[0].Str.Add(new My_Keys('1', '1', "../../Resource/black/num/1.png", "../../Resource/black/num/1.png", 1, 1, 49, 49));
            Key_Model[1].StrList[0].Str.Add(new My_Keys('2', '2', "../../Resource/black/num/2.png", "../../Resource/black/num/2.png", 1, 1, 50, 50));
            Key_Model[1].StrList[0].Str.Add(new My_Keys('3', '3', "../../Resource/black/num/3.png", "../../Resource/black/num/3.png", 1, 1, 51, 51));

            Key_Model[1].StrList.Add(new OneStr());
            Key_Model[1].StrList[1].Str.Add(new My_Keys('4', '4', "../../Resource/black/num/4.png", "../../Resource/black/num/4.png", 1, 1, 52, 52));
            Key_Model[1].StrList[1].Str.Add(new My_Keys('5', '5', "../../Resource/black/num/5.png", "../../Resource/black/num/5.png", 1, 1, 53, 53));
            Key_Model[1].StrList[1].Str.Add(new My_Keys('6', '6', "../../Resource/black/num/6.png", "../../Resource/black/num/6.png", 1, 1, 54, 54));

            Key_Model[1].StrList.Add(new OneStr());
            Key_Model[1].StrList[2].Str.Add(new My_Keys('7', '7', "../../Resource/black/num/7.png", "../../Resource/black/num/7.png", 1, 1, 55, 55));
            Key_Model[1].StrList[2].Str.Add(new My_Keys('8', '8', "../../Resource/black/num/8.png", "../../Resource/black/num/8.png", 1, 1, 56, 56));
            Key_Model[1].StrList[2].Str.Add(new My_Keys('9', '9', "../../Resource/black/num/9.png", "../../Resource/black/num/9.png", 1, 1, 57, 57));

            Key_Model[1].StrList.Add(new OneStr());
            Key_Model[1].StrList[3].Str.Add(new My_Keys('0', '0', "../../Resource/black/num/0.png", "../../Resource/black/num/0.png", 1, 2.1, 48, 48));
            Key_Model[1].StrList[3].Str.Add(new My_Keys(',', ',', "../../Resource/black/symb/,.png", "../../Resource/black/symb/0.png", 1, 1, 188, 188));

            Key_Model.Add(new Alphabet());
            Key_Model[2].StrList.Add(new OneStr());
            Key_Model[2].StrList[0].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/del2.png", "../../Resource/black/symb/del.png", 1, 1, 8, 8));

            Key_Model[2].StrList.Add(new OneStr());
            Key_Model[2].StrList[1].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/enter2.png", "../../Resource/black/symb/enter2.png", 2.1, 1, 13, 13));

            Key_Model[2].StrList.Add(new OneStr());
            Key_Model[2].StrList[2].Str.Add(new My_Keys(' ', ' ', "../../Resource/black/symb/lang.png", "../../Resource/black/symb/lang.png", 1, 1, -1, -1));

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

        public static int SendKey(int key, bool whith_sh)
        {
            if(whith_sh)
                keybd_event((byte)(16), 0x45, 0x01, 0);

            keybd_event((byte)(key), 0x45, 0x01, 0);
            keybd_event((byte)(key), 0x45, 0x01 | 0x02, 0);
            if (whith_sh)
                keybd_event((byte)(16), 0x45, 0x01 | 0x02, 0);

            return 0;
        }

        public static void Sh()
        {
            if (sh)
                sh = false;
            else
                sh = true;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern int LoadKeyboardLayout(string pwszKLID, uint Flags);
        public  void ch_lang()
        {



            //И сами языки 
            //"00000407" Немецкий(стандартный) 
            //"00000409" Английский(США) 
            //"0000040C" Французский(стандартный) 
            //"0000040D" Финский 
            //"00000410" Итальянский 
            //"00000415" Польский 
            //"00000419" Русский 
            //"00000422" Украинский 
            //"00000423" Белорусский 
            //"00000425" Эстонский 
            //"00000426" Латвийский 
            //"00000427" Литовский 
            string lang = "00000419";
            int ret;


            if (Lang == "eng")
            {
                lang = "00000419";
                ret = LoadKeyboardLayout(lang, 1);
                PostMessage(hwnd1, 0x50, 1, ret);
                //keybd_event((byte)(16), 0x45, 0x01, 0);
                //keybd_event((byte)(18), 0x45, 0x01, 0);
                //keybd_event((byte)(18), 0x45, 0x01 | 0x02, 0);
                //keybd_event((byte)(16), 0x45, 0x01 | 0x02, 0);
                Lang = "rus";
                CurLang_Model = Rus_Model;
            }
            else
            {
                lang = "00000409";
                ret = LoadKeyboardLayout(lang, 1);
                PostMessage(hwnd1, 0x50, 1, ret);
                Lang = "eng";
                CurLang_Model = Eng_Model;
            }
        } 
        public void send_command(object objs)
        {
            object[] obj = objs as object[];
                SetForegroundWindow(hwnd1);
            string code = obj[0].ToString();
            string symb = obj[1].ToString();


            if (code == "16")
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
            else if (code == "-1")
            {
                ch_lang();
            }
            else if (code == "-2")
            {
                Lang = "rus";
                ch_lang();
                CurLang_Model = Key_Model;
                Lang = "nums";
            }

            else if (Lang == "nums")
            {
                if("%:<>\"&*~{}()_@?!+".Contains(symb))
                    SendKey((Convert.ToInt32(code)), true);
                else
                    SendKey((Convert.ToInt32(code)), false);
            }
            else if (Lang == "eng")
            {
                if ("*&!?".Contains(symb))
                    SendKey((Convert.ToInt32(code)), true);
                else if (".,".Contains(symb))
                    SendKey((Convert.ToInt32(code)), false);
                else
                    SendKey((Convert.ToInt32(code)), sh);
            }
            else
                SendKey((Convert.ToInt32(code)), sh);

        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
