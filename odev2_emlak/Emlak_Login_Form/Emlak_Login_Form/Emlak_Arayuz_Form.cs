using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak_Login_Form
{
    public partial class Emlak_Arayuz_Form : Form
    {
        public Emlak_Arayuz_Form()
        {
            InitializeComponent();
        }

        private void Emlak_Arayuz_Form_Load(object sender, EventArgs e)
        {

        }

        private void button_evekle_Click(object sender, EventArgs e)
        {
            Emlak_Kayit_Form yeniform = new Emlak_Kayit_Form();
            yeniform.Show();

        }

        private void button_listegüncelle_Click(object sender, EventArgs e)
        {
            Emlak_Liste.Rows.Clear();

            if (File.Exists("kiralik.txt"))
            {
                foreach (string line in File.ReadAllLines("kiralik.txt"))
                {
                    string[] bilgiler = line.Split(':');
                    if (bilgiler.Length >= 11) 
                    {
                        string emlakNumarasi = bilgiler[0];
                        int odaSayisi = int.Parse(bilgiler[1]);
                        int katNumarasi = int.Parse(bilgiler[2]);
                        string semt = bilgiler[3];
                        int metreKare = int.Parse(bilgiler[4]);
                        int binaYasi = int.Parse(bilgiler[5]);
                        bool aktif = bilgiler[6] == "Evet";
                        string evdurum = bilgiler[7];
                        string evTuru = bilgiler[8];
                        int kira = int.Parse(bilgiler[9]);
                        int depozito = int.Parse(bilgiler[10]);

                        
                        Emlak_Liste.Rows.Add(emlakNumarasi, odaSayisi, katNumarasi, semt, metreKare, binaYasi, aktif, evdurum, evTuru, kira, depozito, 0);
                    }
                }
            }

            if (File.Exists("satilik.txt"))
            {
                foreach (string line in File.ReadAllLines("satilik.txt"))
                {
                    string[] bilgiler = line.Split(':');
                    if (bilgiler.Length >= 9) 
                    {
                        string emlakNumarasi = bilgiler[0];
                        int odaSayisi = int.Parse(bilgiler[1]);
                        int katNumarasi = int.Parse(bilgiler[2]);
                        string semt = bilgiler[3];
                        int metreKare = int.Parse(bilgiler[4]);
                        int binaYasi = int.Parse(bilgiler[5]);
                        bool aktif = bilgiler[6] == "Evet";
                        string evdurum = bilgiler[7];
                        string evTuru = bilgiler[8];
                        int fiyat = int.Parse(bilgiler[11]);

                        Emlak_Liste.Rows.Add(emlakNumarasi, odaSayisi, katNumarasi, semt, metreKare, binaYasi, aktif, evdurum, evTuru, 0, 0, fiyat);
                    }
                }
            }

        }   


    }
}
