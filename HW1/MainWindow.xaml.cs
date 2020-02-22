//using HW1.ViewModel;

//using System.Windows;


//namespace HW1
//{
//    /// <summary>
//    /// Логика взаимодействия для MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//            InitializeComponent();

//            DataContext = new MainWindowViewModel();

//        }
//    }
//}



using System.Windows;
using HW1.ViewModel;

namespace HW1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }


    }
}

