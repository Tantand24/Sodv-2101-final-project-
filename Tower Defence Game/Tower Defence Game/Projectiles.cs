using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Game
{
    public abstract class Projectiles : GameAsset
    {
        internal int Damage;
        internal int speed;
    }

    public class Arrow : Projectiles
    {
        public Arrow()
        {
            Damage = 20;
            speed = 20;
        }
    }
}
