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
                if (Discipline == null) return $"{' ',21}{Mark}";
                else
                {
                    int length = 20 - (Discipline.Length);
                    return $"{Discipline}:{new string(' ', length)}{Mark}";
                }
            }
        }

        private void btn_Change_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_Output.SelectedItem != null)
            {
                if (!string.IsNullOrEmpty(tb_Discipline.Text) && !string.IsNullOrEmpty(tb_Mark.Text))
                {
                    int mark = Convert.ToInt32(tb_Mark.Text);
                    if (mark >= 2 && mark <= 5)
                    {
                        string discipline = tb_Discipline.Text;
                        int index = lbox_Output.SelectedIndex;

                        performance[index].Discipline = discipline;
                        performance[index].Mark = mark;

                        Lbox_Update();
                    }
                    else MessageBox.Show("Оценка можеть быть только от 2 до 5", "Внимание");
                }
                else MessageBox.Show("Заполните все поля", "Ошибка");
            }
            else MessageBox.Show("Выберите изменяемую строку", "Ошибка");
        }

        private void btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_Output.SelectedItem != null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int index = lbox_Output.SelectedIndex;

                    performance[index].Discipline = null;
                    performance[index].Mark = 0;

                    Lbox_Update();
                }
            }
            else MessageBox.Show("Выберите удаляемую строку", "Ошибка");
        }

        private void btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double sum = 0;
            double count = 0;
            foreach (var item in performance)
            {
                if (item.Mark != 0)
                {
                    sum += item.Mark;
                    count++;
                }
            }
            if (count != 0)
            {
                double rezult = sum / count;
                tb_rezult.Text = $"{rezult:F2}";
            }
            else MessageBox.Show("Заполните хотя бы одну запись", "Предупреждение");
        }

        private void NumberOnlyTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key == Key.Back || e.Key == Key.OemMinus)
            {
                return;
            }
            e.Handled = true;
        }

        private void Lbox_Update()
        {
            lbox_Output.ItemsSource = null;
            lbox_Output.ItemsSource = performance;
        }

        private void btn_Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Заполнить таблицу успеваемости студента по 5 дисциплинам с полями: дисциплина, успеваемость за месяц. \nВывести результат на экран. \nВывести среднюю успеваемость по всем дисциплинам.");
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }   
}