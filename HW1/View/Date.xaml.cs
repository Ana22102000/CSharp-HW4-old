using CSharpHomework.ViewModel;

using System.Windows.Controls;


namespace CSharpHomework.View
{
    /// <summary>
    /// Логика взаимодействия для Data.xaml
    /// </summary>
    public partial class Date : UserControl
    {
        internal Date()
        {
            InitializeComponent();
            DataContext = new DateViewModel();

        }

    }
}
