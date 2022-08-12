using ClockPatienceExigy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClockPatienceExigy.Helpers
{
    public static class CardHelper
    {
        #region Extension Methods of Card
        public static char GetRankChar(this Card card)
        {
            return GetRankChar(card.Rank);
        }
        public static char GetSuitChar(this Card card)
        {
            return GetSuitChar(card.Suit);
        }
        #endregion

        #region Additional Card Methods

        #region Rank
        public static char GetRankChar(int s)
        {
            if (s < 1 && s > 13) throw new Exception($"Not valid Rank {s}");
            return s switch
            {
                10 => 'T',
                11 => 'J',
                12 => 'Q',
                13 => 'K',
                1 => 'A',
                _ => Convert.ToChar(s + 48),
            };
        }
        public static int GetRankInt(char s)
        {
            if (s > 49 && s < 58) return s - '0';
            return s switch
            {
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 1,
                _ => throw new Exception($"not valid rank {s}"),
            };
        }
        #endregion

        #region Suit
        public static char GetSuitChar(int s)
        {
            return s switch
            {
                0 => 'C',
                1 => 'D',
                2 => 'H',
                3 => 'S',
                _ => throw new Exception($"Not valid Suit {s}"),
            };
        }
        public static int GetSuitInt(char s)
        {
            return s switch
            {
                'C' => 0,
                'D' => 1,
                'H' => 2,
                'S' => 3,
                _ => throw new Exception($"Not valid Suit {s}"),
            };
        }
        #endregion

        #endregion
    }
}
