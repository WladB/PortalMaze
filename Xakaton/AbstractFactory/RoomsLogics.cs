using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    class RoomsLogic1 : AbstractRoomLogic
    {
        //public PictureBox searchItem;//предмет який має знайти персонаж
       // public string task;//Опис дій які має виконати персонаж
       // public PictureBox Сase;//предмет до якого гравець має віднести шукану річ
        //public double speed;
        public override void start()
        {
            searchItem = new Decor((Image)Properties.Resources.ResourceManager.GetObject("Pen"), new Point(180, 59), new Size(30, 30)).GetPictureBox();
            // searchItem.Image = ((Image)Properties.Resources.ResourceManager.GetObject("Pen"));
            // Сase = new Decor((Image)Properties.Resources.ResourceManager.GetObject("msg608701733_164862_removebg_preview"), new Point(660, 569), new Size(73, 79)).GetPictureBox();
            rect = new Rectangle(searchItem.Location, searchItem.Size);
            Сase = Keys.E;
            task = "Поклади цей предмет на платформу";
        }
        public override void show(Form form)
        {
            TextBox tb = new TextBox();
            tb.Text = task;
            tb.Multiline = true;
            tb.ReadOnly = true;
            tb.Size = new Size(322, 90);
            tb.Location = new Point(/* */);
            form.Controls.Add(searchItem);
            form.Controls.Add(tb);
            //form.Controls.Add(Сase);

        }

      
    }
    class RoomsLogic2 : AbstractRoomLogic
    {
        //public PictureBox searchItem;//предмет який має знайти персонаж
        // public string task;//Опис дій які має виконати персонаж
        // public PictureBox Сase;//предмет до якого гравець має віднести шукану річ
        //public double speed;
        public override void start()
        {
            searchItem = new PictureBox();
            searchItem.Image = ((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"));
            // Сase = new PictureBox();
            // Сase.Image = ((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"));
            rect = new Rectangle(searchItem.Location, searchItem.Size);
            task = "Поклади цей предмет на платформу1";
        }
        public override void show(Form form)
        {
            TextBox tb = new TextBox();
            tb.Text = task;
            tb.Location = new Point(/* */);
            form.Controls.Add(searchItem);
            form.Controls.Add(tb);
           // form.Controls.Add(Сase);

        }


    }
    class RoomsLogic3 : AbstractRoomLogic
    {
        //public PictureBox searchItem;//предмет який має знайти персонаж
        // public string task;//Опис дій які має виконати персонаж
        // public PictureBox Сase;//предмет до якого гравець має віднести шукану річ
        //public double speed;
        public override void start()
        {
            searchItem = new PictureBox();
            searchItem.Image = ((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"));
           // Сase = new PictureBox();
           // Сase.Image = ((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"));

            task = "Поклади цей предмет на платформу2";
        }
        public override void show(Form form)
        {
            TextBox tb = new TextBox();
            tb.Text = task;
            tb.Location = new Point(/* */);
            form.Controls.Add(searchItem);
            form.Controls.Add(tb);
           // form.Controls.Add(Сase);

        }


    }

}
