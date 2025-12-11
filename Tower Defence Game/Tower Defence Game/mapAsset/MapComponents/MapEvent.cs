using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Game
{
    internal class MapEvent
    {
        public static event Action<int> EnemiesSpawnedOnRow;

        // Fired when all enemies on that row are gone
        public static event Action<int> AllEnemiesClearedOnRow;

        public static void RaiseEnemiesSpawned(int row)
        {
            EnemiesSpawnedOnRow?.Invoke(row);
        }

        public static void RaiseAllEnemiesCleared(int row)
        {
            AllEnemiesClearedOnRow?.Invoke(row);
        }
    }
}
