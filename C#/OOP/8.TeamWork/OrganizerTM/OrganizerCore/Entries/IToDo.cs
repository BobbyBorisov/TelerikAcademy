namespace OrganizerCore.Entries
{
    public interface IToDo
    {
        void MarkCompleted();

        bool IsCompleted();
    }
}
