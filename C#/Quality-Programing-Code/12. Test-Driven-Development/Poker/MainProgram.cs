using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class MainProgram
    {
        static void Main() 
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


            
        }
    }
}
