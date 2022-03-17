using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordyCrush
{
    public partial class ucCell : UserControl
    {
        public ucCell()
        {
            InitializeComponent();
        }

        private void lblValue_Click(object sender, EventArgs e)
        {
            lblRight.Visible = true;
        }

        private void lblValue_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                lblRight.Visible = false;
                lblLeftDown.Visible = true;
            }
        }

        public Label GetLabel()
        {
            return lblValue;
        }

        public void SetValue(char value)
        {
            lblValue.Text = value.ToString();
        }

        public int GetCellIndex()
        {
            return this.Parent.Controls.IndexOf(this);
        }

        public int GetParentIndex()
        {
            return this.Parent.Parent.Controls.IndexOf(this.Parent);
        }

        public Label GetRightLabel()
        {
            return lblRight;
        }

        public Label GetLeftLabel()
        {
            return lblLeft;
        }

        public Label GetUpLabel()
        {
            return lblUp;
        }

        public Label GetDownLabel()
        {
            return lblDown;
        }

        public Label GetRightDownLabel()
        {
            return lblRightDown;
        }

        public Label GetRightUpLabel()
        {
            return lblRightUp;
        }

        public Label GetLeftUpLabel()
        {
            return lblLeftUp;
        }

        public Label GetLeftDownLabel()
        {
            return lblLeftDown;
        }

        public void HideAllLabels()
        {
            lblRight.Visible =
            lblLeft.Visible =
            lblLeftDown.Visible =
            lblLeftUp.Visible =
            lblRightDown.Visible =
            lblRightUp.Visible =
            lblUp.Visible =
            lblDown.Visible = false;
        }
    }
}