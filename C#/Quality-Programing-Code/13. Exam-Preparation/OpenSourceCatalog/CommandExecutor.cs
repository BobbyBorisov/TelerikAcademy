using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSourceCatalog
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand cmd, StringBuilder sb)
        {
            switch (cmd.Type)
            {
                case CommandType.AddBook:
                    catalog.Add(new ContentItem(ContentItemType.Book, cmd.Parameters));
                    sb.AppendLine("Book added");
                    break;
                case CommandType.AddMovie:
                    catalog.Add(new ContentItem(ContentItemType.Movie, cmd.Parameters));
                    sb.AppendLine("Movie added");
                    break;
                case CommandType.AddSong:
                    catalog.Add(new ContentItem(ContentItemType.Song, cmd.Parameters));
                    sb.AppendLine("Song added");
                    break;
                case CommandType.AddApplication:
                    catalog.Add(new ContentItem(ContentItemType.Application, cmd.Parameters));
                    sb.AppendLine("Application added");
                    break;
                case CommandType.Update:
                    if (cmd.Parameters.Length != 2)
                    {
                        throw new FormatException("Format exception");
                    }
                    var updatedItems = catalog.UpdateContent(cmd.Parameters[0], cmd.Parameters[1]);
                    sb.AppendLine(String.Format("{0} items updated", updatedItems));
                    break;
                case CommandType.Find:
                    {
                        if (cmd.Parameters.Length != 2)
                        {
                            Console.WriteLine("Invalid params!");
                            throw new Exception("Invalid number of parameters!");
                        }

                        int numberOfElementsToList = int.Parse(cmd.Parameters[1]);

                        IEnumerable<IContent> foundContent = catalog.GetListContent(cmd.Parameters[0], numberOfElementsToList);

                        if (foundContent.Count() == 0)
                        {
                            sb.AppendLine("No items found");
                        }
                        else
                        {
                            foreach (IContent content in foundContent)
                            {
                                sb.AppendLine(content.TextRepresentation);
                            }
                        }
                    }
                    break;

                default:
                    {
                        throw new InvalidCastException("Unknown command!");
                    }
            }
        }
    }
}
