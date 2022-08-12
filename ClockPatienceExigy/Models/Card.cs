using ClockPatienceExigy.Helpers;

namespace ClockPatienceExigy.Models
{
    public class Card
    {
        public bool Flipped { get; set; } = false;
        public int Rank { get; set; }
        public int Suit { get; set; }


        public Card(char Rank, char Suit, bool Flipped = false)
        {
            this.Rank = CardHelper.GetRankInt(Rank);
            this.Suit = CardHelper.GetSuitInt(Suit);
            this.Flipped = Flipped;
        }

        public Card(int Rank, int Suit, bool Flipped = false)
        {
            this.Rank = Rank;
            this.Suit = Suit;
            this.Flipped = Flipped;
        }

    }
}
