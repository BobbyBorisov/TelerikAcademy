using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganizerCore;
using OrganizerCore.Entries;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Organizer org = new Organizer();
            Menu menu = new Menu();
            Keyboard key = new Keyboard();
            ConsoleComunicator communicator = new ConsoleComunicator();

            Engine eng = new Engine(key, org, menu, communicator);

            List<Entry> entries = new List<Entry>(){
                new Anniversary("Anniversary event","Does not expire event, hot when 15 are remaining or become 1 day old",DateTime.Now.AddDays(2)),
                new Meeting("Meeting event","Expires on the scheduled date and hour + 2 hours, hot when 1 day is remaining",DateTime.Now.AddMinutes(200)),
                new Memo("Memo","Just a Memo"),
                new ToDo("ToDo","Expires on the scheduled date&time, hot when 2 hours are remaining",DateTime.Now.AddMinutes(100))
            };

            foreach (Entry entry in entries)
            {
                org.Add(entry);
           }

            

            eng.Run();
            

            //Entry newE = org.GetCurrent();

            //if (newE.EntryType ==  EntryType.Anniversary)
            //{
            //    Anniversary ani = newE as Anniversary;
            //    Console.WriteLine(ani.DateOfAnniversary);
            //}
            
            
            
            

        }
    }
}