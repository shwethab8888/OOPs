using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckofCards
{

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

    public class Player
    {
        public string Name { get; set; }
        public Queue<Card> Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new Queue<Card>();
        }

        public void SortHandByRank()
        {
            List<Card> sortedHand = new List<Card>(Hand);
            sortedHand.Sort((x, y) => x.Rank.CompareTo(y.Rank));
            Hand = new Queue<Card>(sortedHand);
        }
    }

    public class DeckOfCardQueue
    {
        private Queue<Card> _deck;

        public DeckOfCardQueue()
        {
            _deck = new Queue<Card>();
            InitializeDeck();
            ShuffleDeck();
        }

        private void InitializeDeck()
        {
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    _deck.Enqueue(new Card(suit, rank));
                }
            }
        }

        private void ShuffleDeck()
        {
            Random random = new Random();
            List<Card> listDeck = new List<Card>(_deck);

            for (int i = listDeck.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = listDeck[i];
                listDeck[i] = listDeck[j];
                listDeck[j] = temp;
            }

            _deck = new Queue<Card>(listDeck);
        }

        public Queue<Card> GetDeck()
        {
            return _deck;
        }
    

        public static void DeckOfCard_Queue()
        {
  
            DeckOfCardQueue deck = new DeckOfCardQueue();

            Player[] players = { new Player("Player 1"), new Player("Player 2"), new Player("Player 3"), new Player("Player 4") };

            while (deck.GetDeck().Count > 0)
            {
                foreach (Player player in players)
                {
                    if (deck.GetDeck().Count == 0) break;
                    player.Hand.Enqueue(deck.GetDeck().Dequeue());
                }
            }

            
            foreach (Player player in players)
            {
                player.SortHandByRank();
            }

            // Print players and their cards
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine("Player {0}: {1}", i + 1, players[i].Name);

                foreach (Card card in players[i].Hand)
                {
                    Console.WriteLine("{0} of {1}", card.Rank, card.Suit);
                }

                Console.WriteLine();
            }
        }
    }

}
