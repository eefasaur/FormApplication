using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerFormApp
{
    public partial class playerForm : Form
    {


        //instantiating classes required, connection and reader

        //create instance of DBMethod
            DatabaseMethods db = new DatabaseMethods();

        //set connection in a string
            static string connString = "Server=lugh4.it.nuigalway.ie; database=msdb2355; uid=msdb2355A";

        //instantiate a new connection - pass in string
            SqlConnection connection = new SqlConnection(connString);

        //set a new data reader to null - may not be used
            SqlDataReader reader = null;


        public playerForm()
        {
            InitializeComponent();
        }

        //on load a message appears explaining a bit about the form
        private void playerForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the GAA Player Data Form. "
                + "Here you can search for, add, update and delete players. "
                + "You can also do a number of calculations using the statistics saved in our database."
                + "\nCreated by Aoife O'Beirn, NUIG, April 2016");
        }


        //deletes player from database - alerts user first
        private void _deleteButton_Click(object sender, EventArgs e)
        {
            //dialog box asking user if they want to delete - yes, no options
            DialogResult alert = MessageBox.Show("Are you sure you want to delete Player record?", "", MessageBoxButtons.YesNo);
            if (alert == DialogResult.No)
            {
                return;
            }
            else if (alert == DialogResult.Yes)
            {
                //encompassed within a try catch
                try
                {
                    int id = Convert.ToInt32(idTextBox.Text);
                    db.deletePlayer(connection, id);

                    idTextBox.Clear();
                    nameTextBox.Clear();
                    ageTextBox.Clear();
                    heightTextBox.Clear();
                    distanceTextBox.Clear();
                    speedTextBox.Clear();

                    MessageBox.Show("Player record deleted.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            } 
        }






        //loads table into data grid - on click changes name to Refresh Players
        private void _loadButton_Click(object sender, EventArgs e)
        {
            //originally had a second button calling the same function (see _refreshPlayersGridButton_Click below)
            //but realised i could just change the text!
            _loadButton.Text = "Refresh Players";


            //stores the returned dataset from the database query in DatabaseMethods into variable ds
            DataSet ds = db.viewPlayers(connection, reader);

            //autosize resizes the columns to an appropriate width based on column headings
            //http://stackoverflow.com/questions/18666582/datagridview-autofit-and-fill
            this._viewPlayersTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //setting the source of the grid to the dataset to table
            _viewPlayersTable.DataSource = ds.Tables[0];
        }
        

        //New Player Button - makes form available for new data entry
        private void _newButton_Click(object sender, EventArgs e)
        {

            MessageBox.Show("You must enter a value in each field.");

            idTextBox.Clear();
            nameTextBox.Clear();
            ageTextBox.Clear();
            heightTextBox.Clear();
            distanceTextBox.Clear();
            speedTextBox.Clear();

            _newButton.Visible = false;
            _addToDatabase.Visible = true;
            nameTextBox.ReadOnly = false;
            ageTextBox.ReadOnly = false;
            heightTextBox.ReadOnly = false;
            distanceTextBox.ReadOnly = false;
            speedTextBox.ReadOnly = false;
        }


        //Add Player button - submits values to database
        private void _addToDatabase_Click(object sender, EventArgs e)
        {
            //set all the values in player with whats in the text box
            Player p = new Player();
            p.Name = (string)nameTextBox.Text;
            p.Age = Convert.ToInt32(ageTextBox.Text);
            p.Height = Convert.ToInt32(heightTextBox.Text);
            p.Distance = Convert.ToInt32(distanceTextBox.Text);
            p.Speed = Convert.ToDouble(speedTextBox.Text);


            //to check that everything is ok e.g. connection etc...
            try
            {
                Boolean response = db.insertPlayer(connection, p);

                if (response == true)
                {

                    MessageBox.Show("Update Successful");

                    nameTextBox.Clear();
                    ageTextBox.Clear();
                    heightTextBox.Clear();
                    distanceTextBox.Clear();
                    speedTextBox.Clear();

                    _newButton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }


        //updates players age
        private void updateAgeButton_Click(object sender, EventArgs e)
        {
            //passes the player id and new value into the method
            int id = Convert.ToInt32(idTextBox.Text);
            int age = Convert.ToInt32(ageTextBox.Text);

            try
            {
                db.updateAge(connection, id, age);
                MessageBox.Show("Update successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        //updates running distance
        private void updateDistanceButton_Click(object sender, EventArgs e)
        {
            //passes id and value(from text box) into method
            int id = Convert.ToInt32(idTextBox.Text);
            int d = Convert.ToInt32(distanceTextBox.Text);

            try
            {
                db.updateDistance(connection, id, d);
                MessageBox.Show("Update successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        //updates the maximum speed
        private void updateSpeedButton_Click(object sender, EventArgs e)
        {
            //passes id and new value taken from text box on form
            int id = Convert.ToInt32(idTextBox.Text);
            double h = Convert.ToDouble(speedTextBox.Text);

            try
            {
                db.updateSpeed(connection, id, h);
                MessageBox.Show("Update successful.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }


        //this adds/removes visibility of the UI to an update view
        private void _updateButton_Click(object sender, EventArgs e)
        {
            updateAgeButton.Visible = true;
            ageTextBox.ReadOnly = false;

            updateDistanceButton.Visible = true;
            distanceTextBox.ReadOnly = false;

            updateSpeedButton.Visible = true;
            speedTextBox.ReadOnly = false;

            doneButton.Visible = true;
            _deleteButton.Visible = false;
            _updateButton.Visible = false;
            _newButton.Visible = false;
        }


        //done update - reverts back to normal form display
        private void doneButton_Click(object sender, EventArgs e)
        {
            //reverses the visibility true/false of clicking update button
            updateAgeButton.Visible = false;
            ageTextBox.ReadOnly = true;

            updateDistanceButton.Visible = false;
            distanceTextBox.ReadOnly = true;

            updateSpeedButton.Visible = false;
            speedTextBox.ReadOnly = true;

            doneButton.Visible = false;
            _deleteButton.Visible = true;
            _updateButton.Visible = true;
            _newButton.Visible = true;
        }





        //nope
        private void _viewPlayersTable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //https://www.youtube.com/watch?v=pb9NZruK2hk

            idTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[0].Value.ToString();
            nameTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[1].Value.ToString();
            ageTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[2].Value.ToString();
            heightTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[3].Value.ToString();
            distanceTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[4].Value.ToString();
            speedTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[5].Value.ToString();

            //the update and delete button become visible for the user to select
            _updateButton.Visible = true;
            _deleteButton.Visible = true;
        }

        
        
        //nope not needed
        private void _viewPlayersTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void statsSpeed_Click(object sender, EventArgs e)
        {

        }

        private void statsDistance_Click(object sender, EventArgs e)
        {

        }


        

    
    
    }
}
