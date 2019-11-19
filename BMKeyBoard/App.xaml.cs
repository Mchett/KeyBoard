using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BMKeyBoard
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static System.Windows.Navigation.NavigationService MainNavigationService =>
            (App.Current.MainWindow as MainWindow).Frame.NavigationService;
    }
}
