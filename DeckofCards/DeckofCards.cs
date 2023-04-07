
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckofCards
{
    internal class DeckOfCards
    {

        private List<Card> deck;

        public DeckOfCards()
        {
            deck = new List<Card>();

            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rand = new Random();

            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                Card temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        public void DealCards()
        {
            Card[,] hands = new Card[4, 9];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    hands[i, j] = deck[i * 9 + j];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Player {0}'s hand:", i + 1);
                for (int j = 0; j < 9; j++)
                {
                    Console.WriteLine("{0} of {1}", hands[i, j].Rank, hands[i, j].Suit);
                }
                Console.WriteLine();
            }
        }


        public class Card
        {
            public string Suit { get; set; }
            public string Rank { get; set; }

            public Card(string suit, string rank)
            {
                Suit = suit;
                Rank = rank;
            }
        }

        public static void DeckOf_Cards()
        {
            DeckOfCards deck = new DeckOfCards();
            deck.Shuffle();
            deck.DealCards();
        }
    }
}
