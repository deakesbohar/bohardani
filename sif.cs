using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Opera
{
    public partial class Form1 : Form
    {
        class adat
        {
            public string azon {  get; set; }
            public string cim {  get; set; }
            public int ev { get; set; }
            public int dij { get; set; }
            public int jelol { get; set; }
        }
       static List<adat> adatok = new List<adat>() ;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            StreamReader olv = new StreamReader("oscar.csv");
            olv.ReadLine();
            while (!olv.EndOfStream)
            {
                string[] sor = olv.ReadLine().Split(';');
                adat rekord = new adat();
                rekord.azon = sor[0];
                rekord.cim = sor[1];
                rekord.ev = int.Parse(sor[2]);
                rekord.dij = int.Parse(sor[3]);
                rekord.jelol= int.Parse(sor[4]);
                adatok.Add(rekord);
            }
            olv.Close();
            foreach (var adat in adatok)
            {
                ListViewItem elem = new ListViewItem(adat.azon);
                elem.SubItems.Add(adat.cim);
                elem.SubItems.Add(adat.ev.ToString());
                elem.SubItems.Add(adat.dij.ToString());
                elem.SubItems.Add(adat.jelol.ToString());
                listView1.Items.Add(elem);
            }
            button1.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> cimek = new List<string>();
            int beev = int.Parse(textBox1.Text);
            for (int i = 0; i < adatok.Count; i++)
            {
                if (beev==adatok[i].ev)
                {
                    cimek.Add(adatok[i].cim);

                }

            }
            foreach (var item in cimek)
            {
                listBox1.Items.Add(item);
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter iro = new StreamWriter("oscarok.txt");
            foreach (var item in listBox1.Items)
            {
                iro.WriteLine(item);
                
            }
            iro.Close();
            MessageBox.Show("Sikeres fájlbaírás", "Siker");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message = "Biztossan kiszeretne lépni?";
            string title = "Kérdés";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
