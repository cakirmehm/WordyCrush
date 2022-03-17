using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordyCrush
{
    public partial class F_NewGame : Form
    {

        private bool mouseDown;
        private Point lastLocation;
        public EGameMode GameMode { get; set; } = EGameMode.FLOATING;
        public ELanguage Lang { get; set; } = ELanguage.TR;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );

        public F_NewGame()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.ShowInTaskbar = false;

        }



        private void F_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void F_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                this.Location.X - lastLocation.X + e.X,
                this.Location.Y - lastLocation.Y + e.Y
                );
                this.Update();
            }
        }

        private void F_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pbxYoda_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            //lblWay.BackColor = Color.FromArgb(50, Color.Aquamarine);
        }

        private void pbxYoda_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            //lblWay.BackColor = Color.MediumAquamarine;
        }

        private async void pbxYoda_Click(object sender, EventArgs e)
        {
            if (GameMode == EGameMode.FLOATING)
            {
                // shift to right
                Image imge = pbxYoda.Image;
                imge.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pbxYoda.Image = imge;

                int speed = 2;
                while (pbxYoda.Location.X < lblWay.Location.X + lblWay.Width - pbxYoda.Width - 3)
                {
                    await Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(10);
                    });

                    pbxYoda.Location = new Point(pbxYoda.Location.X + speed, pbxYoda.Location.Y);
                    speed++;
                }

                GameMode = EGameMode.STATIC;
                lblFloating.ForeColor = Color.DimGray;
                lblStatic.ForeColor = Color.Blue;
            }
            else
            {
                // shift to left
                Image imge = pbxYoda.Image;
                imge.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pbxYoda.Image = imge;

                int speed = 2;
                while (pbxYoda.Location.X > lblWay.Location.X)
                {
                    await Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(10);
                    });

                    pbxYoda.Location = new Point(pbxYoda.Location.X - speed, pbxYoda.Location.Y);
                    speed++;
                }

                GameMode = EGameMode.FLOATING;
                lblStatic.ForeColor = Color.DimGray;
                lblFloating.ForeColor = Color.Blue;
            }
        }

        private void lnkStart_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            this.ShowInTaskbar = false;

            F_WordCrush wordCrush = new F_WordCrush(GameMode, Lang);
            //wordCrush.GameMode = GameMode;
            wordCrush.Text = $"{wordCrush.Text} ({wordCrush.GameMode} MODE)";
            wordCrush.Show();

            this.Hide();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private async void pbxDog_Click(object sender, EventArgs e)
        {
            if (Lang == ELanguage.TR)
            {
                // shift to right
                Image imge = pbxLang.Image;
                imge.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pbxLang.Image = imge;

                int speed = 2;
                while (pbxLang.Location.X < lblLangWay.Location.X + lblLangWay.Width - pbxLang.Width - 3)
                {
                    await Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(10);
                    });

                    pbxLang.Location = new Point(pbxLang.Location.X + speed, pbxLang.Location.Y);
                    speed++;
                }

                Lang = ELanguage.EN;
                lblTR.ForeColor = Color.DimGray;
                lblEN.ForeColor = Color.Blue;
            }
            else
            {
                // shift to left
                Image imge = pbxLang.Image;
                imge.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pbxLang.Image = imge;

                int speed = 2;
                while (pbxLang.Location.X > lblLangWay.Location.X)
                {
                    await Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(10);
                    });


                    pbxLang.Location = new Point(pbxLang.Location.X - speed, pbxLang.Location.Y);
                    speed++;
                }

                Lang = ELanguage.TR;
                lblEN.ForeColor = Color.DimGray;
                lblTR.ForeColor = Color.Blue;
            }
        }

        private void pbxYoda_MouseDown(object sender, MouseEventArgs e)
        {
            pbxYoda_Click(sender, e);
        }

        private void pbxDog_MouseDown(object sender, MouseEventArgs e)
        {
            pbxDog_Click(sender, e);
        }

        private async void pbx_Click(object sender, EventArgs e)
        {
            // shift to right
            PictureBox pbxClicked = sender as PictureBox;


            if (pbxClicked.Location.X < pbxLang.Location.X)
            {
                // shift to left
                int speed = 1;
                while (pbxLang.Location.X > pbxClicked.Location.X)
                {
                    await Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(10);
                    });

                    pbxLang.Location = new Point(pbxLang.Location.X - speed, pbxLang.Location.Y);
                    speed++;
                }


            }
            else
            {
                // shift to right
                int speed = 1;
                while (pbxLang.Location.X < pbxClicked.Location.X)
                {
                    await Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(10);
                    });

                    pbxLang.Location = new Point(pbxLang.Location.X + speed, pbxLang.Location.Y);
                    speed++;
                }
            }

            pbxLang.Location = new Point(pbxClicked.Location.X, pbxClicked.Location.Y);

            resetLangLabelStyles();
            Label lbl = getRelatedLabel(pbxClicked);
            if (lbl != null)
            {
                lbl.ForeColor = Color.Blue;
            }
        }

        private void resetLangLabelStyles()
        {
            lblTR.ForeColor = lblEN.ForeColor = lblDE.ForeColor = lblFR.ForeColor = lblIT.ForeColor =
                lblES.ForeColor = lblNL.ForeColor = Color.DimGray;
        }

        private Label getRelatedLabel(PictureBox pbxClicked)
        {
            foreach (var cnt in this.Controls)
            {
                if (cnt is Label)
                {
                    Label lbl = cnt as Label;
                   
                    if (lbl.Name.Equals(pbxClicked.Name.Replace("pbx", "lbl")))
                    {
                        Lang = lbl.Name.EndsWith("TR")
                            ? ELanguage.TR
                            : lbl.Name.EndsWith("EN")
                                ? ELanguage.EN
                                : lbl.Name.EndsWith("DE")
                                    ? ELanguage.DE
                                    : lbl.Name.EndsWith("FR")
                                        ? ELanguage.FR
                                        : lbl.Name.EndsWith("IT")
                                            ? ELanguage.IT
                                            : lbl.Name.EndsWith("ES")
                                                ? ELanguage.ES
                                                : ELanguage.NL;
                        
                        return lbl;
                    }
                       
                }

            }
            return null;
        }
    }
}