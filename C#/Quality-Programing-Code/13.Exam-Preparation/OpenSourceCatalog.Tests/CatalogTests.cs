using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenSourceCatalog;
using System.Linq;
using System.Text;
using System.IO;
namespace OpenSourceCatalog.Tests
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        [TestCategory("AddToCatalog")]
        public void CatalogAddTest_SingleItem()
        {
            Catalog catalog = new Catalog();
            var item = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });


            catalog.Add(item);
            Assert.AreEqual(1, catalog.Count);
        }

        [TestMethod]
        [TestCategory("AddToCatalog")]
        public void CatalogAddTest_DuplicatedElements()
        {
            Catalog catalog = new Catalog();
            var item = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var item1 = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.introprogramming.info" });



            catalog.Add(item);
            catalog.Add(item);
            catalog.Add(item1);
            Assert.AreEqual(2, catalog.Count);
        }

        [TestMethod]
        [TestCategory("AddToCatalog")]
        public void CatalogAddTest_DuplidcatedElements()
        {
            Catalog catalog = new Catalog();
            var item = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var item1 = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var item2 = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var item3 = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var item4 = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C", "S.Nakov", "12763892", "http://www.introprogramming.info" });



            catalog.Add(item);
            catalog.Add(item);
            catalog.Add(item1);
            catalog.Add(item2);
            catalog.Add(item3);
            catalog.Add(item4);
            Assert.AreEqual(4, catalog.Count);
        }

        [TestMethod]
        [TestCategory("GetListContent")]
        public void CatalogGetTest_SingleElementMatch()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.introprogramming.info" });

            catalog.Add(bookCsharp);
            //catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            var matchingElements = catalog.GetListContent("Intro C#", 1);
            Assert.AreEqual(1, matchingElements.Count());
        }

        [TestMethod]
        [TestCategory("GetListContent")]
        public void CatalogGetTest_RequestedTenAndThreeElementsMatching()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.introprogramming.info" });

            catalog.Add(bookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            var matchingElements = catalog.GetListContent("Intro C#", 10);
            Assert.AreEqual(3, matchingElements.Count());
        }

        [TestMethod]
        [TestCategory("GetListContent")]
        public void CatalogGetTest_RequestedThreeAndThreeElementsMatching()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.introprogramming.info" });

            catalog.Add(bookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            var matchingElements = catalog.GetListContent("Intro C#", 3);
            Assert.AreEqual(3, matchingElements.Count());
        }

        [TestMethod]
        [TestCategory("GetListContent")]
        public void CatalogGetTest_RequestedTwoAndThreeElementsMatching()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.introprogramming.info" });

            catalog.Add(bookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            var matchingElements = catalog.GetListContent("Intro C#", 2);
            Assert.AreEqual(2, matchingElements.Count());
        }

        [TestMethod]
        [TestCategory("GetListContent")]
        public void CatalogGetTest_RequestedOneMatchingMissing()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.introprogramming.info" });

            catalog.Add(bookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            var matchingElements = catalog.GetListContent("Intro Javascript", 1);
            Assert.AreEqual(0, matchingElements.Count());
        }

        [TestMethod]
        [TestCategory("GetListContent")]
        public void CatalogGetTest_RequestedOnexagMissing()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "C.Nakov", "12763892", "http://www.introprogramming.info" });
            var otherbookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "B.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "A.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.introprogramming.info" });

            
            catalog.Add(bookPerl);
            catalog.Add(otherbookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            var matchingElements = catalog.GetListContent("Intro C#", 3);
            Assert.AreEqual(3, matchingElements.Count());

            string[] actual = 
            { 
               "Book: Intro C#; A.Nakov; 12763892; http://www.introprogramming.info",
               "Book: Intro C#; B.Nakov; 12763892; http://www.introprogramming.info",
               "Book: Intro C#; C.Nakov; 12763892; http://www.introprogramming.info"
                                                                                    };
            string[] expected = new string[3];
            
            var i=0;
            foreach (var item  in matchingElements)
            {
                expected[i] = item.ToString();
                i++;
            }
            
            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        [TestCategory("GetListContent")]
        public void CatalogGetTest_WithSetIn()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "C.Nakov", "12763892", "http://www.introprogramming.info" });
            var otherbookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "B.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "A.Nakov", "12763892", "http://www.introprogramming.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.introprogramming.info" });


            catalog.Add(bookPerl);
            catalog.Add(otherbookCsharp);
            catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            var matchingElements = catalog.GetListContent("Intro C#", 3);
            Assert.AreEqual(3, matchingElements.Count());

            string[] actual = 
            { 
               "Book: Intro C#; A.Nakov; 12763892; http://www.introprogramming.info",
               "Book: Intro C#; B.Nakov; 12763892; http://www.introprogramming.info",
               "Book: Intro C#; C.Nakov; 12763892; http://www.introprogramming.info"
                                                                                    };
            string[] expected = new string[3];

            var i = 0;
            foreach (var item in matchingElements)
            {
                expected[i] = item.ToString();
                i++;
            }

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        [TestCategory("UpdateContent")]
        public void CatalogUpdateContent_ThreeMatchingElements()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.csharp.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.java.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.perl.info" });

            catalog.Add(bookCsharp);
           // catalog.Add(bookCsharp);
          //  catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            var updated1 = catalog.UpdateContent("http://www.java.info", "http://www.csharp.info");
            var updated = catalog.UpdateContent("http://www.csharp.info", "http://telerikacademy.com");
            var updated2 = catalog.UpdateContent("http://www.perl.info", "http://telerikacademy.com");
            var updated3 = catalog.UpdateContent("http://telerikacademy.com", "http://telerik.com");

            Assert.AreEqual(3, updated3);
        }

        [TestMethod]
        [TestCategory("UpdateContent")]
        public void CatalogUpdateContent_OneMatchingAndFewNot()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.csharp.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.java.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.perl.info" });

            catalog.Add(bookCsharp);
            // catalog.Add(bookCsharp);
            //  catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            var updatedItems = catalog.UpdateContent("http://www.java.info", "http://www.csharp.info");


            Assert.AreEqual(1, updatedItems);
        }

        [TestMethod]
        [TestCategory("UpdateContent")]
        public void CatalogUpdateContent_NoMatching()
        {
            Catalog catalog = new Catalog();
            var bookCsharp = new ContentItem(ContentItemType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.csharp.info" });
            var bookJava = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Java", "S.Nakov", "12763892", "http://www.java.info" });
            var bookPerl = new ContentItem(ContentItemType.Book,
                new string[] { "Intro Perl", "S.Nakov", "12763892", "http://www.perl.info" });

            catalog.Add(bookCsharp);
            // catalog.Add(bookCsharp);
            //  catalog.Add(bookCsharp);
            catalog.Add(bookJava);
            catalog.Add(bookPerl);
            var updatedItems = catalog.UpdateContent("http://www.nomatching.info", "http://www.csharp.info");


            Assert.AreEqual(0, updatedItems);
        }

        [TestMethod]
        [TestCategory("UpdateContent")]
        public void CatalogUpdateContent_3000Items()
        {
            var add_count = 10;
            var update_const = 5;
            //Prepare input
            StringBuilder input = new StringBuilder();

            for (var i = 0; i < add_count; i++)
            {
                input.AppendLine("Add movie: mov; au; 42323723; http://movie.com");
            }
            for (var i = 0; i < add_count; i++)
            {
                input.AppendLine("Add song: song; au; 42323723; http://song.com");
            }

            input.AppendLine("Update: http://song.com; http://movie.com");

            for (var i = 0; i < update_const; i++)
            {
                input.AppendLine("Update: http://movie.com; http://othermovie.com");
                input.AppendLine("Update: http://othermovie.com; http://movie.com");
            }
            
            input.AppendLine("End");


            //Prepare output
            var expectedOutput = new StringBuilder();

            for (var i = 0; i < add_count; i++)
            {
                expectedOutput.AppendLine("Movie added");
            }

            for (var i = 0; i < add_count; i++)
            {
                expectedOutput.AppendLine("Song added");
            }
            expectedOutput.AppendLine(add_count+" items updated");

            for (var i = 0; i < 2*update_const; i++)
            {
                expectedOutput.AppendLine(2*add_count+" items updated");
            }
            
            //redirecting console 
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            OpenSourceCatalog.Program.Main();

            //Assert 
            string expected = expectedOutput.ToString();
            string actual = consoleOutput.ToString();
            Assert.AreEqual(expected, actual);
            
        }


    //[TestMethod]
    ////[Timeout(5000)]
    //public void TestUpdatePerformance()
    //{
    //    int addsCount = 6000;
    //    int updatesCount = 3000;       
    //    // Prepare the input commands 
    //    StringBuilder input = new StringBuilder();
    //    input.AppendLine("Add movie: mov; au; 42323723; http://movie.com");
    //    for (int i = 0; i < addsCount; i++)
    //    {
    //        input.AppendLine("Add application: app; a; 12345; http://oldurl");
    //    }
    //    input.AppendLine("Update: http://newmovie.com; http://othermovie.com");
    //    input.AppendLine("Update: http://movie.com; http://newmovie.com");
    //    input.AppendLine("Update: http://movie.com; http://newmovie.com");
    //    for (int i = 0; i < updatesCount; i++)
    //    {
    //        input.AppendLine("Update: http://oldurl; http://newurl");
    //        input.AppendLine("Update: http://newurl; http://oldurl");
    //    }
    //    input.AppendLine("Update: http://newurl; http://otherurl");
    //    input.AppendLine("Update: http://movie.com; http://newmovie.com");
    //    input.AppendLine("Update: http://newmovie.com; http://otherurl");
    //    input.AppendLine("End");

    //    // Prepare the expected result 
    //    StringBuilder expectedOutput = new StringBuilder();
    //    expectedOutput.AppendLine("Movie added");
    //    for (int i = 0; i < addsCount; i++)
    //    {
    //        expectedOutput.AppendLine("Application added");
    //    }
    //    expectedOutput.AppendLine("0 items updated");
    //    expectedOutput.AppendLine("1 items updated");
    //    expectedOutput.AppendLine("0 items updated");
    //    for (int i = 0; i < 2 * updatesCount; i++)
    //    {
    //        expectedOutput.AppendLine(addsCount + " items updated");
    //    }
    //    expectedOutput.AppendLine("0 items updated");
    //    expectedOutput.AppendLine("0 items updated");
    //    expectedOutput.AppendLine("1 items updated");

    //    // Redirect the console input / output and invoke the Main() method
    //    Console.SetIn(new StringReader(input.ToString()));
    //    StringWriter consoleOutput = new StringWriter();
    //    Console.SetOut(consoleOutput);
    //    OpenSourceCatalog.Program.Main();

    //    // Assert that the program execution result is correct
    //    string expected = expectedOutput.ToString();
    //    string actual = consoleOutput.ToString();
    //    Assert.AreEqual(expected, actual);
    //}


    }
}
