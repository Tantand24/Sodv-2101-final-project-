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
            string value = comboBox1.SelectedItem?.ToString();
            if (value == null || currentCell == null) return;

            if (value == "Remove Tower")
            {
                currentCell.setToEmpty();
            }
            else
            {
                // 1️⃣ Create tower LOGIC
                Towers tower = value switch
                {
                    "Archer Tower" => new ArcherTower(),
                    "Cannon Tower" => new CannonTower(),
                    "Wall Tower" => new WallTower(),
                    "Bank Tower" => new BankTower(),
                    _ => new ArcherTower()
                };

                // 2️⃣ Pick tower IMAGE (visual only)
                Image img = value switch
                {
                    "Archer Tower" => Image.FromFile("GameAssetImage/Archer tower.jpg"),
                    "Cannon Tower" => Image.FromFile("GameAssetImage/Cannon tower.jpg"),
                    "Wall Tower" => Image.FromFile("GameAssetImage/Blocker tower.jpg"),
                    "Bank Tower" => Image.FromFile("GameAssetImage/money tower.jpg"),
                    _ => Image.FromFile("assets/towers/archer.png")
                };

                // 3️⃣ Place tower into the cell
                currentCell.setToNotEmpty(img, tower);
            }

            this.Hide();
            currentCell = null;
        }

    }
}
