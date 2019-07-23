using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestyGra
{
    public class Object : PictureBox
    {

        public int Speed { get; set; } = 0;
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
     
        public int SrodekX { get; set; } 
        public int SrodekY { get; set; }

        public Object(int x, int y)
        {
            X = x;
            Y = y;                
        }

        public void Draw(int x, int y) //rysuje obiekt w miejscu o zadanych wspolrzednych
        {

            X = x;
            Y = y;

            SrodekX = X + Width / 2;
            SrodekY = Y + Height / 2;

            Location = new Point(X, Y);
            SizeMode = PictureBoxSizeMode.Zoom;
        }

        virtual public void Ruch(int szerOkna, int wysOkna) //metoda przyjmuje szerokosc i wysokosc okna aby ustalic granice planszy
        {
            SrodekX = X + Width / 2;
            SrodekY = Y + Height / 2;

        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        public static bool CzyPrzecinaja(Object a, Object b)
        { //sprawdza czy obiekty sie przecinaja
            
            return a.Right >= b.Left && a.Left <= b.Right
                && a.Bottom >= b.Top && a.Top <= b.Bottom;
        }
    }
}
