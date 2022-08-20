using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using System.IO;

namespace Generator_Testov_for_Brazzers
{
    
    public partial class MainWindow : Window
    {
        private static String Path = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Balance.xdav";
        private StreamWriter write_stream;
        private StreamReader read_stream;

        private int Mode = 0;
        /*
            Mode
            1 - Сложение 
            2 - Вычитание
            3 - Умножение 
            4 - Деление
        */
        private int Dif = 0;
        /*
            Dif
            1 - Первый уровень сложности 
            2 - Второй уровень сложности
            . . .
            8 - Восьмой уровень сложности
        */
        public MainWindow()
        {
            InitializeComponent();
            FileStream fstream = new FileStream(Path, FileMode.OpenOrCreate);
            fstream.Close();
            //                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                (new StreamReader(Path).ReadLine() == "") new StreamWriter(Path).Write("0");
            MainMenu.Visibility = Visibility.Visible;
            DifficultMenu.Visibility = Visibility.Hidden;
            ExampleMenu.Visibility = Visibility.Hidden;
            ErrorMenu.Visibility = Visibility.Hidden;
            SucssesMenu.Visibility = Visibility.Hidden;
            BalanceMenu.Visibility = Visibility.Visible;
            Read_File();
        }

        /////////////    Чтение и запись баланса    //////////////
        private void Read_File()
        {
            read_stream = new StreamReader(Path);
            Balance.Content = "Баланс: " + read_stream.ReadLine();
            read_stream.Close();
        }

        private void Write_File(double pay)
        {
            write_stream = new StreamWriter(Path);
            String temp = Balance.Content.ToString();
            temp = temp.Remove(0, 8);
            if (temp == "") temp = "0";
            double balance = double.Parse(temp) + pay;
            write_stream.WriteLine(balance);
            write_stream.Close();
        }

        /////////////    Задаёт пример для решения    //////////////
        private void Get_Random_Exaple()
        {
            String first = "";
            String second = "";
            Random rnd = new Random();
            for (int i = 0; i < Dif; i++)
            {
                if(i == 0 || i == 7)
                {
                    first += rnd.Next(1, 10).ToString();
                    second += rnd.Next(1, 10).ToString();
                    continue;
                }
                first += rnd.Next(10).ToString();
                second += rnd.Next(10).ToString();
            }
            long first_num = long.Parse(first);
            long second_num = long.Parse(second);
            Second_Number.Content = second_num;
            switch (Mode)
            {
                case 2:
                    {
                        First_Number.Content = first_num + second_num;
                        /*First_Number.Content = "";
                        String temp = (first_num + second_num).ToString();
                        for (int i = 0; i < Dif; i++)
                        {
                            First_Number.Content += temp[i].ToString();
                        }*/
                        break;
                    }
                case 4:
                    {
                        /*First_Number.Content = "";
                        String temp = (first_num * second_num).ToString();
                        for (int i = 0; i < Dif; i++)
                        {
                            First_Number.Content += temp[i].ToString();
                        }*/
                        First_Number.Content = first_num * second_num;
                        break;
                    }
                default:
                    {
                        First_Number.Content = first_num;
                        break;
                    }
            }
        }

        private void Next_Sucsses_Button_Click(object sender, RoutedEventArgs e)
        {
            Get_Random_Exaple();
            ExampleMenu.Visibility = Visibility.Visible;
            SucssesMenu.Visibility = Visibility.Hidden;
            Answer_TextBox.Text = "";
            Answer_TextBox.Focus();
            return;
        }

        private void Next_Error_Button_Click(object sender, RoutedEventArgs e)
        {
            Get_Random_Exaple();
            ExampleMenu.Visibility = Visibility.Visible;
            ErrorMenu.Visibility = Visibility.Hidden;
            Answer_TextBox.Text = "";
            Answer_TextBox.Focus();
            return;
        }

        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Answer_TextBox.Text.ToString() == "") return;
                if (Answer_TextBox.Text.ToString() == "Обнулить" ||
                Answer_TextBox.Text.ToString() == "обнулить" ||
                Answer_TextBox.Text.ToString() == "Обналичить" ||
                Answer_TextBox.Text.ToString() == "обналичить")
            {
                Balance.Content = "Баланс: 0,0";
                Write_File(0);
                Answer_TextBox.Text = "Счёт обнулён";
                return;
            }
            if(!long.TryParse(Answer_TextBox.Text.ToString(), out _))
            {
                MessageBox.Show(
                    "Ответ должен состоять только из цифр",
                    "Ошибка ввода",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            long True_Answear = 0;
            switch (Mode)
            {
                case 1:
                    {
                        True_Answear = long.Parse(First_Number.Content.ToString()) + long.Parse(Second_Number.Content.ToString());
                        break;
                    }
                case 2:
                    {
                        True_Answear = long.Parse(First_Number.Content.ToString()) - long.Parse(Second_Number.Content.ToString());
                        break;
                    }
                case 3:
                    {
                        True_Answear = long.Parse(First_Number.Content.ToString()) * long.Parse(Second_Number.Content.ToString());
                        break;
                    }
                case 4:
                    {
                        if(long.Parse(Second_Number.Content.ToString()) != 0)
                            True_Answear = long.Parse(First_Number.Content.ToString()) / long.Parse(Second_Number.Content.ToString());
                        break;
                    }
            }
            if(True_Answear == long.Parse(Answer_TextBox.Text.ToString()))
            {
                double x = Get_Sum();
                Write_File(x);
                Read_File();
                SucssesMenu.Visibility = Visibility.Visible;
                ExampleMenu.Visibility = Visibility.Hidden;
                Next_Sucsses_Button.Focus();
            }
            else
            {
                Error_Message.Content = "Неправильно\nВаш ответ: " + Answer_TextBox.Text + "\nПравильный ответ: " + True_Answear;
                ErrorMenu.Visibility = Visibility.Visible;
                ExampleMenu.Visibility = Visibility.Hidden;
                Next_Error_Button.Focus();
            }
        }

        private void Clear_ExamMenu()
        {
            DifficultMenu.Visibility = Visibility.Hidden;
            ExampleMenu.Visibility = Visibility.Visible;
            Answer_TextBox.Text = "Введите ответ";
            Get_Random_Exaple();
        }

        private void Dif_1_Button_Click(object sender, RoutedEventArgs e)
        {
            Dif = 1;
            Clear_ExamMenu();
        }

        private void Dif_2_Button_Click(object sender, RoutedEventArgs e)
        {
            Dif = 2;
            Clear_ExamMenu();
        }

        private void Dif_3_Button_Click(object sender, RoutedEventArgs e)
        {
            Dif = 3;
            Clear_ExamMenu();
        }

        private void Dif_4_Button_Click(object sender, RoutedEventArgs e)
        {
            Dif = 4;
            Clear_ExamMenu();
        }

        private void Dif_5_Button_Click(object sender, RoutedEventArgs e)
        {
            Dif = 5;
            Clear_ExamMenu();
        }

        private void Dif_6_Button_Click(object sender, RoutedEventArgs e)
        {
            Dif = 6;
            Clear_ExamMenu();
        }

        private void Dif_7_Button_Click(object sender, RoutedEventArgs e)
        {
            Dif = 7;
            Clear_ExamMenu();
        }

        private void Dif_8_Button_Click(object sender, RoutedEventArgs e)
        {
            Dif = 8;
            Clear_ExamMenu();
        }

        private void Clear_DifMenu()
        {
            MainMenu.Visibility = Visibility.Hidden;
            DifficultMenu.Visibility = Visibility.Visible;
        }

        private double Get_Sum()
        {
            switch (Mode)
            {
                case 1: return Math.Round(((double)Math.Pow(Dif, 2) / 6) * ((double)Math.Pow(Mode, 2) / 6), 4);
                case 2: return Math.Round(((double)Math.Pow(Dif, 2) / 6) * ((double)Math.Pow(Mode, 2) / 6), 4);
                case 3: return Math.Round(((double)Math.Pow(Dif, 2) / 6) * ((double)Math.Pow(Mode, 2) / 6), 4);
                case 4: return Math.Round(((double)Math.Pow(Dif, 2) / 6) * ((double)Math.Pow(Mode, 2) / 6), 4);
                default: return 0;
            }
        }
        /*@see
         @param Orger_Dif Уровень сложности
         */
        private double Get_Sum(int Other_Dif)
        {
            switch (Mode)
            {
                case 1: return Math.Round(((double)Math.Pow(Other_Dif, 2) / 6) * ((double)Math.Pow(Mode, 2) / 6), 4);
                case 2: return Math.Round(((double)Math.Pow(Other_Dif, 2) / 6) * ((double)Math.Pow(Mode, 2) / 6), 4);
                case 3: return Math.Round(((double)Math.Pow(Other_Dif, 2) / 6) * ((double)Math.Pow(Mode, 2) / 6), 4);
                case 4: return Math.Round(((double)Math.Pow(Other_Dif, 2) / 6) * ((double)Math.Pow(Mode, 2) / 6), 4);
                default: return 0;
            }
            
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear_DifMenu();
            Operator.Content = "+";
            Mode = 1;

            Dif_1_Button.Content = "Первый\n"     + Get_Sum(1) + " Руб.";
            Dif_2_Button.Content = "Второй\n"     + Get_Sum(2) + " Руб.";
            Dif_3_Button.Content = "Третий\n"     + Get_Sum(3) + " Руб.";
            Dif_4_Button.Content = "Четвертый\n"  + Get_Sum(4) + " Руб.";
            Dif_5_Button.Content = "Пятый\n"      + Get_Sum(5) + " Руб.";
            Dif_6_Button.Content = "Шестой\n"     + Get_Sum(6) + " Руб.";
            Dif_7_Button.Content = "Седьмой\n"    + Get_Sum(7) + " Руб.";
            Dif_8_Button.Content = "Восьмой\n"    + Get_Sum(8) + " Руб.";
        }

        private void Sub_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear_DifMenu();
            Operator.Content = "-";
            Mode = 2;

            Dif_1_Button.Content = "Первый\n"     + Get_Sum(1) + " Руб.";
            Dif_2_Button.Content = "Второй\n"     + Get_Sum(2) + " Руб.";
            Dif_3_Button.Content = "Третий\n"     + Get_Sum(3) + " Руб.";
            Dif_4_Button.Content = "Четвертый\n"  + Get_Sum(4) + " Руб.";
            Dif_5_Button.Content = "Пятый\n"      + Get_Sum(5) + " Руб.";
            Dif_6_Button.Content = "Шестой\n"     + Get_Sum(6) + " Руб.";
            Dif_7_Button.Content = "Седьмой\n"    + Get_Sum(7) + " Руб.";
            Dif_8_Button.Content = "Восьмой\n"    + Get_Sum(8) + " Руб.";
        }

        private void Mult_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear_DifMenu();
            Operator.Content = "*";
            Mode = 3;

            Dif_1_Button.Content = "Первый\n"     + Get_Sum(1) + " Руб.";
            Dif_2_Button.Content = "Второй\n"     + Get_Sum(2) + " Руб.";
            Dif_3_Button.Content = "Третий\n"     + Get_Sum(3) + " Руб.";
            Dif_4_Button.Content = "Четвертый\n"  + Get_Sum(4) + " Руб.";
            Dif_5_Button.Content = "Пятый\n"      + Get_Sum(5) + " Руб.";
            Dif_6_Button.Content = "Шестой\n"     + Get_Sum(6) + " Руб.";
            Dif_7_Button.Content = "Седьмой\n"    + Get_Sum(7) + " Руб.";
            Dif_8_Button.Content = "Восьмой\n"    + Get_Sum(8) + " Руб.";
        }

        private void Div_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear_DifMenu();
            Operator.Content = "/";
            Mode = 4;

            Dif_1_Button.Content = "Первый\n"     + Get_Sum(1) + " Руб.";
            Dif_2_Button.Content = "Второй\n"     + Get_Sum(2) + " Руб.";
            Dif_3_Button.Content = "Третий\n"     + Get_Sum(3) + " Руб.";
            Dif_4_Button.Content = "Четвертый\n"  + Get_Sum(4) + " Руб.";
            Dif_5_Button.Content = "Пятый\n"      + Get_Sum(5) + " Руб.";
            Dif_6_Button.Content = "Шестой\n"     + Get_Sum(6) + " Руб.";
            Dif_7_Button.Content = "Седьмой\n"    + Get_Sum(7) + " Руб.";
            Dif_8_Button.Content = "Восьмой\n"    + Get_Sum(8) + " Руб.";
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Back_Dif_Button_Click(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Visible;
            DifficultMenu.Visibility = Visibility.Hidden;
        }

        private void Back_Exam_Button_Click(object sender, RoutedEventArgs e)
        {
            DifficultMenu.Visibility = Visibility.Visible;
            ExampleMenu.Visibility = Visibility.Hidden;
        }

        private void Answer_TextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Answer_TextBox.Text = "";
        }

        private void Answer_TextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
                Check_Button_Click(sender, e);
        }

        private void Next_Sucsses_Button_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
                Next_Sucsses_Button_Click(sender, e);
        }

        private void Next_Error_Button_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.ToString() == "Return")
                Next_Error_Button_Click(sender, e);
        }
    }
}