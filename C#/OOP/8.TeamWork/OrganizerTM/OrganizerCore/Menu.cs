using System;

namespace OrganizerCore
{
    public class Menu : IMenu
    {
        public void DisplayMainMenu()
        {
            Console.WriteLine("--------Menu-------");
            Console.WriteLine("1. View");
            Console.WriteLine("2. Add");
            Console.WriteLine("3. AlertMode");
            Console.WriteLine("Esc - Exit");
            Console.WriteLine("-------------------");            
        }

        public void DisplayView()
        {
            Console.WriteLine("---------View---------");
            Console.WriteLine("1. Next - Left Arrow");
            Console.WriteLine("2. Previous - Right Arrow");
            Console.WriteLine("3. Delete - Del");
            Console.WriteLine("4. Previous Menu - Esc");
            Console.WriteLine("-------------------");
        }

        public void DisplayAddOptions()
        {
            Console.WriteLine("--------Add-------");
            Console.WriteLine("select type");
            Console.WriteLine("1. Anniversary");
            Console.WriteLine("2. Meeting");
            Console.WriteLine("3. Memo");
            Console.WriteLine("4. ToDo");
            Console.WriteLine("5. Previous Menu - Esc");
            Console.WriteLine("-------------------");            
        }

        public void DisplayAdd()
        {
            Console.WriteLine("-------Adding------");
            Console.WriteLine("Fill required fields");
            Console.WriteLine("-------------------");
        }
    }
}
