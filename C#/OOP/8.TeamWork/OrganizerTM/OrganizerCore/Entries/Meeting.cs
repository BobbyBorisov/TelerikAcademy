using System;

namespace OrganizerCore.Entries
{
    public class Meeting : Entry
    {
        public Meeting(string aSubject, string aComments, DateTime aMeetingTime)
            : base(aSubject, aComments)
        {
            this.MeetingTime = aMeetingTime;
        }

        public DateTime MeetingTime { get; protected set; }

        public override EntryType EntryType
        {
            get
            {
                return EntryType.Meeting;
            }
        }

        public override bool IsObsolete()
        {
            if (DateTime.Now.AddHours(2) < this.MeetingTime)
            {
                return true;
            }

            return false;
        }

        public override bool IsHot()
        {
            //If day <= 1 are remaining tell me it's a hot entry

            int days = (this.MeetingTime - DateTime.Now).Days;
            if (days <= 1)
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
                "Date: " + this.MeetingTime.ToString(),
                "CreatedOn: " + this.CreatedOn.ToString()
            };
            return str;
        }
    }
}
