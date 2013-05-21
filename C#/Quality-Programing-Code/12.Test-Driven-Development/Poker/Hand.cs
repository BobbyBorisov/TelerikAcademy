namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var card in this.Cards) 
            {
                sb.Append(card.ToString() + " ");
            }

            return sb.ToString().Trim();
        }
    }
}
