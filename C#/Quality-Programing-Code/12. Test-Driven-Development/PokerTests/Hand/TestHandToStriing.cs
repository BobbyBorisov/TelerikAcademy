using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Test
{
    [TestClass]
    public class TestHandToString
    {
        [TestMethod]
        public void HandToStringOfOneCard()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds)
            });
            string result = hand.ToString();
            Assert.AreEqual("7♦", result);
        }

        [TestMethod]
        public void HandToStringOfFiveCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven,CardSuit.Diamonds),
                new Card(CardFace.King,CardSuit.Spades),
                new Card(CardFace.Queen,CardSuit.Hearts),
                new Card(CardFace.Two,CardSuit.Clubs),
                new Card(CardFace.Five,CardSuit.Hearts)
            });
            string result = hand.ToString();
            Assert.AreEqual("7♦ K♠ Q♥ 2♣ 5♥", result);
        }

        [TestMethod]
        public void HandToStringOfNoCards()
        {
            var hand = new Hand(new List<ICard>()
            {
                
            });
            string result = hand.ToString();
            Assert.AreEqual(string.Empty, result);
        }

        
    }
}
