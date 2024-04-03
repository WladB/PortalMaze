using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    public class Goblin1: AbstractEnemy
    {
        public override void start()
        {
            picture = new Decor((Image)Properties.Resources.ResourceManager.GetObject("Goblin1"), new Point(83, 320), new Size(105, 117)).GetPictureBox(); ;
            
            speed = 5;

            attackStrategy = new GoblinStrategy();
        }
        public override void show(Form form)
        {
            form.Controls.Add(picture);
        }
        public override void Attack(Form f, Player p = null, AbstractEnemy b = null)
        {
            attackStrategy.Attack(p, b, f);
        }
        public override void move(Point point)
        {
            if (this.picture.Right - (this.picture.Width / 2) <= point.X)
            {
                this.picture.Left += speed;
            }
            if (this.picture.Left + (this.picture.Width / 2) >= point.X)
            {
                this.picture.Left -= speed;
            }

            if (this.picture.Bottom - (this.picture.Height / 2) <= point.Y)
            {
                this.picture.Top += speed;
            }
            if (this.picture.Top + (this.picture.Height / 2) >= point.Y)
            {
                this.picture.Top -= speed;
            }
        }
    }
    public class Goblin2 : AbstractEnemy
    {
        public override void start()
        {
            picture = new Decor((Image)Properties.Resources.ResourceManager.GetObject("Goblin1"), new Point(83, 320), new Size(105, 117)).GetPictureBox();
            //picture.SizeMode = PictureBoxSizeMode.AutoSize;
            speed = 4;

            attackStrategy = new GoblinStrategy();
        }
        public override void show(Form form)
        {
            form.Controls.Add(picture);
        }
        public override void Attack(Form f, Player p = null, AbstractEnemy b = null)
        {
            attackStrategy.Attack(p, b, f);
        }
        public override void move(Point point)
        {
            if (this.picture.Right - (this.picture.Width / 2) <= point.X)
            {
                this.picture.Left += speed;
            }
            if (this.picture.Left + (this.picture.Width / 2) >= point.X)
            {
                this.picture.Left -= speed;
            }

            if (this.picture.Bottom - (this.picture.Height / 2) <= point.Y)
            {
                this.picture.Top += speed;
            }
            if (this.picture.Top + (this.picture.Height / 2) >= point.Y)
            {
                this.picture.Top -= speed;
            }
        }
    }
    public class Goblin3 : AbstractEnemy
    {
        public override void start()
        {
            picture = new PictureBox();
            picture.Image = ((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"));
            picture.SizeMode = PictureBoxSizeMode.AutoSize;
            speed = 5;

            attackStrategy = new GoblinStrategy();
        }
        public override void show(Form form)
        {
            form.Controls.Add(picture);
        }
        public override void Attack(Form f, Player p = null, AbstractEnemy b = null)
        {
            attackStrategy.Attack(p, b, f);
        }
        public override void move(Point point)
        {
            if (this.picture.Right - (this.picture.Width / 2) <= point.X)
            {
                this.picture.Left += speed;
            }
            if (this.picture.Left + (this.picture.Width / 2) >= point.X)
            {
                this.picture.Left -= speed;
            }

            if (this.picture.Bottom - (this.picture.Height / 2) <= point.Y)
            {
                this.picture.Top += speed;
            }
            if (this.picture.Top + (this.picture.Height / 2) >= point.Y)
            {
                this.picture.Top -= speed;
            }
        }
    }
}
