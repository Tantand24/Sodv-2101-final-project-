using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projectpractice.MapComponents;

namespace Tower_Defence_Game
{
    public partial class cell : UserControl
    {
        PictureBox cellPicture;
        int row;
        int column;
        bool isEmpty = true;
        public cell(int row, int column)
        {
            InitializeComponent();

            this.row = row;
            this.column = column;

            Image cellBgImage = Image.FromFile("assets/decor/snow-tilemap.png");
            this.BackgroundImage = cellBgImage;

            cellPicture = new PictureBox();
            cellPicture.Dock = DockStyle.Fill;
            cellPicture.BackColor = Color.Transparent;
            cellPicture.SizeMode = PictureBoxSizeMode.Zoom;

            Controls.Add(cellPicture);

            cellPicture.Click += onCellClick;

            MapEvent.EnemiesSpawnedOnRow += OnEnemiesSpawnedOnRow;
            MapEvent.AllEnemiesClearedOnRow += OnAllEnemiesClearedOnRow;

            // make sure we unsubscribe when this control is destroyed
            this.Disposed += cell_Disposed;
        }

        private void cell_Disposed(object sender, EventArgs e)
        {
            MapEvent.EnemiesSpawnedOnRow -= OnEnemiesSpawnedOnRow;
            MapEvent.AllEnemiesClearedOnRow -= OnAllEnemiesClearedOnRow;
        }

        private void onCellClick(object sender, EventArgs e)
        {
            showPopUpBar(row, column);
        }

        private void showPopUpBar(int row, int column)
        {
            List<string> towerList;

            Point location = new Point(0, this.Height);

            //popup bar
            //if cell is empty, we wanna create towers
            if (isEmpty)
            {
                towerList = new List<string> { "Splash Tower", "Aerial Tower", "Archer Tower"};
            }
            else //if not empty we want to remove towers, we can implement move if time allows for it
            {
                towerList = new List<string> { "Remove Tower" };
            }

            GlobalGameValues.PopUpBar.showBar(towerList, location, this);
        }

        private void OnEnemiesSpawnedOnRow(int rowIndex)
        {
            // ignore other rows
            if (rowIndex != this.row) return;

            // only towers should react
            if (isEmpty) return;

            StartFiring();
        }

        private void OnAllEnemiesClearedOnRow(int rowIndex)
        {
            if (rowIndex != this.row) return;
            if (isEmpty) return;

            StopFiring();
        }

        private void StartFiring()
        {
            // TODO: implement how your tower actually shoots:
            // - start a Timer on this cell
            // - or set a bool flag and let a global update loop query it
            Console.WriteLine($"Tower at row {row}, col {column} START firing");
        }

        private void StopFiring()
        {
            // TODO: stop whatever you did in StartFiring (Timer, flag, etc.)
            Console.WriteLine($"Tower at row {row}, col {column} STOP firing");
        }

        public void setToNotEmpty(Image img)
        {
            cellPicture.Image = img;
            this.isEmpty = false;
        }

        public void setToEmpty()
        {
            this.isEmpty = true;
        }

        private void paintCell()
        {

        }
    }
}
