using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Game
{
    public abstract class Projectiles : GameAsset
    {
        protected int Damage;
        protected int Speed;

        public int GetDamage() { return Damage; }
        public int GetSpeed() { return Speed; }
    }

    public class Arrow : Projectiles
    {
        public Arrow()
        {
            Damage = 20;
            Speed = 20;
        }
    }
    public class CannonBall : Projectiles
    {
        private int AreaOfEffect;
        public CannonBall()
        {
            Damage = 25;
            Speed = 10;
            AreaOfEffect = 125;
        }

        public int GetAOE() { return AreaOfEffect; }
    }
}
