using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem
{
    class CalendarSystem
    {


        public static void Main()
        {
            

            var eventManager = new EventManager();

            CommandExecutor cmdExecutor = new CommandExecutor(eventManager);
           
            var commands = ReadUserInput();
            foreach (var command in commands)
            {
                
                Console.WriteLine(cmdExecutor.ProcessCommand(command));
            }
                        
        }

        private static List<Command> ReadUserInput()
        {
            List<Command> commands = new List<Command>();

            while (true)
            {
                string userinput = Console.ReadLine();qq
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


