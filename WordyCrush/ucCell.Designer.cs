namespace WordyCrush
{
    partial class ucCell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCell));
            this.lblRightDown = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblLeftUp = new System.Windows.Forms.Label();
            this.lblLeftDown = new System.Windows.Forms.Label();
            this.lblRightUp = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblDown = new System.Windows.Forms.Label();
            this.lblUp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRightDown
            // 
            this.lblRightDown.Image = ((System.Drawing.Image)(resources.GetObject("lblRightDown.Image")));
            this.lblRightDown.Location = new System.Drawing.Point(71, 71);
            this.lblRightDown.Name = "lblRightDown";
            this.lblRightDown.Size = new System.Drawing.Size(24, 24);
            this.lblRightDown.TabIndex = 0;
            this.lblRightDown.Visible = false;
            // 
            // lblValue
            // 
            this.lblValue.Font = new System.Drawing.Font("Candara", 24F, System.Drawing.FontStyle.Bold);
            this.lblValue.Location = new System.Drawing.Point(24, 24);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(48, 48);
            this.lblValue.TabIndex = 3;
            this.lblValue.Text = "A";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValue.Click += new System.EventHandler(this.lblValue_Click);
            this.lblValue.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblValue_MouseClick);
            // 
            // lblLeftUp
            // 
            this.lblLeftUp.Image = ((System.Drawing.Image)(resources.GetObject("lblLeftUp.Image")));
            this.lblLeftUp.Location = new System.Drawing.Point(1, 1);
            this.lblLeftUp.Name = "lblLeftUp";
            this.lblLeftUp.Size = new System.Drawing.Size(24, 24);
            this.lblLeftUp.TabIndex = 4;
            this.lblLeftUp.Visible = false;
            // 
            // lblLeftDown
            // 
            this.lblLeftDown.Image = ((System.Drawing.Image)(resources.GetObject("lblLeftDown.Image")));
            this.lblLeftDown.Location = new System.Drawing.Point(1, 71);
            this.lblLeftDown.Name = "lblLeftDown";
            this.lblLeftDown.Size = new System.Drawing.Size(24, 24);
            this.lblLeftDown.TabIndex = 5;
            this.lblLeftDown.Visible = false;
            // 
            // lblRightUp
            // 
            this.lblRightUp.Image = ((System.Drawing.Image)(resources.GetObject("lblRightUp.Image")));
            this.lblRightUp.Location = new System.Drawing.Point(71, 1);
            this.lblRightUp.Name = "lblRightUp";
            this.lblRightUp.Size = new System.Drawing.Size(24, 24);
            this.lblRightUp.TabIndex = 6;
            this.lblRightUp.Visible = false;
            // 
            // lblRight
            // 
            this.lblRight.Image = ((System.Drawing.Image)(resources.GetObject("lblRight.Image")));
            this.lblRight.Location = new System.Drawing.Point(66, 36);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(30, 24);
            this.lblRight.TabIndex = 7;
            this.lblRight.Visible = false;
            // 
            // lblLeft
            // 
            this.lblLeft.Image = ((System.Drawing.Image)(resources.GetObject("lblLeft.Image")));
            this.lblLeft.Location = new System.Drawing.Point(-1, 36);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(34, 24);
            this.lblLeft.TabIndex = 8;
            this.lblLeft.Visible = false;
            // 
            // lblDown
            // 
            this.lblDown.Image = ((System.Drawing.Image)(resources.GetObject("lblDown.Image")));
            this.lblDown.Location = new System.Drawing.Point(35, 63);
            this.lblDown.Name = "lblDown";
            this.lblDown.Size = new System.Drawing.Size(24, 33);
            this.lblDown.TabIndex = 9;
            this.lblDown.Visible = false;
            // 
            // lblUp
            // 
            this.lblUp.Image = ((System.Drawing.Image)(resources.GetObject("lblUp.Image")));
            this.lblUp.Location = new System.Drawing.Point(35, -1);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(24, 36);
            this.lblUp.TabIndex = 10;
            this.lblUp.Visible = false;
            // 
            // ucCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblUp);
            this.Controls.Add(this.lblDown);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblRightUp);
            this.Controls.Add(this.lblLeftDown);
            this.Controls.Add(this.lblLeftUp);
            this.Controls.Add(this.lblRightDown);
            this.Name = "ucCell";
            this.Size = new System.Drawing.Size(98, 98);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRightDown;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblLeftUp;
        private System.Windows.Forms.Label lblLeftDown;
        private System.Windows.Forms.Label lblRightUp;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblDown;
        private System.Windows.Forms.Label lblUp;
    }
}