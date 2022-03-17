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
    public partial class ucWordRow : UserControl
    {
        public int Score { get; set; }
        public string Word { get; set; }
        public List<Point> Path { get; set; }

        public ucWordRow()
        {
            InitializeComponent();
        }

        public void updateUI(int val = 0)
        {
            lblWord.Text = Word;
            lblScore.Text = Score.ToString();

            int bR = Math.Min(255, BackColor.R + val * 2);
            int bG = Math.Min(255, BackColor.G + val * 3);
            int bB = Math.Min(255, BackColor.B + val * 3);


            //int fR = Math.Min(255, ForeColor.R + val * 1);
            //int fG = Math.Min(255, ForeColor.G + val * 2);
            //int fB = Math.Min(255, ForeColor.B + val * 3);

            lblScore.BackColor = lblWord.BackColor = this.BackColor = Color.FromArgb(bR, bG, bB);
            //lblScore.ForeColor = lblWord.ForeColor = this.ForeColor = Color.FromArgb(fR, fG, fB);
        }

        private void ucWordRow_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ucWordRow_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        public Label GetLabel()
        {
            return lblWord;
        }
    }
}