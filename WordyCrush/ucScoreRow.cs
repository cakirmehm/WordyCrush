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
    public partial class ucScoreRow : UserControl
    {

        public int Rating { get; set; }
        public string UserName { get; set; }
        public string Score { get; set; }

        public int MyProperty { get; set; }

        public ucScoreRow()
        {
            InitializeComponent();
        }

        public void updateUI(int val = 0)
        {
            lblRating.Text = Rating.ToString();
            lblUser.Text = UserName;
            lblScore.Text = Score;

            int bR = Math.Min(255, BackColor.R + val * 2);
            int bG = Math.Min(255, BackColor.G + val * 3);
            int bB = Math.Min(255, BackColor.B + val * 3);


            lblScore.BackColor = lblUser.BackColor = lblRating.BackColor = this.BackColor = Color.FromArgb(bR, bG, bB);
        }
    }
}