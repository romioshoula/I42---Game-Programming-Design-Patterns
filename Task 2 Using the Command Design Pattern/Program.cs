using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandPattern.Client cs = new CommandPattern.Client();
            mainMenu menu = new mainMenu();
            cs.Instantiate();
            menu.ShowMenu();
            while (true)
            {
                cs.ClientOps();
            }
        }
    }
}
