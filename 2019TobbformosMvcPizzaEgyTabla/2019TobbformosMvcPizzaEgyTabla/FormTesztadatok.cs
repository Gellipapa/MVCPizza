﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TobbformosPizzaAlkalmazasEgyTabla.Repository;

namespace _2019TobbformosMvcPizzaEgyTabla
{
    public partial class FormPizzaFutarKft : Form
    {
        RepositoryDatabase rd = new RepositoryDatabase();
        RepositoryDatabaseTablePizza rtp = new RepositoryDatabaseTablePizza();
        RepositoryDatabaseTableMegrendelo rdtm = new RepositoryDatabaseTableMegrendelo();

        private void torolHibauzenetet()
        {
            toolStripLabelHibauzenet.ForeColor = Color.Black;
            toolStripLabelHibauzenet.Text = "";
        }
        private void kiirHibauzenetet(string hibauzenet)
        {
            toolStripLabelHibauzenet.ForeColor = Color.Red;
            toolStripLabelHibauzenet.Text = hibauzenet;
        }

        private void adatázbázisLétrehozásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rd.createDatabase();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Adatbázis létrehozási hiba!");
            }
        }

        private void törölAdatbázisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rd.deleteDatabase();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Adatbázis törlési hiba!");
            }
        }

        private void feltöltésTesztadatokkalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rtp.createTablePizza();
                rdtm.createTableMegrendelo();
                rtp.fillPizzasWithTestDataFromSQLCommand();
                rdtm.fillOrdersWithTestDataFromSQLCommand();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Tesztadatok felöltése sikertelen!");
            }
        }

        private void törölTesztadatokatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                torolHibauzenetet();
                rtp.deleteTablePizza();
                rdtm.deleteTableMegrendelo();
            }
            catch (Exception ex)
            {
                kiirHibauzenetet("Táblák törlése sikertelen!");
            }
        }
    }
}
