using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {
        public class JsonResult
        {
            public int ID { get; set; }
            public string NAME { get; set; }
            public string PSWD { get; set; }
            public bool ADMIN { get; set; }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //QUIT
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OK
            try
            {
                string html = string.Empty;
                string url = @"http://localhost:8080/users";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                }

                string file = @"C:/Users/Projects/Downloads/Login/certificate.pem";
                X509Certificate cert = new X509Certificate();
                cert.Import(file);
                request.ClientCertificates.Add(cert);

                var result = JsonConvert.DeserializeObject<List<JsonResult>>(html);
                bool found = false;
                foreach(var x in result) {
                    if(x.NAME == usr_txt.Text && x.PSWD == pwd_txt.Text)
                    {
                        found = true;
                        MessageBox.Show("Your login info is correct!", "Logged in", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (x.ADMIN)
                        {
                            Admin window = new Admin();
                            window.Show();
                            Hide();
                        }
                        else
                        {
                            User window = new User();
                            window.Show();
                            Hide();
                        }
                     break;
                    }
                }
                if(!found)
                {
                    MessageBox.Show("Your login info is wrong.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            //HEKA
            System.Diagnostics.Process.Start("https://hekaschoolproject.wixsite.com/heka");
        }
    }
}
