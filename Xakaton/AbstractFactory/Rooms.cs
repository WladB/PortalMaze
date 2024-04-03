using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    class Room1 : AbstractFactory
    {
        public override AbstractEnemy CreateEnemyOgr()
        {
            return new Ogr1();
        }
        public override AbstractEnemy CreateEnemyGoblin()
        {
            return new Goblin1();
        }
        public override AbstractEnemy CreateEnemyBomb()
        {
            return new Bomb();
        }
        public override AbstractRoomLogic CreateRoomLogic()
        {
            return new RoomsLogic1();
        }
        public override RoomsDecor CreateDecor()
        {
            return new DecorRoom1();
        }
        public override bool play()
        {
           
            Form form1 = new Form();
            form1.KeyPreview = true;
            PictureBox picturePlayer = new Decor((Image)Properties.Resources.ResourceManager.GetObject("player"), new Point(504, 283), new Size(60, 94)).GetPictureBox();
            Player player = new Player(picturePlayer);
            ProgressBar prBar = new ProgressBar();
            prBar.Size = new Size(341, 17);
            prBar.Location = new Point(741, 17);
            // new Point(X, Y);
            int X = picturePlayer.Location.X;
            int Y = picturePlayer.Location.Y;
            
            Timer timer = new Timer();
            void timer1_Tick(object sender, EventArgs e)
            {
                if (player.health != 0)
                {
                    player.move(new Point(X, Y));
                    player.Attack(form1);
                    prBar.Value = player.health;
                    
                }
                else {
                    timer.Enabled = false;
                    MessageBox.Show("Ви не впорались");
                    form1.DialogResult= DialogResult.No;

                }
                
            }
             void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                X = e.X - picturePlayer.Width / 2;
                Y = e.Y - picturePlayer.Height / 2;
            }
             
           
            timer.Tick += timer1_Tick;
            
            prBar.Minimum = 0;
            prBar.Maximum = 100;
            
            form1.Text = "Room1 Level";
            form1.BackColor = Color.White;
            form1.Width = 1149;
            form1.Height = 720;
            form1.Controls.Add(picturePlayer);
            form1.Controls.Add(prBar);
            form1.KeyDown += Form1_KeyDown;
            ogr = CreateEnemyOgr();
            goblin = CreateEnemyGoblin();
            bomb = CreateEnemyBomb();
            logic = CreateRoomLogic();
            decor = CreateDecor();
            player.enemies.Add(ogr);
            player.enemies.Add(goblin);
            player.enemies.Add(bomb);
            ogr.start();
            goblin.start();
            bomb.start();
            logic.start();
            decor.start();
            void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.W: Y -= player.speed; break;
                    case Keys.A: X -= player.speed; break;
                    case Keys.D: X += player.speed; break;
                    case Keys.S: Y += player.speed; break;

                }
                if (e.KeyCode == logic.Сase && Math.Sqrt(((player.picture.Location.X - logic.searchItem.Location.X) * (player.picture.Location.X - logic.searchItem.Location.X)) + ((player.picture.Location.Y - logic.searchItem.Location.Y) * (player.picture.Location.Y - logic.searchItem.Location.Y))) <= 40)
                {
                    timer.Enabled = false;
                    MessageBox.Show("Вітаємо! ви проходите далі");
                    form1.DialogResult = DialogResult.OK;
                }
            }
            ogr.show(form1);
            goblin.show(form1);
            bomb.show(form1);
            logic.show(form1);
            decor.show(form1);
            bomb.show(form1);
            timer.Enabled = true;
            return form1.ShowDialog() == DialogResult.OK;

        }
    }
}

