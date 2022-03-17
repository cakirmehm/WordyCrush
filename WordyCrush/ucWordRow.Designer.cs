namespace WordyCrush
{
    partial class ucWordRow
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblScore = new System.Windows.Forms.Label();
            this.lblWord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblScore
            //
            this.lblScore.BackColor = System.Drawing.Color.Gainsboro;
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblScore.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Green;
            this.lblScore.Location = new System.Drawing.Point(288, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(80, 36);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "+25";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblScore.MouseEnter += new System.EventHandler(this.ucWordRow_MouseEnter);
            this.lblScore.MouseLeave += new System.EventHandler(this.ucWordRow_MouseLeave);
            //
            // lblWord
            //
            this.lblWord.BackColor = System.Drawing.Color.Gainsboro;
            this.lblWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWord.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWord.ForeColor = System.Drawing.Color.Teal;
            this.lblWord.Location = new System.Drawing.Point(0, 0);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(288, 36);
            this.lblWord.TabIndex = 3;
            this.lblWord.Text = "WORD";
            this.lblWord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWord.MouseEnter += new System.EventHandler(this.ucWordRow_MouseEnter);
            this.lblWord.MouseLeave += new System.EventHandler(this.ucWordRow_MouseLeave);
            //
            // ucWordRow
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblWord);
            this.Controls.Add(this.lblScore);
            this.ForeColor = System.Drawing.Color.Teal;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ucWordRow";
            this.Size = new System.Drawing.Size(368, 36);
            this.MouseEnter += new System.EventHandler(this.ucWordRow_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ucWordRow_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblWord;
    }
}