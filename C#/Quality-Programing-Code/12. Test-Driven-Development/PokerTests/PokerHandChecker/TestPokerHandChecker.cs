using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class TestPokerHandChecker
    {
        [TestMethod]
        public void IsValidHand_DifferentCards()
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

            bool result = pokerChecker.IsValidHand(hand);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsValidHand_OneRepeatingCard()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Spades),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Two,CardSuit.Clubs),
                new Card(CardFace.Seven,CardSuit.Diamonds),
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsValidHand(hand);

            Assert.IsFalse(result);
        }


       


    }
}
