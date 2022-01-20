using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDesignPatterns_Task2
{
    class CommandPattern
    {
        delegate void Invoker();
        delegate void InvokerSet(string s);

        static Invoker Execute, Print, Redo, Undo;
        static InvokerSet Add;

        class Command
        {
            public Command(Receiver receiver)
            {
                Add = receiver.SetData;
                Execute = receiver.DoIt;
                Print = receiver.Print;
                Redo = receiver.DoIt;
                Undo = receiver.Reverse;
            }
        }

        public class Receiver
        {
            string current, Previous;
            string Selector;
            public void SetData(string s)
            {
                this.Selector = s;
            }
            public void DoIt()
            {
                Previous = current;
                current += Selector;
            }
            public void Reverse()
            {
                current = Previous;
            }
            public void Print()
            {
                Console.WriteLine(current);
            }
        }

        public class Client
        {
            public void Instantiate()
            {
                new Command(new Receiver());
            }
            public void ClientOps()
            {
                mainMenu menu = new mainMenu();
                Console.Write("Enter the number or letter for your choice (Ex. 1 for Hello ): ");
                string StringHandle = Console.ReadLine().ToLower(); //Convert to lowercase

                switch (StringHandle)
                {
                    case "1":
                        {
                            Add("Hello ");
                            Execute();
                            Console.Clear();
                            menu.ShowMenu();
                            break;
                        }

                    case "2":
                        {
                            Add("Welcome ");
                            Execute();
                            Console.Clear();
                            menu.ShowMenu();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine();
                            Print();
                            Console.WriteLine();
                            break;
                        }
                    case "e":
                        {
                            Environment.Exit(0);
                            break;

                        }
                    case "u":
                        {
                            Undo();
                            Console.Clear();
                            menu.ShowMenu();
                            break;
                        }
                    case "r":
                        {

                            Redo();
                            Console.Clear();
                            menu.ShowMenu();
                            break;
                        }
                }
            }
        }
    }

    class mainMenu
    {
        public void ShowMenu()
        {
            Console.WriteLine("1. Hello");
            Console.WriteLine("2. Welcome");
            Console.WriteLine("3. Print_String");
            Console.WriteLine("E/e. Exit_Program");
            Console.WriteLine("R/r. Redo");
            Console.WriteLine("U/u. Undo");
        }
    }
}
