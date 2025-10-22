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
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RPM_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Performance[] performance;
        public MainWindow()
        {
            InitializeComponent();
            performance = new Performance[5];
            lbox_Output.ItemsSource = performance;
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
                return $"{Discipline,-20}{Mark}";
            }
        }

        private void btn_Change_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_Output.SelectedItem != null )
            {
                if (!string.IsNullOrEmpty(tb_Discipline.Text) && !string.IsNullOrEmpty(tb_Mark.Text))
                {
                    string discipline = tb_Discipline.Text;
                    int mark = Convert.ToInt32(tb_Mark.Text);
                    int index = lbox_Output.SelectedIndex;

                    performance[index].Discipline = discipline;
                    performance[index].Mark = mark;

                    lbox_Output.ItemsSource = null;
                    lbox_Output.ItemsSource = performance;
                }
            }
        }
    }   
}