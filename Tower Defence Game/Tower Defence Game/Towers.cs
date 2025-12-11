using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_Game
{
    public abstract class Towers : GameAsset
    {
        protected int TowerHP { get; set; }
        protected int TowerCost { get; set; }

        public void TakeDamage(Enemys Enemy) 
        {
            TowerHP -= Enemy.GetDamage();
        }

        public int CheckHP(){ return TowerHP; }
    };

    public abstract class ShootingTower : Towers, ITowerShoot 
    {
        protected int TowerAttackSpeed { get; set; }

        public int CheckAttackSpeed() { return TowerAttackSpeed; }

        public virtual Object TowerShoot() {
            Projectiles Arrow = new Arrow();
            return Arrow;
        }
    };
    
    public abstract class BlockerTower : Towers, ITowerRegenHP
    {
        protected int regenRate { get; set; }
        protected int regenAmount { get; set; }
        protected int maxHP { get; set; }

        public void RegenHP()
        {
            if(TowerHP < maxHP)
            {
                TowerHP += regenAmount;
                if(TowerHP > maxHP)
                {
                    TowerHP = maxHP;
                }
            }
        }
    }

    public abstract class MoneyTower : Towers, ITowerGenMoney
    {
        protected int GenMoneyAmount { get; set; }
        protected int MoneyRate { get; set; }

        public virtual int TowerGenMoney()
        {
            return GenMoneyAmount;
        }
    }

    public class ArcherTower : ShootingTower
    {
        public ArcherTower()
        {
            TowerHP = 100;
            TowerAttackSpeed = 10;
        }
    }
    public class CannonTower : ShootingTower
    {
        public CannonTower()
        {
            TowerHP = 100;
            TowerAttackSpeed = 5;
        }

        public override object TowerShoot()
        {
            Projectiles CannonBall = new CannonBall();
            return CannonBall;
        }
    }
    public class WallTower : BlockerTower
    {
        public WallTower()
        {
            TowerHP = 200;
            maxHP = 200;
            regenAmount = 40;
            regenRate = 25;
        }
    }

    public class BankTower : MoneyTower
    {
        public BankTower()
        {

        }
    }
}
