using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CardClasses
{
    public class GUIPlayer : Player
    {
        private PictureBox[] pBoxes = new PictureBox[5];

        public GUIPlayer(params PictureBox[] pBoxes)
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
                cards[i].Show(pBoxes[i]);
            }
        }

    }
}
