using System;
using System.Text;

namespace Poker
{
    public class Card : ICard, IEquatable<Card>
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public bool Equals(Card other)
        {

            //Check whether the compared object is null. 
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data. 
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the cards' properties are equal. 
            return Face.Equals(other.Face) && Suit.Equals(other.Suit);
        }

        // If Equals() returns true for a pair of objects  
        // then GetHashCode() must return the same value for these objects. 

        public override int GetHashCode()
        {

            //Get hash code for the Suit field if it is not null. 
            int hashCardSuit = Suit == null ? 0 : Suit.GetHashCode();

            //Get hash code for the Face field. 
            int hashCardFace = Face.GetHashCode();

            //Calculate the hash code for the product. 
            return hashCardSuit ^ hashCardFace;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            switch (Face)
            {
                case CardFace.Two:
                    sb.Append("2");
                    break;
                case CardFace.Three:
                    sb.Append("3");
                    break;
                case CardFace.Four:
                    sb.Append("4");
                    break;
                case CardFace.Five:
                    sb.Append("5");
                    break;
                case CardFace.Six:
                    sb.Append("6");
                    break;
                case CardFace.Seven:
                    sb.Append("7");
                    break;
                case CardFace.Eight:
                    sb.Append("8");
                    break;
                case CardFace.Nine:
                    sb.Append("9");
                    break;
                case CardFace.Ten:
                    sb.Append("10");
                    break;
                case CardFace.Jack:
                    sb.Append("J");
                    break;
                case CardFace.Queen:
                    sb.Append("Q");
                    break;
                case CardFace.King:
                    sb.Append("K");
                    break;
                case CardFace.Ace:
                    sb.Append("A");
                    break;
                default:
                    break;
            }

            switch (Suit)
            {
                case CardSuit.Clubs:
                    sb.Append("♣");
                    break;
                case CardSuit.Diamonds:
                    sb.Append("♦");
                    break;
                case CardSuit.Hearts:
                    sb.Append("♥");
                    break;
                case CardSuit.Spades:
                    sb.Append("♠");
                    break;
                default:
                    break;
            }


            return sb.ToString();
        }
    }
}
