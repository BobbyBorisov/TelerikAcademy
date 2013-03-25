using System.Collections.Generic;
using OrganizerCore.Entries;

namespace OrganizerCore
{
    public interface IOrganizer
    {
        IList<Entry> Entries
        {
            get;
        }

        Entry GetCurrent();

        void GetNext();
        
        void GetPrevious();

        void Restart();

        void Add(Entry aNewEntry);

        void Remove(Entry aEntryToRemove);
    }
}