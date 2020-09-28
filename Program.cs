using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating 13 instances (of value 1 to 13) of each Suit into a deck
            //using (var context = new MyContext())
            //{
            //FOLLOWING OUTCOMMENTED CODE GENERATED THE DECK IN DB. 
            //IF YOU RUN THIS IN YOUR COMPUTER A DB WILL BE CREATED.


            //var cards = new List<Card>();

            //for (int i = 1; i < 14; i++)
            //{
            //    var cardHearts = new Card {Suit = Suit.Hearts, Value = i  };
            //    cards.Add(cardHearts);
            //    var cardDiamonds = new Card {Suit= Suit.Diamonds, Value = i  };
            //    cards.Add(cardDiamonds);
            //    var cardClubs = new Card {Suit= Suit.Clubs, Value = i  };
            //    cards.Add(cardClubs);
            //    var cardSpades = new Card {Suit= Suit.Spades, Value = i  };
            //    cards.Add(cardSpades);
            //}

            //foreach (var item in cards)
            //{
            //    //Console.WriteLine(item.Value + " " + item.Suit);
            //    context.Cards.Add(item);
            //}

            //context.SaveChanges();


            //FOLLOWING CODE WILL MAKE A QUERY TO THE CREATED DB AND DISPLAY THE SORED DATA

            var allCards = new List<Card>();
            allCards = GetAllCards();
            Console.WriteLine("Retrieve all cards from the database:");

            foreach (var card in allCards)
            {
                string name;

                if (card.Value == 1)
                {
                    name = "ace of " + card.Suit;
                }
                else if (card.Value == 11)
                {
                    name = "jack of " + card.Suit;
                }
                else if (card.Value == 12)
                {
                    name = "queen of " + card.Suit;
                }
                else if (card.Value == 13)
                {
                    name = "king of " + card.Suit;
                }
                else
                {
                    name = card.Value + " of " + card.Suit;
                }

                Console.WriteLine(name);
            }
            Console.WriteLine("press any key to exit...");
            Console.ReadKey();

            //This method shall find the specific index of a card by its properti values
            int index = GetIndexFor(1, "Spades");
            Console.WriteLine($"The index of Ace of Spades is {index}");

            int index2 = GetIndexFor(7, "Spades");
            Console.WriteLine($"The index of Seven of Spades is {index2}");

            int index3 = GetIndexFor(8, "Hearts");
            Console.WriteLine($"The index of Eight of Hearts is {index3}");

            int index4 = GetIndexFor(12, "Diamonds");
            Console.WriteLine($"The index of Queen of Diamonds is {index4}");
            //}
            Console.ReadKey();

        }

        private static List<Card> GetAllCards()
        {

            using (var context = new MyContext())
            {
                var cards = (from c in context.Cards
                             orderby c.Value
                             select c).ToList<Card>();

                return cards;
            }

        }

        private static int GetIndexFor(int v1, string v2)
        {
            int index;
            var cards = GetAllCards();

            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Value == v1 && cards[i].Suit.ToString() == v2)
                {
                    return index = i;
                }
            }

            return 53;
        }
    }

    public class Card
    {
        [Key]
        public int ID { get; set; }
        public int Value { get; set; }
        public Suit Suit { get; set; }

    }
    public enum Suit
    {
        Hearts, Diamonds, Clubs, Spades
    }

    public class MyContext : DbContext
    {
        public virtual DbSet<Card> Cards { get; set; }

    }
}
