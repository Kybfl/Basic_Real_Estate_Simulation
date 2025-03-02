using Emlak_Library;
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
    public partial class Emlak_Kayit_Form : Form
    {
        
        public Emlak_Kayit_Form()
        {
            InitializeComponent();
        }

        private Ev[] evDizisi = new Ev[1000];
        private int evSayisi = 0;

        private bool Kontrol(out int odaSayisi, out int katNumarasi, out int metreKare)
        {
            odaSayisi = katNumarasi = metreKare = 0;
            bool dogrula = true;

            if (!int.TryParse(textBox_odasayisi.Text, out odaSayisi) || odaSayisi < 0)
            {
                MessageBox.Show("Oda sayısı negatif olamaz.");
                dogrula = false;

                StreamWriter sw = new StreamWriter("odasayisi_negatif.txt", true);
                sw.WriteLine(textBox_odasayisi.Text);
                sw.Close();
            }

            if (!int.TryParse(textBox_katnumarasi.Text, out katNumarasi) || katNumarasi < 0)
            {
                MessageBox.Show("Kat numarası negatif olamaz.");
                dogrula = false;

                StreamWriter sw = new StreamWriter("katnumarasi_negatif.txt", true);
                sw.WriteLine(textBox_katnumarasi.Text);
                sw.Close();
            }

            if (!int.TryParse(textBox_metrekare.Text, out metreKare) || metreKare <= 0)
            {
                MessageBox.Show("Metrekare değeri pozitif olmalıdır.");
                dogrula = false;

                StreamWriter sw = new StreamWriter("metrekare_negatif.txt", true);
                sw.WriteLine(textBox_metrekare.Text);
                sw.Close();
            }

            return dogrula;
        }



        private void Buton_Kaydet(object sender, EventArgs e)
        {
            if (!Kontrol(out int odaSayisi, out int katNumarasi, out int metreKare)) return;

            string emlakNumarasi = Guid.NewGuid().ToString();
            string semt = comboBox_semt.Text;
            DateTime yapimTarihi = dateTimePicker_yapim.Value;
            bool aktif = checkBox_aktif.Checked;
            EmlakTur turu = (EmlakTur)Enum.Parse(typeof(EmlakTur), comboBox_evtür.SelectedItem.ToString());
            string evdurum = comboBox_evdurum.Text;

            if (comboBox_evdurum.SelectedItem.ToString() == "Kiralık")
            {
                if (!int.TryParse(textBox_Kira.Text, out int kira) || !int.TryParse(textBox_depozito.Text, out int depozito))
                {
                    MessageBox.Show("Kira ve depozito değerleri sayısal olmalıdır.");
                    return;
                }

                KiralikEv kiralikEv = new KiralikEv(emlakNumarasi, odaSayisi, katNumarasi, semt, metreKare, yapimTarihi, aktif, kira, depozito, turu, evdurum);
                EvKaydet(kiralikEv);

                MessageBox.Show("Ev başarıyla kaydedildi.");
                this.Close();
            }
            else if (comboBox_evdurum.SelectedItem.ToString() == "Satılık")
            {
                if (!int.TryParse(textBox_Fiyat.Text, out int fiyat))
                {
                    MessageBox.Show("Fiyat değeri sayısal olmalıdır.");
                    return;
                }

                SatilikEv satilikEv = new SatilikEv(emlakNumarasi, odaSayisi, katNumarasi, semt, metreKare, yapimTarihi, aktif, fiyat, turu, evdurum);
                EvKaydet(satilikEv);

                MessageBox.Show("Ev başarıyla kaydedildi.");
                this.Close();
            }
        }

        private void EvKaydet(Ev yeniEv)
        {
            string dosyaAdi = yeniEv is KiralikEv ? "kiralik.txt" : "satilik.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(dosyaAdi, true))
                {
                    sw.WriteLine(yeniEv.EvBilgileri());
                }
                evDizisi[evSayisi] = yeniEv; 
                evSayisi++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosyaya kaydetme sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void Buton_Iptal(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Buton_ilonay(object sender, EventArgs e)
        {
            string il = comboBox_il.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(il))
            {
                MessageBox.Show("Lütfen bir il seçin.");
                return;
            }

            string secilen = $"semtler_{il}.txt";
            if (File.Exists(secilen))
            {
                comboBox_semt.Items.Clear();
                foreach (string semt in File.ReadAllLines(secilen))
                {
                    comboBox_semt.Items.Add(semt);
                }
            }
            else
            {
                MessageBox.Show("Seçilen ile ait semtler bulunamadı!");
            }
        }

        private void Buton_otohesapla(object sender, EventArgs e)
        {
            if (int.TryParse(textBox_odasayisi.Text, out int odasayisi) && File.Exists("ev_fiyat.txt"))
            {
                int katsayi = int.Parse(File.ReadAllText("ev_fiyat.txt"));
                int fiyat = katsayi * odasayisi;
                textBox_Fiyat.Text = fiyat.ToString();

            }
            else
            {
                MessageBox.Show("Oda veya ev fiyat katsayısı geçerli değil.");
            }
        }

        private void Buton_evdurumonay(object sender, EventArgs e)
        {
            if (comboBox_evdurum.SelectedItem?.ToString() == "Kiralık")
            {
                textBox_depozito.ReadOnly = false;
                textBox_Kira.ReadOnly = false;
                textBox_Fiyat.Clear();
                textBox_Fiyat.ReadOnly = true;
                button_otohesapla.Enabled = false;
            }
            else if (comboBox_evdurum.SelectedItem?.ToString() == "Satılık")
            {
                textBox_depozito.Clear();
                textBox_Kira.Clear();
                textBox_depozito.ReadOnly = true;
                textBox_Kira.ReadOnly = true;
                textBox_Fiyat.ReadOnly = false;
                button_otohesapla.Enabled = true;
            }
        }

        private void Emlak_Kayit_Form_Load(object sender, EventArgs e)
        {
            comboBox_evtür.DataSource = Enum.GetValues(typeof(Emlak_Library.EmlakTur));
        }

    }
}
