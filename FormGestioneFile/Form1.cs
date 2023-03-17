using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormStrutture
{
    public partial class Form1 : Form
    {
        #region Dichiarazioni
        public struct prodotto
        {
            public string nome;
            public float prezzo;
            public int quantità;
        }
        prodotto p;
        public float somma;
        public string path = @"ListaProdotti.csv";
        #endregion
        #region Funzioni evento
        public Form1()
        {
            InitializeComponent();
        }
        private void agg_Click(object sender, EventArgs e)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(prodString(p));
                    MessageBox.Show("File creato correttamente!");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path, append:true))
                {
                    sw.WriteLine(prodString(p));
                }
            }
            MessageBox.Show("Elemento inserito correttamente!");
        }
       
        private void ext_Click(object sender, EventArgs e)
        {
            var rispExt = MessageBox.Show("È sicuro di voler terminare l'applicazione?", "Uscita programma", MessageBoxButtons.YesNo);
            if (rispExt == DialogResult.Yes)
            {
                var savefile = MessageBox.Show("Salvare modifiche alla lista?", "Salvataggio lista", MessageBoxButtons.YesNo);
                if (savefile == DialogResult.No)
                {
                    File.Delete(path);
                }
                Application.Exit();
            }
        }
        #endregion
        #region Funzioni servizio
        public string prodString(prodotto p)
        {
            p.nome = prodinpt.Text;
            p.prezzo = float.Parse(prezinpt.Text);
            p.quantità = 1;
            return p.nome + "; " + p.prezzo.ToString("0.00") + "; " + p.quantità;
        }
        #endregion
    }
}