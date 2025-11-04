using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Game
{
    public abstract class Enemys : GameAsset
    {
        private int EnemyHP { get; set; }
        private int EnemySpeed { get; set; }
        private int EnemyDamage { get; set; }
        private int EnemyAttackSpeed { get; set; }
        
        public void TakeDamage(Projectiles projectile) 
        {
            EnemyHP -= projectile.Damage;
        }

        public void SetHP(int SetHP) { EnemyHP = SetHP; }
        public void SetAttackSpeed(int SetAS) { EnemyAttackSpeed = SetAS; }
        public void SetDamage(int SetDam) { EnemyDamage = SetDam; }
        public void SetSpeed(int SetSpe) { EnemySpeed = SetSpe; }
        public int CheckHP() { return EnemyHP; }
        public int CheckAttackSpeed() { return EnemyAttackSpeed; }
        public int GetDamage() { return EnemyDamage; }
        public int CheckSpeed() { return EnemySpeed; }
    }
}
