﻿using System;
using SG.ConsoleUtil2.BLL;


namespace SG.ConsoleUtilities.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = UserInput.GetIntFromUser("Enter your age:");

            Console.WriteLine("The entered age was: {0}", age);

            Console.ReadLine();
        }
    }
}
