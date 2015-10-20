using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Party_planner
{
    public partial class Form1 : Form
    {
        DinnerParty dinnerParty;
        Birthday birthdayParty;
        
        public Form1()
        {
            InitializeComponent();
            dinnerParty = new DinnerParty((int)numericUpDown1.Value,
                                 healthyBox.Checked, fancyBox.Checked);
            DisplayDinnerPartyCost();
            birthdayParty = new Birthday((int)numericUpDown2.Value,
                            checkBox1.Checked, cakewriting.Text);
        }

        private void fancyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.FancyDecorations = fancyBox.Checked;
            DisplayDinnerPartyCost();
        }

        private void healthyBox_CheckedChanged(object sender, EventArgs e)
        {
            dinnerParty.SetHealthyOption(healthyBox.Checked);
            DisplayDinnerPartyCost();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dinnerParty.NumberOfPeople = (int)numericUpDown1.Value;
            DisplayDinnerPartyCost();
        }

        private void DisplayDinnerPartyCost()
        {
            decimal Cost = dinnerParty.CalculateCost(healthyBox.Checked);
            costLabel.Text = Cost.ToString("c");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            birthdayParty.NumberOfPeople = (int)numericUpDown2.Value;
            decimal cost = birthdayParty.Cost;
            costLabel.Text = Convert.ToString(cost);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            birthdayParty.FancyDecorations = checkBox1.Checked;
            decimal cost = birthdayParty.Cost;
            costLabel.Text = Convert.ToString(cost);   
        }

        private void cakewriting_TextChanged(object sender, EventArgs e)
        {
            birthdayParty.CakeWriting = cakewriting.Text;
            if (birthdayParty.iscakewritinglong)
            {
                label5.Text = "too long";
                label5.BackColor = Color.Red;
            }
            else
            {
                label5.Text = "OK";
                label5.BackColor = Color.Green;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            costLabel.Text = "0";
        }


    }
}