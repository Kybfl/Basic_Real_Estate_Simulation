using Microsoft.VisualBasic;

namespace Emlak_Login_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici_ad = textBox_Kullanici.Text;
            int sifre = Convert.ToInt32(textBox_Parola.Text);

            if (Dogrulama(kullanici_ad, sifre))
            {
                Emlak_Arayuz_Form emlakArayuz = new Emlak_Arayuz_Form();
                emlakArayuz.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanýcý Bulunamadý !!");

            }




        }


        private bool Dogrulama(string kullanici_ad, int sifre)
        {
            string filePath = "users.txt";
            string sifre_kontrol = Convert.ToString(sifre);


            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 2)
                    {
                        string fileUsername = parts[0].Trim();
                        string filePassword = parts[1].Trim();

                        if (fileUsername == kullanici_ad && filePassword == sifre_kontrol)
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kullanýcý dosyasý bulunamadý.");
            }

            return false;
        }
    }
}
