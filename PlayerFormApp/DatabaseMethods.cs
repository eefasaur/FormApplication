using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerFormApp
{
    public class DatabaseMethods
    {

        //view players
        internal DataSet viewPlayers(SqlConnection connection, SqlDataReader reader)
        //pass in connection and reader (reader not required)
        {
            try
            {
                connection.Open();//open connection to db

                //DataAdapter is used as a bridge between the DataSet and the source (db)
                //Adapter has .Fill() method which populates the Set with the information
                //in the db.  This is a way to decouple the code
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PlayerData", connection);
                    SqlCommandBuilder command = new SqlCommandBuilder(adapter);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;
            }
            catch { }
            finally//encompasses the code to fully close the connection
            {
                if (reader != null)//if there is a reader that is open - close it
                {
                    reader.Close();
                }
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }

            return null;
        }



        //UPDATE METHODS
        //the following 3 methods follow the same steps
        //update age will be commented

        //update age
        //changes since previous version - reader has been removed as it was not needed
        internal void updateAge(SqlConnection connection, int player, int a)
        //pass in connection, player id (from ui), age (from ui)
        {
            try
            {
                connection.Open();

                //set variables
                    int id = player;
                    int age = a;

                //set sql string - using a simple update statement this will overwrite 
                //the current value int he database
                    string insert = @"UPDATE PlayerData SET Age = @age WHERE PlayerID = @player";
                //new connection
                    SqlCommand insertCommand = new SqlCommand(insert, connection);

                //set values (this enables the values to be parameterized)
                    insertCommand.Parameters.AddWithValue("@player", id);
                    insertCommand.Parameters.AddWithValue("@age", age);

                insertCommand.ExecuteNonQuery();//execute query

            }
            catch { }
            finally//encompasses the code to fully close the connection
            {
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }
        }


        //update distance
        //same steps as update age
        internal void updateDistance(SqlConnection connection, int player, int d)
        //pass in connection, player id, age
        {
            try
            {
                connection.Open();

                //set variables
                int id = player;
                int distance = d;

                //set string
                string insert = @"UPDATE PlayerData SET RunningDistance = @distance WHERE PlayerID = @player";
                //new connection
                SqlCommand insertCommand = new SqlCommand(insert, connection);

                //set values
                insertCommand.Parameters.AddWithValue("@player", id);
                insertCommand.Parameters.AddWithValue("@distance", d);

                insertCommand.ExecuteNonQuery();//execute query
    }
            catch { }
            finally//encompasses the code to fully close the connection
            {
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }
        }


        //update speed
        //same steps as update age
        internal void updateSpeed(SqlConnection connection, int player, double s)
        //pass in connection, reader, player id, age
        {
            try
            {
                connection.Open();

                //set variables
                int id = player;
                double speed = s;

                //set string
                string insert = @"UPDATE PlayerData SET MaximumSpeed = @speed WHERE PlayerID = @player";
                //new connection
                SqlCommand insertCommand = new SqlCommand(insert, connection);

                //set values
                insertCommand.Parameters.AddWithValue("@player", id);
                insertCommand.Parameters.AddWithValue("@speed", s);

                insertCommand.ExecuteNonQuery();//execute query
            }
            catch { }
            finally//encompasses the code to fully close the connection
            {
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }
        }



        //delete player
        public void deletePlayer(SqlConnection connection, int id)
        //pass in connection, id (from ui)
        {
            try
            {
                connection.Open();

                //create sql statement as a string
                    string delete = @"DELETE FROM PlayerData WHERE PlayerID = @id";
                //pass string and connection into sql command instance
                 SqlCommand deleteCommand = new SqlCommand(delete, connection);

                deleteCommand.Parameters.AddWithValue("@id", id);//set the parameter value

                deleteCommand.ExecuteNonQuery();//excecute the query
            }
            catch { }
            
            finally//encompasses the code to fully close the connection
            {

                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }
        }


        //add new player
        //returns a boolean value to alert the form method that the insert method worked
        //this then alerts the user on the ui
        public Boolean insertPlayer(SqlConnection connection, Player p)
        //pass in connection, player
        {
            try//encompass within a try/catch/finally block
            {
                connection.Open();//open connection to db

                //get parameters from player object
                    string name = p.Name;
                    int age = p.Age;
                    int height = p.Height;
                    int distance = p.Distance;
                    double speed = p.Speed;

                //instantiate new sql command which takes a statement and a connection as parameters
                //pass the variable parameters into sql statement
                SqlCommand command = new SqlCommand("INSERT INTO PlayerData (Name, Age, Height, RunningDistance, MaximumSpeed) VALUES "
                    + "(@name, @age, @height, @distance, @speed)", connection);


                //set the parameters
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);//shortcut
                    command.Parameters.AddWithValue("@height", height);
                    command.Parameters.AddWithValue("@distance", distance);
                    command.Parameters.AddWithValue("@speed", speed);

                command.ExecuteNonQuery();//excecutes the query

                return true;
            }
            catch
            {
                return false;
            }//catch exceptions - not currently set for any
            
            finally//encompasses the code to fully close the connection
            {
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }


        }

    
        //the following methods each involve a sql query using aggregate functions
        //MAX() MIN() AVG()
        
        //RUNNING DISTANCE
        public int maxDistance(SqlConnection connection)
        {
           connection.Open();
           try
           {
               //MAX() returns the highest value in a column
                   string query = @"SELECT MAX(RunningDistance) FROM PlayerData";
                   SqlCommand command = new SqlCommand(query, connection);
               //as it is only a single value returned, execute scalar can be called
               //the value is converted to an int - appropriate to return type
                    return Convert.ToInt32(command.ExecuteScalar());
           }
           catch { }
           finally//encompasses the code to fully close the connection
           {
               if (connection != null)//if there is a connection that is open - close it
               {
                   connection.Close();
               }
           }
           return 0;
        }

        public int minDistance(SqlConnection connection)
        {
            connection.Open();
            try
            {
                //MIN() returns smallest value in column
                    string query = @"SELECT MIN(RunningDistance) FROM PlayerData";
                    SqlCommand command = new SqlCommand(query, connection);
               //as it is only a single value returned, execute scalar can be called
               //the value is converted to an int - appropriate to return type
                     return Convert.ToInt32(command.ExecuteScalar());
            }
            catch { }
           finally//encompasses the code to fully close the connection
            {
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }
            return 0;
        }

        public double meanDistance(SqlConnection connection)
        {
            connection.Open();
            try
            {
                //AVG() returns average/mean of the column values
                    string query = @"SELECT AVG(RunningDistance) FROM PlayerData";
                    SqlCommand command = new SqlCommand(query, connection);
                //as it is only a single value returned, execute scalar can be called
                //the value is converted to an double - appropriate to return type
                //Math.Round used for formatting purposes
                    double meanDist = Convert.ToDouble(command.ExecuteScalar());
                    return Math.Round(meanDist, 1);
            }
            catch { }
           finally//encompasses the code to fully close the connection
            {
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }
            return 0;
        }



        //MAXIMUM SPEED
        //The same steps have been taken in the max speed calculations
        //all return types are doubles to math.round is used for each
        public double maxSpeed(SqlConnection connection)
        {
            connection.Open();
            try
            {
                string query = @"SELECT MAX(MaximumSpeed) FROM PlayerData";
                SqlCommand command = new SqlCommand(query, connection);
                double maxSp = Convert.ToDouble(command.ExecuteScalar());
                return Math.Round(maxSp, 1);
            }
            catch { }
           finally//encompasses the code to fully close the connection
            {
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }
            return 0;
        }

        public double minSpeed(SqlConnection connection)
        {
            connection.Open();
            try
            {
                string query = @"SELECT MIN(MaximumSpeed) FROM PlayerData";
                SqlCommand command = new SqlCommand(query, connection);
                return Convert.ToDouble(command.ExecuteScalar());
            }
            catch { }
           finally//encompasses the code to fully close the connection
            {
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }
            return 0;
        }

        public double meanSpeed(SqlConnection connection)
        {
            connection.Open();
            try
            {
                string query = @"SELECT AVG(MaximumSpeed) FROM PlayerData";
                SqlCommand command = new SqlCommand(query, connection);
                double meanSp = Convert.ToDouble(command.ExecuteScalar());
                return Math.Round(meanSp, 1);
            }
            catch { }
           finally//encompasses the code to fully close the connection
            {
                if (connection != null)//if there is a connection that is open - close it
                {
                    connection.Close();
                }
            }
            return 0;
        }



        //GET COUNT
        //returns the amount of rows in the database
        //used to test that update and deleting of records is taking place
        public int count(SqlConnection connection)
        {
            connection.Open();

            //get row count of db
            //initial number of rows
            SqlCommand command = new SqlCommand("SELECT COUNT(PlayerID) FROM PlayerData", connection);
            return Convert.ToInt32(command.ExecuteScalar());

        }



    }
}
