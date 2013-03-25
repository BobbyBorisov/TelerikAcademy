using System;

namespace OrganizerCore.Entries
{
    public abstract class Entry : IEntry, IDisplayable
    {
        private DateTime createdOn;

        private string subject;

        protected Entry(string aSubject, string aComments)
        {
            this.Subject = aSubject;
            this.Comments = aComments;
            this.createdOn = DateTime.Now;
        }

        public string Subject
        {
            get
            {
                return this.subject;
            }

            protected set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentOutOfRangeException("Subject must not be empty");
                }

                this.subject = value;
            }
        }

        public DateTime CreatedOn
        {
            get
            {
                return this.createdOn;
            }

            internal set
            {
                this.createdOn = value;
            }
        }

        public string Comments { get; set; }

        public abstract EntryType EntryType { get; }

        public abstract bool IsObsolete();

        // return list of the properties and their values
        public abstract string[] GetInformation();

        public virtual bool IsHot()
        {
            return false;
        }
    }
}
