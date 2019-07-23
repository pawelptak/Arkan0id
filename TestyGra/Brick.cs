using System.Drawing;

namespace TestyGra
{
    public class Brick : Object
    {

        public bool zniszczono = false;
        public Brick(int x, int y) : base(x, y)
        {
  
            Width = 80;
            Height = 30;

            x -= Width;
            X = x;
            Y = y;

            BackColor = Color.OrangeRed;

        }

        public bool CzyZniszczono()
        {
            return zniszczono;
        }
    }
}
