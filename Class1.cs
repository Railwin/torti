using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.Reflection;

namespace tortiki_5_pract
{
    internal class Class1
    {
        public string form;
        public string size;
        public string taste;
        public string glaze;
        public string decor;
        public string all_options;
        public int FormPrice;
        public int SizePrice;
        public int TastePrice;
        public int GlazePrice;
        public int DecorPrice;
        public int AllPrice;

        public Class1(int formPrice, int sizePrice, int tastePrice, int glazePrice, int decorPrice, int allPrice, string AllOptions)
        {
            FormPrice = formPrice;
            SizePrice = sizePrice;
            TastePrice = tastePrice;
            GlazePrice = glazePrice;
            DecorPrice = decorPrice;
            AllPrice = allPrice;
            all_options = AllOptions;
        }
    }
}
