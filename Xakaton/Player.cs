using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
  public class Player
    {
        public Player(PictureBox p)
        {
            picture = p;
            speed = 7;
            rect = new Rectangle(picture.Location, picture.Size);
        }
        public int speed;
        public PictureBox picture;
        public Rectangle rect;
        public int health = 100;
        int AttackRadius = 500;
        public List<AbstractEnemy> enemies = new List<AbstractEnemy>();
        public void Attack(Form f, Player p = null, AbstractEnemy b = null)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Attack(f, this, enemies[i]);
            }
        }
        public  void move(Point point)
        {
            this.picture.Left = point.X;
            this.picture.Top = point.Y;


            for (int i = 0; i < enemies.Count; i++)
            {
                if (new Rectangle(this.picture.Location.X + ((this.picture.Width - AttackRadius) / 2), this.picture.Location.Y + ((this.picture.Height - AttackRadius) / 2), AttackRadius, AttackRadius).Contains(enemies[i].picture.Location))
                {
                    enemies[i].move(new Point(point.X + (this.picture.Width / 2), point.Y + (this.picture.Height / 2)));
                }
            }
        }
    }
}
