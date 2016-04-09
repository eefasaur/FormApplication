using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Data;

namespace PlayerFormApp
{
    [TestFixture]
    public class UnitTesting
    {

        /* All the crap I need
         * //create instance of DBMethod
            DatabaseMethods db = new DatabaseMethods();

        //set connection in a string
            string connString = "Server=lugh4.it.nuigalway.ie; database=msdb2355; uid=msdb2355A";

        //instantiate a new connection - pass in string
            SqlConnection connection = new SqlConnection(connString);

        //set a new data reader to null - may not be used
            SqlDataReader reader = null;
         * 
         */
        
        //the following unit tests in this class test the databasemethods class
        //in the running application, these methods are called based on clicks frm the UI
        //this set up keeps a clear separation of logic which makes code easier to manage


        [Test]
        public void testMax()
        {
        //create instance of DBMethod
            DatabaseMethods db = new DatabaseMethods();

        //set connection in a string
            string connString = "Server=lugh4.it.nuigalway.ie; database=msdb2355; uid=msdb2355A";

        //instantiate a new connection - pass in string
            SqlConnection connection = new SqlConnection(connString);

        //testing distance
            int expectedMaxDistance = 4321;
            int actualMaxDistance = db.maxDistance(connection);
            Assert.AreEqual(expectedMaxDistance, actualMaxDistance);

        //testing speed
            double expectedMaxSpeed = 3.8;//change method to round up double number
            double actualMaxSpeed = db.maxSpeed(connection);
            Assert.AreEqual(expectedMaxSpeed, actualMaxSpeed, 0.00000000000001);
            
        }

        [Test]
        public void testMin()
        {
            //create instance of DBMethod
            DatabaseMethods db = new DatabaseMethods();

            //set connection in a string
            string connString = "Server=lugh4.it.nuigalway.ie; database=msdb2355; uid=msdb2355A";

            //instantiate a new connection - pass in string
            SqlConnection connection = new SqlConnection(connString);

            //testing distance
            int expectedMinDistance = 1000;
            int actualMinDistance = db.minDistance(connection);
            Assert.AreEqual(expectedMinDistance, actualMinDistance);

            //testing speed
            double expectedMinSpeed = 2.0;
            double actualMinSpeed = db.minSpeed(connection);
            Assert.AreEqual(expectedMinSpeed, actualMinSpeed, 0.1);

        }

        [Test]
        public void testMean() {
            //create instance of DBMethod
            DatabaseMethods db = new DatabaseMethods();

            //set connection in a string
            string connString = "Server=lugh4.it.nuigalway.ie; database=msdb2355; uid=msdb2355A";

            //instantiate a new connection - pass in string
            SqlConnection connection = new SqlConnection(connString);

            //testing distance
            double expectedMeanDistance = 2613;
            double actualMeanDistance = db.meanDistance(connection);
            Assert.AreEqual(expectedMeanDistance, actualMeanDistance);

            //testing speed
            double expectedMeanSpeed = 2.9;
            double actualMeanSpeed = db.meanSpeed(connection);
            Assert.AreEqual(expectedMeanSpeed, actualMeanSpeed, 0.1);
        }

        [Test]
        public void testAddPlayer()
        {
            //create instance of DBMethod
            DatabaseMethods db = new DatabaseMethods();

            //set connection in a string
            string connString = "Server=lugh4.it.nuigalway.ie; database=msdb2355; uid=msdb2355A";

            //instantiate a new connection - pass in string
            SqlConnection connection = new SqlConnection(connString);

            connection.Open();

            //get row count of db
            //initial number of rows
            SqlCommand command = new SqlCommand("SELECT COUNT(PlayerID) FROM PlayerData", connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            
            //instantiate a new player and add to database using insertPlayer method
            Player p = new Player("F Gillespie", 22, 155, 2000, 3.4);//default called

            db.insertPlayer(connection, p);
            //connection closed in insertPlayer method

            
            connection.Open();//need to re-open connection as the insert player method closes on completion
            //get updated count value and compare to expected
            SqlCommand update = new SqlCommand("SELECT COUNT(PlayerID) FROM PlayerData", connection);
            int countUpdated = Convert.ToInt32(update.ExecuteScalar());

            int countExpected = count + 1;
            int countAcutal = countUpdated;
            Assert.AreEqual(countExpected, countAcutal);

            connection.Close();
        }

        [Test]
        public void testDeletePlayer()
        {
            //create instance of DBMethod
            DatabaseMethods db = new DatabaseMethods();

            //set connection in a string
            string connString = "Server=lugh4.it.nuigalway.ie; database=msdb2355; uid=msdb2355A";

            //instantiate a new connection - pass in string
            SqlConnection connection = new SqlConnection(connString);

            //initial number of rows in databse
            int initial = db.count(connection);

            //delete a player
            db.deletePlayer(connection, 101006);


            int countExpected = initial - 1;//one less than first time
            int countAcutal = db.count(connection);
            Assert.AreEqual(countExpected, countAcutal);

            connection.Close();
        }

        //using player id 100001
        [Test]
        public void updateAge() {

            //create instance of DBMethod
            DatabaseMethods db = new DatabaseMethods();

            //set connection in a string
            string connString = "Server=lugh4.it.nuigalway.ie; database=msdb2355; uid=msdb2355A";

            //instantiate a new connection - pass in string
            SqlConnection connection = new SqlConnection(connString);

            //set a new data reader to null - may not be used
            //SqlDataReader reader = null;

            //stores the returned dataset from the database query in DatabaseMethods into variable ds
            //DataSet ds = db.viewPlayers(connection, reader);
            
            
            //passes the player id and new value into the method




        }

        //using player id 100001
        [Test]
        public void updateDistance() { }

        //using player id 100001
        [Test]
        public void updateSpeed() { }

        //do mean in the morning when i've figured out the rounding!!!

        //test written and seem fine BUT must set up a local database to test the add and delete methods

        //http://www.w3schools.com/sql/sql_func_count.asp
        //adding new player
        //do count, expected = count+1

        //deleting a player
        //do count, expected = count-1

        //updating
        //age, distance, speed

        //max distance, speed
        //min distance, speed
        //mean distance, speed
        //take screenshot of database at current time these tests were taken
        //will be done before adding and subtracting tests?!

        

        //screenshots of datagrid loading
        //screenshots of the different functionalities
        //main view, add new player, update a player, delete a player

        //used max, min, avg sql statements and execute scalar to return the values
        //this lead to repeditive text - but easier to understand
        //each method takes in connection, opens connection, instantiates a sql command
        //object and uses the execute scalar method to return the value
        //execute scalar is used when there is only one value, this eleminiates the need
        //for a reader in this case
        //try catch is utilised to stick to best practice standards





        
    }
}
