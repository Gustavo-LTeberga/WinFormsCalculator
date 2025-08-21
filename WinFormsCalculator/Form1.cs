using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsCalculator {
    public partial class Form1 : Form {

        bool operatorClicker = true;

        public Form1() {
            InitializeComponent();
        }

        private void btnEquals_Click(object sender, EventArgs e) {

            //To be implemented later

        }

        private void number_Click(object sender, EventArgs e) {

            Button buttonClicked = (Button)sender;

            txbScreen.Text += buttonClicked.Text;

            operatorClicker = false;

        }

        private void operator_Click(object sender, EventArgs e) {

            if (!operatorClicker) {

                Button buttonClicked = (Button)sender;

                txbScreen.Text += buttonClicked.Text;

                operatorClicker = true;


            }


        }

    }
}
