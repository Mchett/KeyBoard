using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BMKeyBoard.Annotations;

namespace BMKeyBoard.Model
{
    class OneStr:INotifyPropertyChanged
    {


        public void reverce()
        {
            foreach (var VARIABLE in Str)
            {
                VARIABLE.reverce();
            }
        }

 

        private ObservableCollection<My_Keys> _Str = new ObservableCollection<My_Keys>();
        public ObservableCollection<My_Keys> Str
        {
            get => _Str;
            set
            {
                _Str = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class Alphabet:INotifyPropertyChanged
    {
        public void reverce()
        {
            foreach (var VARIABLE in StrList)
            {
                VARIABLE.reverce();
            }
        }

        private ObservableCollection<OneStr> _Str = new ObservableCollection<OneStr>();
        public ObservableCollection<OneStr> StrList
        {
            get => _Str;
            set
            {
                _Str = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    class Pr
    {
        public string name { get; set; }

        public Pr(string a)
        {
            name = a;
        }
    }

    class My_Keys:INotifyPropertyChanged
    {
        private char _ContentN;  
        public char ContentN
        {
            get => _ContentN;
            set
            {
                _ContentN = value;
                OnPropertyChanged();
            }
        }

        private char _ContentSh;
        public char ContentSh
        {
            get => _ContentSh;
            set
            {
                _ContentSh = value;
                OnPropertyChanged();
            }
        }
        private string _IconN;
        public string IconN
        {
            get => _IconN;
            set
            {
                _IconN = value;
                OnPropertyChanged();
            }
        }
        private string _IconSh;
        public string IconSh
        {
            get => _IconSh;
            set
            {
                _IconSh = value;
                OnPropertyChanged();
            }
        }

        public Double H { get; set; }
        public Double W { get; set; }
        private int _SendInfoN;
        public int SendInfoN
        {
            get => _SendInfoN;
            set
            {
                _SendInfoN = value;
                OnPropertyChanged();
            }
        }
        private int _SendInfoSh;
        public int SendInfoSh
        {
            get => _SendInfoSh;
            set
            {
                _SendInfoSh = value;
                OnPropertyChanged();
            }
        }

        public My_Keys(char contentN, char contentSh, string iconn, string iconsh, Double h, Double w,
            int sendInfoN, int sendInfoSh)
        {
            ContentN = contentN;
            ContentSh = contentSh;
            IconN = iconn;
            IconSh = iconsh;
            H = h * 50;
            W = w * 50;
            SendInfoN = sendInfoN;
            SendInfoSh = sendInfoSh;
        }

        public void reverce()
        {
            char c;
            c = ContentN;
            ContentN = ContentSh;
            ContentSh = c;
            string i;
            i = IconSh;
            IconSh = IconN;
            IconN = i;
            int h;
            h = SendInfoN;
            SendInfoN = SendInfoSh;
            SendInfoSh = h;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
