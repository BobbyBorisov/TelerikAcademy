using System;

namespace OrganizerCore.Entries
{
    public class Memo : Entry
    {
        public Memo(string aSubject, string aComment)
            : base(aSubject, aComment) { }

        public override EntryType EntryType
        {
            get
            {
                return EntryType.Memo;
            }
        }

        public override bool IsObsolete()
        {
            return false;
        }

        public override string[] GetInformation()
        {
            string[] str =
            {
                "Type: " + this.EntryType,
                "Subject: " + this.Subject,
                "Comments: " + this.Comments,
                "CreatedOn: " + this.CreatedOn.ToString()
            };
            return str;
        }
    }
}
