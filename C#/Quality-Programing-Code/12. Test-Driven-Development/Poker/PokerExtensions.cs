namespace Poker
{
    using System;
    using System.Linq;

    internal static class PokerExtensions
    {
        public static bool HasXOfKind(this IHand hand, int x)
        {
            return hand.Cards.GroupBy(c => c.Face).Any(g => g.Count() == x);
        }

        public static int TimesOfKind(this IHand hand, int x) 
        {
            return hand.Cards.GroupBy(c => c.Face).Where(g => g.Count() == x).Count();
        }

        public static bool HasOnlyOneSuit(this IHand hand) 
        {
            return hand.Cards.GroupBy(x => x.Suit).Count() == 1;
        }

        public static bool AreInSequence(this IHand hand) 
        {
            var sortedCards = hand.Cards
                .OrderBy(x => (int)x.Face)
                .ToList();
            
            bool result = true;

            for (int i = 1; i < sortedCards.Count(); i++)
            {
                if ((int)sortedCards[i - 1].Face + 1 != (int)sortedCards[i].Face)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
