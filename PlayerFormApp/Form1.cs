using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerFormApp
{
    public partial class playerForm : Form
    {
        public playerForm()
        {
            InitializeComponent();
        }

        private void playerForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the GAA Player Data Form. "
                + "Here you can search for, add, update and delete players. "
                + "You can also do a number of calculations using the statistics saved in our database."
                + "\nCreated by Aoife O'Beirn, NUIG, April 2016");
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {

        }






        //might not need this one
        private void doneButton_Click(object sender, EventArgs e)
        {

        }
    }
}
