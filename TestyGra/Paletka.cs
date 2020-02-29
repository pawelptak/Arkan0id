using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestyGra
{
    public class Paletka : Object
    {
           
        public void Ruch(int szerOkna, int wysOkna, int opcja) //metoda przyjmuje szerokosc i wysokosc okna aby ustalic granice planszy
        {
         
          switch (opcja){
                case 1:
                    if (X > 0)
                    {                       
                        X -= Speed;
                        BackColor = Color.Red;
                       
                    }
                    break;
                case 2:
                    if ( X <= szerOkna - Width-10)
                    {

                        X += Speed;
                        BackColor = Color.Green;


                    }
                    break;
                default:
                    BackColor = Color.Blue;
                    break;

            }

          
        }

        public Paletka(int x, int y) : base(x, y)
        {
            Speed = 10;
                        
            Width = 80;
            Height = 20;

            x -= Width;
            X = x;
            Y = y;
            
            BackColor = Color.LightGray;
     
        }

    }
}
