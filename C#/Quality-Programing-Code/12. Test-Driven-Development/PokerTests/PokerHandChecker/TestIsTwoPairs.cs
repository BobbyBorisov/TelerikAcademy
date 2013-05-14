using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class TestIsTwoPairs
    {
        [TestMethod]
        public void IsTwoPairs_NoPairs()
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

            bool result = pokerChecker.IsTwoPair(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTwoPairs_OnePairOfCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace,CardSuit.Diamonds),
                new Card(CardFace.Two,CardSuit.Spades),
                new Card(CardFace.Seven,CardSuit.Hearts),
                new Card(CardFace.Seven,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsTwoPair(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTwoPairs_ThreeSameFaceCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.Two,CardSuit.Spades),
                new Card(CardFace.Five,CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsTwoPair(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTwoPairs_TwoPairs()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Seven,CardSuit.Spades),
                new Card(CardFace.Two,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Clubs),
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsTwoPair(hand);

            Assert.IsTrue(result);
        }
    }
}


