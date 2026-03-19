namespace APPR_TickTackChess_24SD_Finn
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxBoard = new System.Windows.Forms.GroupBox();
            this.pcbFive = new System.Windows.Forms.PictureBox();
            this.pcbNine = new System.Windows.Forms.PictureBox();
            this.pcbOne = new System.Windows.Forms.PictureBox();
            this.pcbEight = new System.Windows.Forms.PictureBox();
            this.pcbTwo = new System.Windows.Forms.PictureBox();
            this.pcbSeven = new System.Windows.Forms.PictureBox();
            this.pcbThree = new System.Windows.Forms.PictureBox();
            this.pcbSix = new System.Windows.Forms.PictureBox();
            this.pcbFour = new System.Windows.Forms.PictureBox();
            this.gbxPieces = new System.Windows.Forms.GroupBox();
            this.pcbRook = new System.Windows.Forms.PictureBox();
            this.pcbKnight = new System.Windows.Forms.PictureBox();
            this.pcbQueen = new System.Windows.Forms.PictureBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.rbnWhite = new System.Windows.Forms.RadioButton();
            this.rbnBlack = new System.Windows.Forms.RadioButton();
            this.lblGameState = new System.Windows.Forms.Label();
            this.gbxBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbEight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSeven)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbThree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFour)).BeginInit();
            this.gbxPieces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbQueen)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxBoard
            // 
            this.gbxBoard.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbxBoard.Controls.Add(this.pcbFive);
            this.gbxBoard.Controls.Add(this.pcbNine);
            this.gbxBoard.Controls.Add(this.pcbOne);
            this.gbxBoard.Controls.Add(this.pcbEight);
            this.gbxBoard.Controls.Add(this.pcbTwo);
            this.gbxBoard.Controls.Add(this.pcbSeven);
            this.gbxBoard.Controls.Add(this.pcbThree);
            this.gbxBoard.Controls.Add(this.pcbSix);
            this.gbxBoard.Controls.Add(this.pcbFour);
            this.gbxBoard.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbxBoard.Location = new System.Drawing.Point(12, 59);
            this.gbxBoard.Name = "gbxBoard";
            this.gbxBoard.Size = new System.Drawing.Size(331, 351);
            this.gbxBoard.TabIndex = 9;
            this.gbxBoard.TabStop = false;
            this.gbxBoard.Text = "Board";
            // 
            // pcbFive
            // 
            this.pcbFive.Location = new System.Drawing.Point(116, 126);
            this.pcbFive.Name = "pcbFive";
            this.pcbFive.Size = new System.Drawing.Size(100, 105);
            this.pcbFive.TabIndex = 4;
            this.pcbFive.TabStop = false;
            this.pcbFive.Tag = "22";
            this.pcbFive.DragDrop += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragDrop);
            this.pcbFive.DragOver += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragOver);
            this.pcbFive.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbAllBoard_MouseDown);
            // 
            // pcbNine
            // 
            this.pcbNine.Location = new System.Drawing.Point(222, 237);
            this.pcbNine.Name = "pcbNine";
            this.pcbNine.Size = new System.Drawing.Size(100, 105);
            this.pcbNine.TabIndex = 8;
            this.pcbNine.TabStop = false;
            this.pcbNine.Tag = "33";
            this.pcbNine.DragDrop += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragDrop);
            this.pcbNine.DragOver += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragOver);
            this.pcbNine.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbAllBoard_MouseDown);
            // 
            // pcbOne
            // 
            this.pcbOne.Location = new System.Drawing.Point(10, 15);
            this.pcbOne.Name = "pcbOne";
            this.pcbOne.Size = new System.Drawing.Size(100, 105);
            this.pcbOne.TabIndex = 0;
            this.pcbOne.TabStop = false;
            this.pcbOne.Tag = "11";
            this.pcbOne.DragDrop += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragDrop);
            this.pcbOne.DragOver += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragOver);
            this.pcbOne.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbAllBoard_MouseDown);
            // 
            // pcbEight
            // 
            this.pcbEight.Location = new System.Drawing.Point(116, 237);
            this.pcbEight.Name = "pcbEight";
            this.pcbEight.Size = new System.Drawing.Size(100, 105);
            this.pcbEight.TabIndex = 7;
            this.pcbEight.TabStop = false;
            this.pcbEight.Tag = "23";
            this.pcbEight.DragDrop += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragDrop);
            this.pcbEight.DragOver += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragOver);
            this.pcbEight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbAllBoard_MouseDown);
            // 
            // pcbTwo
            // 
            this.pcbTwo.Location = new System.Drawing.Point(116, 15);
            this.pcbTwo.Name = "pcbTwo";
            this.pcbTwo.Size = new System.Drawing.Size(100, 105);
            this.pcbTwo.TabIndex = 1;
            this.pcbTwo.TabStop = false;
            this.pcbTwo.Tag = "21";
            this.pcbTwo.DragDrop += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragDrop);
            this.pcbTwo.DragOver += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragOver);
            this.pcbTwo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbAllBoard_MouseDown);
            // 
            // pcbSeven
            // 
            this.pcbSeven.Location = new System.Drawing.Point(10, 237);
            this.pcbSeven.Name = "pcbSeven";
            this.pcbSeven.Size = new System.Drawing.Size(100, 105);
            this.pcbSeven.TabIndex = 6;
            this.pcbSeven.TabStop = false;
            this.pcbSeven.Tag = "13";
            this.pcbSeven.DragDrop += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragDrop);
            this.pcbSeven.DragOver += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragOver);
            this.pcbSeven.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbAllBoard_MouseDown);
            // 
            // pcbThree
            // 
            this.pcbThree.Location = new System.Drawing.Point(222, 15);
            this.pcbThree.Name = "pcbThree";
            this.pcbThree.Size = new System.Drawing.Size(100, 105);
            this.pcbThree.TabIndex = 2;
            this.pcbThree.TabStop = false;
            this.pcbThree.Tag = "31";
            this.pcbThree.DragDrop += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragDrop);
            this.pcbThree.DragOver += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragOver);
            this.pcbThree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbAllBoard_MouseDown);
            // 
            // pcbSix
            // 
            this.pcbSix.Location = new System.Drawing.Point(222, 126);
            this.pcbSix.Name = "pcbSix";
            this.pcbSix.Size = new System.Drawing.Size(100, 105);
            this.pcbSix.TabIndex = 5;
            this.pcbSix.TabStop = false;
            this.pcbSix.Tag = "32";
            this.pcbSix.DragDrop += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragDrop);
            this.pcbSix.DragOver += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragOver);
            this.pcbSix.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbAllBoard_MouseDown);
            // 
            // pcbFour
            // 
            this.pcbFour.Location = new System.Drawing.Point(10, 126);
            this.pcbFour.Name = "pcbFour";
            this.pcbFour.Size = new System.Drawing.Size(100, 105);
            this.pcbFour.TabIndex = 3;
            this.pcbFour.TabStop = false;
            this.pcbFour.Tag = "12";
            this.pcbFour.DragDrop += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragDrop);
            this.pcbFour.DragOver += new System.Windows.Forms.DragEventHandler(this.pcbAllBoard_DragOver);
            this.pcbFour.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbAllBoard_MouseDown);
            // 
            // gbxPieces
            // 
            this.gbxPieces.Controls.Add(this.pcbRook);
            this.gbxPieces.Controls.Add(this.pcbKnight);
            this.gbxPieces.Controls.Add(this.pcbQueen);
            this.gbxPieces.Location = new System.Drawing.Point(365, 59);
            this.gbxPieces.Name = "gbxPieces";
            this.gbxPieces.Size = new System.Drawing.Size(118, 354);
            this.gbxPieces.TabIndex = 10;
            this.gbxPieces.TabStop = false;
            this.gbxPieces.Text = "Pieces";
            // 
            // pcbRook
            // 
            this.pcbRook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pcbRook.Location = new System.Drawing.Point(9, 15);
            this.pcbRook.Name = "pcbRook";
            this.pcbRook.Size = new System.Drawing.Size(100, 105);
            this.pcbRook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbRook.TabIndex = 9;
            this.pcbRook.TabStop = false;
            this.pcbRook.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbPieces_MouseDown);
            // 
            // pcbKnight
            // 
            this.pcbKnight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbKnight.Location = new System.Drawing.Point(9, 126);
            this.pcbKnight.Name = "pcbKnight";
            this.pcbKnight.Size = new System.Drawing.Size(100, 105);
            this.pcbKnight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbKnight.TabIndex = 10;
            this.pcbKnight.TabStop = false;
            this.pcbKnight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbPieces_MouseDown);
            // 
            // pcbQueen
            // 
            this.pcbQueen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbQueen.Location = new System.Drawing.Point(9, 237);
            this.pcbQueen.Name = "pcbQueen";
            this.pcbQueen.Size = new System.Drawing.Size(100, 105);
            this.pcbQueen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbQueen.TabIndex = 11;
            this.pcbQueen.TabStop = false;
            this.pcbQueen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbPieces_MouseDown);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(12, 12);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(92, 41);
            this.btnRestart.TabIndex = 11;
            this.btnRestart.Text = "Restart game";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // rbnWhite
            // 
            this.rbnWhite.AutoSize = true;
            this.rbnWhite.Location = new System.Drawing.Point(360, 24);
            this.rbnWhite.Name = "rbnWhite";
            this.rbnWhite.Size = new System.Drawing.Size(53, 17);
            this.rbnWhite.TabIndex = 12;
            this.rbnWhite.TabStop = true;
            this.rbnWhite.Text = "White";
            this.rbnWhite.UseVisualStyleBackColor = true;
            this.rbnWhite.CheckedChanged += new System.EventHandler(this.rbnWhite_CheckedChanged);
            // 
            // rbnBlack
            // 
            this.rbnBlack.AutoSize = true;
            this.rbnBlack.Location = new System.Drawing.Point(431, 24);
            this.rbnBlack.Name = "rbnBlack";
            this.rbnBlack.Size = new System.Drawing.Size(52, 17);
            this.rbnBlack.TabIndex = 13;
            this.rbnBlack.TabStop = true;
            this.rbnBlack.Text = "Black";
            this.rbnBlack.UseVisualStyleBackColor = true;
            this.rbnBlack.CheckedChanged += new System.EventHandler(this.rbnBlack_CheckedChanged);
            // 
            // lblGameState
            // 
            this.lblGameState.AutoSize = true;
            this.lblGameState.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameState.Location = new System.Drawing.Point(154, 24);
            this.lblGameState.Name = "lblGameState";
            this.lblGameState.Size = new System.Drawing.Size(107, 19);
            this.lblGameState.TabIndex = 14;
            this.lblGameState.Text = "Choose pieces";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 422);
            this.Controls.Add(this.lblGameState);
            this.Controls.Add(this.rbnBlack);
            this.Controls.Add(this.rbnWhite);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.gbxPieces);
            this.Controls.Add(this.gbxBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbFive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbNine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbEight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSeven)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbThree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFour)).EndInit();
            this.gbxPieces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbRook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbQueen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbOne;
        private System.Windows.Forms.PictureBox pcbTwo;
        private System.Windows.Forms.PictureBox pcbThree;
        private System.Windows.Forms.PictureBox pcbSix;
        private System.Windows.Forms.PictureBox pcbFive;
        private System.Windows.Forms.PictureBox pcbFour;
        private System.Windows.Forms.PictureBox pcbNine;
        private System.Windows.Forms.PictureBox pcbEight;
        private System.Windows.Forms.PictureBox pcbSeven;
        private System.Windows.Forms.GroupBox gbxBoard;
        private System.Windows.Forms.PictureBox pcbRook;
        private System.Windows.Forms.PictureBox pcbKnight;
        private System.Windows.Forms.PictureBox pcbQueen;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.RadioButton rbnWhite;
        private System.Windows.Forms.RadioButton rbnBlack;
        private System.Windows.Forms.GroupBox gbxPieces;
        private System.Windows.Forms.Label lblGameState;
    }
}

