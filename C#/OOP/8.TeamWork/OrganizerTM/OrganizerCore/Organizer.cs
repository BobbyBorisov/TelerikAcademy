using System;
using System.Collections.Generic;
using System.Linq;
using OrganizerCore.Entries;

namespace OrganizerCore
{
    public class Organizer : IOrganizer, IDisplayable
    {
        #region Fields

        private IList<Entry> entries;

        private int currentEntry;

        #endregion

        #region Constructor

        public Organizer()
        {
            this.Entries = new List<Entry>();
            this.CurrentEntry = 0;
        }

        #endregion

        #region Properties

        public IList<Entry> Entries
        {
            get
            {
                IList<Entry> listToReturn = new List<Entry>();
                foreach (var item in this.entries)
                {
                    switch (item.EntryType)
                    {
                        case EntryType.Anniversary:
                            Anniversary newAnniversary = item as Anniversary;
                            Anniversary anniversatyToAdd = new Anniversary(newAnniversary.Subject, newAnniversary.Comments, newAnniversary.DateOfAnniversary);
                            anniversatyToAdd.CreatedOn = newAnniversary.CreatedOn;
                            listToReturn.Add(anniversatyToAdd);
                            break;
                        case EntryType.Meeting:
                            Meeting newMeeting = item as Meeting;
                            Meeting meetingToAdd = new Meeting(newMeeting.Subject, newMeeting.Comments, newMeeting.MeetingTime);
                            meetingToAdd.CreatedOn = newMeeting.CreatedOn;
                            listToReturn.Add(meetingToAdd);
                            break;
                        case EntryType.Memo:
                            Memo newMemo = item as Memo;
                            Memo memoToAdd = new Memo(newMemo.Subject, newMemo.Comments);
                            memoToAdd.CreatedOn = newMemo.CreatedOn;
                            listToReturn.Add(memoToAdd);
                            break;
                        case EntryType.ToDo:
                            ToDo newTodo = item as ToDo;
                            ToDo todoToAdd = new ToDo(newTodo.Subject, newTodo.Comments, newTodo.DateOfAction);
                            todoToAdd.CreatedOn = newTodo.CreatedOn;
                            listToReturn.Add(todoToAdd);
                            break;
                    }
                }

                return listToReturn;
            }

            private set
            {
                this.entries = value;
            }
        }

        internal int CurrentEntry
        {
            get
            {
                return this.currentEntry;
            }

            private set
            {
                this.currentEntry = value;
            }
        }

        #endregion

        #region Methods

        // List of entries
        // Add, Remove
        // GetPrevious, GetCurrent, GetNext
        public Entry GetCurrent()
        {
            if (this.currentEntry >= this.entries.Count || this.currentEntry < 0)
            {
                return null;
            }

            return this.entries[this.CurrentEntry];
        }

        public void GetNext()
        {
            if (this.currentEntry >= this.entries.Count)
            {
                return;
            }
            else
            {
                this.currentEntry = this.CurrentEntry + 1;
            }
        }

        public void GetPrevious()
        {
            if (this.currentEntry <= 0)
            {
                return;
            }

            this.CurrentEntry = this.CurrentEntry - 1;
        }

        public void Restart()
        {
            this.CurrentEntry = 0;
        }

        public void Add(Entry aNewEntry)
        {
            this.entries.Add(aNewEntry);
        }

        public void Remove(Entry aEntryToRemove)
        {
            this.entries.Remove(aEntryToRemove);
        }

        // return list of entries (Title and Date)
        public string[] GetInformation()
        {
            string[] informationString = new string[this.Entries.Count()];
            for (int eventNumber = 0; eventNumber < informationString.Length; eventNumber++)
            {
                informationString[eventNumber] = string.Format(this.Entries[eventNumber].Subject + this.Entries[eventNumber].CreatedOn);
            }

            return informationString;
        }

        #endregion
    }
}