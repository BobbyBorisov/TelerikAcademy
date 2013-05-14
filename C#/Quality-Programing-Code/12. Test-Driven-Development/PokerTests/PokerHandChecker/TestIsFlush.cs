using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class TestIsFlush
    {
        [TestMethod]
        public void IsFlush_DifferentSuitCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Spades),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Two,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFlush(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFlush_FiveSameSuitCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.Two,CardSuit.Diamonds),
                new Card(CardFace.Six,CardSuit.Diamonds),
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFlush(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFlush_WithInvalidHand()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.Six,CardSuit.Diamonds),
                new Card(CardFace.Six,CardSuit.Diamonds),
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFlush(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFlush_FourSameSuitCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.Two,CardSuit.Diamonds),
                new Card(CardFace.Three,CardSuit.Clubs),
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFlush(hand);

            Assert.IsFalse(result);
        }






    }
}
