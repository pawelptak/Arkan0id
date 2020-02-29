using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestyGra
{
    public class Ball : Object
    {

        public int kierPoz = 1;
        public int kierPio = -1;
        override public void Ruch(int szerOkna, int wysOkna) //metoda przyjmuje szerokosc i wysokosc okna aby ustalic granice planszy
        {
            //  Width = Wid;
            //  Height = Hei;
            // Image = Image.FromFile("C:/Users/PC/source/repos/TestyGra/TestyGra/Images/kula.PNG");

            X = X + Speed * kierPoz;
            Y = Y + Speed * kierPio;
            if (X + Width >= szerOkna - 10 || X < 0) kierPoz *= -1; //wychodzi za granice troche
            if (Y + Height >= wysOkna || Y < 0) kierPio *= -1;

        }

        public Ball(int x, int y) : base(x, y) //przyjmuje wspolrzedne poczatkowe pilki
        {
            BackColor = Color.Red;
            Width = 20;
            Height = 20;
            Speed = 5;

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
    }
}
