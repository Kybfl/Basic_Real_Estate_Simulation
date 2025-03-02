using System;
using System.IO;

namespace Emlak_Library
{
    public enum EmlakTur
    {
        Daire, Bahçeli, Dubleks, Müstakil
    }

    public class Ev
    {
        private int odaSayisi;
        private int katNumarasi;
        private string semt;
        private int metreKare;
        private DateTime yapimTarihi;
        private EmlakTur turu;
        private string evdurum;
        private bool aktif;
       

        public int binaYas => DateTime.Now.Year - yapimTarihi.Year;

        public int Depozito { get; set; }

        public string emlakNumarasi { get; private set; }
        public int Kira { get; set; }
        public int Fiyat { get; set; }

        public int OdaSayisi
        {
            get => odaSayisi;
            set
            {
                if (value < 0)
                {
                    odaSayisi = 0;
                    LogHatasi("Oda sayısı negatif olamaz.");
                }
                else
                {
                    odaSayisi = value;
                    LogKaydi("Oda sayısı başarıyla atandı.");
                }
            }
        }

        public int KatNumarasi
        {
            get => katNumarasi;
            set
            {
                if (value < 0)
                {
                    katNumarasi = 0;
                    LogHatasi("Kat numarası negatif olamaz.");
                }
                else
                {
                    katNumarasi = value;
                    LogKaydi("Kat numarası başarıyla atandı.");
                }
            }
        }

        public int MetreKare
        {
            get => metreKare;
            set
            {
                if (value <= 0)
                {
                    metreKare = 0;
                    LogHatasi("Metrekare değeri pozitif olmalıdır.");
                }
                else
                {
                    metreKare = value;
                    LogKaydi("Metrekare başarıyla atandı.");
                }
            }
        }

        private void LogHatasi(string mesaj)
        {
            string logDosyasi = "log.txt";
            string logMesaji = $"{DateTime.Now}: Hata - {mesaj}";

            try
            {
                using (StreamWriter sw = new StreamWriter(logDosyasi, true))
                {
                    sw.WriteLine(logMesaji);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log kaydı yapılamadı: " + ex.Message);
            }
        }

        private void LogKaydi(string mesaj)
        {
            string logDosyasi = "log.txt";
            string logMesaji = $"{DateTime.Now}: {mesaj}";

            try
            {
                using (StreamWriter sw = new StreamWriter(logDosyasi, true))
                {
                    sw.WriteLine(logMesaji);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log kaydı yapılamadı: " + ex.Message);
            }
        }
        public int FiyatHesapla()
        {
            int katsayi = 200;
            string dosyaYol_EvFiyati = "ev_fiyat.txt";

            if (File.Exists(dosyaYol_EvFiyati))
            {
                katsayi = Convert.ToInt32(File.ReadAllText(dosyaYol_EvFiyati));
            }
            return katsayi * odaSayisi;
        }

        public Ev(string emlaknumarasi, int odaSayisi, int katNumarasi, string semt, int metreKare, DateTime yapimTarihi, bool aktif, EmlakTur turu,string evdurum)
        {
            this.emlakNumarasi = Guid.NewGuid().ToString();
            this.OdaSayisi = odaSayisi;
            this.KatNumarasi = katNumarasi;
            this.semt = semt;
            this.MetreKare = metreKare;
            this.yapimTarihi = yapimTarihi;
            this.turu = turu;
            this.aktif = aktif;
            this.evdurum = evdurum;
            
        }

        public virtual string EvBilgileri()
        {
            
            return $"{emlakNumarasi}:{OdaSayisi}:{KatNumarasi}:{semt}:{MetreKare}:{binaYas}:{(aktif ? "Evet" : "Hayır")}:{evdurum}:{turu}";
        }

    }

    public class KiralikEv : Ev
    {
        public KiralikEv(string emlakNumarasi, int odaSayisi, int katNumarasi, string semt, int metreKare, DateTime yapimTarihi,bool aktif, int Kira, int Depozito, EmlakTur turu, string evdurum)
            : base(emlakNumarasi,odaSayisi, katNumarasi, semt, metreKare, yapimTarihi, aktif, turu, evdurum)
        {
            this.Depozito = Depozito;
            this.Kira = Kira;
        }

        public override string EvBilgileri()
        {
            return base.EvBilgileri() + $":{Kira}:{Depozito}:0";
        }
    }

    public class SatilikEv : Ev
    {
        public SatilikEv(string emlakNumarasi, int odaSayisi, int katNumarasi, string semt, int metreKare, DateTime yapimTarihi,bool aktif, int Fiyat, EmlakTur turu,string evdurum)
            : base(emlakNumarasi, odaSayisi, katNumarasi, semt, metreKare, yapimTarihi, aktif, turu,evdurum)
        {
            this.Fiyat = Fiyat;
        }

        public override string EvBilgileri()
        {
            return base.EvBilgileri() + $":0:0:{Fiyat}";
        }
    }
}
