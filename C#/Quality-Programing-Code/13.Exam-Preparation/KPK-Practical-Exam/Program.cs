using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Problem04_Free_Content
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();ca cat = new ca();
ICommandExecutor c = new ce();

            foreach (ICommand item in parse())
            {
                c.ExecuteCommand(cat, item, output); //this is how we do


            }

            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(output
                ); //printing the output
        }

        private static List<ICommand> parse()
        {
            List<ICommand> ins = new List<ICommand>();
            bool end = false;

            do
            {
                string l = Console.ReadLine();
                end = (l.Trim() == "End");
                if (!end)
                {
                    ins.Add(new com(l));
                }

            }
            while (!end);

            return ins;
        }
    }

    public class ce : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog contCat, ICommand c, StringBuilder sb)
        {
            switch (c.Type)
            {
                case comt.AddBook:
                    {
                        contCat.Add(new co(ct.Kniga, c.Parameters)
                        );sb.AppendLine("Books Added");
                    }break;

                case comt.AddMovie:
                    {
                        contCat.Add(new co(ct.Film, c.Parameters));

                        sb.AppendLine("Movie added");


                    }
                    break;

                case comt.AddSong:
                    {
                        contCat.Add(new co(ct.Muzika, c.Parameters));

                        sb.Append("Song added");
                    }
                    break;

                case comt.AddApplication:
                    {
                        
                        contCat.Add(new co(ct.Prilozenie, c.Parameters));

                        sb.AppendLine("Application added");
                    }
                    break;

                case comt.Update:
                    {

                        if (c.Parameters.Length == 2)
                        {
                            
                        }
                        else
                        {
                            throw new FormatException("невалидни параметри!");
                        }




                        sb.AppendLine(String.Format("{0} items updated", contCat.UpdateContent(c.Parameters[0], c.Parameters[1]) - 1));
                    }
                    break;

                case comt.Find:
                    {
                        if (c.Parameters.Length != 2)
                        {
                            Console.WriteLine("Invalid params!");
                            throw new Exception("Invalid number of parameters!");
                        }



                        Int32 numberOfElementsToList = Int32.Parse(c.Parameters[1]);

                        IEnumerable<IContent> foundContent = contCat.GetListContent(c.Parameters[0], numberOfElementsToList);

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
    class ca : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public ca()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, Int32 numberOfContentElementsToList)
        {
            IEnumerable<IContent> contentToList = from c in this.title[title] select c;

            return contentToList.Take(numberOfContentElementsToList);
        }


        public Int32 UpdateContent(string old, string newUrl)
        {
            Int32 theElements = 0;

            List<IContent> contentToList = this.url[old].ToList();


            foreach (co content in contentToList)
            {
                this.title.Remove(content.Title, content);
                theElements++; //increase updatedElements
            }
            this.url.Remove(old);


            foreach (IContent content in contentToList)
            {
                content.URL = newUrl;
            }

            //again
            foreach (IContent content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return theElements;
        }
    }

    
    
    public class co : IComparable, IContent
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public Int64 Size { get; set; }

        private string url;

        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public ct Type { get; set; }

        public string TextRepresentation { get; set; }

        public co(ct type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)acpi.Title];
            this.Author = commandParams[(int)acpi.Author];
            this.Size = Int64.Parse(commandParams[(int)acpi.Size]);
            this.URL = commandParams[(int)acpi.Url];
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
                return 1;

            co otherContent = obj as co;
            if (otherContent != null)
            {
                Int32 comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }
            
            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}", this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;}}
    public class com : ICommand
    {
        readonly char[] paramsSeparators = { ';' };
        readonly char commandEnd = ':';

        public comt Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        private Int32 commandNameEndIndex;

        public com(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        public comt ParseCommandType(string commandName)
        {
            comt type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException();
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    {
                        type = comt.AddBook;
                    } break;

                case "Add movie":
                    {
                        type = comt.AddMovie;
                    } break;

                case "Add song ":
                    {
                        type = comt.AddSong;
                    } break;

                case "Add application":
                    {
                        type = comt.AddApplication;
                    } break;

                case "Update":
                    {
                        type = comt.Update;
                    } break;

                case "Find":
                    {
                        type = comt.Find;
                    } break;

                default:
                    {
                        if (commandName.ToLower().Contains("book")

                            || commandName.ToLower().Contains("movie")|| commandName.ToLower().Contains("song")
                            || commandName.ToLower().Contains("application"))throw new InsufficientExecutionStackException();

                        if (commandName.ToLower().Contains("find")
                            || commandName.ToLower().Contains("update"))
                            throw new InvalidProgramException();

                        throw new MissingFieldException("Invalid command name!");
                    }
            }

            return type;
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex);
            return name;
        }

        public string[] ParseParameters()
        {
            Int32 paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = parameters[i];
            }

            return parameters;
        }

        public Int32 GetCommandNameEndIndex()
        {
            Int32 endIndex = this.OriginalForm.IndexOf(commandEnd) - 1;

            return endIndex;
        }

        private void TrimParams()
        {
            for (int i = 0; ; i++)
            {
                if (!(i < this.Parameters.Length))
                {break;

                }
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        public override string ToString()
        {
            string toString = "" + this.Name + " ";

            foreach (string param in this.Parameters)
            {
                toString += param + " ";
            }return toString;
        }
    }
}
