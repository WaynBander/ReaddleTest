using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReaddleTestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {           
            comboBox1.SelectedIndex = 0;
        }
        //when a button is pressed, a function is called that returns the result of the work and transfers it to the textBox1
        private void button1_Click(object sender, EventArgs e)
        {            
            string currency = comboBox1.Text;           
            try
            {
                textBox1.Text = ConvertOperation(currency);
            }
            catch (Exception)
            {
                MessageBox.Show("Some problems with function ConvertOperation");
            }
        }
        //A method that accepts a user-selected currency type. The method itself sends a request, receives data, and returns the result
        public string ConvertOperation(string currency)
        {            
            decimal result = 0; decimal usd = 0; decimal otherV = 0; string line = null, url = null;           
            usd = numericUpDown1.Value;            
            url = "http://free.currencyconverterapi.com/api/v5/convert?q=USD_"+ currency+ "&compact=ultra";
            WebRequest request = WebRequest.Create(url);           
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());
            if ((line = stream.ReadLine()) != null)
            {               
                string[] data = line.Split(new Char[] { '.', ':', '}' });
                line = data[1] + ',' + data[2];
                try
                {
                    otherV = Convert.ToDecimal(line);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Problem with FormatOperation");
                }
            }            
            stream.Close();
            response.Close();            
            result = usd * otherV;
            try
            {                
                result = Decimal.Round(result, 6);
                line = Convert.ToString(result)+" \t"+currency;
            }
            catch (FormatException)
            {
                MessageBox.Show("Problem with FormatOperation");
            }
            return line;
        }
    }
}
