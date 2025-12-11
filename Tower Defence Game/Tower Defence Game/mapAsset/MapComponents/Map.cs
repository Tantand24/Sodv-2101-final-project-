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
    public partial class Map : UserControl
    {
        int rows = 6;
        int columns = 7;

        TableLayoutPanel mapLayout;

        public Map()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            BackColor = Color.Transparent;

            mapLayout = new TableLayoutPanel();
            mapLayout.Padding = new Padding(4, 4, 4, 4);
            mapLayout.Dock = DockStyle.Fill;
            mapLayout.RowCount = rows;
            mapLayout.ColumnCount = columns;
            mapLayout.BackColor = Color.AliceBlue;
            
           

            // set row heights
            for (int r = 0; r < rows; r++)
            {
                mapLayout.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 100f / rows)
                );
            }

            // set column widths
            for (int c = 0; c < columns; c++)
            {
                mapLayout.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100f / columns)
                );
            }

            // create cells
            int cellNumbers = rows * columns;

            //setup row number and column number here
            int currentRow = 0;
            int currentColumn = 0;


            for (int i = 0; i < cellNumbers; i++)
            {
                cell mapCell = new cell(currentRow, currentColumn);

                mapLayout.Controls.Add(mapCell, currentColumn, currentRow);

                //+check to handle currentRow and currentColumn recalculation
                if(currentColumn == 6)
                {
                    //reset currentcolumn
                    currentColumn = 0;
                    //add 1 to row
                    currentRow += 1;
                }
                else
                {
                    currentColumn += 1;
                }
            }

            Controls.Add(mapLayout);
        }

        private void showPopUpBar(int row, int column)
        {

        }
    }

}
