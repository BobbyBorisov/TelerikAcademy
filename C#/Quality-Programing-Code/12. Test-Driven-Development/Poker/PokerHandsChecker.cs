namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            var cardsCollection = hand.Cards.GroupBy(x => new { x.Face, x.Suit });

            if (cardsCollection.Distinct().Count() != 5)
            {
                throw new ArgumentException("not a valid poker hand:" + hand);
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            return hand.HasOnlyOneSuit() && hand.AreInSequence();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            return this.IsValidHand(hand) &&
                   hand.HasXOfKind(4);
        }

        public bool IsFullHouse(IHand hand)
        {
            return this.IsValidHand(hand) &&
                   hand.HasXOfKind(3) && 
                   hand.HasXOfKind(2);
        }

        public bool IsFlush(IHand hand)
        {
            return this.IsValidHand(hand) &&
                   hand.HasOnlyOneSuit();
        }

        public bool IsStraight(IHand hand)
        {
            return this.IsValidHand(hand) &&
                   hand.AreInSequence() &&
                   !hand.HasOnlyOneSuit();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            return this.IsValidHand(hand) &&
                   hand.HasXOfKind(3) &&
                   !hand.HasXOfKind(2);
        }

        public bool IsTwoPair(IHand hand)
        {
            return this.IsValidHand(hand) &&
                   hand.TimesOfKind(2) == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            return this.IsValidHand(hand) &&
                   hand.TimesOfKind(2) == 1 &&
                   !hand.HasXOfKind(3);
        }

        public bool IsHighCard(IHand hand)
        {
            return this.IsValidHand(hand) &&
                   !hand.HasXOfKind(2) &&
                   !hand.HasXOfKind(3) &&
                   !hand.HasXOfKind(4) &&
                   !hand.HasOnlyOneSuit() &&
                   !hand.AreInSequence();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
