using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class TestIsThreeOfaKind
    {
        [TestMethod]
        public void ThreeOfaKind_FourSameFaceCards()
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

            bool result = pokerChecker.IsThreeOfAKind(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ThreeOfaKind_ThreeSameFaceCards()
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

            bool result = pokerChecker.IsThreeOfAKind(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ThreeOfaKind_FullHouseHand()
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

            bool result = pokerChecker.IsThreeOfAKind(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ThreeOfaKind_FiveDifferentCards()
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

            bool result = pokerChecker.IsThreeOfAKind(hand);

            Assert.IsFalse(result);
        }

    }
}
