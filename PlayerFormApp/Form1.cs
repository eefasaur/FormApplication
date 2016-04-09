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
    //this is set as a partial class to handle UI controls
    //there is another designer partial class which contains
    //automatic generated code as different elements are added
    //to the UI design view
    //this enables easily readable methods - separated from
    //the underlying design controls
    public partial class playerForm : Form
    {


        // new instances of required classes are set (methods class, connection and reader)
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
            //initial form control - can set different preferences here
            //e.g. visibility of buttons on load (if not done in preferences)
            //did not make use of any features in this
            InitializeComponent();
        }

        /// <summary>
        /// on load a message appears explaining a bit about the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playerForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the GAA Player Data Form. "
                + "Here you can search for, add, update and delete players. "
                + "You can also do a number of calculations using the statistics saved in our database."
                + "\nCreated by Aoife O'Beirn, NUIG, April 2016");
        }

        /// <summary>
        /// loads table into data grid 
        /// here you can view the list of players that are currently in the database
        /// on click changes name to Refresh Players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _loadButton_Click(object sender, EventArgs e)
        {
            //this changes the text in the button
            //for the rest of the run time the button will read refresh player
            //will be easier for user to understand 
            _loadButton.Text = "Refresh Players";


            //stores the returned dataset from the database query in DatabaseMethods into variable ds
            DataSet ds = db.viewPlayers(connection, reader);

            //autosize resizes the columns to an appropriate width based on column headings
            //http://stackoverflow.com/questions/18666582/datagridview-autofit-and-fill
            this._viewPlayersTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            //setting the source of the grid to the dataset to table
            _viewPlayersTable.DataSource = ds.Tables[0];
        }





        /// <summary>
        /// This method is called when the delete player button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    //get id from text box
                    int id = Convert.ToInt32(idTextBox.Text);
                    db.deletePlayer(connection, id);

                    //this clears the text box of values
                        idTextBox.Clear();
                        nameTextBox.Clear();
                        ageTextBox.Clear();
                        heightTextBox.Clear();
                        distanceTextBox.Clear();
                        speedTextBox.Clear();

                    //resets the UI - delete and update buttons disappear
                        _deleteButton.Visible = false;
                        _updateButton.Visible = false;

                    MessageBox.Show("Player record deleted.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            } 
        }

        /// <summary>
        /// this code is bound to the data grid view
        /// if a row is double clicked - the values will auto bind to the 
        /// text boxes defined
        /// this was set by selecting events - MouseDoubleClick and adding _viewPlayersTable
        /// and then in properties selecting SelectionMode - FullRowSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _viewPlayersTable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //https://www.youtube.com/watch?v=pb9NZruK2hk

            //on double click, each value in the selected row will be bound to a text box
            //in the UI e.g. id - row[0]cell[0] the 0th index (first row, first column)
            //row 0 cell 1 is first (selected row) second column, etc...
                idTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[0].Value.ToString();
                nameTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[1].Value.ToString();
                ageTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[2].Value.ToString();
                heightTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[3].Value.ToString();
                distanceTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[4].Value.ToString();
                speedTextBox.Text = _viewPlayersTable.SelectedRows[0].Cells[5].Value.ToString();

           
            //when the player has been selected the update and delete options become visibile
            //for the user to select
                _updateButton.Visible = true;
                _deleteButton.Visible = true;
        }



        /// <summary>
        /// Update button is just UI manipulation
        /// makes it easier for user to navigate functions by adding and removing
        /// buttons as required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _updateButton_Click(object sender, EventArgs e)
        {
            //shows the update buttons to the user
            //also changes the ReadOnly from false to true so the
            //values can be changed
                updateAgeButton.Visible = true;
                ageTextBox.ReadOnly = false;

                updateDistanceButton.Visible = true;
                distanceTextBox.ReadOnly = false;

                updateSpeedButton.Visible = true;
                speedTextBox.ReadOnly = false;

            //done button becomes visible
                 doneButton.Visible = true;
            //the other buttons disappear as they are not required for an update
                _deleteButton.Visible = false;
                _updateButton.Visible = false;
                _newButton.Visible = false;
        }


        /// <summary>
        /// each of the following 3 methods does the same thing essentially
        /// only age, distance and speed can be updated - each has a button associated
        /// with it so you can update all or just one as required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //updates players age
        private void updateAgeButton_Click(object sender, EventArgs e)
        {
            //passes the player id and new value into the method
            //takes the id from UI
            //takes the age that has been entered from UI
            int id = Convert.ToInt32(idTextBox.Text);
            int age = Convert.ToInt32(ageTextBox.Text);

            //use try catch to handle any exceptions thrown
            try
            {
                //call the update age method in methods class
                //connection is set at start of this class
                    db.updateAge(connection, id, age);
                
                //lets user know the update has been sucessful
                    MessageBox.Show("Update successful.");
            }
            catch (Exception ex)
            {
                //will give error message if exception is thrown
                    MessageBox.Show("Error: " + ex);
            }
        }

        //updates running distance
        //follows identical steps as update age
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
        //follows identical steps as update age
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


        /// <summary>
        /// the done button method is again just UI manipulation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
  
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

            //reverses visibility set on update click
                doneButton.Visible = false;
                _deleteButton.Visible = true;
                _updateButton.Visible = true;
                _newButton.Visible = true;
        }


        /// <summary>
        /// following two methods are relating to adding a new player to
        /// the database
        /// first method is UI manipulation
        /// and the second is taking the data from the ui and passing it to 
        /// the appropriate method in the methods class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //New Player Button - makes form available for new data entry
        private void _newButton_Click(object sender, EventArgs e)
        {
            //alerts the user that a value must be entered for each field
            MessageBox.Show("You must enter a value in each field.");

            //clears the box if the have been occupied
                idTextBox.Clear();
                nameTextBox.Clear();
                ageTextBox.Clear();
                heightTextBox.Clear();
                distanceTextBox.Clear();
                speedTextBox.Clear();

            //sets visibiliy of buttons for UI
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

            //test that each field has a value before continuing
            if (nameTextBox.Text.Length > 0 && ageTextBox.Text.Length > 0 && heightTextBox.Text.Length > 0 && distanceTextBox.Text.Length > 0 && speedTextBox.Text.Length > 0)
            {

                //reads values from text box and converts them into the
                //appropirate value types for database
                //create new instance of a player
                Player p = new Player();
                p.Name = (string)nameTextBox.Text;
                p.Age = Convert.ToInt32(ageTextBox.Text);
                p.Height = Convert.ToInt32(heightTextBox.Text);
                p.Distance = Convert.ToInt32(distanceTextBox.Text);
                p.Speed = Convert.ToDouble(speedTextBox.Text);


                //to check that everything is ok e.g. connection etc...
                //used a boolean to test that the method has worked
                try
                {
                    Boolean response = db.insertPlayer(connection, p);

                    //if the method runs a true is returned
                    if (response == true)
                    {

                        //user alerted to succesful update
                        MessageBox.Show("Update Successful");

                        //the text box are cleared
                            nameTextBox.Clear();
                            ageTextBox.Clear();
                            heightTextBox.Clear();
                            distanceTextBox.Clear();
                            speedTextBox.Clear();

                        //text boxes reset to read only
                            nameTextBox.ReadOnly = true;
                            ageTextBox.ReadOnly = true;
                            heightTextBox.ReadOnly = true;
                            distanceTextBox.ReadOnly = true;
                            speedTextBox.ReadOnly = true;

                        //add new player become visible again
                            _newButton.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }

            }
            else
            {
                MessageBox.Show("Please enter a value in each field.");
            }

        }

        /// <summary>
        /// the following two methods correspond to the statistics buttons
        /// on the UI
        /// when clicked a series of queries are sent to the database via
        /// the db methods class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //speed statistics button
        private void statsSpeed_Click(object sender, EventArgs e)
        {
            //sets the return value of the method to the
            //corresponding text box value - text boxes hold string
            //datatypes so ToString() must be called
            //this is done for each method
                maxTextBox.Text = db.maxSpeed(connection).ToString();
                minTextBox.Text = db.minSpeed(connection).ToString();
                meanTextBox.Text = db.meanSpeed(connection).ToString();
        }

        //distance statistics button
        private void statsDistance_Click(object sender, EventArgs e)
        {
            //sets the return value of the method to the
            //corresponding text box value - text boxes hold string
            //datatypes so ToString() must be called
            //this is done for each method
                maxTextBox.Text = db.maxDistance(connection).ToString();
                minTextBox.Text = db.minDistance(connection).ToString();
                meanTextBox.Text = db.meanDistance(connection).ToString();

        }

     
        //nope not needed
        private void _viewPlayersTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

   
    }
}
