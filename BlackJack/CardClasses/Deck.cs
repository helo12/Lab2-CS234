using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        //public delegate void EmptyHandler(Deck d);
        //public event EmptyHandler AlmostEmpty;

        //public void HandleEmpty(Deck d) { }

        public Deck()
        {
            for (int value = 1; value <= 13; value++)
                for (int suit = 1; suit <= 4; suit++)
                    cards.Add(new Card(value, suit));
            //AlmostEmpty = new EmptyHandler(HandleEmpty);
        }

        public int NumCards
        {
            get 
            {
                return cards.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return (cards.Count == 0);
            }
        }

        public Card Deal()
        {
            if (NumCards > 10)
            {
                Card c = cards[0];
                cards.Remove(c);
                return c;
            }
            else if (IsEmpty)
            {
                return null;
            }
            else
            {
                Card c = cards[0];
                cards.Remove(c);
                //AlmostEmpty(this);
                return c;
            }
        }

        public void Shuffle()
        {
            Random gen = new Random();
            for (int i = 0; i < NumCards; i++)
            {
                int rnd = gen.Next(i, NumCards);
                Card c = cards[rnd];
                cards[rnd] = cards[i];
                cards[i] = c;
            }
        }
    }
}
