using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Dealer : Player
    {
        private Deck deck;

        public Dealer() : base()
        {
            deck = new Deck();
            deck.Shuffle();
        }
        
        public override void Reset()
        {
            base.Reset();
            deck = new Deck();
            deck.Shuffle();
        }

        public Card Deal()
        {
            return deck.Deal();
        }

        public void Play()
        {
            while (Score < 17)
            {
                Hit(Deal());
            }
        }

        public bool IsWinner(Player p)
        {
            if (p.IsBusted)
                return true;
            else if (IsBusted)
                return false;
            else if (p.Score < Score)
                return true;
            else
                return false;
        }
    }
}
