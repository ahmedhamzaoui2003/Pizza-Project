using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project
{
    public partial class frmPizzaMain : Form
    {

        private float TotalPrice = 0;
        private float SizePrice = 0;
        private float CrustPrice = 0;
        private float ToppingsPrice = 0;
        public frmPizzaMain()
        {
            InitializeComponent();
        }

        
        // Adding The Toppings Price (+5$)
        private float ToppingsCost(CheckBox chk)
        {
            return (chk.Checked ? ToppingsPrice += 5 : ToppingsPrice -= 5);
        }
        private string TotalCost()
        {
            float TotalPrice = SizePrice + CrustPrice + ToppingsPrice;
            return $"$ {TotalPrice}" ;
        }
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            lbSize.Text = rbSmall.Text;

            SizePrice = 10;
            // Total Price :
            lbPrice.Text = TotalCost();
        }
        
        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            lbSize.Text = rbMedium.Text;
            SizePrice = 20;
            // Total Price :
            lbPrice.Text = TotalCost();

        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            lbSize.Text = rbLarge.Text;
            SizePrice = 30;
            // Total Price :
            lbPrice.Text = TotalCost().ToString();
        }

        
        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            lbCrustType.Text = rbThin.Text;
            CrustPrice = 10;
            // Total Price :
            lbPrice.Text = TotalCost();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            lbCrustType.Text = rbThick.Text;
            CrustPrice = 20;
            // Total Price :
            lbPrice.Text = TotalCost().ToString();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text = rbEatIn.Text;
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            lbWhereToEat.Text = rbTakeOut.Text;
        }


        
        // this is how to deal with Troppings :
        private string JoinToppings()
        {
            List<CheckBox> CheckBoxes = new List<CheckBox>(6) { chkExtraCheese,chkOnion,chkMushrooms,chkOlives,chkTomatoes,chkGreepPeppers};

            string result = "";
            bool isFirstElement = true;
            foreach(CheckBox chk in CheckBoxes)
            {
                if (isFirstElement && chk.Checked)
                {
                    result += chk.Text;
                    isFirstElement = false;
                }
                else if (!isFirstElement && chk.Checked) result += ", " + chk.Text ;
            }

            // The case when the "lbToppings.Text"  is empty  => this means that "lbToppings.Text" will be "No Toppings" 
            return (result == "") ? result = "No Toppings" : result;
        }
        
        
        private void chkGreepPeppers_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = JoinToppings();

            ToppingsPrice = ToppingsCost(chkGreepPeppers);
            // Total Price : Add Checked ToppingsPrice to the Total Price
            lbPrice.Text = TotalCost();

        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = JoinToppings();

            ToppingsPrice = ToppingsCost(chkOnion);
            // Total Price : Add Checked ToppingsPrice to the Total Price
            lbPrice.Text = TotalCost();

        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = JoinToppings();

            ToppingsPrice = ToppingsCost(chkOlives);
            // Total Price : Add Checked ToppingsPrice to the Total Price
            lbPrice.Text = TotalCost();

        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = JoinToppings();

            ToppingsPrice = ToppingsCost(chkTomatoes);
            // Total Price : Add Checked ToppingsPrice to the Total Price
            lbPrice.Text = TotalCost();

        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = JoinToppings();

            ToppingsPrice = ToppingsCost(chkMushrooms);
            // Total Price : Add Checked ToppingsPrice to the Total Price
            lbPrice.Text = TotalCost();

        }

        private void chkExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            lbToppings.Text = JoinToppings();

            ToppingsPrice = ToppingsCost(chkExtraCheese);
            // Total Price : Add Checked ToppingsPrice to the Total Price
            lbPrice.Text = TotalCost();

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Confirm Order","Confirm",MessageBoxButtons.OKCancel,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if(MessageBox.Show("Order placed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    gbMenue.Enabled = false;
                    btnOrder.Enabled = false;
                }
            }
            
        }

        // Default Controls :
        private void DefaultControls()
        {
            // Default RadioButtons : 
            rbMedium.Checked = true;
            rbThin.Checked = true;
            rbEatIn.Checked = true;

            // Uncheck all the checkboxes : 
            List<CheckBox> CheckBoxes = new List<CheckBox>(6) { chkExtraCheese,chkOnion,chkMushrooms,chkOlives,chkTomatoes,chkGreepPeppers};
            foreach(CheckBox chk in CheckBoxes)
            {
                chk.Checked = false;
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            // enable the whole Groupbox and the "Order Buttons":
            gbMenue.Enabled =  true;
            btnOrder.Enabled = true;

            DefaultControls();
           

        }
    }
}
