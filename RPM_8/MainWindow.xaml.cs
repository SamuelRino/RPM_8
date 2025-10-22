using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPM_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public struct Performance
        {
            public string Discipline;
            public int Mark;

            public Performance(string discipline, int mark)
            {
                Discipline = discipline;
                Mark = mark;
            }

            public override string ToString()
            {
                return $"{Discipline,20}: {Mark}";
            }
        }
    }   
}