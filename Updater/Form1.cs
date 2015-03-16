using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            updt();
        }

        public void updt()
        {
            string ultimaModificaS = "";
            label1.Text = "Download in corso.";
            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile("http://maktheeater.altervista.org/Uscite_Manga.exe", "Uscite Manga.exe");
            }
            label1.Text = "Download completato.";

            string url1 = "http://maktheeater.altervista.org/UltimoAggiornamento.html";
            var webGet1 = new HtmlWeb();
            var document1 = webGet1.Load(url1);
            HtmlNodeCollection tl1 = document1.DocumentNode.SelectNodes("//p");
            if (tl1 != null)
            {
                foreach (HtmlAgilityPack.HtmlNode node in tl1)
                {
                    ultimaModificaS = node.InnerText;
                }
            }
            try
            {
                StreamWriter sw = new StreamWriter("UltimaModifica.txt", false, Encoding.GetEncoding(1252));
                sw.Write(ultimaModificaS);
                sw.Close();
            }
            catch (Exception)
            {
            }
            var process = new Process();
            process.StartInfo.FileName = "Uscite Manga.exe";
            process.Start();
            Environment.Exit(0);
        }

        /*
        private void btn_Replace_Click(object sender, EventArgs e)

        {

            str_Source = txtSource.Text;

            str_Destination = txtDestination.Text;

            str_backup = txtBackup.Text;

            if (str_Source == null || str_Destination == null)

            {

                MessageBox.Show("SOUC OR DETNATION FILE PATH MISSING");

            }

            else

            {

                if (File.Exists(str_Source) == true)

                {

                    if (File.Exists(str_Destination) == true)

                    {

                        File.Replace(str_Source, str_Destination, str_backup);

                        MessageBox.Show("Data REPLACED");

                    }

                    else

                    {

                         MessageBox.Show("FILE NOT EXISTED");

                    }

               }

                else

                    MessageBox.Show("SOURCE FILE DOES NOT EXIST");

            }

        }  
        */

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
