using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class TestIsOnePair
    {
        [TestMethod]
        public void IsOnePair_NoPairs()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.Eight,CardSuit.Spades),
                new Card(CardFace.Five,CardSuit.Hearts),
                new Card(CardFace.King,CardSuit.Clubs),
                new Card(CardFace.Ace,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsOnePair(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsOnePair_OnePairs()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Two,CardSuit.Spades),
                new Card(CardFace.Seven,CardSuit.Spades),
                new Card(CardFace.Seven,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsOnePair(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsOnePair_TwoPairs()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.Two,CardSuit.Spades),
                new Card(CardFace.Seven,CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsOnePair(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsOnePair_ThreeCardsFromSameFace()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Seven,CardSuit.Spades),
                new Card(CardFace.Two,CardSuit.Diamonds),
                new Card(CardFace.Seven,CardSuit.Clubs),
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsOnePair(hand);

            Assert.IsFalse(result);
        }
    }
}


