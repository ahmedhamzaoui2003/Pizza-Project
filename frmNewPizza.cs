using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project
{
    public partial class frmNewPizza : Form
    {
        public frmNewPizza()
        {
            InitializeComponent();
        }



        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lbSize.Text = "Small";
                return;
            }
            else if(rbMedium.Checked)
            {
                lbSize.Text = "Medium";
                return;
            }
            else
            {
                lbSize.Text = "Large";
                return;
            }
        }

        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThin.Checked)
            {
                lbCrustType.Text = rbThin.Text;
            }
            
            if (rbThick.Checked)
            {
                lbCrustType.Text = rbThick.Text;
            }
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();

            string sToppings = "";
            if(chkExtraCheese.Checked)
            {
                sToppings += "Extra Cheese";
            }
            if(chkOnion.Checked)
            {
                sToppings += ", Onion";
            }
            if(chkMushrooms.Checked)
            {
                sToppings += ", Mushrooms";
            }
            if(chkOlives.Checked)
            {
                sToppings += ", Olives";
            }
            if(chkTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }
            if(chkGreepPeppers.Checked)
            {
                sToppings += ", Green Peppers";
            }

            if (sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(2);
            }

            if (sToppings == "")
                sToppings = "No Toppings";

            lbToppings.Text = sToppings;

        }

        void UpdateWhereToEat()
        {
            lbWhereToEat.Text = (rbEatIn.Checked ? rbEatIn.Text : rbTakeOut.Text);
        }
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void chkGreepPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }

        private void chkExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        // Calculating Total Price :

        float GetSelectedSizePrice()
        {
            return (rbSmall.Checked ? Convert.ToSingle(rbSmall.Tag) : (rbMedium.Checked ? Convert.ToSingle(rbMedium.Tag) : Convert.ToSingle(rbLarge.Tag)));
        }

        float GetSelectedCrustPrice()
        {
            return (rbThin.Checked ? Convert.ToSingle(rbThin.Tag) : Convert.ToSingle(rbThick.Tag));
        }

        float GetSelectedToppingsPrice()
        {
            float ToppingsPrice = 0;

            if (chkExtraCheese.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkExtraCheese.Tag);
            }
            if (chkOnion.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkOnion.Tag);
            }
            if (chkMushrooms.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkMushrooms.Tag);
            }
            if (chkOlives.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkOlives.Tag);
            }
            if (chkTomatoes.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkTomatoes.Tag);
            }
            if (chkGreepPeppers.Checked)
            {
                ToppingsPrice += Convert.ToSingle(chkGreepPeppers.Tag);
            }

            return ToppingsPrice; 
        }
        
        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + GetSelectedCrustPrice() + GetSelectedToppingsPrice();
        }

        void UpdateTotalPrice()
        {
            lbPrice.Text = "$" + CalculateTotalPrice().ToString();
        }


        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateCrust();
            UpdateToppings();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }
        
        private void frmNewPizza_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                MessageBox.Show("Order placed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbMenue.Enabled = false;
                btnOrder.Enabled = false;
            }
            else
                MessageBox.Show("Update Your Order", "Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        void ResetForm()
        {
            // reset groups boxes :
            gbMenue.Enabled = true;
            btnOrder.Enabled = true;

            // reset size : 
            rbMedium.Checked = true ;


            // reset Crust type :
            rbThin.Checked = true ;

            // reset Toppings boxes :
            chkExtraCheese.Checked = false ;
            chkOnion.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkGreepPeppers.Checked = false;

            // reset Where To Eat :
            rbEatIn.Checked = true;
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }



    }
}
