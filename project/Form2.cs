using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private double add_VAT(double beforeVAT)
        {
            double rateVAt = 20;
            double withVAT = 0;
            withVAT += beforeVAT * (rateVAt / 100);
            return (withVAT);
        }
        //finding minimum price
        private double minimum()
        {
            double min = 0.0;
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                if (i == 0.0)
                {
                    min = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }

                if (min > double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()))
                {
                    min = double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
            }
            return (min);
        }

        //sum to total price
       private double total()
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
            }
            return sum;
        }
        //clear all field
        private void clear_btn()
        {
            textBox1.Text = textBox2.Text = null;
            comboBox1.Text = "";
            dataGridView1.Rows.Clear();
        }
        //clear textboxes
        private void clear_textbox()
        {
            textBox1.Text = textBox2.Text = null;
            comboBox1.Text = "";
            
        }
        //validation code started

        //validation code for  product name/description input box
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Enter Product Name/Description");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");
            }
        }
        //validation code for  unit price input box
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Enter Unit Price");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textBox2, "");
            }
        }
        //validation code for  unit price input box
        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                e.Cancel = true;
                comboBox1.Focus();
                errorProvider3.SetError(comboBox1, "Enter Product Quantity");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(comboBox1, "");
            }
        }
          //add item
        private void button1_Click(object sender, EventArgs e)
        {
            // validation
            if (this.ValidateChildren(ValidationConstraints.Enabled))
            {
                if (dataGridView1.RowCount < 5)
                {
                    //getting datafrom textboxes
                    try
                    {
                        double unitprice = Convert.ToDouble(textBox2.Text);
                        double quantity = Convert.ToDouble(comboBox1.Text);
                        //calculating vat
                        double withoutvat = unitprice * quantity;
                        double pricewithvat = add_VAT(withoutvat);
                        double tot = withoutvat + pricewithvat;
                        //add data in datagridview
                        dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, comboBox1.Text, withoutvat, tot);
                        //clear field
                        clear_textbox();
                    }
                    catch (Exception )
                    {
                        MessageBox.Show("Enter Correct Data");
                    }
                }
                else {
                    MessageBox.Show("Maximum 5 Products");
                }
            }
        }
        
        //clear
        private void button2_Click(object sender, EventArgs e)
        {
            //clear all field
            clear_btn();
            
        }
             //calculate amount button
        private void button3_Click(object sender, EventArgs e)
        {
            double total_amount = total();
          //check if the user brought 5 items
            if (dataGridView1.Rows.Count == 5)
            {
                double minimum_amount = minimum();
                textBox3.Text = Convert.ToString(total_amount);
                textBox4.Text = Convert.ToString(total_amount - minimum_amount);
            }
            else
            {
                textBox3.Text= Convert.ToString(total_amount);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}