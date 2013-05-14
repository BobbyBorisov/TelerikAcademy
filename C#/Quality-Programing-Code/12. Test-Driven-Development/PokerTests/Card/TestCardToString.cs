using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Test
{
    [TestClass]
    public class TestCardToString
    {
        [TestMethod]
        public void CardToStringOfSevenDiamonds()
        {
            Card card = new Card(CardFace.Seven, CardSuit.Diamonds);
            string result = card.ToString();
            Assert.AreEqual("7♦", result);
        }

        [TestMethod]
        public void CardToStringOfAceHeart()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Hearts);
            string result = card.ToString();
            Assert.AreEqual("A♥", result);
        }

        [TestMethod]
        public void CardToStringOfKingSpades()
        {
            Card card = new Card(CardFace.King, CardSuit.Spades);
            string result = card.ToString();
            Assert.AreEqual("K♠", result);   
        }

        [TestMethod]
        public void CardToStringOfQueenSpades()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Clubs);
            string result = card.ToString();
            Assert.AreEqual("Q♣", result);
        }
    }
}
