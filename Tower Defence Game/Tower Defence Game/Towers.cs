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
        private int TowerHP { get; set; }
        private int TowerAttackSpeed { get; set; }

        public abstract object TowerSpecial();

        public void TakeDamage(Enemys Enemy) 
        {
            TowerHP -= Enemy.GetDamage();
        }

        public void SetHP(int SetHP) { TowerHP = SetHP; }
        public void SetAttackSpeed(int SetAS) { TowerAttackSpeed = SetAS; }
        public int CheckHP(){ return TowerHP; }
        public int CheckAttackSpeed() { return TowerAttackSpeed;}
    };

    public class StandardTower : Towers 
    {
        public StandardTower() {
            SetHP(100);
            SetAttackSpeed(1);
        }

        public override object TowerSpecial() 
        {
            return new Arrow();   
        }

    };

}
