using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xakaton
{
    class Decor {// клас для того, щоб було зручно додавати пікче бокси в ліст 
        
        public PictureBox picture;
        public Decor(Image img, Point l, Size s) {
            
           
            picture = new PictureBox();
            picture.Image = img;
            picture.Location = l;
            picture.Size = s;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.BackColor = Color.Transparent;
        }
        public PictureBox GetPictureBox(){
            return picture;
        }
    }
    class DecorRoom1 : RoomsDecor
    {
        public override void start()
        {
            listDecor = new List<object>();
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("Tree1"), new Point(877, 27), new Size(142, 185)).GetPictureBox());
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("Tree1"), new Point(98, 114), new Size(142, 185)).GetPictureBox());
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("Tree1"), new Point(210, 484), new Size(142, 185)).GetPictureBox());
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("Bochka"), new Point(615, 41), new Size(73, 83)).GetPictureBox());
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("Bochka"), new Point(118, 392), new Size(73, 83)).GetPictureBox());
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("Kamen2"), new Point(994, 535), new Size(141, 145)).GetPictureBox());
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("Kamin"), new Point(823, 370), new Size(53, 49)).GetPictureBox());
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("Kamin"), new Point(456, 599), new Size(53, 49)).GetPictureBox());
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("Kamin"), new Point(27, 41), new Size(53, 49)).GetPictureBox());
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("msg608701733_164862_removebg_preview"), new Point(660, 569), new Size(73, 79)).GetPictureBox());
            bkGround = new Decor((Image)Properties.Resources.ResourceManager.GetObject("Grass"), new Point(660, 569), new Size(73, 79)).GetPictureBox();
        }
        public override void show(Form form)
        {
            form.BackgroundImage = bkGround.Image;
            for(int i = 0; i< listDecor.Count; i++) {
                form.Controls.Add((PictureBox)listDecor[i]);
            }
        }
    }
    class DecorRoom2 : RoomsDecor
    {
        public override void start()
        {
           listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"), new Point(), new Size()).GetPictureBox());
           listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"), new Point(), new Size()).GetPictureBox());
        }
        public override void show(Form form)
        {
            for (int i = 0; i < listDecor.Count; i++)
            {
                form.Controls.Add((PictureBox)listDecor[i]);
            }
        }
    }
    class DecorRoom3 : RoomsDecor
    {
        public override void start()
        {
            listDecor.Add(new Decor((Image)Properties.Resources.ResourceManager.GetObject("OffRoad1"), new Point(), new Size()).GetPictureBox());
        }
        public override void show(Form form)
        {
            for (int i = 0; i < listDecor.Count; i++)
            {
                form.Controls.Add((PictureBox)listDecor[i]);
            }
        }
    }
}
