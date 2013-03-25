using System;

namespace OrganizerCore.Entries
{
    public class ToDo : Entry, IToDo
    {
        public ToDo(string aSubject, string aComment, DateTime aDateOfAction)
            : base(aSubject, aComment)
        {
            this.DateOfAction = aDateOfAction;
            this.Status = false;
        }

        public DateTime DateOfAction { get; private set; }

        public override EntryType EntryType
        {
            get
            {
                return EntryType.ToDo;
            }
        }
        
        private bool Status { get; set; }

        // MarkObsolete if no date is marked
        public override bool IsObsolete()
        {
            if (DateTime.Now > this.DateOfAction)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool IsHot()
        {
            // If hours <= 2 are remaining tell me it's a hot entry
            int hours = (this.DateOfAction - DateTime.Now).Hours;
            if (hours <= 2)
            {
                return true;
            }

            return false;
        }

        public override string[] GetInformation()
        {
            string[] str =
            {
                "Type: " + this.EntryType,
                "Subject: " + this.Subject,
                "Comments: " + this.Comments,
                "Date: " + this.DateOfAction.ToString(),
                "CreatedOn: " + this.CreatedOn.ToString()
            };
            return str;
        }

        public void MarkCompleted()
        {
            this.Status = true;
        }

        public bool IsCompleted()
        {
            if (!this.IsObsolete() && this.Status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
