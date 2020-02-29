using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TestyGra
{
    public class Level : Form
    {
        Icon ic = Properties.Resources.icon;
        
        protected Ball piuka;
        protected Paletka paleta;
        private Timer timer;
        private int Wid = 911;
        private int Hei = 503;
        private Label blocknum;
        Panel menu;
        private static List<Brick> bloczki;
        private int n_blokow = 0;
        private bool pause = false;
        private bool isOver = false;
        public Level()
        {
            Icon = ic;
            Controls.Clear();
            DoubleBuffered = true;

            Draw_Menu();
            Initialize();

            Paint += Level_Paint;
            KeyDown += Level_KeyDown;
            KeyUp += Level_KeyUp;

            timer = new Timer
            {
                Interval = 1,
                Enabled = true
            };
            timer.Tick += Ruch_Tick;

            BackColor = ColorTranslator.FromHtml("#6699ff");


        }

        private void Initialize()
        {
            blocknum = new Label();
            // FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //usuwa belke gorna
            FormBorderStyle = FormBorderStyle.FixedSingle; //nie mozna zmieniac rozmiaru okna
            MaximizeBox = false;
            MinimizeBox = false;
            bloczki = new List<Brick>();
            Draw_HUD();
            Draw_Blocks(36);

            Width = Wid;
            Height = Hei;

            piuka = new Ball(Width/2, Height-110);
            Random random = new Random(); 
            int r = random.Next(2);
            if (r == 0) piuka.kierPoz = -1; //losowy kierunek poziomy pilki na poczatku
            paleta = new Paletka(Width / 2, Height - 100);
            Controls.Add(blocknum);
            Controls.Add(piuka);
            Controls.Add(paleta);

            // InitializeComponent();
        }

        private void Draw_Blocks(int n)
        {        
            n_blokow = n;
            int start_x = 120;
            int start_y = 10;
            for (int i = 0; i < n; i++)
            {
                Brick blok = new Brick(start_x, start_y);
                bloczki.Add(blok);
                start_x += blok.Width + 10; //odleglosc pozioma miedzy bloczkami     
                if (start_x >= Wid)
                {
                    start_x = 120;
                    start_y += blok.Height+ 10; // odleglosc pionowa miedzy bloczkami
                }

            }

        }
        private void Draw_Menu()
        {
            menu = new Panel();
            menu.BackColor = ColorTranslator.FromHtml("#00004d");
            menu.Width = Wid;
            menu.Height = Hei;
            Controls.Add(menu);
            Label start = new Label();
            start.Dock = DockStyle.Fill;
            start.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            start.ForeColor = ColorTranslator.FromHtml("#00FF99");
            start.Text = "PRESS ENTER TO START";
            start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            menu.Controls.Add(start);

        }

        private void Draw_HUD()
        {
            blocknum.Font = new System.Drawing.Font("Bahnschrift Semibold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            blocknum.ForeColor = ColorTranslator.FromHtml("#800040");
            blocknum.Text = n_blokow.ToString();
            blocknum.BackColor = Color.Transparent;     
            blocknum.Location = new Point(Wid - blocknum.Width / 2, Hei - blocknum.Height * 3);
        }


        private void Game_Over()
        {
            isOver = true;
            Controls.Clear();
            menu = new Panel();
            menu.BackColor = Color.Gray;
            menu.Width = Wid;
            menu.Height = Hei;
            Controls.Add(menu);
            Label over = new Label();
            over.Location = new Point(Wid / 2 - over.Width * 3, Hei / 2 - over.Height * 4);
            over.AutoSize = true;
            over.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            over.Text = "GAME OVER";
           
            //over.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            menu.Controls.Add(over);

            Label exit = new Label();   
            exit.AutoSize = true;
            exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exit.Text = "Press X to exit, R to restart";
            exit.Location = new Point(over.Location.X + over.Width / 4, over.Location.Y + over.Height);
            menu.Controls.Add(exit);

        }

        private void Draw_Pause()
        {
            menu = new Panel();
            menu.BackColor = Color.DarkGray;
            menu.Width = Wid;
            menu.Height = Hei;
            Controls.Add(menu);
            Label pauza = new Label();
            pauza.Location = new Point(Wid / 2 - pauza.Width * 2, Hei / 2 - pauza.Height * 4);
            pauza.AutoSize = true;
            pauza.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pauza.ForeColor = ColorTranslator.FromHtml("#333333");
            pauza.Text = "PAUSE";
            menu.Controls.Add(pauza);

            Label exit = new Label();          
            exit.AutoSize = true;
            exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            exit.ForeColor = ColorTranslator.FromHtml("#4d4d4d");
            exit.Text = "Press X to exit";
            exit.Location = new Point(pauza.Location.X + pauza.Width / 4, pauza.Location.Y + pauza.Height);
            menu.Controls.Add(exit);

        }



        private int opcja = 0;
        protected void Ruch_Tick(object sender, EventArgs e)
        {
            if (menu.Visible == false)
            {
                Draw_HUD();       
                piuka.Ruch(Width, Height);
                paleta.Ruch(Width, Height, opcja);
                Physics();
                foreach (Brick br in bloczki)
                {
                    Brick_Physics(br);
                }
                bloczki.RemoveAll(blok => blok.CzyZniszczono()); //usuwa zniczczone bloki

                if (n_blokow == 0 || piuka.Y>=Hei-20) Game_Over();

                Invalidate();
            }


        }

        protected void Level_Paint(object sender, PaintEventArgs e)
        {
            piuka.Draw(piuka.X, piuka.Y);
            paleta.Draw(paleta.X, paleta.Y);

            foreach (Brick b in bloczki)
            {
                b.Draw(b.X, b.Y);
                Controls.Add(b);
            }
        }


        protected void Level_KeyDown(object sender, KeyEventArgs e) //sterowanie paletka
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    opcja = 1;
                    break;
                case Keys.Right:
                    opcja = 2;
                    break;
                case Keys.Escape:
                    if (pause == false && menu.Visible == false)
                    {
                        Draw_Pause();
                        blocknum.Visible = false;
                        pause = true;
                    }
                    else if (pause == true)
                    {
                        menu.Visible = false;
                        blocknum.Visible = true;
                        pause = false;
                    }
                    break;
                case Keys.Enter:
                    if (pause == false && menu.Visible == true)
                    {
                        menu.Visible = false;
                    }
                    break;
                case Keys.X:
                    if (pause == true || isOver == true)
                    {
                        Close();
                    }
                    break;
                case Keys.R:
                    // if (isOver == true)
                    // {
                    menu.Visible = false;
                    Controls.Clear();
                    Initialize();
                    //   }
                    break;
            }
        }

        protected void Level_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    opcja = 0;
                    break;
                case Keys.Right:
                    opcja = 0;
                    break;
            }
        }



        protected bool Physics()
        {
            bool b = false;

            if (!Object.CzyPrzecinaja(piuka, paleta)) return false;
            else if (piuka.Y > paleta.Y)
            {
                piuka.kierPio = 1; //jesli kula trafi w dolna czesc paletki odbij w dol      
            }
            else if (piuka.Y < paleta.Y)
            {
                piuka.kierPio = -1;
            }

            return b;

        }

        protected bool Brick_Physics(Brick br)
        {
            bool b = false;


            if (!Object.CzyPrzecinaja(piuka, br)) return false;
            else if (piuka.Y > br.Y)
            {
                piuka.kierPio = 1; //jesli kula trafi w dolna czesc paletki odbij w dol    
            }
            else if (piuka.Y < br.Y)
            {
                piuka.kierPio = -1;
            }

            if (piuka.X < br.X)
            { //jesli kula trafi w lewa czesc paletki odbij w lewo
                piuka.kierPoz = -1;
                b = true;
            }
            else if (piuka.X > br.X)
            {
                piuka.kierPoz = 1;
                b = true;
            }
            br.zniszczono = true;
            n_blokow--;
            br.Visible = false;


            return b;

        }
    }
}
