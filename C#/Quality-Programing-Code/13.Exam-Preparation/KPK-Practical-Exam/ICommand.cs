using System;
using System.Linq;
using System.Text;

namespace Problem04_Free_Content
{
    public interface ICommand
    {
        comt Type { get; set; }

        string OriginalForm { get; set; }

        string Name { get; set; }

        string[] Parameters { get; set; }

        comt ParseCommandType(string commandName);

        string ParseName();

        string[] ParseParameters();
    }
}
