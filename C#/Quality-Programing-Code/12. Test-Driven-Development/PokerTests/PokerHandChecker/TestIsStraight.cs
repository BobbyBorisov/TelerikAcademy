using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class TestIsStraight
    {
        [TestMethod]
        public void IsStraight_ProperStraightNotShuffled()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two,CardSuit.Diamonds),
                new Card(CardFace.Three,CardSuit.Spades),
                new Card(CardFace.Four,CardSuit.Hearts),
                new Card(CardFace.Five,CardSuit.Clubs),
                new Card(CardFace.Six,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsStraight(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStraight_OneCardMissingForStraight()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two,CardSuit.Diamonds),
                new Card(CardFace.Three,CardSuit.Spades),
                new Card(CardFace.Four,CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Clubs),
                new Card(CardFace.Six,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsStraight(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStraight_FromSevenToJackShuffled()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Spades),
                new Card(CardFace.Jack,CardSuit.Hearts),
                new Card(CardFace.Nine,CardSuit.Clubs),
                new Card(CardFace.Ten,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsStraight(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsStraight_FiveDifferentCards()
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

            bool result = pokerChecker.IsStraight(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsStraight_WithStraightFlushCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ten,CardSuit.Diamonds),
                new Card(CardFace.Jack,CardSuit.Diamonds),
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Diamonds),
                new Card(CardFace.Ace,CardSuit.Diamonds),
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsStraight(hand);

            Assert.IsFalse(result);
        }

        
    }
}
