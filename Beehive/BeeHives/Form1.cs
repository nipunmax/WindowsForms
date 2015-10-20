using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeHives
{
    public partial class Form1 : Form
    {
        Queen queen;
        public Form1()
        {
            InitializeComponent();
            
            comboBox1.SelectedIndex = 0;
            
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Nectar collector", "Honey manufacturing" },152);
            workers[1] = new Worker(new string[] { "Egg care", "Baby bee tutoring" },200);
            workers[2] = new Worker(new string[] { "Hive maintenance", "Sting patrol" },120);
            workers[3] = new Worker(new string[] { "Nectar collector", "Honey manufacturing",
            "Egg care", "Baby bee tutoring", "Hive maintenance", "Sting patrol" },112);
            queen = new Queen(workers,355);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (queen.assignWork(comboBox1.Text, (int)numericUpDown1.Value) == false)
            {
                MessageBox.Show("No workers are available to do the job ‘"
            + comboBox1.Text + "’", "The queen bee says...");
            }

            else
                MessageBox.Show("The job ‘" + comboBox1.Text + "’ will be done in "
                + numericUpDown1.Value  + " shifts", "The queen bee says...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = queen.WorkTheNextShift();
        }   
    }
}
