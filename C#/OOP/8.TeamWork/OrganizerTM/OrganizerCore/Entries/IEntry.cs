namespace OrganizerCore.Entries
{
    public interface IEntry
    {
        bool IsObsolete();

        bool IsHot();
    }
}
