using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestyGra
{
    public partial class Menu : Form
    {
        public bool start = false;
        public Menu()
        {
            InitializeComponent();
        }

        public void Label1_Click(object sender, EventArgs e)
        {
            start = true;
            PrzyciskStart.ForeColor = Color.Blue;
            Visible = false;

        }
    }
}
