using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordyCrush
{
    class CControlFlusher
    {
        private static Control control;
        private static TreeNode treeNode;
        private static Color StartColor;
        private static Color EndColor;
        private static Timer tmr = null;
        private static Timer tmr2 = null;
        private static int tmrVal = 0;
        private static int tmrVal2 = 0;

        public static void initialize()
        {
            tmr = new Timer();
            tmr.Interval = 20;
            tmr.Tick += Tmr_Tick;

            tmr2 = new Timer();
            tmr2.Interval = 20;
            tmr2.Tick += Tmr2_Tick;
        }

        private static void Tmr_Tick(object sender, EventArgs e)
        {
            int Speed = 20;
            if (control != null)
            {
                // RGB Start
                int Rrange = EndColor.R - StartColor.R;
                int Grange = EndColor.G - StartColor.G;
                int Brange = EndColor.B - StartColor.B;

                control.BackColor = Color.FromArgb(
                StartColor.R + (int)(Rrange / Speed) * tmrVal,
                StartColor.G + (int)(Grange / Speed) * tmrVal,
                StartColor.B + (int)(Brange / Speed) * tmrVal
                );

                tmrVal++;
                if (tmrVal == Speed)
                {
                    tmrVal = 0;
                    control.Enabled = true;
                    control.BackColor = EndColor;
                    tmr.Stop();

                }
            }
        }

        private static void Tmr2_Tick(object sender, EventArgs e)
        {
            int Speed = 20;
            if (treeNode != null)
            {
                // RGB Start
                int Rrange = EndColor.R - StartColor.R;
                int Grange = EndColor.G - StartColor.G;
                int Brange = EndColor.B - StartColor.B;

                treeNode.BackColor = Color.FromArgb(
                StartColor.R + (int)(Rrange / Speed) * tmrVal2,
                StartColor.G + (int)(Grange / Speed) * tmrVal2,
                StartColor.B + (int)(Brange / Speed) * tmrVal2
                );

                tmrVal2++;
                if (tmrVal2 == Speed)
                {
                    tmrVal2 = 0;
                    treeNode.BackColor = EndColor;
                    tmr2.Stop();
                }
            }
        }

        public static void highlightControl(Control cnt, Color startColor, Color endColor, bool blnDisableControl = false)
        {
            if (tmr == null && tmr2 == null)
                initialize();

            control = cnt;

            if (blnDisableControl)
                control.Enabled = false;
            //control.DoubleBuffered(true);

            StartColor = startColor;
            EndColor = endColor;
            tmr.Start();
        }


    }
}