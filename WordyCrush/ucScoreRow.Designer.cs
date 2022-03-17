namespace WordyCrush
{
    partial class ucScoreRow
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
            this.lblRating = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // lblScore
            //
            this.lblScore.BackColor = System.Drawing.Color.Gainsboro;
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblScore.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.Green;
            this.lblScore.Location = new System.Drawing.Point(357, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(74, 36);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "000";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblRating
            //
            this.lblRating.BackColor = System.Drawing.Color.Gainsboro;
            this.lblRating.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRating.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.ForeColor = System.Drawing.Color.Green;
            this.lblRating.Location = new System.Drawing.Point(0, 0);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(74, 36);
            this.lblRating.TabIndex = 6;
            this.lblRating.Text = "1";
            this.lblRating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblUser
            //
            this.lblUser.BackColor = System.Drawing.Color.Gainsboro;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Teal;
            this.lblUser.Location = new System.Drawing.Point(74, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(283, 36);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "mecakir";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ucScoreRow
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblScore);
            this.Name = "ucScoreRow";
            this.Size = new System.Drawing.Size(431, 36);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label lblUser;
    }
}
