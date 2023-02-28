using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CobaKalkulator
{
    public partial class Form1 : Form
    {
        private string currentCalculation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentCalculation += (sender as Button).Text;

            textBox1.Text = currentCalculation;
        }

        private void button_Equals_Click(object sender, EventArgs e)
        {
            string formattedCalculation = currentCalculation.ToString().Replace("x", "*").ToString().Replace("&divide;", "/");

            try
            {
                textBox1.Text = new DataTable().Compute(formattedCalculation, null).ToString();

            }
            catch (Exception ex)
            {
                textBox1.Text = "0";
                currentCalculation = "";
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            currentCalculation = "";
        }

        private void button_ClearEntry_Click(object sender, EventArgs e)
        {
            if (currentCalculation.Length > 0)
            {
                currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1, 1);
            }
            textBox1.Text = currentCalculation;
        }
    }
}
