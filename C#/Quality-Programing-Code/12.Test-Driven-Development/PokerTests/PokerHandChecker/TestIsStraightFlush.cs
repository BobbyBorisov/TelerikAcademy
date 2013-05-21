using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class TestIsStraightFlush
    {
        [TestMethod]
        public void IsStraightFlush_ProperStraightFlushNotShuffled()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two,CardSuit.Diamonds),
                new Card(CardFace.Three,CardSuit.Diamonds),
                new Card(CardFace.Four,CardSuit.Diamonds),
                new Card(CardFace.Five,CardSuit.Diamonds),
                new Card(CardFace.Six,CardSuit.Diamonds)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsStraightFlush(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStraightFlush_OneCardMissingForStraight()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two,CardSuit.Diamonds),
                new Card(CardFace.Three,CardSuit.Diamonds),
                new Card(CardFace.Four,CardSuit.Diamonds),
                new Card(CardFace.Eight,CardSuit.Diamonds),
                new Card(CardFace.Six,CardSuit.Diamonds)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsStraightFlush(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStraightFlush_ProperSFFromNineToJackShuffled()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Queen,CardSuit.Spades),
                new Card(CardFace.King,CardSuit.Spades),
                new Card(CardFace.Jack,CardSuit.Spades),
                new Card(CardFace.Nine,CardSuit.Spades),
                new Card(CardFace.Ten,CardSuit.Spades)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsStraightFlush(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStraightFlush_FiveDifferentCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Spades),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsStraightFlush(hand);

            Assert.IsFalse(result);
        }
    }
}
