using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardClasses;

namespace BlackJack
{
    public partial class boardFormSimple : Form
    {
        #region Instance Variables
        public Deck deck;
        public GUIPlayer player;
        public GUIPlayer dealer;
        #endregion

        public boardFormSimple()
        {
            InitializeComponent();
        }

        #region Methods
        /*
        private void FillCards()
        {
            int i = 1;

            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 1; value <= 5; value++)
                {
                    cards[i] = new Card(value, suit);
                    i++;
                }
            }
        }
        // change this one
        private void LoadCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            cards[i].Show(card);
        }
        // change this one
        private void LoadCardBack(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            (cards[i]).ShowBack(card);
        }

        private void HideCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            card.Enabled = false;
            card.Visible = false;
        }

        // change this one
        private bool IsMatch(int index1, int index2)
        {
            if (cards[index1].HasMatchingValue(cards[index2]))
                return true;
            else
                return false;
        }

        private void HideAllCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                card.Enabled = false;
                card.Visible = false;
            }
        }

        private void ShowAllCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                card.Enabled = true;
                card.Visible = true;
            }
        }

        private void DisableAllCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                card.Enabled = false;
            }
        }

        private void DisableCard(int i)
        {
            PictureBox card = (PictureBox)this.Controls["card" + i];
            card.Enabled = false;
        }

        private void EnableAllVisibleCards()
        {
            for (int i = 1; i <= 20; i++)
            {
                PictureBox card = (PictureBox)this.Controls["card" + i];
                if (card.Visible)
                    card.Enabled = true;
            }
        }
         * */

        public void Play()
        {
            while (dealer.Score < 17)
            {
                dealer.Hit(deck.Deal());
            }
        }

        public bool IsDealerWinner()
        {
            if (player.IsBusted)
                return true;
            else if (dealer.IsBusted)
                return false;
            else if (player.Score < dealer.Score)
                return true;
            else
                return false;
        }

        #endregion

        
        public void HandleEmpty(Deck d)
        {
            if (d == deck)
            {
                deck = new Deck();
                deck.Shuffle();
            }
        }
        
        private void frmBoard_Load(object sender, EventArgs e)
        {
            hitButton.Enabled = true;
            standButton.Enabled = true;
            playerWinLabel.Visible = false;
            dealerWinLabel.Visible = false;
            playAgainButton.Enabled = false;

            player = new GUIPlayer(card1, card2, card3, card4, card5);
            dealer = new GUIPlayer(card16, card17, card18, card19, card20);
            deck = new Deck();

            deck.AlmostEmpty += new Deck.EmptyHandler(HandleEmpty);
            deck.Shuffle();
            for (int i = 1; i <= 38; i++)
                deck.Deal();

            player.Hit(deck.Deal());
            dealer.Hit(deck.Deal());
            player.Hit(deck.Deal());
            dealer.Hit(deck.Deal());

            player.Show();
            dealer.Show();
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            player.Hit(deck.Deal());
            player.Show();
            if (player.IsBusted)
            {
                hitButton.Enabled = false;
                standButton.Enabled = false;
                dealerWinLabel.Visible = true;
                playAgainButton.Enabled = true;
            }
        }

        private void standButton_Click(object sender, EventArgs e)
        {
            player.Stand();
            Play();
            dealer.Show();
            if (IsDealerWinner())
                dealerWinLabel.Visible = true;
            else
                playerWinLabel.Visible = true;

            hitButton.Enabled = false;
            standButton.Enabled = false;
            playAgainButton.Enabled = true;
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            hitButton.Enabled = true;
            standButton.Enabled = true;
            playerWinLabel.Visible = false;
            dealerWinLabel.Visible = false;
            playAgainButton.Enabled = false;

            player.Reset();
            dealer.Reset();

            player.Hit(deck.Deal());
            dealer.Hit(deck.Deal());
            player.Hit(deck.Deal());
            dealer.Hit(deck.Deal());

            player.Show();
            dealer.Show();
        }
    }
}
