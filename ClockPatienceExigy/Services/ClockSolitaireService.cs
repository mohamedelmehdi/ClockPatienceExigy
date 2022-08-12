using ClockPatienceExigy.Helpers;
using ClockPatienceExigy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClockPatienceExigy.Services
{
    public class ClockSolitaireService
    {
        public void PlayGame()
        {
            //Initialize 52 Cards (input as 4 * 13) and Structure to represent the clock distribution
            int column = 13, row = 4;
            LinkedList<Card>[] CardsDistribution;

            //Read Input from Console and Prepare distribution of cards using Clock model
            CardsDistribution = ReadInput(row, column);

            //Play the Game and return the last Card
            var finalCard = SortPlayCards(ref CardsDistribution, out int ExposedCardsCount);

            //Display Output 
            Console.WriteLine($"{ExposedCardsCount},{finalCard.GetRankChar()}{finalCard.GetSuitChar()}");
            Console.ReadLine();
        }

        #region Read Methods
        public LinkedList<Card>[] ReadInput(int row, int column)
        {
            Console.WriteLine("****PLEASE ENTER YOUR 52 CARDS****");

            LinkedList<Card>[] cardArray = new LinkedList<Card>[13];

            int rowIndex = 0;

            while (true)
            {
                string rowInput = Console.ReadLine().Trim();
                
                //Check to finish reading rows
                if (rowInput.Equals("#") && rowIndex >= row)
                {
                    cardArray.Reverse();
                    return cardArray;
                }

                else if (!rowInput.Equals("#") && rowIndex >= row)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You already entered 4 rows, Please enter # to start .. ");
                    Console.ResetColor();
                }

                else
                {
                    List<string> rowcards = rowInput.Split(' ')?.ToList();
                    try
                    {
                        //validation for number of cards by row
                        if (rowcards.Count() != column) throw new Exception($"Not valid number of cards by row , should be => {column}"); 

                        DistributedInputRow(rowcards, ref cardArray);
                        rowIndex++;
                    }
                    catch(Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Error.WriteLine($"This Row is not Valid, {e.Message}");
                        Console.ResetColor();
                    }
                }
            }
        }

        public void DistributedInputRow(List<string> rowcards, ref LinkedList<Card>[] cards)
        {
            int index = 0;
            //reverse one input row cards processing
            for (int x = rowcards.Count() - 1; x >= 0; x--)
            {
                var currentCard = new Card(rowcards[x][0], rowcards[x][1]);

                //Initializing linkedList 
                if (cards[index] == null) cards[index] = new LinkedList<Card>();

                //Adding the card 
                cards[index].AddLast(currentCard);
                index++;
            }
        }
        #endregion

        #region Process Methods
        public Card SortPlayCards(ref LinkedList<Card>[] cards, out int exposedCardsCount)
        {
            var playcard = cards.Last().First();
            cards.Last().RemoveFirst();

            int KingCount = playcard.Rank == 12 ? 1 : 0;
            exposedCardsCount = 1;

            bool play = true;
            while (play)
            {
                exposedCardsCount++;
                //Getting the new card in each round
                playcard = GetNewPlayCard(ref playcard, ref cards);

                if (playcard.Rank == 13) KingCount++;

                //Determines if all king piles were flipped
                if (KingCount == 4 || playcard.Flipped == true)  play = false; //End Game
            }

            //Returns last card played
            return playcard;
        }

        public Card GetNewPlayCard(ref Card playCard, ref LinkedList<Card>[] cards)
        {

            //Flipping card played
            playCard.Flipped = true;

            //Search the rank holder and place card in the last pile.
            int playCardRankIndex = playCard.Rank - 1;
            cards[playCardRankIndex].AddLast(playCard);

            //Get first card from pile and remove it.
            var newCard = cards[playCardRankIndex].First.Value;
            cards[playCardRankIndex].RemoveFirst();
            return newCard;
        }
        #endregion
    }
}
