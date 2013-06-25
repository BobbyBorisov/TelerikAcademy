using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_4___Free_Content
{
    public class FreeContentGenerator
    {
        static string[] types =
	{
		"book", "movie", "song", "application"
	};

        static string[] titles =
	{
		"party", "exam", "C# course", "C# exam (again)", "PARTY", "Chalga party",
		"party Lora", "party Kiro", "Exam", "EXAM", "Party LORA", "Rock party"
	};

        static string[] authors =
	{
		"Baj Mangal", "Bate Bojko", "Baba Yaga", "Kiro", "Pepi", "Kiril Kirilov Kirilov",
		"Prakash Nilesh Katataharhsmaftar", "baba mi", "Kaka Mara", "Nakata Makata Fakata"
	};

        static string[] urls =
	{
		"http://energy-torrent.com/details.php?id=26980",
		"https://www.google.bg/webhp?sourceid=chrome-instant&ix=heb&ie=UTF-8&ion=1#sclient=psy-ab&hl=bg&safe=active&site=webhp&source=hp&q=%D0%A1%D0%B2%D0%B5%D1%82%D0%BB%D0%B8%D0%BD%20%D0%9D%D0%B0%D0%BA%D0%BE%D0%B2%20%E2%80%93%2020%20%D0%B3%D0%BE%D0%B4%D0%B8%D0%BD%D0%B8%20%D0%BF%D1%80%D0%B0%D0%BA%D1%82%D0%B8%D0%BA%D0%B0%20%D0%B2%20%D1%80%D0%B0%D0%B7%D1%80%D0%B0%D0%B1%D0%BE%D1%82%D0%BA%D0%B0%D1%82%D0%B0%20%D0%BD%D0%B0%20%D1%81%D0%BE%D1%84%D1%82%D1%83%D0%B5%D1%80&oq=&aq=&aqi=&aql=&gs_l=&pbx=1&fp=45669e7a7f451412&ix=heb&ion=1&bav=on.2,or.r_gc.r_pw.r_cp.,cf.osb&biw=1364&bih=677",
		"http://dreal.net/wiki/index.php/%D0%A1%D0%B2%D0%B5%D1%82%D0%BB%D0%B8%D0%BD_%D0%9D%D0%B0%D0%BA%D0%BE%D0%B2",
		"http://www.introprogramming.info/intro-csharp-book/read-online/glava6-cikli/",
		"http://www.nakov.com/blog/2012/03/19/pc-magazine-contest-finding-the-treasure-march-2012/",
		"http://vicove.com/statistic_list.php?type=vic&sort=random",
		"http://bira.freebg.eu/",
		"http://uroci.net/urok/2208/%D0%9A%D0%B0%D0%BA-%D0%B4%D0%B0-%D1%81%D1%82%D0%B0%D0%BD%D0%B0-%D1%85%D0%B0%D0%BA%D0%B5%D1%80/",
		"http://www.facebook.com/groups/197381707167/photos/",
		"http://bgcoder.com/Home/SubmissionLog",
		"http://www.flickr.com/photos/telerik-academy/sets/72157629582907243/"
	};

        static Random rnd = new Random();
        static List<string> commands = new List<string>();

        static void Main()
        {
            GenerateRandomFindCommands(10);
            GenerateRandomAddCommands(30000);
            GenerateInvalidFindCommands(8000);
            GenerateInvalidUpdateCommands(8000);
            GenerateRandomUpdateCommands(8000);
            GenerateRandomFindCommands(500);

            //DuplicateAllCommands();

            AppendEndCommand();

            PrintCommands();
        }

        private static void GenerateRandomAddCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateRandomAddCommand();
            }
        }

        private static void GenerateRandomAddCommand()
        {
            string type = GenerateRandomType();
            string title = GenerateRandomTitle();
            string author = GenerateRandomAuthor();
            long size = GenerateRandomSize();
            string url = GenerateRandomUrl();

            string cmd = String.Format(
                "Add {0}: {1}; {2}; {3}; {4}",
                type, title, author, size, url);

            commands.Add(cmd);
        }

        private static string GenerateRandomUrl()
        {
            string url = urls[rnd.Next(urls.Length)];
            if (rnd.Next(3) == 0)
            {
                url += " - " + rnd.Next(1000000);
            }
            return url;
        }

        private static string GenerateRandomAuthor()
        {
            string author = authors[rnd.Next(authors.Length)];
            if (rnd.Next(3) == 0)
            {
                author += " - " + rnd.Next(1000000);
            }
            return author;
        }

        private static string GenerateRandomType()
        {
            string type = types[rnd.Next(types.Length)];
            return type;
        }

        private static long GenerateRandomSize()
        {
            long size = rnd.Next(10000);
            size = size * rnd.Next(1000000) * 10000;
            size = 1 + (size % 10000000000);
            return size;
        }

        private static string GenerateRandomTitle()
        {
            string title = titles[rnd.Next(titles.Length)];
            if (rnd.Next(3) == 0)
            {
                title += " - " + rnd.Next(1000000);
            }
            return title;
        }

        private static void DuplicateAllCommands()
        {
            commands.AddRange(commands);
        }

        private static void GenerateRandomUpdateCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateRandomUpdateCommand();
            }
        }

        private static void GenerateRandomUpdateCommand()
        {
            string oldUrl = GenerateRandomUrl();
            string newUrl = GenerateRandomUrl();
            string cmd = "Update: " + oldUrl + "; " + newUrl;
            commands.Add(cmd);
        }

        private static void GenerateInvalidUpdateCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateInvalidUpdateCommand();
            }
        }

        private static void GenerateInvalidUpdateCommand()
        {
            string oldUrl = GenerateRandomUrl() + rnd.Next(1000000, 5000000);
            string newUrl = GenerateRandomUrl();
            string cmd = "Update: " + oldUrl + "; " + newUrl;
            commands.Add(cmd);
        }

        private static void GenerateRandomFindCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateRandomFindCommand();
            }
        }

        private static void GenerateRandomFindCommand()
        {
            string title = GenerateRandomTitle();
            int count = rnd.Next(1, 10);
            string cmdFormat = "Find: {0}; {1}";
            string cmd = String.Format(cmdFormat, title, count);
            commands.Add(cmd);
        }

        private static void GenerateInvalidFindCommands(int count)
        {
            for (int i = 0; i < count; i++)
            {
                GenerateInvalidFindCommand();
            }
        }

        private static void GenerateInvalidFindCommand()
        {
            string title = GenerateRandomTitle() + DateTime.Now.Ticks;
            int count = rnd.Next(1, 100);
            string cmdFormat = "Find: {0}; {1}";
            string cmd = String.Format(cmdFormat, title, count);
            commands.Add(cmd);
        }

        private static void AppendEndCommand()
        {
            commands.Add("End");
        }

        private static void PrintCommands()
        {
            foreach (var cmd in commands)
            {
                Console.WriteLine(cmd);
            }
        }
    }
}
