using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;


namespace Rest.Window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new RestClient();
            client.BaseUrl = "http://search.twitter.com/search.json";
            var request = new RestRequest();
            request.AddParameter("q", "#g2po");
            var response = client.Execute <TwitterQueryResponse>(request);

            var tweets = JsonConvert.DeserializeObject<List<tweet>>(response.Data.results);

            this.dataGridView1.DataSource = tweets;
        }

    }


    public class TwitterQueryResponse
    {
        public string completed_in { get; set; }
        public string results { get; set; }
       
   }

    public class tweet
    {
        public DateTime created_at { get; set; }
        public string from_user { get; set; }
        public int from_user_id { get; set; }
        public string from_user_id_str { get; set; }
        public string from_user_name { get; set; }
        public string profile_image_url { get; set; }
        public string profile_image_url_https { get; set; }
        public string source { get; set; }
        public string text { get; set; }
    }







}
