using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Game
{
    public abstract class Enemys : GameAsset
    {
        protected int EnemyHP { get; set; }
        protected int EnemySpeed { get; set; }
        protected int EnemyDamage { get; set; }
        protected int EnemyAttackSpeed { get; set; }
        
        public void TakeDamage(Projectiles projectile) 
        {
            EnemyHP -= projectile.GetDamage();
        }

        public int CheckHP() { return EnemyHP; }
        public int CheckAttackSpeed() { return EnemyAttackSpeed; }
        public int GetDamage() { return EnemyDamage; }
        public int CheckSpeed() { return EnemySpeed; }
    }

    public class StandardEnemy : Enemys
    {
        public StandardEnemy() 
        { 
            EnemyHP = 100;
            EnemySpeed = 20;
            EnemyDamage = 25;
            EnemyAttackSpeed = 25;
        }
    }
    public class TankEnemy : Enemys
    {
        public TankEnemy()
        {
            EnemyHP = 200;
            EnemySpeed = 5;
            EnemyDamage = 75;
            EnemyAttackSpeed = 5;
        }
    }
    public class FastEnemy : Enemys
    {
        public FastEnemy()
        {
            EnemyHP = 75;
            EnemySpeed = 40;
            EnemyDamage = 25;
            EnemyAttackSpeed = 50;
        }
    }
    public class FlyingEnemy : Enemys
    {
        public FlyingEnemy()
        {
            EnemyHP = 75;
            EnemySpeed = 60;
            EnemyDamage = 15;
            EnemyAttackSpeed = 50;
        }
    }
    public class BossEnemy : Enemys
    {
        public BossEnemy()
        {
            EnemyHP = 300;
            EnemySpeed = 10;
            EnemyDamage = 100;
            EnemyAttackSpeed = 25;
        }
    }
}
