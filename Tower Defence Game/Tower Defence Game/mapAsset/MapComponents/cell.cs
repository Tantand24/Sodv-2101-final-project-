using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Tower_Defence_Game
{
    public partial class cell : UserControl
    {
        PictureBox cellPicture;
        int row;
        int column;
        bool isEmpty = true;
        private Timer? fireTimer;
        public Towers? Tower { get; private set; }


        public cell(int row, int column)
        {
            InitializeComponent();

            this.row = row;
            this.column = column;

            Image cellBgImage = Image.FromFile("GameAssetImage/decor/snow-tilemap.png");
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
                towerList = new List<string> { "Archer Tower", "Cannon Tower", "Wall Tower", "Bank Tower" };

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
            if (Tower == null) return;
            if (fireTimer != null) return;

            fireTimer = new Timer();
            fireTimer.Interval = 250;

            fireTimer.Tick += (_, __) =>
            {
                if (Tower is ShootingTower shooter)
                {
                    // Your TowerShoot returns Object, so cast it
                    //make projecctile spawn on cell then move to
                    var projObj = shooter.TowerShoot();
                    if (projObj is Projectiles projectile)
                    {
                        GlobalGameValues.CurrentMap?.TryHitEnemy(this.row, projectile);
                    }
                }
            };

            fireTimer.Start();
        }


        private void StopFiring()
        {
            if (fireTimer == null) return;

            fireTimer.Stop();
            fireTimer.Dispose();
            fireTimer = null;
        }


        public void setToNotEmpty(Image img, Towers tower)
        {
            Tower = tower;
            cellPicture.Image = img;
            this.isEmpty = false;
        }

        public void setToEmpty()
        {
            StopFiring();
            Tower = null;
            cellPicture.Image = null;
            this.isEmpty = true;
        }


        private void paintCell()
        {

        }
    }
}
