using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    public abstract class AbstractEnemy
    {
        
        public PictureBox picture;
        public abstract void move(Point point);
        public abstract void Attack(Form f, Player p = null, AbstractEnemy b = null);

        public AttackStrategy attackStrategy;


       
        public int speed;
        abstract public void start();
        abstract public void show(Form form);
       // abstract public void win(Form form);
       // abstract public void move(Timer timer, float gripCoef, int endRoad, Form form);
    }
  
    public abstract class AbstractRoomLogic //головоломки які будуть задіяні у кімнатах
    {
        public PictureBox searchItem;//предмет який має знайти персонаж
        public Rectangle rect;
        public string task;//Опис дій які має виконати персонаж
        public Keys Сase;//предмет до якого гравець має віднести шукану річ
        //public double speed;
        abstract public void start();
        abstract public void show(Form form);
    }

    public abstract class RoomsDecor
    {
        public List<object> listDecor; //list декорацій для кімнати 
        public PictureBox bkGround;
        abstract public void start();
        abstract public void show(Form form);
    }
    public abstract class AbstractFactory
    {
        public AbstractEnemy ogr;
        public AbstractEnemy goblin;
        public AbstractEnemy bomb;
        public AbstractRoomLogic logic;
        public RoomsDecor decor;
        abstract public AbstractEnemy CreateEnemyOgr();
        abstract public AbstractEnemy CreateEnemyGoblin();
        abstract public AbstractEnemy CreateEnemyBomb();
        abstract public AbstractRoomLogic CreateRoomLogic();
        abstract public RoomsDecor CreateDecor();
        abstract public bool play();
    }

}
