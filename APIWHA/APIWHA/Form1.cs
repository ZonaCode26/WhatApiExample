using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string apikey = "71PS8H834FQA4U9EJEMK";
            string destination = "51977741155";
            string text = "<label>hola burro</label>";
            string response = "";

            Uri uri = new Uri("http://panel.apiwha.com/send_message.php?apikey=" + System.Web.HttpUtility.UrlEncode(apikey) + "&number=" + System.Web.HttpUtility.UrlEncode(destination) + "&text=" + System.Web.HttpUtility.UrlEncode(text));


            HttpWebRequest requestFile = (HttpWebRequest)WebRequest.Create(uri);

            requestFile.ContentType = "application/json";

            HttpWebResponse webResp = requestFile.GetResponse() as HttpWebResponse;

            if (requestFile.HaveResponse)
            {
                if (webResp.StatusCode == HttpStatusCode.OK || webResp.StatusCode == HttpStatusCode.Accepted)
                {
                    StreamReader respReader = new StreamReader(webResp.GetResponseStream(), Encoding.GetEncoding("utf-8"));

                    response = respReader.ReadToEnd(); // This is the APIWHA response		

                    var result = MessageBox.Show(response, "Notice",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                }
            }
        }
    }
}
