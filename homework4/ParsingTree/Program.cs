﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ParsingTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{TreeCalculator.CalculateTree("..\\..\\Input.txt")}");
            Console.ReadKey();
        }
    }
}
