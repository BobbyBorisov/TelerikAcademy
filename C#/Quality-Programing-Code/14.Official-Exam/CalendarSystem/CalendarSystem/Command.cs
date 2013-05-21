using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSystem
{
    public class Command
    {
        readonly static char[] paramsSeparators = { '|' };
        readonly static  char commandEnd = ' ';


        public string CommandName;

        public  string OriginalForm { get; set; }
        public  string[] Parameters { get; set; }

        private int commandNameEndIndex;

        public Command() 
        {
        
        }
        public Command(string input) 
        {
            this.OriginalForm = input;
            this.Parse(input);
        }

        public  void Parse(string inputCommand)
        {
            this.commandNameEndIndex = GetCommandNameEndIndex();
            this.CommandName = ParseName();
            this.Parameters = ParseParameters();
            TrimParams();

            
        }

        private   int GetCommandNameEndIndex() 
        {
            int endIndex = OriginalForm.IndexOf(commandEnd);

            return endIndex;
        }

        private   string ParseName()
        {
            string name = OriginalForm.Substring(0, commandNameEndIndex);
            return name;
        }

        private  string[] ParseParameters()
        {
            int paramsLength = OriginalForm.Length - (commandNameEndIndex+1);

            string paramsOriginalForm = OriginalForm.Substring(commandNameEndIndex + 1, paramsLength);
            string[] parameters = paramsOriginalForm.Split(paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        private  void TrimParams()
        {
            for (var i = 0; i < Parameters.Length; i++)
            {qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq
                Parameters[i] = Parameters[i].Trim();
            }
        }
    }
}
