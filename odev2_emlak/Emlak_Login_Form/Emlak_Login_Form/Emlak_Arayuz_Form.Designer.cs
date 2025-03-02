namespace Emlak_Login_Form
{
    partial class Emlak_Arayuz_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_evekle = new Button();
            Emlak_Liste = new DataGridView();
            button1 = new Button();
            Column_emlaknumara = new DataGridViewTextBoxColumn();
            Column_odasayisi = new DataGridViewTextBoxColumn();
            Column_katnumara = new DataGridViewTextBoxColumn();
            Column_semt = new DataGridViewTextBoxColumn();
            Column_metrekare = new DataGridViewTextBoxColumn();
            Column_binayaş = new DataGridViewTextBoxColumn();
            Column_aktif = new DataGridViewTextBoxColumn();
            Column_evdurum = new DataGridViewTextBoxColumn();
            Column_evtur = new DataGridViewTextBoxColumn();
            Column_kira = new DataGridViewTextBoxColumn();
            Column_depozito = new DataGridViewTextBoxColumn();
            Column_fiyat = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Emlak_Liste).BeginInit();
            SuspendLayout();
            // 
            // button_evekle
            // 
            button_evekle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button_evekle.Location = new Point(77, 422);
            button_evekle.Name = "button_evekle";
            button_evekle.Size = new Size(152, 43);
            button_evekle.TabIndex = 1;
            button_evekle.Text = "Ev Ekle";
            button_evekle.UseVisualStyleBackColor = true;
            button_evekle.Click += button_evekle_Click;
            // 
            // Emlak_Liste
            // 
            Emlak_Liste.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Emlak_Liste.Columns.AddRange(new DataGridViewColumn[] { Column_emlaknumara, Column_odasayisi, Column_katnumara, Column_semt, Column_metrekare, Column_binayaş, Column_aktif, Column_evdurum, Column_evtur, Column_kira, Column_depozito, Column_fiyat });
            Emlak_Liste.Location = new Point(77, 12);
            Emlak_Liste.Name = "Emlak_Liste";
            Emlak_Liste.Size = new Size(1240, 391);
            Emlak_Liste.TabIndex = 2;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Location = new Point(1091, 422);
            button1.Name = "button1";
            button1.Size = new Size(226, 43);
            button1.TabIndex = 1;
            button1.Text = "Listeyi Güncelle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_listegüncelle_Click;
            // 
            // Column_emlaknumara
            // 
            Column_emlaknumara.Frozen = true;
            Column_emlaknumara.HeaderText = "Emlak Numarası";
            Column_emlaknumara.Name = "Column_emlaknumara";
            Column_emlaknumara.ReadOnly = true;
            // 
            // Column_odasayisi
            // 
            Column_odasayisi.Frozen = true;
            Column_odasayisi.HeaderText = "Oda Sayısı";
            Column_odasayisi.Name = "Column_odasayisi";
            Column_odasayisi.ReadOnly = true;
            // 
            // Column_katnumara
            // 
            Column_katnumara.Frozen = true;
            Column_katnumara.HeaderText = "Kat Numarası";
            Column_katnumara.Name = "Column_katnumara";
            Column_katnumara.ReadOnly = true;
            // 
            // Column_semt
            // 
            Column_semt.Frozen = true;
            Column_semt.HeaderText = "Semt";
            Column_semt.Name = "Column_semt";
            Column_semt.ReadOnly = true;
            // 
            // Column_metrekare
            // 
            Column_metrekare.Frozen = true;
            Column_metrekare.HeaderText = "Metrekare";
            Column_metrekare.Name = "Column_metrekare";
            // 
            // Column_binayaş
            // 
            Column_binayaş.Frozen = true;
            Column_binayaş.HeaderText = "Bina Yaşı";
            Column_binayaş.Name = "Column_binayaş";
            Column_binayaş.ReadOnly = true;
            // 
            // Column_aktif
            // 
            Column_aktif.Frozen = true;
            Column_aktif.HeaderText = "Aktif";
            Column_aktif.Name = "Column_aktif";
            Column_aktif.ReadOnly = true;
            // 
            // Column_evdurum
            // 
            Column_evdurum.Frozen = true;
            Column_evdurum.HeaderText = "Ev Durumu";
            Column_evdurum.Name = "Column_evdurum";
            Column_evdurum.ReadOnly = true;
            // 
            // Column_evtur
            // 
            Column_evtur.Frozen = true;
            Column_evtur.HeaderText = "Ev Türü";
            Column_evtur.Name = "Column_evtur";
            Column_evtur.ReadOnly = true;
            // 
            // Column_kira
            // 
            Column_kira.Frozen = true;
            Column_kira.HeaderText = "Kira";
            Column_kira.Name = "Column_kira";
            // 
            // Column_depozito
            // 
            Column_depozito.Frozen = true;
            Column_depozito.HeaderText = "Depozito";
            Column_depozito.Name = "Column_depozito";
            Column_depozito.ReadOnly = true;
            // 
            // Column_fiyat
            // 
            Column_fiyat.Frozen = true;
            Column_fiyat.HeaderText = "Fiyat ";
            Column_fiyat.Name = "Column_fiyat";
            Column_fiyat.ReadOnly = true;
            // 
            // Emlak_Arayuz_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1421, 677);
            Controls.Add(Emlak_Liste);
            Controls.Add(button1);
            Controls.Add(button_evekle);
            Name = "Emlak_Arayuz_Form";
            Text = "Emlak_Arayuz_Form";
            Load += Emlak_Arayuz_Form_Load;
            ((System.ComponentModel.ISupportInitialize)Emlak_Liste).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button_evekle;
        private DataGridView Emlak_Liste;
        private Button button1;
        private DataGridViewTextBoxColumn Column_emlaknumara;
        private DataGridViewTextBoxColumn Column_odasayisi;
        private DataGridViewTextBoxColumn Column_katnumara;
        private DataGridViewTextBoxColumn Column_semt;
        private DataGridViewTextBoxColumn Column_metrekare;
        private DataGridViewTextBoxColumn Column_binayaş;
        private DataGridViewTextBoxColumn Column_aktif;
        private DataGridViewTextBoxColumn Column_evdurum;
        private DataGridViewTextBoxColumn Column_evtur;
        private DataGridViewTextBoxColumn Column_kira;
        private DataGridViewTextBoxColumn Column_depozito;
        private DataGridViewTextBoxColumn Column_fiyat;
    }
}