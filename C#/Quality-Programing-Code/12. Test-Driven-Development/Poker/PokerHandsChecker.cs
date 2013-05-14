using System;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
     
        public bool IsValidHand(IHand hand)
        {
            var cardsCollection = hand.Cards.GroupBy(x => new { x.Face, x.Suit });

            bool result = false;

            if (cardsCollection.Distinct().Count()==5)
            {
                result = true;
            }

            return result;
        }

        public bool IsStraightFlush(IHand hand)
        {
            var cardsCollection = hand.Cards
                .OrderBy(x => (int)x.Face)
                .ToList();

            bool isFlush = false;
            bool isStraight = true;

            for (int i = 1; i < cardsCollection.Count(); i++)
            {
                if ((int)cardsCollection[i - 1].Face + 1 != (int)cardsCollection[i].Face)
                {
                    isStraight = false;
                    break;
                }
            }

            var sortedbySuit = cardsCollection
                .GroupBy(x => x.Suit);
            if (sortedbySuit.Count() == 1)
            {
                isFlush = true;
            }

            

            bool result = isFlush && isStraight && IsValidHand(hand);

            return result;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var cardsCollection = hand.Cards.GroupBy(x => x.Face)
                      .Where(g => g.Count() == 4);

            bool result = false;

            if (cardsCollection.Count() == 1 && IsValidHand(hand))
            {
                result = true;
            }

            return result;
        }

        public bool IsFullHouse(IHand hand)
        {
            
            var cardsCollection = hand.Cards
                      .GroupBy(x => x.Face)
                      .Where(g => g.Count() == 3 || g.Distinct().Count() == 2);
            var twopairsCardsList = hand.Cards.GroupBy(x => x.Face)
                      .Where(g => g.Count() == 2);

            bool result = false;

            if (twopairsCardsList.Count() != 2 && cardsCollection.Count() == 2 && IsValidHand(hand))
            {
                result = true;
            }

            return result;
        }

        public bool IsFlush(IHand hand)
        {
            
            var cardsCollection = hand.Cards.GroupBy(x => x.Suit );

            bool result = false;

            if (cardsCollection.Count() == 1 && IsValidHand(hand))
            {
                result = true;
            }

            return result;
        }

        public bool IsStraight(IHand hand)
        {
            if (this.IsStraightFlush(hand)) 
            {
                return false;
            }

                var sortedCards = hand.Cards
                    .OrderBy(c => (int)c.Face)
                    .ToList();

                bool result = true;

                for(int i=1; i < sortedCards.Count();i++)
                {
                    if ((int)sortedCards[i-1].Face + 1 != (int)sortedCards[i].Face) 
                    {
                        result = false;
                        break;
                    }
                }
                return result;
        }

        public bool IsThreeOfAKind(IHand hand)
        {

            var cardsCollection = hand.Cards.GroupBy(x => x.Face)
                      .Where(g => g.Count() == 3 || g.Count() == 2);

            bool result = false;

            if (cardsCollection.Count() == 1 && IsValidHand(hand))
            {
                result = true;
            }

            return result;

        }

        public bool IsTwoPair(IHand hand)
        {
            var cardsCollection = hand.Cards.GroupBy(x => x.Face)
                      .Where(g => g.Count() == 2);

            bool result = false;

            if (cardsCollection.Count() == 2 && IsValidHand(hand))
            {
                result = true;
            }

            return result;
        }

        public bool IsOnePair(IHand hand)
        {
            var cardsCollection = hand.Cards.GroupBy(x => x.Face)
                      .Where(g => g.Count() == 2);

            bool result = false;

            if (cardsCollection.Count()==1 && IsValidHand(hand))
            {
                result = true;
            }

            return result;

        }

        public bool IsHighCard(IHand hand)
        {
            bool result = false;
            if(!IsStraightFlush(hand) && !IsFourOfAKind(hand) && !IsFullHouse(hand) && !IsFlush(hand)
                && !IsStraight(hand) && !IsThreeOfAKind(hand) && !IsTwoPair(hand) && !IsOnePair(hand)
                && IsValidHand(hand))
            {
                result = true;
            }
            return result;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
