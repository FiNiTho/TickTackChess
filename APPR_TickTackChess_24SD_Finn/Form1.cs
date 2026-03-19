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
        Piece currentPiece = null;
        PictureBox pcbFrom = null;
        PictureBox pcbTo = null;

        int horizontal = 0;
        int vertical = 0;
        string pieceOptions = "";
        List<Board> boardlist = new List<Board>();

        List<Piece> piecelist = new List<Piece>();

        Color notSelectableColor = Color.Red;
        Color backgroundColor = Color.SandyBrown;
        Color allowDropColor = Color.Green;

        List<PictureBox> White_List = new List<PictureBox>();
        List<PictureBox> Black_List = new List<PictureBox>();

        bool gameState = false;
        string currentTurn = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbnWhite.Checked = true;

            foreach (PictureBox picturebox in gbxBoard.Controls.OfType<PictureBox>())
            {
                picturebox.BackColor = backgroundColor;
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
                picturebox.AllowDrop = true;
            }

            foreach (PictureBox picturebox in gbxPieces.Controls.OfType<PictureBox>())
            {
                picturebox.BackColor = backgroundColor;
                picturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            boardlist.Clear();
            boardlist.Add(new Board(1, 1, "pcbOne"));
            boardlist.Add(new Board(2, 1, "pcbTwo"));
            boardlist.Add(new Board(3, 1, "pcbThree"));
            boardlist.Add(new Board(1, 2, "pcbFour"));
            boardlist.Add(new Board(2, 2, "pcbFive"));
            boardlist.Add(new Board(3, 2, "pcbSix"));
            boardlist.Add(new Board(1, 3, "pcbSeven"));
            boardlist.Add(new Board(2, 3, "pcbEight"));
            boardlist.Add(new Board(3, 3, "pcbNine"));
        }

        private void rbnWhite_CheckedChanged(object sender, EventArgs e)
        {
            piecesColorsChanged("White");
        }

        private void rbnBlack_CheckedChanged(object sender, EventArgs e)
        {
            piecesColorsChanged("Black");
        }

        private void pcbPieces_MouseDown(object sender, MouseEventArgs e)
        {
            pcbFrom = (PictureBox)sender;

            List<PictureBox> White_Placement = new List<PictureBox>();
            White_Placement.Add(pcbSeven);
            White_Placement.Add(pcbEight);
            White_Placement.Add(pcbNine);

            List<PictureBox> Black_Placement = new List<PictureBox>();
            Black_Placement.Add(pcbOne);
            Black_Placement.Add(pcbTwo);
            Black_Placement.Add(pcbThree);

            if (pcbFrom.Image != null)
            {
                if (pcbFrom.Tag.ToString() == "White")
                {
                    foreach (PictureBox pcb in White_Placement)
                    {
                        if (pcb.Image == null)
                        {
                            pcb.BackColor = Color.Green;
                        }
                    }
                    pcbFrom.DoDragDrop(pcbFrom.Image, DragDropEffects.Copy);
                }
                else
                {
                    foreach (PictureBox pcb in Black_Placement)
                    {
                        if (pcb.Image == null)
                        {
                            pcb.BackColor = Color.Green;
                        }
                    }
                    pcbFrom.DoDragDrop(pcbFrom.Image, DragDropEffects.Copy);
                }
            }
        }

        private void pcbAllBoard_MouseDown(object sender, MouseEventArgs e)
        {
            ClearBoardColors();
            pcbFrom = (PictureBox)sender;

            if (pcbFrom.Image != null && pcbFrom.BackColor == backgroundColor)
            {
                //Only be able to move the pieces if the game started
                if (gameState == true)
                {
                    
                    //Search for the horizontal and vertical based on the picturebox name
                    LocationOfPicturebox(pcbFrom.Name);
                    //Get the current piece based on the horizontal and vertical
                    currentPiece = piecelist.FirstOrDefault(x => x.GetCurrentHorizontal() == horizontal && x.GetCurrentVertical() == vertical);
                    if (currentPiece.GetColor() == currentTurn)
                    {
                        GetBoardOptions();
                        UpdateBoardPieceLocations();
                        pcbFrom.DoDragDrop(pcbFrom.Image, DragDropEffects.Copy);
                    }
                }
            }
        }

        private void pcbAllBoard_DragDrop(object sender, DragEventArgs e)
        {
            //This changes the images of the new picturebox
            //Adds a new piece and the right location
            pcbTo = (PictureBox)sender;

            horizontal = Convert.ToInt32(pcbTo.Tag.ToString().Substring(0, 1));
            vertical = Convert.ToInt32(pcbTo.Tag.ToString().Substring(1, 1));

            //Only add new pieces when the game is not started
            if (gameState == false)
            {
                //Add piece the name and color
                piecelist.Add(currentPiece = new Piece(pcbFrom.Name.Remove(0, 3), pcbFrom.Tag.ToString()));
            }
            currentPiece.SetLocation(horizontal, vertical);

            Image getImage = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            pcbTo.Image = getImage;

            pcbFrom.Image = null;

            //Save witch pieces have been chosen for choosing pieces
            if (pcbFrom.Tag.ToString() == "White")
            {
                White_List.Add(pcbFrom);
            }
            else
            {
                Black_List.Add(pcbFrom);
            }

            if (gameState == true)
            {
                //TODO: SHOW WITH COLOR WITCH CAN BE PICKED UP
                currentTurn = currentTurn == "White" ? "Black" : "White";
                lblGameState.Text = currentTurn + "s turn";
            }

            ClearBoardColors();

            //When all pieces are chosen start the game
            if (White_List.Count == 3 && Black_List.Count == 3)
            {
                lblGameState.Text = "Game started, Whites turn";
                gbxPieces.Enabled = false;
                rbnWhite.Enabled = false;
                rbnBlack.Enabled = false;
                gameState = true;
                currentTurn = "White";

                
            }
        }

        PictureBox FindByTag(string tag)
        {
            return this.Controls.OfType<PictureBox>().FirstOrDefault(p => p.Tag?.ToString() == tag);
        }

        private void pcbAllBoard_DragOver(object sender, DragEventArgs e)
        {
            pcbTo = (PictureBox)sender;
            if (pcbTo.BackColor == Color.Green)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public void GetBoardOptions()
        {
            pieceOptions = "";
            foreach (Board board in boardlist)
            {
                if (currentPiece != null)
                {
                    pieceOptions += currentPiece.GetMoveOptions(board.GetHorizontal(), board.GetVertical());
                }
            }
        }

        public void UpdateBoardPieceLocations()
        {
            for (int i = 0; i < pieceOptions.Length; i += 2)
            {
                foreach (PictureBox pcb in gbxBoard.Controls.OfType<PictureBox>())
                {
                    if (pcb.Tag.ToString() == pieceOptions[i].ToString() + pieceOptions[i + 1].ToString() && pcb.Image == null)
                    {
                        pcb.BackColor = allowDropColor;
                    }
                }
            }
        }

        //Sets the horizontal and vertival variable based on picturebox name
        private void LocationOfPicturebox(String pictureboxName)
        {
            switch (pictureboxName)
            {
                case "pcbOne": horizontal = 1; vertical = 1; break;
                case "pcbTwo": horizontal = 2; vertical = 1; break;
                case "pcbThree": horizontal = 3; vertical = 1; break;
                case "pcbFour": horizontal = 1; vertical = 2; break;
                case "pcbFive": horizontal = 2; vertical = 2; break;
                case "pcbSix": horizontal = 3; vertical = 2; break;
                case "pcbSeven": horizontal = 1; vertical = 3; break;
                case "pcbEight": horizontal = 2; vertical = 3; break;
                case "pcbNine": horizontal = 3; vertical = 3; break;
                default:
                    MessageBox.Show("Something went wrong with the location of your piece");
                    break;
            }
        }

        private void piecesColorsChanged(string color)
        {
            pcbRook.Image = (Image)Properties.Resources.ResourceManager.GetObject(color + "_Rook");
            pcbKnight.Image = (Image)Properties.Resources.ResourceManager.GetObject(color + "_Knight");
            pcbQueen.Image = (Image)Properties.Resources.ResourceManager.GetObject(color + "_Queen");

            pcbRook.Tag = color;
            pcbKnight.Tag = color;
            pcbQueen.Tag = color;

            //Gets the right list of pieces
            List<PictureBox> list = (color == "White") ? White_List : Black_List;
            foreach (PictureBox pcb in list)
            {
                pcb.Image = null;
            }

            ClearBoardColors();
        }

        private void ClearBoardColors()
        {
            foreach (PictureBox pcb in gbxBoard.Controls.OfType<PictureBox>())
            {
                pcb.BackColor = backgroundColor;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void ResetGame()
        {
            //All player pictureboxes will be empty and allowed to drop a image
            foreach (PictureBox pcb in gbxBoard.Controls.OfType<PictureBox>())
            {
                pcb.BackColor = backgroundColor;
                pcb.Image = null;
                pcb.AllowDrop = true;
            }

            gameState = false;

            //Reset label for game state
            lblGameState.Text = "Choose pieces";

            //Choose pieces enabled
            gbxPieces.Enabled = true;
            rbnWhite.Enabled = true;
            rbnBlack.Enabled = true;

            //Reset lists
            White_List.Clear();
            Black_List.Clear();
            piecelist.Clear();

            //Reset the piece choices
            string color = rbnWhite.Checked ? "White" : "Black";
            piecesColorsChanged(color);

            //Clear colors
            ClearBoardColors();
        }
    }
}
