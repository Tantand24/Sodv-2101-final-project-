using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Game
{
    public interface ITowerShoot
    {
        object TowerShoot();
    }

    public interface ITowerGenMoney
    {
        int TowerGenMoney();
    }

    public interface ITowerRegenHP
    {
        void RegenHP();
    }
}
