﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneOtomasyon
{
    public partial class Hasta_Bilgi_Güncelleme : Form
    {
        public Hasta_Bilgi_Güncelleme()
        {
            InitializeComponent();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            MskTc.Text = "";
            MskTelefon.Text = "";
            CmbCinsiyet.Text = "";
            TxtSifre.Text = "";
        }

        public string Tcno;
        
        SqlBaglanti bgl = new SqlBaglanti();    
        private void Hasta_Bilgi_Güncelleme_Load(object sender, EventArgs e)
        {
            MskTc.Text = Tcno;
            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTelefon.Text = dr[4].ToString();
                CmbCinsiyet.Text = dr[5].ToString();
                TxtSifre.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hastalar set HastaAd = @p1, HastaSoyad = @p2, HastaTel = @p3, HastaCinsiyet = @p4, HastaSifre = @p5 where HastaTc = @p6 ", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut2.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", MskTelefon.Text);
            komut2.Parameters.AddWithValue("@p4", CmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut2.Parameters.AddWithValue("@p6", MskTc.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
