using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tower_Defence_Game
{
    public partial class SideLayout : UserControl
    {
        int cellNumber;
        TableLayoutPanel sideLayoutPanel;

        public SideLayout(int row, int column)
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
            BackColor = Color.Transparent;

            cellNumber = row * column;

            // create and configure the TableLayoutPanel
            sideLayoutPanel = new TableLayoutPanel();
            sideLayoutPanel.Dock = DockStyle.Fill;

            sideLayoutPanel.ColumnCount = column;
            sideLayoutPanel.RowCount = row;

            sideLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3f));
            sideLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3f));
            sideLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3f));

            string[] images = { "assets/decor/main-tree.png", "assets/decor/snowman.png", "assets/decor/lamp-post.png" };


            // add pictureboxes
            for (int i = 0; i < cellNumber; i++)
            {
                PictureBox picBox = new PictureBox();
                picBox.Dock = DockStyle.Fill;

                Image original = Image.FromFile(images[i]);
                Image scaled = new Bitmap(original, new Size(72, 72));

                picBox.Image = scaled;
                picBox.SizeMode = PictureBoxSizeMode.CenterImage;


                sideLayoutPanel.Controls.Add(picBox);
            }

            // ✅ NOW add the panel to the user control
            Controls.Add(sideLayoutPanel);
        }
    }

}
