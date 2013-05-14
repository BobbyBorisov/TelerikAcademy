namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MainProgram
    {
        public static void Main() 
        {
            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
            });

            var pokerChecker = new PokerHandsChecker();

            bool result = pokerChecker.IsFullHouse(hand);
        }
    }
}
