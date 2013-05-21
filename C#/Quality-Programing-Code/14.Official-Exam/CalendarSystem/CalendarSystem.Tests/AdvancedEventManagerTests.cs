qqqqqqqqusing System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;
using System.Linq;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class AdvancedEventManagerTests
    {
        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void AddNoEvent()
        {
            var eventManager = new AdvancedEventManager();

            Assert.AreEqual(0, eventManager.Count);
        }

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void AddSingleEvent()
        {
            var eventManager = new AdvancedEventManager();

            var eventItem = new Event("Drink beer","The Pope",DateTime.Now.AddHours(2));

            eventManager.AddEvent(eventItem);

            Assert.AreEqual(1, eventManager.Count);
        }

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void AddMultipleEventsNoDuplicates()
        {
            var eventManager = new AdvancedEventManager();

            var drinkBeer = new Event("Drink beer", "The Pope", DateTime.Now.AddHours(2));
            var drinkVodka = new Event("Drink vodka", "The Pope", DateTime.Now.AddHours(2));
            var drinkWater = new Event("Drink water", "The Pope", DateTime.Now.AddHours(2));
            var drinkUzo = new Event("Drink uzo", "The Pope", DateTime.Now.AddHours(2));
            var drinkWhisky = new Event("Drink whisky", "The Pope", DateTime.Now.AddHours(2));

            eventManager.AddEvent(drinkBeer);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkWater);
            eventManager.AddEvent(drinkUzo);
            eventManager.AddEvent(drinkWhisky);

            Assert.AreEqual(5, eventManager.Count);
        }

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void AddMultipleEventsWithDuplicates()
        {
            var eventManager = new AdvancedEventManager();

            var drinkBeer = new Event("Drink beer", "The Pope", DateTime.Now.AddHours(2));
            var drinkVodka = new Event("Drink vodka", "The Pope", DateTime.Now.AddHours(2));
            var drinkWater = new Event("Drink water", "The Pope", DateTime.Now.AddHours(2));
            var drinkUzo = new Event("Drink uzo", "The Pope", DateTime.Now.AddHours(2));
            var drinkWhisky = new Event("Drink whisky", "The Pope", DateTime.Now.AddHours(2));

            //Duplicates are acceptable
            eventManager.AddEvent(drinkBeer);

            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkVodka);

            eventManager.AddEvent(drinkWater);

            eventManager.AddEvent(drinkUzo);

            eventManager.AddEvent(drinkWhisky);
            eventManager.AddEvent(drinkWhisky);

            //checks non duplicated elements
            Assert.AreEqual(5, eventManager.Count);
        }

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteNoExistingEventFromNonEmptyList()
        {
            var eventManager = new AdvancedEventManager();

            var drinkBeer = new Event("Drink beer", "The Pope", DateTime.Now.AddHours(2));
            var drinkVodka = new Event("Drink vodka", "The Pope", DateTime.Now.AddHours(2));
            var drinkWater = new Event("Drink water", "The Pope", DateTime.Now.AddHours(2));
            var drinkUzo = new Event("Drink uzo", "The Pope", DateTime.Now.AddHours(2));
            var drinkWhisky = new Event("Drink whisky", "The Pope", DateTime.Now.AddHours(2));

            eventManager.AddEvent(drinkBeer);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkWater);
            eventManager.AddEvent(drinkUzo);
            eventManager.AddEvent(drinkWhisky);

            var deletedEvents = eventManager.DeleteEventsByTitle("Drink wine");

            Assert.AreEqual(0, deletedEvents);
        }

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteNoExistingEventFromEmptyList()
        {
            var eventManager = new AdvancedEventManager();

            var deletedEvents = eventManager.DeleteEventsByTitle("Drink wine");

            Assert.AreEqual(0, deletedEvents);
        }

        //[TestMethod]
        //[TestCategory("AdvancedEventManagerTest")]
        //public void DeleteSeveralExistingEventsWithNoDuplicates()
        //{
        //    var eventManager = new AdvancedEventManager();

        //    var drinkBeer = new Event("Drink beer", "The Pope", DateTime.Now.AddHours(2));
        //    var drinkVodka = new Event("Drink vodka", "The Pope", DateTime.Now.AddHours(2));
        //    var drinkWater = new Event("Drink water", "The Pope", DateTime.Now.AddHours(2));
        //    var drinkUzo = new Event("Drink uzo", "The Pope", DateTime.Now.AddHours(2));
        //    var drinkWhisky = new Event("Drink whisky", "The Pope", DateTime.Now.AddHours(2));

        //    eventManager.AddEvent(drinkBeer);
        //    eventManager.AddEvent(drinkVodka);
        //    eventManager.AddEvent(drinkWater);
        //    eventManager.AddEvent(drinkUzo);
        //    eventManager.AddEvent(drinkWhisky);

        //    eventManager.DeleteEventsByTitle("Drink water");
        //    eventManager.DeleteEventsByTitle("Drink whisky");

        //    Assert.AreEqual(3, eventManager.Count);

        //}

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void DeleteSeveralExistingEventsAndCheckListCount()
        {
            var eventManager = new AdvancedEventManager();

            var drinkBeer = new Event("Drink beer", "The Pope", DateTime.Now.AddHours(2));
            var drinkVodka = new Event("Drink vodka", "The Pope", DateTime.Now.AddHours(2));
            var drinkWater = new Event("Drink water", "The Pope", DateTime.Now.AddHours(2));
            var drinkUzo = new Event("Drink uzo", "The Pope", DateTime.Now.AddHours(2));
            var drinkWhisky = new Event("Drink whisky", "The Pope", DateTime.Now.AddHours(2));

            eventManager.AddEvent(drinkBeer);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkWater);
            eventManager.AddEvent(drinkUzo);
            eventManager.AddEvent(drinkWhisky);

            eventManager.DeleteEventsByTitle("Drink water");
            
            eventManager.DeleteEventsByTitle("Drink whisky");

            //3 elements left after deletion
            Assert.AreEqual(3, eventManager.Count);
            
        }
        
        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void DeleteEventWithThreeDuplicates()
        {
            var eventManager = new AdvancedEventManager();

            var drinkBeer = new Event("Drink beer", "The Pope", DateTime.Now.AddHours(2));
            var drinkVodka = new Event("Drink vodka", "The Pope", DateTime.Now.AddHours(2));
            var drinkWater = new Event("Drink water", "The Pope", DateTime.Now.AddHours(2));
            var drinkUzo = new Event("Drink uzo", "The Pope", DateTime.Now.AddHours(2));
            var drinkWhisky = new Event("Drink whisky", "The Pope", DateTime.Now.AddHours(2));

            eventManager.AddEvent(drinkBeer);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkWater);
            eventManager.AddEvent(drinkUzo);
            eventManager.AddEvent(drinkWhisky);

            //deletes 3 event with title "drink vodka"
            var deletedEvents = eventManager.DeleteEventsByTitle("Drink vodka");
            Assert.AreEqual(3, deletedEvents);
        }

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void DeleteTwoEventWithDuplicates()
        {
            var eventManager = new AdvancedEventManager();

            var drinkBeer = new Event("Drink beer", "The Pope", DateTime.Now.AddHours(2));
            var drinkVodka = new Event("Drink vodka", "The Pope", DateTime.Now.AddHours(2));
            var drinkWater = new Event("Drink water", "The Pope", DateTime.Now.AddHours(2));
            var drinkUzo = new Event("Drink uzo", "The Pope", DateTime.Now.AddHours(2));
            var drinkWhisky = new Event("Drink whisky", "The Pope", DateTime.Now.AddHours(2));

            eventManager.AddEvent(drinkBeer);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkWater);
            eventManager.AddEvent(drinkUzo);
            eventManager.AddEvent(drinkWhisky);
            eventManager.AddEvent(drinkWhisky);
            eventManager.AddEvent(drinkWhisky);

            //deletes 3 event with title "drink vodka" and checks what left
            eventManager.DeleteEventsByTitle("Drink vodka");
            eventManager.DeleteEventsByTitle("Drink whisky");
            Assert.AreEqual(3, eventManager.Count);
        }

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void ListSingleEventRequestedTen()
        {
            var eventManager = new AdvancedEventManager();
            DateTime date = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime anotherDate = new DateTime(2010, 3, 1, 7, 0, 0);

            var drinkBeer = new Event("Drink beer", "The Pope", date);
            var drinkVodka = new Event("Drink vodka", "The Pope", anotherDate);
            var drinkWater = new Event("Drink water", "The Pope", anotherDate);
            var drinkUzo = new Event("Drink uzo", "The Pope", anotherDate);
            var drinkWhisky = new Event("Drink whisky", "The Pope", anotherDate);

            eventManager.AddEvent(drinkBeer);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkWater);
            eventManager.AddEvent(drinkUzo);
            eventManager.AddEvent(drinkWhisky);

            var matchingEvents = eventManager.ListEvents(date, 10);
            Assert.AreEqual(1, matchingEvents.Count());
        }

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void ListMultipleEventWithSameDateRequestenTen()
        {
            var eventManager = new AdvancedEventManager();
            DateTime date = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime anotherDate = new DateTime(2010, 3, 1, 7, 0, 0);

            var drinkBeer = new Event("Drink beer", "The Pope", date);
            var drinkVodka = new Event("Drink vodka", "The Pope", anotherDate);
            var drinkWater = new Event("Drink water", "The Pope", anotherDate);
            var drinkUzo = new Event("Drink uzo", "The Pope", anotherDate);
            var drinkWhisky = new Event("Drink whisky", "The Pope", anotherDate);

            eventManager.AddEvent(drinkBeer);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkWater);
            eventManager.AddEvent(drinkUzo);
            eventManager.AddEvent(drinkWhisky);

            var matchingEvents = eventManager.ListEvents(anotherDate, 10);
            Assert.AreEqual(4, matchingEvents.Count());
        }

        [TestMethod]
        [TestCategory("AdvancedEventManagerTest")]
        public void ListMultipleEventWithSameDateLessThanActualCount()
        {
            var eventManager = new AdvancedEventManager();
            DateTime date = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime anotherDate = new DateTime(2010, 3, 1, 7, 0, 0);

            var drinkBeer = new Event("Drink beer", "The Pope", date);
            var drinkVodka = new Event("Drink vodka", "The Pope", anotherDate);
            var drinkWater = new Event("Drink water", "The Pope", anotherDate);
            var drinkUzo = new Event("Drink uzo", "The Pope", anotherDate);
            var drinkWhisky = new Event("Drink whisky", "The Pope", anotherDate);

            eventManager.AddEvent(drinkBeer);
            eventManager.AddEvent(drinkVodka);
            eventManager.AddEvent(drinkWater);
            eventManager.AddEvent(drinkUzo);
            eventManager.AddEvent(drinkWhisky);

            var matchingEvents = eventManager.ListEvents(anotherDate, 2);
            Assert.AreEqual(2, matchingEvents.Count());
        }


    }
}
