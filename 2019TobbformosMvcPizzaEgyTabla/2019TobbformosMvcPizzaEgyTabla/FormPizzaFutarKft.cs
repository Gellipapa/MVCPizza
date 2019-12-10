using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _2019TobbformosMvcPizzaEgyTabla
{
    public partial class FormPizzaFutarKft : Form
    {


        public FormPizzaFutarKft()
        {
            InitializeComponent();
            beallitKezdoFormot();
        }

        public void beallitKezdoFormot()
        {
            this.Size = new Size(1024, 768);
            this.Text = "Pizza Futar KFT.";
        }

        private void megrendelőToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlPizzaFutarKFT.SelectTab("tabPageMegrendelok");
        }

        private void futárToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlPizzaFutarKFT.SelectTab("tabPageFutarok");
        }

        private void pizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControlPizzaFutarKFT.SelectTab("tabPagePizzak");
        }

        //private void textBoxPizzaAr_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void textBoxPizzaNev_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void buttonMegsem_Click(object sender, EventArgs e)
        //{

        //}

        //private void buttonUjMentes_Click(object sender, EventArgs e)
        //{

        //}

        //private void buttonUjPizza_Click(object sender, EventArgs e)
        //{

        //}

        //private void buttonMegrendeloBetoltes_Click(object sender, EventArgs e)
        //{

        //}

        //private void buttonUjmegrendeloMentese_Click(object sender, EventArgs e)
        //{

        //}

        //private void buttonUjMegrendelo_Click(object sender, EventArgs e)
        //{

        //}

        private void buttonMegsemMegrendelo_Click(object sender, EventArgs e)
        {

        }

        //private void textBoxOrdersPrice_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void textBoxOrderAddress_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void textBoxOrderName_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void buttonMegrendeloModosit_Click(object sender, EventArgs e)
        //{

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{

        //}

        //private void dataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        //{

        //}
    }
}
