using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSourceCatalog
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor cmdExecutor = new CommandExecutor();

            var commands = ReadUserInput();
            foreach (ICommand command in commands)
            {
                cmdExecutor.ExecuteCommand(catalog, command, output);
            }

            Console.Write(output); 
        }

        private static List<ICommand> ReadUserInput()
        {
            List<ICommand> commands = new List<ICommand>();
            bool end = false;

            while (true) 
            {
                string userinput = Console.ReadLine();
                if (userinput.Trim() == "End") 
                {
                    break;
                }

                commands.Add(new Command(userinput));
            }
            return commands;
        }
    }
}
