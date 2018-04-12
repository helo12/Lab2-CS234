using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CardClasses
{
    public class GUIDealer : Dealer
    {
        private PictureBox[] pBoxes = new PictureBox[5];

        public GUIDealer(params PictureBox[] pBoxes)
            : base()
        {
            int i = 0;
            foreach (PictureBox b in pBoxes)
            {
                this.pBoxes[i] = b;
                i++;
            }
        }

        public void Show()
        {
            foreach (PictureBox b in pBoxes)
                b.Visible = false;
            for (int i = 0; i < NumCards; i++)
            {
                pBoxes[i].Visible = true;
                if (i == 0)
                    cards[i].ShowBack(pBoxes[i]);
                else
                    cards[i].Show(pBoxes[i]);
            }
        }

        public void ShowAll()
        {
            Show();
            cards[0].Show(pBoxes[0]);
        }
    }
}
