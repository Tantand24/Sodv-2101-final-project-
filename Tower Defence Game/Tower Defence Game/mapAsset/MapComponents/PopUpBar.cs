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
    //should we have just one? i think so
    //so we can make it a singleton class
    public partial class PopUpBar : UserControl
    {
        List<string> towerOptions = new List<string>();

        //instance for popup bar initialization
        private static PopUpBar _instance;

        //keep track of current cell
        private cell currentCell;

        private PopUpBar()
        {
            InitializeComponent();

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        //function to create singleton instance
        public static PopUpBar initPopUpBar()
        {
            if (_instance == null)
            {
                _instance = new PopUpBar();
            }

            return _instance;
        }

        //function to show Bar
        public void showBar(List<string> options, Point location, cell clickedCell)
        {
            //clear list
            towerOptions.Clear();

            //insert new options to display
            towerOptions.AddRange(options);

            //attach list to combo box
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(options.ToArray());
            comboBox1.Text = "";

            Location = new Point(location.X, location.Y - this.Height);

            //add to cell it was clicked on
            clickedCell.Controls.Add(this);
            this.BringToFront();
            this.Show();

            currentCell = clickedCell;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //execute action
            string value = comboBox1.SelectedItem?.ToString();

            //just for testing, as long as its not == Remove Tower, we'll spawn same, we will chnage later
            if(value != "Remove Tower")
            {
                //create new tower and place in cell
                Image cellImage = Image.FromFile("assets/towers/Archer tower.jpg");
                currentCell.setToNotEmpty(cellImage);
            }
            else
            {
                //remove tower ??

                //reset cell to empty
                currentCell.setToEmpty();
            }

            // show action
            MessageBox.Show($"You selected: {value}", "Tower Selected");
            

            //hide bar
            this.Hide();
            currentCell = null;
        }
    }
}
