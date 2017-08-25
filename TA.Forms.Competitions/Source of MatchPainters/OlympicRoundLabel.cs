using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TA.Competitions.Forms
{
    class RoundLabel
    {
        internal int Left;
        internal int Top;
        internal string LabelText = "";

        internal void Draw(System.Drawing.Graphics gr)
        {
            if (LabelText != "")
            {
                Font font_bold = new Font(FontFamily.GenericSansSerif, OlympicPainterSettings.FontSize * 1.3f, FontStyle.Bold);
                SizeF labelSize = gr.MeasureString(LabelText, font_bold);
                Point loc = new Point(Left + (OlympicPainterSettings.MatchSize.Width - labelSize.ToSize().Width) / 2, Top - labelSize.ToSize().Height);
                gr.DrawString(LabelText, font_bold, new SolidBrush(OlympicPainterSettings.MatchLabelColors.ForeColor), loc);
            }
        }
    }
}
