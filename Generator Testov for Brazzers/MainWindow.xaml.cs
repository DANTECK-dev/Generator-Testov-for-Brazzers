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
        public static String Json_Path = @"C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Data_GTforB.json";

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

        private double MAX_MONEY_ADD_MODE   = 4.5;
        private double MAX_MONEY_SUB_MODE   = 11.5;
        private double MAX_MONEY_MULT_MODE  = 19.5;
        private double MAX_MONEY_DIV_MODE   = 27.5;

        Data data = new Data();

        public MainWindow()
        {
            InitializeComponent();
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
            data = Json.ReadJson();
            Balance.Content = "Баланс: " + data.Cur_Summ;
        }

        private void Write_File()
        {
            
            

            Json.WriteJson(data);
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
            switch (Mode)
            {
                case 1:
                    {
                        if (data.Counter_Add[Dif - 1] >= data.Max_Counter_Add[Dif - 1])
                        {
                            Back_Exam_Button_Click(sender, e);
                            SucssesMenu.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                case 2:
                    {
                        if (data.Counter_Sub[Dif - 1] >= data.Max_Counter_Sub[Dif - 1])
                        {
                            Back_Exam_Button_Click(sender, e);
                            SucssesMenu.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                case 3:
                    {
                        if (data.Counter_Mult[Dif - 1] >= data.Max_Counter_Mult[Dif - 1])
                        {
                            Back_Exam_Button_Click(sender, e);
                            SucssesMenu.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                case 4:
                    {
                        if (data.Counter_Div[Dif - 1] >= data.Max_Counter_Div[Dif - 1])
                        {
                            Back_Exam_Button_Click(sender, e);
                            SucssesMenu.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
            }
            return;
        }

        private void Next_Error_Button_Click(object sender, RoutedEventArgs e)
        {
            Get_Random_Exaple();
            ExampleMenu.Visibility = Visibility.Visible;
            ErrorMenu.Visibility = Visibility.Hidden;
            Answer_TextBox.Text = "";
            Answer_TextBox.Focus();
            switch (Mode)
            {
                case 1:
                    {
                        if (data.Counter_Add[Dif - 1] >= data.Max_Counter_Add[Dif - 1])
                        {
                            Back_Exam_Button_Click(sender, e);
                            ErrorMenu.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                case 2:
                    {
                        if (data.Counter_Sub[Dif - 1] >= data.Max_Counter_Sub[Dif - 1])
                        {
                            Back_Exam_Button_Click(sender, e);
                            ErrorMenu.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                case 3:
                    {
                        if (data.Counter_Mult[Dif - 1] >= data.Max_Counter_Mult[Dif - 1])
                        {
                            Back_Exam_Button_Click(sender, e);
                            ErrorMenu.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
                case 4:
                    {
                        if (data.Counter_Div[Dif - 1] >= data.Max_Counter_Div[Dif - 1])
                        {
                            Back_Exam_Button_Click(sender, e);
                            ErrorMenu.Visibility = Visibility.Hidden;
                        }
                        break;
                    }
            }
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
                data.Cur_Summ = 0;
                Write_File();
                Read_File();
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
            if (True_Answear == long.Parse(Answer_TextBox.Text.ToString()))
            {
                //double x = Get_Sum();
                //data.Cur_Summ += x;
                switch (Mode)
                {
                    case 1: { data.Counter_Add[Dif - 1]++;  data.Cur_Summ += data.Price_Add[Dif];   break; }
                    case 2: { data.Counter_Sub[Dif - 1]++;  data.Cur_Summ += data.Price_Sub[Dif];   break; }
                    case 3: { data.Counter_Mult[Dif - 1]++; data.Cur_Summ += data.Price_Mult[Dif];  break; }
                    case 4: { data.Counter_Div[Dif - 1]++;  data.Cur_Summ += data.Price_Div[Dif];   break; }
                }
                SucssesMenu.Visibility = Visibility.Visible;
                ExampleMenu.Visibility = Visibility.Hidden;
                Next_Sucsses_Button.Focus();
                isEnabled_Write();
                Write_File();
                Read_File();

            }
            else
            {
                Error_Message.Content = "Неправильно\nВаш ответ: " + Answer_TextBox.Text + "\nПравильный ответ: " + True_Answear;
                ErrorMenu.Visibility = Visibility.Visible;
                ExampleMenu.Visibility = Visibility.Hidden;
                Next_Error_Button.Focus();
                /*switch (Mode)
                {
                    case 1: data.Counter_Add[Dif - 1]--; break;
                    case 2: data.Counter_Sub[Dif - 1]--; break;
                    case 3:data.Counter_Mult[Dif - 1]--; break;
                    case 4: data.Counter_Div[Dif - 1]--; break;
                }*/
                isEnabled_Write();
                Write_File();
                Read_File();
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

        /*private double Get_Sum()
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
            
        }*/
                private double Get_Sum()
        {
            switch (Mode)
            {
                case 1: return Math.Round((double) ((MAX_MONEY_ADD_MODE / (Mode * 8)) * (Mode * Dif)), 4);
                case 2: return Math.Round((double) ((MAX_MONEY_ADD_MODE / (Mode * 8)) * (Mode * Dif)), 4);
                case 3: return Math.Round((double) ((MAX_MONEY_ADD_MODE / (Mode * 8)) * (Mode * Dif)), 4);
                case 4: return Math.Round((double) ((MAX_MONEY_ADD_MODE / (Mode * 8)) * (Mode * Dif)), 4);
                default: return Math.Round((double)((MAX_MONEY_ADD_MODE / (Mode * 8)) * (Mode * Dif)), 4);
            }
        }

        private double Get_Sum(int Other_Dif)
        {
            switch (Mode)
            {
                case 1: return Math.Round((double) ((MAX_MONEY_ADD_MODE / (Mode * 8)) * (Mode * Other_Dif)), 4);
                case 2: return Math.Round((double) ((MAX_MONEY_SUB_MODE / (Mode * 8)) * (Mode * Other_Dif)), 4);
                case 3: return Math.Round((double)((MAX_MONEY_MULT_MODE / (Mode * 8)) * (Mode * Other_Dif)), 4);
                case 4: return Math.Round((double) ((MAX_MONEY_DIV_MODE / (Mode * 8)) * (Mode * Other_Dif)), 4);
                default: return Math.Round((double)((MAX_MONEY_ADD_MODE / (Mode * 8)) * (Mode * Other_Dif)), 4);
            }
        }

        private void isEnabled_Read()
        {
            switch (Mode)
            {
                case 1:
                    {
                        Dif_1_Button.IsEnabled = data.Enabled_Add[0];
                        Dif_2_Button.IsEnabled = data.Enabled_Add[1];
                        Dif_3_Button.IsEnabled = data.Enabled_Add[2];
                        Dif_4_Button.IsEnabled = data.Enabled_Add[3];
                        Dif_5_Button.IsEnabled = data.Enabled_Add[4];
                        Dif_6_Button.IsEnabled = data.Enabled_Add[5];
                        Dif_7_Button.IsEnabled = data.Enabled_Add[6];
                        Dif_8_Button.IsEnabled = data.Enabled_Add[7];
                        break;
                    }
                case 2:
                    {
                        Dif_1_Button.IsEnabled = data.Enabled_Sub[0];
                        Dif_2_Button.IsEnabled = data.Enabled_Sub[1];
                        Dif_3_Button.IsEnabled = data.Enabled_Sub[2];
                        Dif_4_Button.IsEnabled = data.Enabled_Sub[3];
                        Dif_5_Button.IsEnabled = data.Enabled_Sub[4];
                        Dif_6_Button.IsEnabled = data.Enabled_Sub[5];
                        Dif_7_Button.IsEnabled = data.Enabled_Sub[6];
                        Dif_8_Button.IsEnabled = data.Enabled_Sub[7];
                        break;
                    }
                case 3:
                    {
                        Dif_1_Button.IsEnabled = data.Enabled_Mult[0];
                        Dif_2_Button.IsEnabled = data.Enabled_Mult[1];
                        Dif_3_Button.IsEnabled = data.Enabled_Mult[2];
                        Dif_4_Button.IsEnabled = data.Enabled_Mult[3];
                        Dif_5_Button.IsEnabled = data.Enabled_Mult[4];
                        Dif_6_Button.IsEnabled = data.Enabled_Mult[5];
                        Dif_7_Button.IsEnabled = data.Enabled_Mult[6];
                        Dif_8_Button.IsEnabled = data.Enabled_Mult[7];
                        break;
                    }
                case 4:
                    {
                        Dif_1_Button.IsEnabled = data.Enabled_Div[0];
                        Dif_2_Button.IsEnabled = data.Enabled_Div[1];
                        Dif_3_Button.IsEnabled = data.Enabled_Div[2];
                        Dif_4_Button.IsEnabled = data.Enabled_Div[3];
                        Dif_5_Button.IsEnabled = data.Enabled_Div[4];
                        Dif_6_Button.IsEnabled = data.Enabled_Div[5];
                        Dif_7_Button.IsEnabled = data.Enabled_Div[6];
                        Dif_8_Button.IsEnabled = data.Enabled_Div[7];
                        break;
                    }
            }
        }

        private void isEnabled_Write()
        {
            switch (Mode)
            {
                case 1:
                    {
                        data.Enabled_Add[0] = Dif_1_Button.IsEnabled;
                        data.Enabled_Add[1] = Dif_2_Button.IsEnabled;
                        data.Enabled_Add[2] = Dif_3_Button.IsEnabled;
                        data.Enabled_Add[3] = Dif_4_Button.IsEnabled;
                        data.Enabled_Add[4] = Dif_5_Button.IsEnabled;
                        data.Enabled_Add[5] = Dif_6_Button.IsEnabled;
                        data.Enabled_Add[6] = Dif_7_Button.IsEnabled;
                        data.Enabled_Add[7] = Dif_8_Button.IsEnabled;
                        break;
                    }
                case 2:
                    {
                        data.Enabled_Sub[0] = Dif_1_Button.IsEnabled;
                        data.Enabled_Sub[1] = Dif_2_Button.IsEnabled;
                        data.Enabled_Sub[2] = Dif_3_Button.IsEnabled;
                        data.Enabled_Sub[3] = Dif_4_Button.IsEnabled;
                        data.Enabled_Sub[4] = Dif_5_Button.IsEnabled;
                        data.Enabled_Sub[5] = Dif_6_Button.IsEnabled;
                        data.Enabled_Sub[6] = Dif_7_Button.IsEnabled;
                        data.Enabled_Sub[7] = Dif_8_Button.IsEnabled;
                        break;
                    }
                case 3:
                    {
                        data.Enabled_Mult[0] = Dif_1_Button.IsEnabled;
                        data.Enabled_Mult[1] = Dif_2_Button.IsEnabled;
                        data.Enabled_Mult[2] = Dif_3_Button.IsEnabled;
                        data.Enabled_Mult[3] = Dif_4_Button.IsEnabled;
                        data.Enabled_Mult[4] = Dif_5_Button.IsEnabled;
                        data.Enabled_Mult[5] = Dif_6_Button.IsEnabled;
                        data.Enabled_Mult[6] = Dif_7_Button.IsEnabled;
                        data.Enabled_Mult[7] = Dif_8_Button.IsEnabled;
                        break;
                    }
                case 4:
                    {
                        data.Enabled_Div[0] = Dif_1_Button.IsEnabled;
                        data.Enabled_Div[1] = Dif_2_Button.IsEnabled;
                        data.Enabled_Div[2] = Dif_3_Button.IsEnabled;
                        data.Enabled_Div[3] = Dif_4_Button.IsEnabled;
                        data.Enabled_Div[4] = Dif_5_Button.IsEnabled;
                        data.Enabled_Div[5] = Dif_6_Button.IsEnabled;
                        data.Enabled_Div[6] = Dif_7_Button.IsEnabled;
                        data.Enabled_Div[7] = Dif_8_Button.IsEnabled;
                        break;
                    }
            }
            for(int i = 0; i < 8; i++)
            {
                switch (Mode)
                {
                    case 1:
                        {
                            if (data.Counter_Add[i] >= data.Max_Counter_Add[i])
                                data.Enabled_Add[i] = false;
                            break;
                        } 
                    case 2:
                        {
                            if (data.Counter_Sub[i] >= data.Max_Counter_Sub[i])
                                data.Enabled_Sub[i] = false;
                            break;
                        }
                    case 3:
                        {
                            if (data.Counter_Mult[i] >= data.Max_Counter_Mult[i])
                                data.Enabled_Mult[i] = false;
                            break;
                        }
                    case 4:
                        {
                            if (data.Counter_Div[i] >= data.Max_Counter_Div[i])
                                data.Enabled_Div[i] = false;
                            break;
                        }
                }
            }
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear_DifMenu();
            Operator.Content = "+";
            Mode = 1;

            Dif_1_Button.Content = "Первый\n"     + data.Price_Add[0] + " Руб.";
            Dif_2_Button.Content = "Второй\n"     + data.Price_Add[1] + " Руб.";
            Dif_3_Button.Content = "Третий\n"     + data.Price_Add[2] + " Руб.";
            Dif_4_Button.Content = "Четвертый\n"  + data.Price_Add[3] + " Руб.";
            Dif_5_Button.Content = "Пятый\n"      + data.Price_Add[4] + " Руб.";
            Dif_6_Button.Content = "Шестой\n"     + data.Price_Add[5] + " Руб.";
            Dif_7_Button.Content = "Седьмой\n"    + data.Price_Add[6] + " Руб.";
            Dif_8_Button.Content = "Восьмой\n"    + data.Price_Add[7] + " Руб.";

            isEnabled_Read();
        }

        private void Sub_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear_DifMenu();
            Operator.Content = "-";
            Mode = 2;

            Dif_1_Button.Content = "Первый\n"     + data.Price_Sub[0] + " Руб.";
            Dif_2_Button.Content = "Второй\n"     + data.Price_Sub[1] + " Руб.";
            Dif_3_Button.Content = "Третий\n"     + data.Price_Sub[2] + " Руб.";
            Dif_4_Button.Content = "Четвертый\n"  + data.Price_Sub[3] + " Руб.";
            Dif_5_Button.Content = "Пятый\n"      + data.Price_Sub[4] + " Руб.";
            Dif_6_Button.Content = "Шестой\n"     + data.Price_Sub[5] + " Руб.";
            Dif_7_Button.Content = "Седьмой\n"    + data.Price_Sub[6] + " Руб.";
            Dif_8_Button.Content = "Восьмой\n"    + data.Price_Sub[7] + " Руб.";
            isEnabled_Read();
        }

        private void Mult_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear_DifMenu();
            Operator.Content = "*";
            Mode = 3;

            Dif_1_Button.Content = "Первый\n"     + data.Price_Mult[0] + " Руб.";
            Dif_2_Button.Content = "Второй\n"     + data.Price_Mult[1] + " Руб.";
            Dif_3_Button.Content = "Третий\n"     + data.Price_Mult[2] + " Руб.";
            Dif_4_Button.Content = "Четвертый\n"  + data.Price_Mult[3] + " Руб.";
            Dif_5_Button.Content = "Пятый\n"      + data.Price_Mult[4] + " Руб.";
            Dif_6_Button.Content = "Шестой\n"     + data.Price_Mult[5] + " Руб.";
            Dif_7_Button.Content = "Седьмой\n"    + data.Price_Mult[6] + " Руб.";
            Dif_8_Button.Content = "Восьмой\n"    + data.Price_Mult[7] + " Руб.";
            isEnabled_Read();
        }

        private void Div_Button_Click(object sender, RoutedEventArgs e)
        {
            Clear_DifMenu();
            Operator.Content = "/";
            Mode = 4;

            Dif_1_Button.Content = "Первый\n"     + data.Price_Div[0] + " Руб.";
            Dif_2_Button.Content = "Второй\n"     + data.Price_Div[1] + " Руб.";
            Dif_3_Button.Content = "Третий\n"     + data.Price_Div[2] + " Руб.";
            Dif_4_Button.Content = "Четвертый\n"  + data.Price_Div[3] + " Руб.";
            Dif_5_Button.Content = "Пятый\n"      + data.Price_Div[4] + " Руб.";
            Dif_6_Button.Content = "Шестой\n"     + data.Price_Div[5] + " Руб.";
            Dif_7_Button.Content = "Седьмой\n"    + data.Price_Div[6] + " Руб.";
            Dif_8_Button.Content = "Восьмой\n"    + data.Price_Div[7] + " Руб.";
            isEnabled_Read();
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
            isEnabled_Read();
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