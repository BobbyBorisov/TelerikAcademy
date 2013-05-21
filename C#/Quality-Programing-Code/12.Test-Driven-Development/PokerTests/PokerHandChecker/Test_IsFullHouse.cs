using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class Test_IsFullHouse
    {
        [TestMethod]
        public void IsFullHouse_FourOfaKind()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.Seven,CardSuit.Spades),
                new Card(CardFace.Seven,CardSuit.Hearts),
                new Card(CardFace.Seven,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFullHouse(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFullHouse_ThreeOfAKindAnd2DifferentCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.Two,CardSuit.Spades),
                new Card(CardFace.Seven,CardSuit.Hearts),
                new Card(CardFace.Seven,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFullHouse(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFullHouse_ProperFullHouseHand()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.Seven,CardSuit.Spades),
                new Card(CardFace.Seven,CardSuit.Hearts),
                new Card(CardFace.Four,CardSuit.Clubs),
                new Card(CardFace.Four,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFullHouse(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFullHouse_WithTwoPairs()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.Three,CardSuit.Diamonds),
                new Card(CardFace.Queen,CardSuit.Diamonds),
                new Card(CardFace.Queen,CardSuit.Spades),
                new Card(CardFace.Three,CardSuit.Clubs),
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFullHouse(hand);

            Assert.IsFalse(result);
        }






    }
}
