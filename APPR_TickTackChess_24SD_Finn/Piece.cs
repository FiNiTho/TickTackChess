using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR_TickTackChess_24SD_Finn
{
    internal class Piece
    {
        //Properties
        private string name = "";
        private string color = "";
        private string moveOptions = "";
        private int curHor, curVer, newHor, newVer;

        //Constructor
        public Piece(string c_name, string c_color)
        {
            name = c_name;
            color = c_color;
        }

        //Updates the new location
        public void SetLocation(int _newHor, int _newVer)
        {
            curHor = _newHor;
            curVer = _newVer;
        }

        //Based on the object you move it uses the move method
        public string GetMoveOptions(int _newHor, int _newVer)
        {
            newHor = _newHor;
            newVer = _newVer;
            moveOptions = "";

            switch (name)
            {
                case "Rook": MoveRook(); break;
                case "Knight": MoveKnight(); break;
                case "Queen": MoveQueen(); break;
                default:
                    break;
            }

            return moveOptions;
        }

        //Movement of the Rook
        public void MoveRook()
        {
            //Create a temporary location for horizontal and vertical
            //Uses Math.Abs to never have a negitve number
            int temp_hor = Math.Abs(newHor - curHor);
            int temp_ver = Math.Abs(newVer - curVer);

            //If you move 2 or 1 vertical the rook cant move horizontal
            if (temp_ver == 2 || temp_ver == 1)
            {
                if (temp_hor == 0)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
            //If you move 2 or 1 horizontal the rook cant move vertical
            else if (temp_hor == 2 || temp_hor == 1)
            {
                if (temp_ver == 0)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
        }

        public void MoveKnight()
        {
            int temp_hor = Math.Abs(newHor - curHor);
            int temp_ver = Math.Abs(newVer - curVer);

            if (temp_ver == 2)
            {
                if (temp_hor == 1)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
            else if (temp_hor == 2)
            {
                if (temp_ver == 1)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
        }

        public void MoveQueen()
        {
            int temp_hor = Math.Abs(newHor - curHor);
            int temp_ver = Math.Abs(newVer - curVer);

            //moves like an X
            if (temp_ver == 1 && temp_hor == 1 || temp_ver == 2 && temp_hor == 2)
            {
                moveOptions = $"{newHor}{newVer}";
            }
            //Moves like the rook
            else if (temp_hor == 2 || temp_hor == 1)
            {
                if (temp_ver == 0)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
            else if (temp_ver == 2 || temp_ver == 1)
            {
                if (temp_hor == 0)
                {
                    moveOptions = $"{newHor}{newVer}";
                }
            }
        }

        public string GetName() { return name; }

        public string GetLocationTag() { return $"{curHor}{curVer}"; }

        public string GetLocation() { return $"{curHor},{curVer}"; }

        public int GetCurrentHorizontal() { return curHor;  }

        public int GetCurrentVertical() { return curVer; }

        public string GetColor() { return color; }
    }
}
