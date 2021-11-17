using System.Drawing;
using System.Windows.Forms;

namespace OLV
{
    public class NamedDescriptionDecoration : BrightIdeasSoftware.AbstractDecoration
    {
        public ImageList ImageList;
        public string ImageName;
        public string Title;
        public string Description;

        public Font TitleFont = new Font("Tahoma", 9, FontStyle.Bold);
        public Color TitleColor = Color.FromArgb(255, 32, 32, 32);
        public Font DescripionFont = new Font("Tahoma", 9);
        public Color DescriptionColor = Color.FromArgb(255, 96, 96, 96);
        public Size CellPadding = new Size(1, 1);

        public override void Draw(BrightIdeasSoftware.ObjectListView olv, Graphics g, Rectangle r)
        {
            Rectangle cellBounds = CellBounds;
            cellBounds.Inflate(-CellPadding.Width, -CellPadding.Height);
            Rectangle textBounds = cellBounds;

            if (ImageList != null && !string.IsNullOrEmpty(ImageName))
            {
                g.DrawImage(ImageList.Images[ImageName], cellBounds.Location);
                textBounds.X += ImageList.ImageSize.Width;
                textBounds.Width -= ImageList.ImageSize.Width;
            }

            //g.DrawRectangle(Pens.Red, textBounds);

            // Draw the title
            StringFormat fmt = new StringFormat(StringFormatFlags.NoWrap);
            fmt.Trimming = StringTrimming.EllipsisCharacter;
            fmt.Alignment = StringAlignment.Near;
            fmt.LineAlignment = StringAlignment.Near;

            using (SolidBrush b = new SolidBrush(TitleColor))
            {
                g.DrawString(Title, TitleFont, b, textBounds, fmt);
            }

            // Draw the description
            SizeF size = g.MeasureString(Title, TitleFont, (int)textBounds.Width, fmt);
            textBounds.Y += (int)size.Height;
            textBounds.Height -= (int)size.Height;
            StringFormat fmt2 = new StringFormat();
            fmt2.Trimming = StringTrimming.EllipsisCharacter;
            using (SolidBrush b = new SolidBrush(DescriptionColor))
            {
                g.DrawString(Description, DescripionFont, b, textBounds, fmt2);
            }
        }
    }
}
