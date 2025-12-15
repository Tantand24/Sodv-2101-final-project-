using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Game
{
    internal static class GlobalGameValues
    {
        private static int coins = 200;

        private static PopUpBar bar = PopUpBar.initPopUpBar();

        // Global reference to the active map (set once when Map is created)
        public static Map? CurrentMap { get; set; }

        public static PopUpBar PopUpBar
        {
            get { return bar; }
        }

        public static int getCoins()
        {
            return coins;
        }

        public static void AddCoins(int value)
        {
            coins += value;
        }
    }
}
