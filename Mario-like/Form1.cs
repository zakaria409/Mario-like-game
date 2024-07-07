using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace largG
{
    public partial class Form1 : Form
    {

        Bitmap bitmap;
        actor floor, laser;
        actor hstill, blast;
        actor rhstill, portal;
        actor ladder, floaty;
        actor elevator, roc, star;
        actor rooml, roomr, fly;
        Bitmap bg, end = new Bitmap("end.png");
        List<Box> lb = new List<Box>();
        Bitmap boxim = new Bitmap("fb.png");
        List<actor> exp = new List<actor>();
        List<actor> hero = new List<actor>();
        List<actor> rhero = new List<actor>();
        List<actor> heroj = new List<actor>();
        List<actor> rheroj = new List<actor>();

        Timer t = new Timer();
        actor k1;
        int IwhicheFrame = 0, bmframe = 0;
        int jframe = 0;
        int xhero;
        int yhero, laserdir = 0;
        int flycut = 0, boom2 = 0;
        int mvn = 0, counter = 0;
        int ctl = 1, floatyt = 1;
        int dir = 1, boom = 0, win = 0;
        int elm = 0, blastoff = 0;
        int mh = 0, flym = 0;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            t.Tick += T_Tick;
            t.Start();
            t.Interval = 50;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            mvn = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            mvn = 1;

            if (e.KeyCode == Keys.Up)
            {
                if(xhero< ladder.img.Width - 50 && yhero > ladder.y)
                {
                    yhero -= 25;
                }
            }

            if(e.KeyCode == Keys.Space)
            {
                if (ctl == 0 && jframe == 0)
                {
                    jframe = 0;
                }
                if (jframe < 7 && jframe > 3)
                {
                    jframe = 0;
                }
                ctl = 0;
            }

            if (e.KeyCode == Keys.Left)
            {
                xhero -= 20;
                IwhicheFrame ++;
                if (IwhicheFrame == hero.Count)
                {
                    IwhicheFrame = 0;
                }
                dir = 0;
            }
            if (e.KeyCode == Keys.Right)
            {
                xhero += 20;
                IwhicheFrame++;

                if (IwhicheFrame == hero.Count)
                {
                    IwhicheFrame = 0;
                }
                dir = 1;
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(this.Width, this.Height);
            bg = new Bitmap("D6fip+ (4).png");

            fly = new actor();
            fly.img = new Bitmap("fly.png");
            fly.img.MakeTransparent(fly.img.GetPixel(0, 0));
            fly.x = this.Width / 2;
            fly.y = 0;

            ladder = new actor();
            ladder.img = new Bitmap("Preview_69.png");
            ladder.img.MakeTransparent(ladder.img.GetPixel(0, 0));
            ladder.x = 0;
            ladder.y = this.Height - ladder.img.Height - 90;

            elevator = new actor();
            elevator.img = new Bitmap("elevator.png");
            elevator.img.MakeTransparent(elevator.img.GetPixel(0, 0));
            elevator.x = this.Width / 2 - elevator.img.Width / 2;
            elevator.y = this.Height - elevator.img.Height-100;

            rooml = new actor();
            rooml.img = new Bitmap("rooml.png");
            rooml.x = -10;
            rooml.y = this.Height / 2 - 50;

            roomr = new actor();
            roomr.img = new Bitmap("roomr.png");
            roomr.x = this.Width - roomr.img.Width + 200;
            roomr.y = this.Height / 2 - 50;

            roc = new actor();
            roc.img = new Bitmap("rc.png");
            roc.img.MakeTransparent(roc.img.GetPixel(0, 0));
            roc.x = this.Width - roc.img.Width - 20;
            roc.y = roomr.y + 136;

            star = new actor();
            star.img = new Bitmap("star.png");
            star.img.MakeTransparent(roc.img.GetPixel(0, 0));
            star.x = this.Width - roc.img.Width - 60;
            star.y = roomr.y -20-star.img.Height;

            floaty = new actor();
            floaty.img = new Bitmap("floaty.png");
            floaty.img.MakeTransparent(floaty.img.GetPixel(0, 0));
            floaty.x = rooml.img.Width ;
            floaty.y = rooml.y - floaty.img.Height - 6;

            floor = new actor();
            floor.x = 0;
            floor.y = this.Height - 92;
            floor.img = new Bitmap("floor.png");

            hstill = new actor();
            hstill.img = new Bitmap("still.jpg");
            hstill.img.MakeTransparent(hstill.img.GetPixel(0, 0));

            portal = new actor();
            portal.img = new Bitmap("portal.png");
            portal.img.MakeTransparent(portal.img.GetPixel(0, 0));
            portal.x = 0;

            blast = new actor();
            blast.img = new Bitmap("blast.png");
            blast.img.MakeTransparent(portal.img.GetPixel(0, 0));
            blast.x = this.Width/4;
            blast.y = fly.img.Height;

            laser = new actor();
            laser.img = new Bitmap("laser.png");
            laser.img.MakeTransparent(laser.img.GetPixel(0, 0));
            laser.x = this.Width / 2-200;
            laser.y = rooml.y - laser.img.Height;

            for (int i = 1; i < 9; i++)
            {
                k1 = new actor();
                k1.img = new Bitmap("exp (" + i.ToString() + ").jpg");
                k1.img.MakeTransparent(k1.img.GetPixel(0, 0));
                k1.x = rooml.img.Width;
                k1.y = rooml.y - floaty.img.Height - 6;
                exp.Add(k1);
            }

            for (int i = 1; i < 7; i++)
            {
                k1 = new actor();
                k1.img = new Bitmap("image_part_00" + i.ToString() + ".jpg");
                k1.img.MakeTransparent(k1.img.GetPixel(0, 0));
                k1.x = k1.img.Width;
                k1.y = floor.y - k1.img.Height;

                hero.Add(k1);
            }

            for (int i = 1; i < 10; i++)
            {
                k1 = new actor();
                k1.img = new Bitmap("jump" + i.ToString() + ".jpg");
                k1.img.MakeTransparent(k1.img.GetPixel(0, 0));
                k1.x = k1.img.Width;
                k1.y = floor.y - k1.img.Height;

                heroj.Add(k1);
            }
            for (int i = 1; i < 10; i++)
            {
                k1 = new actor();
                k1.img = new Bitmap("rjump (" + i.ToString() + ").jpg");
                k1.img.MakeTransparent(k1.img.GetPixel(0, 0));
                k1.x = k1.img.Width;
                k1.y = floor.y - k1.img.Height;

                rheroj.Add(k1);
            }

            rhstill = new actor();
            rhstill.img = new Bitmap("rstill.jpg");
            rhstill.img.MakeTransparent(rhstill.img.GetPixel(0, 0));

            for (int i = 1; i < 7; i++)
            {
                k1 = new actor();
                k1.img = new Bitmap("rimage_part_00" + i.ToString() + ".jpg");
                k1.img.MakeTransparent(k1.img.GetPixel(0, 0));
                k1.x = k1.img.Width;
                k1.y = floor.y - k1.img.Height;


                rhero.Add(k1);

            }

            xhero = hero[0].img.Width;
            yhero = floor.y - k1.img.Height;
            Drawdoublebuffer(this.CreateGraphics());
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (laserdir == 0)
            {
                laser.x -= 7;
                if (laser.x < 50)
                {
                    laserdir = 1;
                }
            }
            else
            {
                laser.x += 7;
                if (laser.x > this.Width / 2 - 200)
                {
                    laserdir = 0;
                }
            }

            if (fly.x+fly.img.Width/2-5<blast.x&& fly.x + fly.img.Width / 2 + 5 > blast.x)
            {
                blastoff = 1;
            }
            if (blastoff == 1)
            {
                blast.y += 5;
            }

            if (floatyt == 1)
            {
                floaty.y--;
                if(floaty.y < rooml.y - floaty.img.Height - 8)
                {
                    floatyt = 0;
                }
            }
            else
            {
                floaty.y++;
                if (floaty.y > rooml.y - floaty.img.Height)
                {
                    floatyt = 1;
                }
            }
            counter++;
            if (counter == 20)
            {
                Box pnn = new Box();
                pnn.x = this.Width - roc.img.Width - boxim.Width;
                pnn.y = roomr.y + 150;
                lb.Add(pnn);
                counter = 0;
            }
            for (int i = 0; i < lb.Count; i++)
            {
                if (lb[i].x > this.ClientSize.Width /2)
                {
                    lb[i].x -= 10;
                }
                else
                {
                    lb.Remove(lb[i]);
                }
            }

            if (elm == 0)
            {
                elevator.y -= 5;
                if (mh == 1)
                {
                    yhero -= 5;
                }
                if (elevator.y < this.Height / 2)
                {
                    elm = 1;
                }
            }
            else
            {
                elevator.y += 5;
                if (mh == 1)
                {
                    yhero += 5;
                }
                if (elevator.y > this.Height - elevator.img.Height - 100)
                {
                    elm = 0;
                }
            }

            if (fly.x < portal.img.Width / 2)
            {
                flym = 1;
                flycut += 5;
                if(flycut > fly.img.Width)
                {
                    fly.x = fly.x + this.Width - portal.img.Width - flycut;
                    flycut = 0;
                    flym = 0;
                }
            }
            else
            {
                fly.x -= 5;
            }


            if (ctl == 0)
            {
                if (dir == 1)
                {
                    jframe++;
                    xhero += 15;
                    if (jframe < 4)
                    {
                        if (yhero > 0)
                        {
                            yhero -= 20;

                        }
                    }
                    if (jframe > 6)
                    {
                        yhero += 20;
                    }
                    if (jframe == 9)
                    {
                        ctl = 1;
                        jframe = 0;
                    }
                }
                else
                {
                    jframe++;
                    xhero -= 15;
                    if (jframe < 4)
                    {
                        if (yhero > 0)
                        {
                            yhero -= 20;

                        }
                    }
                    if (jframe > 6)
                    {
                        yhero += 20;
                    }
                    if (jframe == 9)
                    {
                        ctl = 1;
                        jframe = 0;
                    }
                }
            }
            else
            {
                //g
                if(yhero + hstill.img.Height > elevator.y-10 && yhero + hstill.img.Height < elevator.y && xhero+70>elevator.x && xhero+50 < elevator.x + elevator.img.Width)
                {
                    mh = 1;
                }
                else
                {
                    mh = 0;
                    if (yhero + hstill.img.Height > roomr.y - 10 && yhero + hstill.img.Height < roomr.y && xhero + 70 > roomr.x && xhero + 50 < roomr.x + roomr.img.Width)
                    {}
                    else
                    {
                        if (yhero + hstill.img.Height > rooml.y - 10 && yhero + hstill.img.Height < rooml.y && xhero + 70 > rooml.x && xhero +50 < rooml.img.Width - 190)
                        {}
                        else
                        {
                            if(yhero + hstill.img.Height > rooml.y+rooml.img.Height-55
                                && yhero + hstill.img.Height < rooml.y+rooml.img.Height-20 && xhero + 70 > rooml.x && xhero + 50 < rooml.img.Width - 190)
                            {}
                            else
                            {
                                if (yhero + hstill.img.Height > roomr.y + roomr.img.Height - 55
                                    && yhero + hstill.img.Height < roomr.y + roomr.img.Height - 20 && xhero + 70 > roomr.x && xhero + 50 < roomr.x + roomr.img.Width)
                                {}
                                else
                                {
                                    if (yhero + hstill.img.Height < floor.y)
                                        yhero += 6;
                                }

                            }
                            
                        }
                    }
                    
                }

            }
             
            Drawdoublebuffer(this.CreateGraphics());

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Drawdoublebuffer(e.Graphics);
        }

        void Drawdoublebuffer(Graphics g) //main
        {
            Graphics g2 = Graphics.FromImage(bitmap);
            Drawscene(g2);
            g.DrawImage(bitmap, 0, 0);
        }
        void Drawscene(Graphics g) //main
        {
            g.Clear(Color.Black);

            g.DrawImage(bg, 0, 0);
            for (int i = 0; i < 8; i++)
            {
                g.DrawImage(floor.img, floor.x + i * 204, floor.y);
            }

            g.DrawImage(elevator.img, elevator.x, elevator.y);
            g.DrawImage(rooml.img, rooml.x, rooml.y);
            g.DrawImage(roomr.img, roomr.x, roomr.y);
            g.DrawImage(portal.img, portal.x, 0);
            g.DrawImage(portal.img, this.Width - portal.img.Width - 20, 0);
            if (blastoff == 1)
            {
                g.DrawImage(blast.img, blast.x, blast.y - 20);
                if (xhero + 50 < blast.x && xhero - 50 + hstill.img.Width > blast.x && yhero + hstill.img.Height > blast.y && yhero < blast.y)
                {
                    xhero = hero[0].img.Width;
                    yhero = floor.y - k1.img.Height;
                    blastoff = 0;
                    boom2 = 1;
                }
                if (blast.y > this.Height/2+82)
                {
                    blastoff = 0;
                    boom2 = 1;
                }
            }
            if (boom2 == 1)
            {
                g.DrawImage(exp[bmframe].img, blast.x, blast.y);
                bmframe++;
                if (bmframe == 9)
                {
                    bmframe = 0;
                    boom2 = 0;
                    blast.x = this.Width / 4;
                    blast.y = fly.img.Height;
                }
            }

            if (xhero + 30 < laser.x && xhero - 50 + hstill.img.Width > laser.x && yhero + hstill.img.Height > laser.y && yhero < laser.y)
            {
                xhero = hero[0].img.Width;
                yhero = floor.y - k1.img.Height;
            }

                if (boom == 0)
            {
                g.DrawImage(floaty.img, floaty.x, floaty.y);
            }
            else
            {
                g.DrawImage(exp[bmframe].img, exp[boom].x, exp[boom].y);
                bmframe++;
                if (bmframe == 9)
                {
                    bmframe = 0;
                    boom = 0;
                }
            }
            //g.DrawImage(fly.img, fly.x, fly.y);
            g.DrawImage(fly.img, new Rectangle(fly.x, fly.y, fly.img.Width, fly.img.Height),
                                       new Rectangle(flycut, 0, fly.img.Width, fly.img.Height),
                                       GraphicsUnit.Pixel);
            if (flym == 1)
            {
                g.DrawImage(fly.img, new Rectangle(fly.x + this.Width - portal.img.Width-flycut, fly.y, flycut, fly.img.Height),
                           new Rectangle(0, 0, flycut, fly.img.Height),
                           GraphicsUnit.Pixel);
            }
            g.DrawImage(ladder.img, ladder.x, ladder.y);
            g.DrawImage(roc.img, roc.x, roc.y);
            g.DrawImage(laser.img, laser.x, laser.y);
            g.DrawImage(star.img, star.x, star.y);

            for (int i = 0; i < lb.Count; i++)
            {
                g.DrawImage(boxim, lb[i].x, lb[i].y);
                if(xhero+50< lb[i].x&& xhero - 50+hstill.img.Width > lb[i].x&&yhero+hstill.img.Height> lb[i].y&& yhero < lb[i].y)
                {
                    xhero = hero[0].img.Width;
                    yhero = floor.y - k1.img.Height;
                }
            }
            if (xhero + 15 <floaty.x && xhero - 50 + hstill.img.Width > floaty.x && yhero + hstill.img.Height > floaty.y && yhero < floaty.y)
            {
                xhero = hero[0].img.Width;
                yhero = floor.y - k1.img.Height;
                boom = 1;
            }

            if (xhero < 0)
                xhero = 0;
            if (xhero > this.Width - hstill.img.Width)
                xhero = this.Width - hstill.img.Width;

            if (ctl == 0)
            {
                if (dir == 1)
                {
                    g.DrawImage(heroj[jframe].img, xhero, yhero);
                }
                else
                {
                    g.DrawImage(rheroj[jframe].img, xhero, yhero);
                }
            }
            else
            {
                if (dir == 1)
                {
                    if (mvn == 1)
                    {
                        g.DrawImage(hero[IwhicheFrame].img, xhero, yhero);
                    }
                    else
                    {
                        g.DrawImage(hstill.img, xhero, yhero);
                    }
                }
                else
                {
                    if (mvn == 1)
                    {
                        g.DrawImage(rhero[IwhicheFrame].img, xhero, yhero);
                    }
                    else
                    {
                        g.DrawImage(rhstill.img, xhero, yhero);
                    }
                }
            }
            if (xhero + 15 < star.x && xhero - 50 + hstill.img.Width > star.x && yhero + hstill.img.Height > star.y && yhero < star.y)
            {
                win = 1;
            }            
            if (win == 1)
            {
                g.DrawImage(end, 0,0);
            }
        }

        class actor
        {
            public int x, y;
            public Bitmap img;
        }
        public class Box
        {
            public int x;
            public int y;
            public int speed;
        }
    }
}
