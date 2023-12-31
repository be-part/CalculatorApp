﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        double enterFirstValue;
        double enterSecondValue;
        String op;
        Queue<string> historyQueue = new Queue<string>(5);
        bool equalsPress;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void numberOperator(object sender, EventArgs e)
        {
            Button num = (Button)sender;


            int number = 0;
            if (Int32.TryParse(txtResult.Text, out number))
            {
                enterFirstValue = Convert.ToDouble(txtResult.Text);
            }

            if (!string.IsNullOrEmpty(op))
            {
                op = num.Text;
            }
            else
            {
                op = num.Text;
            }
            
            txtResult.Text = "";
            equalsPress = false;
        }

        private void enterNumbers(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            string pattern = @"[^0-9.]";
            bool containsNonDigits = Regex.IsMatch(txtResult.Text, pattern);

            if (equalsPress)
            {
                txtResult.Text = "";
            }

            if (txtResult.Text == "0")
            {
                txtResult.Text = num.Text;
            }
            else if (containsNonDigits)
            {
                txtResult.Text = num.Text;
            }
            else
            {
                if (num.Text == ".")
                {
                    if (!txtResult.Text.Contains("."))
                    {
                        txtResult.Text = txtResult.Text + num.Text;
                    }
                }
                else
                {
                    txtResult.Text = txtResult.Text + num.Text;
                }
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {

            int number = 0;
            if (Int32.TryParse(txtResult.Text, out number))
            {
                enterSecondValue = Convert.ToDouble(txtResult.Text);
            }

            switch (op)
            {
                case "+":
                    txtResult.Text = (enterFirstValue + enterSecondValue).ToString();
                    break;

                case "-":
                    txtResult.Text = (enterFirstValue - enterSecondValue).ToString();
                    break;

                case "*":
                    txtResult.Text = (enterFirstValue * enterSecondValue).ToString();
                    break;

                case "/":
                    if (enterSecondValue != 0)
                    {
                        txtResult.Text = (enterFirstValue / enterSecondValue).ToString();
                    }
                    else
                    {
                        txtResult.Text = "Cannot divide by zero.";
                    }
                    break;

                case "Mod":
                    txtResult.Text = (enterFirstValue % enterSecondValue).ToString();
                    break;

                case "Exp":
                    double a = Convert.ToDouble(txtResult.Text);
                    double b = enterSecondValue; 
                    double result = a * Math.Pow(10, b);
                    txtResult.Text = result.ToString();
                    break;

            }



            if (historyQueue.Count > 7)
            {
                historyQueue.Dequeue();
                string newHistoryItem = $"{enterFirstValue} {op} {enterSecondValue} = {txtResult.Text}";
                historyQueue.Enqueue(newHistoryItem);
            }
            else
            {
                string newHistoryItem = $"{enterFirstValue} {op} {enterSecondValue} = {txtResult.Text}";
                historyQueue.Enqueue(newHistoryItem);
            }

            
            string historyText = string.Join(Environment.NewLine, historyQueue.Reverse());
            historyBox.Text = historyText;

            equalsPress = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
           
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";

            String firstNum, secondNum;
            firstNum = Convert.ToString(enterFirstValue);
            secondNum = Convert.ToString(enterSecondValue);

            firstNum = "";
            secondNum = "";

            historyQueue.Clear();
            string historyText = string.Join(Environment.NewLine, historyQueue.Reverse());
            historyBox.Text = historyText;

        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            double q = Convert.ToDouble(txtResult.Text);
            txtResult.Text = Convert.ToString(-1 * q);
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Length > 0)
            {
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1, 1);
            }

            if (txtResult.Text == "")
            {
                txtResult.Text = "0";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 596;
            txtResult.Width = 302;
            historyBox.Text = "There is no history yet.";

        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 596;
            txtResult.Width = 302;
        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 937;
            txtResult.Width = 646;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitCalc;

            exitCalc = MessageBox.Show("Confirm if you want to exit", "Calculator", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exitCalc == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            txtResult.Text = "3.141592653589976323";
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            double logg = Convert.ToDouble(txtResult.Text);
            logg = Math.Log10(logg);
            txtResult.Text = Convert.ToString(logg);
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double sqrt = Convert.ToDouble(txtResult.Text);
            sqrt = Math.Sqrt(sqrt);
            txtResult.Text = Convert.ToString(sqrt);
        }

        private void btnSqr_Click(object sender, EventArgs e)
        {
            double squared = Convert.ToDouble(txtResult.Text);
            squared = squared * squared;
            txtResult.Text = Convert.ToString(squared);
        }

        private void btnCube_Click(object sender, EventArgs e)
        {
            double cubed = Convert.ToDouble(txtResult.Text);
            cubed = cubed * cubed * cubed;
            txtResult.Text = Convert.ToString(cubed);
        }

        private void btnSinh_Click(object sender, EventArgs e)
        {
            double sinh = Convert.ToDouble(txtResult.Text);
            sinh = Math.Sinh(sinh);
            txtResult.Text = Convert.ToString(sinh);
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            double sin = Convert.ToDouble(txtResult.Text);
            sin = Math.Sin(sin);
            txtResult.Text = Convert.ToString(sin);
        }

        private void btnCosh_Click(object sender, EventArgs e)
        {
            double cosh = Convert.ToDouble(txtResult.Text);
            cosh = Math.Cosh(cosh);
            txtResult.Text = Convert.ToString(cosh);
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            double cos = Convert.ToDouble(txtResult.Text);
            cos = Math.Cosh(cos);
            txtResult.Text = Convert.ToString(cos);
        }

        private void btnTanh_Click(object sender, EventArgs e)
        {
            double tanh = Convert.ToDouble(txtResult.Text);
            tanh = Math.Tanh(tanh);
            txtResult.Text = Convert.ToString(tanh);
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            double tan = Convert.ToDouble(txtResult.Text);
            tan = Math.Tan(tan);
            txtResult.Text = Convert.ToString(tan);
        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            int num = int.Parse(txtResult.Text);
            txtResult.Text = Convert.ToString(num, 2);
        }

        private void btnFraction_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(txtResult.Text);

            if (num != 0)
            {
                num = 1.0 / num;
                txtResult.Text = Convert.ToString(num);
            }
            else
            {
                txtResult.Text = "Cannot divide by zero.";
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            double lnx = Convert.ToDouble(txtResult.Text);
            lnx = Math.Log(lnx);
            txtResult.Text = Convert.ToString(lnx);
        }

        private void btnPer_Click(object sender, EventArgs e)
        {
            double num = Convert.ToDouble(txtResult.Text);
            num = num / 100;
            txtResult.Text = Convert.ToString(num);
        }

        private void expMod(object sender, EventArgs e)
        {
            Button num = (Button)sender;

            enterFirstValue = Convert.ToDouble(txtResult.Text);
            op = num.Text;
            txtResult.Text = "";
        }

        private void btnDec_Click(object sender, EventArgs e)
        {
            decimal num = Convert.ToDecimal(txtResult.Text);
            txtResult.Text = Convert.ToString(num);
        }

       
    }
}
