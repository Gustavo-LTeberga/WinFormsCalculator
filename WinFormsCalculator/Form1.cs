using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WinFormsCalculator {
    public partial class Form1 : Form {

        bool operatorClicker = true;

        bool existDot = false;

        bool existSubtract = false;

        public Form1() {
            InitializeComponent();
        }

        private void btnEquals_Click(object sender, EventArgs e) {

            if (txbScreen.Text.Contains("/0")) {

                if (!txbScreen.Text.Contains("/0.")) {

                    MessageBox.Show("Division by zero is not allowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    btnClear.PerformClick();
                }
                else if (!operatorClicker) {

                    string expression = txbScreen.Text;

                    var rawresult = new DataTable(expression).Compute(expression, null);

                    double result = Convert.ToDouble(rawresult, CultureInfo.InvariantCulture);

                    txbScreen.Text = result.ToString("F7", CultureInfo.InvariantCulture);


                }

            }
            else if (!operatorClicker) {

                string expression = txbScreen.Text;

                var rawresult = new DataTable(expression).Compute(expression, null);

                double result = Convert.ToDouble(rawresult, CultureInfo.InvariantCulture);

                txbScreen.Text = result.ToString(CultureInfo.InvariantCulture);

            }



        }

        private void number_Click(object sender, EventArgs e) {

            Button buttonClicked = (Button)sender;

            txbScreen.Text += buttonClicked.Text;

            operatorClicker = false;

        }

        private void operator_Click(object sender, EventArgs e) {

            Button buttonClicked = (Button)sender;

            if (!operatorClicker || (buttonClicked.Text == "-" && !existSubtract)) {



               

                txbScreen.Text += buttonClicked.Text;

                operatorClicker = true;

                existDot = false;

                existSubtract = true;


            }


        }

        private void btnClear_Click(object sender, EventArgs e) {

            txbScreen.Text = null;

            operatorClicker = true;

            existDot = false;
        }

        private void btnDot_Click(object sender, EventArgs e) {


            if ((txbScreen.Text == "" && !existDot) || (operatorClicker && !existDot)) {
                txbScreen.Text += "0.";
                existDot = true;
            }
            else if (!existDot) {
                txbScreen.Text += ".";
                existDot = true;
            }

        }

    }




}

