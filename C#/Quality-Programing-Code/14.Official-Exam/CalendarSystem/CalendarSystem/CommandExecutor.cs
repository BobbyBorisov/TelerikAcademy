using System;
using System.Linq;
using System.Text;
using System.Globalization;

namespace CalendarSystem
{
    public class CommandExecutor
    {
        private readonly IEventsManager eventManager;
        public CommandExecutor(IEventsManager eventManager)
        {
            this.eventManager = eventManager;
        }
        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventManager;
            }
        }
        public string ProcessCommand(Command cmd)
        {
            var output = new StringBuilder();

            switch (cmd.CommandName)
            {
                case "AddEvent":
                    if (cmd.Parameters.Length == 2)
                    {
                        var date = DateTime.ParseExact(cmd.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                        var e = new Event(cmd.Parameters[1], null, date);
                        //{
                        //    dateAndTime = date,
                        //    Title = cmd.Parameters[1],
                        //    Location = null,
                        //};

                        this.eventManager.AddEvent(e);
                        
                        output.AppendLine("Event added");
                    }
                    if (cmd.Parameters.Length == 3) 
                    {
                        var date = DateTime.ParseExact(cmd.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

                        var e = new Event(cmd.Parameters[1], cmd.Parameters[2], date);
                        //{
                        //    dateAndTime = date,
                        //    Title = cmd.Parameters[1],
                        //    Location = cmd.Parameters[2],
                        //};

                        this.eventManager.AddEvent(e);

                        output.AppendLine("Event added");
                    }
                    break;
                case "DeleteEvents":
                    if (cmd.Parameters.Length == 1)
                    {
                        int c = this.eventManager.DeleteEventsByTitle(cmd.Parameters[0]);

                        if (c == 0)
                        {
                            output.AppendLine("No events found");
                        }
                        else
                        { 
                         output.AppendLine(c + " events deleted");
                        }
                    }
                    break;
                case "ListEvents":
                    if (cmd.Parameters.Length == 2)
                    {
                        var date = DateTime.ParseExact(cmd.Parameters[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                        var c = int.Parse(cmd.Parameters[1]);
                        var events = this.eventManager.ListEvents(date, c).ToList();

                        if (!events.Any())
                        {
                            output.AppendLine("No events found");
                        }

                        foreach (var e in events)
                        {
                            output.AppendLine(e.ToString());
                        }
                    }
                    break;
                default:
                    throw new InvalidOperationException("Command is not valid");
                    
            }
            return output.ToString().Trim();
        }
    }     
}
