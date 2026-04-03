using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR_TickTackChess_24SD_Finn
{
    public partial class Form1 : Form
    {
        Piece currentPiece = null;
        Board currentBoard = null;
        Board prevBoard = null;
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
        Color notAllowedDropColor = Color.Gray;

        List<PictureBox> White_List = new List<PictureBox>();
        List<PictureBox> Black_List = new List<PictureBox>();

        List<PictureBox> White_Placement = new List<PictureBox>();
        List<PictureBox> Black_Placement = new List<PictureBox>();

        bool gameState = false;
        string currentTurn = "";

        //TODO
        // fix legalmoves NOW IT ONLY USES THE LOCATION OF THE SELECTED PEICE INSTEAD OF THE LOCATIONS IT CHECKS

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

            White_Placement.Clear();
            White_Placement.Add(pcbSeven);
            White_Placement.Add(pcbEight);
            White_Placement.Add(pcbNine);

            Black_Placement.Clear();
            Black_Placement.Add(pcbOne);
            Black_Placement.Add(pcbTwo);
            Black_Placement.Add(pcbThree);
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
            varDump();
        }

        private void pcbAllBoard_MouseDown(object sender, MouseEventArgs e)
        {
            ClearBoardColors(true);
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
                        prevBoard = boardlist.FirstOrDefault(x => x.GetHorizontal() == horizontal && x.GetVertical() == vertical);
                        GetBoardOptions();
                        UpdateBoardPieceLocations();
                        pcbFrom.DoDragDrop(pcbFrom.Image, DragDropEffects.Copy);
                    }
                }
            }
            varDump();
        }

        private void pcbAllBoard_DragDrop(object sender, DragEventArgs e)
        {
            //This changes the images of the new picturebox
            //Adds a new piece and the right location
            pcbTo = (PictureBox)sender;

            horizontal = Convert.ToInt32(pcbTo.Tag.ToString().Substring(0, 1));
            vertical = Convert.ToInt32(pcbTo.Tag.ToString().Substring(1, 1));

            currentBoard = boardlist.FirstOrDefault(x => x.GetHorizontal() == horizontal && x.GetVertical() == vertical);

            //Only add new pieces when the game is not started
            if (gameState == false)
            {
                //Add piece the name and color
                piecelist.Add(currentPiece = new Piece(pcbFrom.Name.Remove(0, 3), pcbFrom.Tag.ToString()));
            }

            currentBoard.SetPiece(currentPiece);
            currentPiece.SetLocation(horizontal, vertical);

            // ==========================================
            // ADD THIS TO CLEAR THE PREVIOUS SQUARE
            // ==========================================
            if (gameState == true && prevBoard != null)
            {
                // Nullify the piece on the old square so it is marked as empty.
                // (Adjust "null" if your SetPiece method expects a specific "Empty" object)
                prevBoard.SetPiece(null);
            }
            // ==========================================

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

            ClearBoardColors();

            if (gameState == true)
            {
                currentTurn = currentTurn == "White" ? "Black" : "White";
                lblGameState.Text = currentTurn + "s turn";

                CheckWinner();
                BlockOpponentSquares();
            }

            //When all pieces are chosen start the game
            if (White_List.Count == 3 && Black_List.Count == 3)
            {
                lblGameState.Text = "Game started, Whites turn";
                gbxPieces.Enabled = false;
                rbnWhite.Enabled = false;
                rbnBlack.Enabled = false;
                gameState = true;
                currentTurn = "White";

                BlockOpponentSquares();
            }

            varDump();
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
                    string tag = pcb.Tag.ToString();

                    int hor = int.Parse(tag.Substring(0, 1));
                    int ver = int.Parse(tag.Substring(1, 1));

                    if (tag == pieceOptions[i].ToString() + pieceOptions[i + 1].ToString()
                        && pcb.Image == null)
                    {
                        if(checkLegalMove(hor, ver))
                        {
                            pcb.BackColor = allowDropColor;
                        }
                    }
                }
            }
            Console.WriteLine($"---bomboclad");
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

        private bool checkLegalMove(int targetHor, int targetVer)
        {
            //Checks for rules of the queen and rook
            Piece currentSelected = piecelist.FirstOrDefault(p => p.GetName() == currentPiece.GetName() && p.GetColor() == currentPiece.GetColor());
            if (currentSelected.GetName() == "Knight") return true;

            string[] parts = currentSelected.GetLocation().Split(',');
            int curH = int.Parse(parts[0]);
            int curV = int.Parse(parts[1]);

            int diffH = Math.Abs(targetHor - curH);
            int diffV = Math.Abs(targetVer - curV);

            if (diffH == 2 || diffV == 2)
            {
                int midH = (curH + targetHor) / 2;
                int midV = (curV + targetVer) / 2;

                var middleTile = gbxBoard.Controls.OfType<PictureBox>()
                    .FirstOrDefault(pcb => pcb.Tag?.ToString() == $"{midH}{midV}");

                if (middleTile?.Image != null)
                {
                    return false;
                }
            }

            PictureBox targetSquare = gbxBoard.Controls.OfType<PictureBox>().FirstOrDefault(pcb => pcb.Tag?.ToString() == $"{targetHor}{targetVer}");

            if (targetSquare == null) return false;

            return true;
        }

        private void ClearBoardColors(bool allowDrop = false)
        {
            foreach (PictureBox pcb in gbxBoard.Controls.OfType<PictureBox>())
            {
                if(allowDrop == true)
                {
                    if (pcb.BackColor == allowDropColor)
                    {
                        pcb.BackColor = backgroundColor;
                    }
                }
                else
                {
                    pcb.BackColor = backgroundColor;
                }
            }
        }

        public void CheckWinner()
        {
            //Loop trough all boardlocations
            foreach (Board board in boardlist)
            {
                int currentHorBoard = board.GetHorizontal();
                int currentVerBoard = board.GetVertical();

                if (board.GetPiece() != null)
                {
                    //Store all neighbour in its own object
                    Board boardLeft = boardlist.FirstOrDefault(x => x.GetHorizontal() == currentHorBoard - 1 && x.GetVertical() == currentVerBoard);
                    Board boardRight = boardlist.FirstOrDefault(x => x.GetHorizontal() == currentHorBoard + 1 && x.GetVertical() == currentVerBoard);
                    Board boardUp = boardlist.FirstOrDefault(x => x.GetHorizontal() == currentHorBoard && x.GetVertical() == currentVerBoard - 1);
                    Board boardDown = boardlist.FirstOrDefault(x => x.GetHorizontal() == currentHorBoard && x.GetVertical() == currentVerBoard + 1);
                    Board boardUpLeft = boardlist.FirstOrDefault(x => x.GetHorizontal() == currentHorBoard - 1 && x.GetVertical() == currentVerBoard - 1);
                    Board boardDownRight = boardlist.FirstOrDefault(x => x.GetHorizontal() == currentHorBoard + 1 && x.GetVertical() == currentVerBoard + 1);
                    Board boardUpRight = boardlist.FirstOrDefault(x => x.GetHorizontal() == currentHorBoard + 1 && x.GetVertical() == currentVerBoard - 1);
                    Board boardDownLeft = boardlist.FirstOrDefault(x => x.GetHorizontal() == currentHorBoard - 1 && x.GetVertical() == currentVerBoard + 1);

                    //Check all options to see if there's a winner
                    CheckNeighbour(board, boardLeft, boardRight);
                    CheckNeighbour(board, boardUp, boardDown);
                    CheckNeighbour(board, boardUpLeft, boardDownRight);
                    CheckNeighbour(board, boardUpRight, boardDownLeft);
                }
            }
        }

        private void CheckNeighbour(Board selectedBoard, Board boardOne, Board boardTwo)
        {
            if (boardOne != null && boardTwo != null)
            {
                if (boardOne.GetPiece() != null && boardTwo.GetPiece() != null)
                {
                    //Check if all three colors are of the same color
                    if (selectedBoard.GetPiece().GetColor() == boardOne.GetPiece().GetColor() && boardOne.GetPiece().GetColor() == boardTwo.GetPiece().GetColor())
                    {
                        if (selectedBoard.GetPiece().GetColor() == "White")
                        {
                            if (selectedBoard.GetVertical() != 3)
                            {
                                MessageBox.Show("White won!");
                                ResetGame();
                            }
                        }
                        else
                        {
                            if (selectedBoard.GetVertical() != 1)
                            {
                                MessageBox.Show("Black won!");
                                ResetGame();
                            }
                        }
                    }
                }
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

            foreach (Board board in boardlist)
            {
                board.SetPiece(null);
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

        private void BlockOpponentSquares()
        {
            foreach (Piece piece in piecelist.Where(x => x.GetColor() != currentTurn))
            {
                string location = piece.GetLocationTag();

                PictureBox pcb = FindByTag(location);

                if (pcb != null)
                {
                    pcb.BackColor = notAllowedDropColor;
                }
            }
        }

        PictureBox FindByTag(string tag)
        {
            return gbxBoard.Controls.OfType<PictureBox>().FirstOrDefault(p => p.Tag?.ToString() == tag);
        }

        private void varDump()
        {
            
            Piece selectedObj = piecelist.FirstOrDefault(p => p.GetLocationTag() == currentPiece.GetLocationTag());

            if (selectedObj != null)
            {
                lblGameState.Text = selectedObj.GetDebugInfo();
            }
            else
            {
                lblGameState.Text = "Nothing.";
            }
        }
    }
}
