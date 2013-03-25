using System;
using System.IO;
using System.Linq;
using OrganizerCore.Entries;

namespace OrganizerCore
{
    public class TextFilesIO
    {
        public static void PrintEntriesOfType<T>(string filePath, IOrganizer org)
        {            
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {             
                foreach (Entry entry in org.Entries)
                {
                    if (entry is T)
                    {
                        foreach (string info in entry.GetInformation())
                        {
                            writer.WriteLine(info);                            
                        }
                        writer.WriteLine();
                    }
                }
            }
        }

        public static void PrintAll(string filePath, IOrganizer org)
        {
            TextFilesIO.PrintEntriesOfType<Entry>(filePath, org);
        }

        public static void PrintAllByType(string filePath, IOrganizer org)
        {
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                var sortedEntries = org.Entries.OrderBy(entrie => entrie.EntryType);
                foreach (Entry entry in sortedEntries)
                {
                    foreach (string info in entry.GetInformation())
                    {
                        writer.WriteLine(info);                       
                    }
                    writer.WriteLine();
                }
            }
        }

        public static void PrintHot(string filePath, IOrganizer org)
        {
            StreamWriter writer = new StreamWriter(filePath);
            using (writer)
            {
                foreach (Entry entry in org.Entries)
                {
                    if (entry.IsHot())
                    {
                        foreach (string info in entry.GetInformation())
                        {
                            writer.WriteLine(info);                            
                        }
                        writer.WriteLine();
                    }
                }
            }
        }        

        public static void ReadEntries(string filePath, IOrganizer org)
        {
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                string[] entries = reader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < entries.Length; i++)
                {
                    entries[i] = entries[i].Replace("Type: ", "");
                    entries[i] = entries[i].Replace("Subject: ", "");
                    entries[i] = entries[i].Replace("Comments: ", "");
                    entries[i] = entries[i].Replace("Date: ", "");
                    entries[i] = entries[i].Replace("CreatedOn: ", "");
                }

                for (int i = 0; i < entries.Length; i++)
                {
                    switch (entries[i])
                    {
                        case "Anniversary":
                            Anniversary anniversary = new Anniversary(entries[i + 1], entries[i + 2], DateTime.Parse(entries[i + 3]));
                            anniversary.CreatedOn = DateTime.Parse(entries[i + 4]);
                            org.Add(anniversary);
                            i += 4;
                            break;
                        case "Meeting":
                            Meeting meeting = new Meeting(entries[i + 1], entries[i + 2], DateTime.Parse(entries[i + 3]));
                            meeting.CreatedOn = DateTime.Parse(entries[i + 4]);
                            org.Add(meeting);
                            i += 4;
                            break;
                        case "ToDo":
                            ToDo toDo = new ToDo(entries[i + 1], entries[i + 2], DateTime.Parse(entries[i + 3]));
                            toDo.CreatedOn = DateTime.Parse(entries[i + 4]);
                            org.Add(toDo);
                            i += 4;
                            break;
                        case "Memo":
                            Memo memo = new Memo(entries[i + 1], entries[i + 2]);
                            memo.CreatedOn = DateTime.Parse(entries[i + 4]);
                            org.Add(memo);
                            i += 3;
                            break;
                        default:
                            throw new InvalidDataException();
                    }
                }
            }                     
        }
    }
}