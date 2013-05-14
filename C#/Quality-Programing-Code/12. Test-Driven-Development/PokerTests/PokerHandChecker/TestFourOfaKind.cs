using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class TestFourOfaKind
    {
        [TestMethod]
        public void FourOfaKind_FourSevenCards()
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

            bool result = pokerChecker.IsFourOfAKind(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FourOfaKind_ThreeSevenCards()
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

            bool result = pokerChecker.IsFourOfAKind(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FourOfaKind_TwoSevenCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.Two,CardSuit.Spades),
                new Card(CardFace.Seven,CardSuit.Hearts),
                new Card(CardFace.Eight,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Hearts)
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFourOfAKind(hand);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FourOfaKind_DifferentCards()
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

            bool result = pokerChecker.IsFourOfAKind(hand);

            Assert.IsFalse(result);
        }

    }
}
