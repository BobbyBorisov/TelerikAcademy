using System;

namespace OrganizerCore.Entries
{
    public class Anniversary : Entry
    {
        // Date of the Anniversary
        // Repeat Each Year

        public Anniversary(string aSubject, string aComment, DateTime aDateOfAnniversary)
            : base(aSubject, aComment)
        {
            this.DateOfAnniversary = aDateOfAnniversary;
        }

        public DateTime DateOfAnniversary { get; set; }

        public override EntryType EntryType
        {
            get
            {
                return EntryType.Anniversary;
            }
        }

        public override bool IsHot()
        {
            //If day <= 15 are remaining tell me it's a hot entry
            int days = (this.DateOfAnniversary - DateTime.Now).Days;
            // And not if it is more one day old
            if (days <= 15 && days > -1)
            {
                return true;
            }

            return false;
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
                "Date: " + this.DateOfAnniversary.ToString(),
                "CreatedOn: " + this.CreatedOn.ToString()
            };
            return str;
        }
    }
}
