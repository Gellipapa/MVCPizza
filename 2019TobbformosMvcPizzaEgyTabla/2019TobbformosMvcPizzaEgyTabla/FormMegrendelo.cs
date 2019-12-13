using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TobbformosPizzaAlkalmazasEgyTabla.Repository;
using TobbformosPizzaAlkalmazasEgyTabla.Model;
using System.Diagnostics;

namespace _2019TobbformosMvcPizzaEgyTabla
{
    public partial class FormPizzaFutarKft : Form
    {
        /// <summary>
        /// Megrendelőket tartalmazó adattábla
        /// </summary>
        private DataTable ordersDT = new DataTable();
        /// <summary>
        /// Tárolja a megrendelőket listában
        /// </summary>
        private Repository repomegrendelo = new Repository();

        bool ujAdatfelvitelMegrendelo = false;

        private void buttonMegrendeloBetoltes_Click(object sender, EventArgs e)
        {
            //Adatbázisban megrendelo tábla kezelése
            RepositoryDatabaseTableMegrendelo rdtm = new RepositoryDatabaseTableMegrendelo();
            //A repo-ba lévő megrendelo listát feltölti az adatbázisból
            repomegrendelo.setOrders(rdtm.getOrdersFromDatabaseTable());
            frissitMegrendeloAdatokkalDataGriedViewt();
            beallitMegrendeloDataGriViewt();
            beallitMegrendeloGombokat();
            //javítani mert nem fog müködni ha átírom
            dataGridViewOrders.SelectionChanged += dataGridViewOrders_SelectionChanged;
        }
        /// <summary>
        /// Megrendelo panel hívó metódus
        /// </summary>
        public void beallitMegrendeloGombokat()
        {
            panelMegrendloAdatokPanel.Visible = false;
            panelMegrendeloModositTorolGombok.Visible = false;
            if (dataGridViewOrders.SelectedRows.Count != 0)
                buttonUjMegrendelo.Visible = false;
            else
                buttonUjMegrendelo.Visible = true;
        }
        /// <summary>
        /// DataGridview Kijelölési része
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (ujAdatfelvitelMegrendelo)
            {
                beallitMegrendeloGombokatKattintaskor();
            }
            if (dataGridViewOrders.SelectedRows.Count == 1)
            {
                panelMegrendloAdatokPanel.Visible = true;
                panelMegrendeloModositTorolGombok.Visible = true;
                buttonUjMegrendelo.Visible = true;
                textBoxOrdersID.Text =
                    dataGridViewOrders.SelectedRows[0].Cells[0].Value.ToString();
                textBoxOrderName.Text =
                    dataGridViewOrders.SelectedRows[0].Cells[1].Value.ToString();
                textBoxOrderAddress.Text =
                    dataGridViewOrders.SelectedRows[0].Cells[2].Value.ToString();
                textBoxOrdersPrice.Text =
                    dataGridViewOrders.SelectedRows[0].Cells[3].Value.ToString();
            }
            else
            {
                panelMegrendloAdatokPanel.Visible = false;
                panelMegrendeloModositTorolGombok.Visible = false;
                buttonUjMegrendelo.Visible = false;
            }
        }
        /// <summary>
        /// Modosit és töröl gomb meghívási metódus
        /// </summary>
        private void beallitMegrendeloGombokatKattintaskor()
        {
            ujAdatfelvitelMegrendelo = false;
            buttonUjMegrendelo.Visible = false;
            buttonMegsemMegrendelo.Visible = false;
            panelMegrendeloModositTorolGombok.Visible = true;
            errorProviderMegrendeloName.Clear();
            errorProviderMegrendeloAddress.Clear();
            errorProviderMegrendeloPrice.Clear();
        }
        /// <summary>
        /// Adatokat frissit datagridviewba
        /// </summary>
        private void frissitMegrendeloAdatokkalDataGriedViewt()
        {
            ordersDT = repomegrendelo.getMegrendeloDataTableFromList();
            dataGridViewOrders.DataSource = null;
            dataGridViewOrders.DataSource = ordersDT;
        }
        /// <summary>
        /// beállítja a datagridview oszlop neveit
        /// </summary>
        private void beallitMegrendeloDataGriViewt()
        {
            ordersDT.Columns[0].ColumnName = "Azonosító";
            ordersDT.Columns[0].Caption = "Megrendelő azonosító";
            ordersDT.Columns[1].ColumnName = "Név";
            ordersDT.Columns[1].Caption = "Megrendelő név";
            ordersDT.Columns[2].ColumnName = "Cím";
            ordersDT.Columns[2].Caption = "Megrendelő címe";
            ordersDT.Columns[3].ColumnName = "Ára";
            ordersDT.Columns[3].Caption = "Pizza ár";

            dataGridViewOrders.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.AllowUserToDeleteRows = false;
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.MultiSelect = false;
        }
        /// <summary>
        /// Törlés gomb 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTorolMegrendelot_Click(object sender, EventArgs e)
        {



            torolHibauzenetet();
            if ((dataGridViewOrders.Rows == null) ||
                (dataGridViewOrders.Rows.Count == 0))
                return;
            //A felhasználó által kiválasztott sor a DataGridView-ban            
            int sor = dataGridViewOrders.SelectedRows[0].Index;
            if (MessageBox.Show(
                "Valóban törölni akarja a sort?",
                "Törlés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                //1. törölni kell a listából
                int id = -1;
                if (!int.TryParse(
                         dataGridViewOrders.SelectedRows[0].Cells[0].Value.ToString(),
                         out id))
                    return;
                try
                {
                    repomegrendelo.deleteMegrendeloFromList(id);
                }
                catch (RepositoryExceptionCantDelete recd)
                {
                    kiirHibauzenetet(recd.Message);
                    Debug.WriteLine("A megrendelő törlése nem sikerült, nincs a listába!");
                }
                //2. törölni kell az adatbázisból
                RepositoryDatabaseTableMegrendelo rdtm = new RepositoryDatabaseTableMegrendelo();
                try
                {
                    rdtm.deleteOrderFromDatabase(id);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                //3. frissíteni kell a DataGridView-t  
                frissitMegrendeloAdatokkalDataGriedViewt();
                if (dataGridViewOrders.SelectedRows.Count <= 0)
                {
                    buttonUjMegrendelo.Visible = true;
                }
                beallitMegrendeloDataGriViewt();
            }

        }

        
        /// <summary>
        /// Módosit gomb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMegrendeloModosit_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderMegrendeloName.Clear();
            errorProviderMegrendeloAddress.Clear();
            errorProviderMegrendeloPrice.Clear();
            try
            {
                Megrendelo2 modosult = new Megrendelo2(
                    Convert.ToInt32(textBoxOrdersID.Text),
                    textBoxOrderName.Text,
                    textBoxOrderAddress.Text,
                    textBoxOrdersPrice.Text
                    );
                int azonosito = Convert.ToInt32(textBoxOrdersID.Text);
                //1. módosítani a listába
                try
                {
                    repomegrendelo.updateMegrendeloInList(azonosito, modosult);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }
                //2. módosítani az adatbáziba
                RepositoryDatabaseTableMegrendelo rdtm = new RepositoryDatabaseTableMegrendelo();
                try
                {
                    rdtm.updateMegrendeloInDatabase(azonosito, modosult);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                //3. módosítani a DataGridView-ban           
                frissitMegrendeloAdatokkalDataGriedViewt();
            }
            catch (ModelPizzaNotValidNameExeption nvn)
            {
                errorProviderMegrendeloName.SetError(textBoxOrderName, nvn.Message);
            }

            catch(ModelMegrendeloNotValidAddressException nve)
            {
                errorProviderMegrendeloAddress.SetError(textBoxOrderAddress, nve.Message);
            }
            catch (ModelPizzaNotValidPriceExeption nvp)
            {
                errorProviderMegrendeloPrice.SetError(textBoxOrdersPrice, nvp.Message);
            }
            catch (RepositoryExceptionCantModified recm)
            {
                kiirHibauzenetet(recm.Message);
                Debug.WriteLine("Módosítás nem sikerült, a megrendelő nincs a listába!");
            }
            catch (Exception ex)
            { }
        }
        /// <summary>
        /// Uj megrendelési gomb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUjmegrendeloMentese_Click(object sender, EventArgs e)
        {
            torolHibauzenetet();
            errorProviderMegrendeloName.Clear();
            errorProviderMegrendeloAddress.Clear();
            errorProviderMegrendeloPrice.Clear();
            try
            {
                Megrendelo2 ujMegrendelo = new Megrendelo2(
                    Convert.ToInt32(textBoxOrdersID.Text),
                    textBoxOrderName.Text,
                    textBoxOrderAddress.Text,
                    textBoxOrdersPrice.Text
                    );
                int azonosito = Convert.ToInt32(textBoxOrdersID.Text);
                //1. Hozzáadni a listához
                try
                {
                    repomegrendelo.addMegrendeloToList(ujMegrendelo);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                    return;
                }
                //2. Hozzáadni az adatbázishoz
                RepositoryDatabaseTableMegrendelo rdtm = new RepositoryDatabaseTableMegrendelo();
                try
                {
                    rdtm.insertMegrendeloToDatabase(ujMegrendelo);
                }
                catch (Exception ex)
                {
                    kiirHibauzenetet(ex.Message);
                }
                //3. Frissíteni a DataGridView-t
                beallitGombokatUjMegrendeloMegsemEsMentes();
                frissitMegrendeloAdatokkalDataGriedViewt();
                if (dataGridViewOrders.SelectedRows.Count == 1)
                {
                    beallitMegrendeloDataGriViewt();
                }

            }
            catch (ModelPizzaNotValidNameExeption nvn)
            {
                errorProviderMegrendeloName.SetError(textBoxOrderName, nvn.Message);
            }
            catch (ModelMegrendeloNotValidAddressException nve)
            {
                errorProviderMegrendeloAddress.SetError(textBoxOrderAddress, nve.Message);
            }
            catch (ModelPizzaNotValidPriceExeption nvp)
            {
                errorProviderMegrendeloPrice.SetError(textBoxOrdersPrice, nvp.Message);
            }
            catch (Exception ex)
            {
            }

        }
        /// <summary>
        /// uj megrendelo panel előhozzása
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUjMegrendelo_Click(object sender, EventArgs e)
        {
            ujAdatfelvitelMegrendelo = true;
            beallitGombokatTextboxokatUjMegrendelo();
            buttonMegsemMegrendelo.Visible = true;
            int ujMegrendeloAzonosito = repomegrendelo.getNextMegrendeloId();
            textBoxOrdersID.Text = ujMegrendeloAzonosito.ToString();
        }
        /// <summary>
        /// uj megrendelőnél lévő gomb üres textboxokat készít
        /// </summary>
        private void beallitGombokatTextboxokatUjMegrendelo()
        {
            panelMegrendloAdatokPanel.Visible = true;
            panelMegrendeloModositTorolGombok.Visible = false;
            textBoxOrderName.Text = string.Empty;
            textBoxOrderAddress.Text = string.Empty;
            textBoxOrdersPrice.Text = string.Empty;
        }
        /// <summary>
        /// megsem gomb
        /// </summary>
        private void beallitGombokatUjMegrendeloMegsemEsMentes()
        {
            //if ((dataGridViewOrders.Rows != null) &&
            //    (dataGridViewOrders.Rows.Count > 0))
            //    dataGridViewOrders.Rows[0].Selected = true;
            //buttonUjMegrendelo.Visible = false;
            //panelMegrendloAdatokPanel.Visible = false;
            //buttonMegsemMegrendelo.Visible = false;
            //panelMegrendeloModositTorolGombok.Visible = false;
            //ujAdatfelvitelMegrendelo = false;

            //textBoxOrderName.Text = string.Empty;
            //textBoxOrderAddress.Text = string.Empty;
            //textBoxOrdersPrice.Text = string.Empty;

        }

        private void textBoxOrderName_TextChanged(object sender, EventArgs e)
        {
            kezelMegrendeloUjMegsemGombokat();
        }

        private void textBoxOrderAddress_TextChanged(object sender, EventArgs e)
        {
            kezelMegrendeloUjMegsemGombokat();
        }

        private void textBoxOrdersPrice_TextChanged(object sender, EventArgs e)
        {
            kezelMegrendeloUjMegsemGombokat();
        }
        /// <summary>
        /// kezel gomb megjelenítést ha textbox nem üres
        /// </summary>
        private void kezelMegrendeloUjMegsemGombokat()
        {
            if (ujAdatfelvitelMegrendelo == false)
                return;
            if ((textBoxOrderName.Text != string.Empty) ||
                (textBoxOrderAddress.Text != string.Empty)||
                (textBoxOrdersPrice.Text != string.Empty))
            {
                buttonUjmegrendeloMentese.Visible = true;
                buttonMegsemMegrendelo.Visible = true;
            }
            else
            {
                buttonUjmegrendeloMentese.Visible = false;
                buttonMegsemMegrendelo.Visible = false;
            }
        }

        private void buttonMegsemMegrendelo_Click(object sender, EventArgs e)
        {
            if ((dataGridViewOrders.Rows != null) &&
                (dataGridViewOrders.Rows.Count > 0))
                dataGridViewOrders.Rows[0].Selected = true;
            buttonUjMegrendelo.Visible = true;
            panelMegrendloAdatokPanel.Visible = false;
            buttonMegsemMegrendelo.Visible = false;
            panelMegrendeloModositTorolGombok.Visible = false;
            ujAdatfelvitelMegrendelo = false;

            buttonUjmegrendeloMentese.Visible = false;

            textBoxOrderName.Text = string.Empty;
            textBoxOrderAddress.Text = string.Empty;
            textBoxOrdersPrice.Text = string.Empty;
        }





    }
}
