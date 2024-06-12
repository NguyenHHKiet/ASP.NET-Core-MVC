using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureConverter
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

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if(rdFah.Checked)
            {
                double input    = double.Parse(txtTemp.Text);
                double result   = (input * 1.8) + 32;
                txtResult.Text  = result.ToString();
            }
            if (rdCel.Checked)
            {
                double input = double.Parse(txtTemp.Text);
                double result = (input - 32) * 0.5555; 
                txtResult.Text = result.ToString();
            }
        }
    }
}
