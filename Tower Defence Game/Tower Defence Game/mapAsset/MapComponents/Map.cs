using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Tower_Defence_Game
{
    public partial class Map : UserControl
    {
        int rows = 6;
        int columns = 7;

        TableLayoutPanel mapLayout;

        private cell[,] cells;
        private List<EnemyUnit>[] enemiesByRow;
        private Timer spawnTimer;
        private Timer moveTimer;
        private Random rng = new Random();

        private class EnemyUnit
        {
            public int Row;
            public int Col;
            public Enemys Logic;
            public PictureBox Sprite;
        }


        public Map()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            BackColor = Color.Transparent;

            GlobalGameValues.CurrentMap = this;

            mapLayout = new TableLayoutPanel();
            mapLayout.Padding = new Padding(4, 4, 4, 4);
            mapLayout.Dock = DockStyle.Fill;
            mapLayout.RowCount = rows;
            mapLayout.ColumnCount = columns;
            mapLayout.BackColor = Color.AliceBlue;

            cells = new cell[rows, columns];
            enemiesByRow = new List<EnemyUnit>[rows];
            for (int r = 0; r < rows; r++) enemiesByRow[r] = new List<EnemyUnit>();

            for (int r = 0; r < rows; r++)
                mapLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));

            for (int c = 0; c < columns; c++)
                mapLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columns));

            // create cells (clean row/col math)
            for (int i = 0; i < rows * columns; i++)
            {
                int currentRow = i / columns;
                int currentColumn = i % columns;

                cell mapCell = new cell(currentRow, currentColumn);
                cells[currentRow, currentColumn] = mapCell;

                mapLayout.Controls.Add(mapCell, currentColumn, currentRow);
            }

            Controls.Add(mapLayout);

            // spawn & move loops
            spawnTimer = new Timer();
            spawnTimer.Interval = 1800;
            spawnTimer.Tick += (_, __) => SpawnEnemy();
            spawnTimer.Start();

            moveTimer = new Timer();
            moveTimer.Interval = 2500;
            moveTimer.Tick += (_, __) => MoveEnemiesLeft();
            moveTimer.Start();
        }

        // used by cell.cs
        public bool HasEnemies(int row) =>
            row >= 0 && row < rows && enemiesByRow[row].Count > 0;

        // used by cell.cs
        public void TryHitEnemy(int row, Projectiles projectile)
        {
            if (row < 0 || row >= rows) return;
            if (enemiesByRow[row].Count == 0) return;

            var target = enemiesByRow[row].OrderBy(e => e.Col).First();

            target.Logic.TakeDamage(projectile);

            if (target.Logic.CheckHP() <= 0)
                RemoveEnemy(target);
        }



        private void SpawnEnemy()
        {
            int row = rng.Next(0, rows);
            int col = columns - 1;

            bool occupied = enemiesByRow[row].Any(e => e.Col == col);
            if (occupied) return;

            // choose enemy type
            Enemys enemyLogic = rng.Next(0, 3) switch
            {
                0 => new StandardEnemy(),
                1 => new TankEnemy(),
                2 => new FlyingEnemy(),
                _ => new StandardEnemy()
            };

            var pb = new PictureBox();
            pb.Dock = DockStyle.Fill;
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Enabled = false;
            pb.Image = Image.FromFile(enemyLogic.SpritePath);


            var enemy = new EnemyUnit
            {
                Row = row,
                Col = col,
                Logic = enemyLogic,
                Sprite = pb
            };

            enemiesByRow[row].Add(enemy);
            cells[row, col].Controls.Add(pb);
            pb.BringToFront();

            if (enemiesByRow[row].Count == 1)
                MapEvent.RaiseEnemiesSpawned(row);
        }


        private void MoveEnemiesLeft()
        {
            for (int r = 0; r < rows; r++)
            {
                // move left: process lowest cols first to avoid double-moves
                var movers = enemiesByRow[r].OrderBy(e => e.Col).ToList();

                foreach (var enemy in movers)
                {
                    int nextCol = enemy.Col - 1;

                    // reached end -> remove (you can reduce lives here)
                    if (nextCol < 0)
                    {
                        RemoveEnemy(enemy);
                        continue;
                    }

                    // block if another enemy already in next cell
                    bool occupied = enemiesByRow[r].Any(e => e != enemy && e.Col == nextCol);
                    if (occupied) continue;

                    // move sprite control to next cell
                    cells[r, enemy.Col].Controls.Remove(enemy.Sprite);
                    enemy.Col = nextCol;
                    cells[r, enemy.Col].Controls.Add(enemy.Sprite);
                    enemy.Sprite.BringToFront();
                }
            }
        }

        private void RemoveEnemy(EnemyUnit enemy)
        {
            int r = enemy.Row;
            int c = enemy.Col;

            enemiesByRow[r].Remove(enemy);

            try { cells[r, c].Controls.Remove(enemy.Sprite); } catch { }
            enemy.Sprite.Dispose();

            if (enemiesByRow[r].Count == 0)
                MapEvent.RaiseAllEnemiesCleared(r);
        }

        private static Image BuildEnemyImage(Enemys enemy)
        {
            Color c = enemy switch
            {
                TankEnemy => Color.DarkRed,
                FastEnemy => Color.Orange,
                FlyingEnemy => Color.DeepSkyBlue,
                BossEnemy => Color.Black,
                _ => Color.DarkViolet
            };

            var bmp = new Bitmap(64, 64);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            using var b = new SolidBrush(c);
            g.FillEllipse(b, 10, 10, 44, 44);
            g.DrawString("E", new Font("Segoe UI", 18, FontStyle.Bold), Brushes.White, 22, 16);
            return bmp;
        }

    }
}
