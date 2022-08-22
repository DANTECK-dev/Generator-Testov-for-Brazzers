using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Generator_Testov_for_Brazzers
{
    internal class Data
    {
        /////////////   Сумма     ////////////////////////////////////////////////
        
        public double Cur_Summ { get; set; }

        /////////////   Цена каждого уровня     ////////////////////////////////////////////////

        public double[] Price_Add   { get; set; }
        public double[] Price_Sub   { get; set; }
        public double[] Price_Mult  { get; set; }
        public double[] Price_Div   { get; set; }

        ////////////    Блокировки уровней      /////////////////////////////////////////////////

        public bool[] Enabled_Add     { get; set; }
        public bool[] Enabled_Sub     { get; set; }
        public bool[] Enabled_Mult    { get; set; }
        public bool[] Enabled_Div     { get; set; }

        ////////////    Количество решеных задач вообще     /////////////////////////////////////////////////

        public int[] Counter_Add  { get; set; }
        public int[] Counter_Sub  { get; set; }
        public int[] Counter_Mult { get; set; }
        public int[] Counter_Div  { get; set; }

        ////////////    Максималное количество решеных задач    /////////////////////////////////////////////////

        public int[] Max_Counter_Add  { get; set; }
        public int[] Max_Counter_Sub  { get; set; }
        public int[] Max_Counter_Mult { get; set; }
        public int[] Max_Counter_Div  { get; set; }
    }
}
