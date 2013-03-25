using System;

namespace OrganizerCore
{
    public interface IComunicator
    {
        string ReadStringData();

        void DisplayMessage(string[] entryInfo);

        void ClearScreen();

        DateTime ParseDate();
    }
}
