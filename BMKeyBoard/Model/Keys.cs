using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BMKeyBoard.Annotations;

namespace BMKeyBoard.Model
{
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
        private string _SendInfoN;
        public string SendInfoN
        {
            get => _SendInfoN;
            set
            {
                _SendInfoN = value;
                OnPropertyChanged();
            }
        }
        private string _SendInfoSh;
        public string SendInfoSh
        {
            get => _SendInfoSh;
            set
            {
                _SendInfoSh = value;
                OnPropertyChanged();
            }
        }

        public My_Keys(char contentN, char contentSh, string iconn, string iconsh, Double h, Double w,
            string sendInfoN, string sendInfoSh)
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
            i = SendInfoN;
            SendInfoN = SendInfoSh;
            SendInfoSh = i;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
