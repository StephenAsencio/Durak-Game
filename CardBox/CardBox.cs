using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ch13CardLib;

namespace CardBox
{
    public partial class CardBox: UserControl
    {
        private Card myCard;
        public Card Card
        {
            set
            {
                myCard = value;
                UpdateCardImage();
            }
            get { return myCard; }
        }
        private void UpdateCardImage()
        {
            pbMyPictureBox.Image = myCard.GetCardImage();
        }
        public CardBox()
        {
            InitializeComponent();
            Card = new Card(Suit.Spade, Rank.Ace);
        }

        public CardBox(Card card)
        {
            InitializeComponent();
            myCard = card;
        }

        public override string ToString()
        {
            return myCard.ToString();
        }

        private void CardBox_Load(object sender, EventArgs e)
        {
            UpdateCardImage();
        }
    }
}
