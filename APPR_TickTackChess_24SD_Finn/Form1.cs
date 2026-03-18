using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR_TickTackChess_24SD_Finn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbnWhite.Checked = true;

            foreach (PictureBox picturebox in gbxBoard.Controls.OfType<PictureBox>())
            {
                picturebox.BackColor = Color.White;
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                picturebox.AllowDrop = true;
            }

            //boardlist.Clear();
            //boardlist.Add(new Board(1, 1, "pcbOne"));
            //boardlist.Add(new Board(2, 1, "pcbTwo"));
            //boardlist.Add(new Board(3, 1, "pcbThree"));
            //boardlist.Add(new Board(1, 2, "pcbFour"));
            //boardlist.Add(new Board(2, 2, "pcbFive"));
            //boardlist.Add(new Board(3, 2, "pcbSix"));
            //boardlist.Add(new Board(1, 3, "pcbSeven"));
            //boardlist.Add(new Board(2, 3, "pcbEight"));
            //boardlist.Add(new Board(3, 3, "pcbNine"));
        }

        private void rbnWhite_CheckedChanged(object sender, EventArgs e)
        {
            pcbRook.Image = Properties.Resources.White_Rook;
            pcbKnight.Image = Properties.Resources.White_Knight;
            pcbQueen.Image = Properties.Resources.White_Queen;
        }

        private void rbnBlack_CheckedChanged(object sender, EventArgs e)
        {
            pcbRook.Image = Properties.Resources.Black_Rook;
            pcbKnight.Image = Properties.Resources.Black_Knight;
            pcbQueen.Image = Properties.Resources.Black_Queen;
        }
    }
}
