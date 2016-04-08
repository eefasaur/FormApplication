using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerFormApp
{
    class DatabaseMethods
    {


        //copied from original form project

        //insert player
        internal Boolean insertPlayer(SqlConnection connection, Player p)
        //pass in connection, reader, player
        {
            try//encompass within a try/catch/finally block
            {
                connection.Open();//open connection to db

                //get parameters
                string name = p.Name;
                int height = p.Height;
                int age = p.Age;
                int distance = p.Distance;
                double speed = p.Speed;

                //instantiate new sql command which takes a statement and a connection as parameters
                //pass the variable parameters into sql statement
                SqlCommand command = new SqlCommand("INSERT INTO PlayerData (Name, Age, Height, RunningDistance, MaximumSpeed) VALUES "
                    + "(@name, @age, @height, @distance, @speed)", connection);


                //two different ways of setting the parameter values
                //command.Parameters.Add("@name", SqlDbType.Text);
                //command.Parameters["@name"].Value = name;//the proper way
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


        //delete player
        internal void deletePlayer(SqlConnection connection, int id)
        //pass in connection, reader, id (from user input)
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


        //view players
        internal DataSet viewPlayers(SqlConnection connection, SqlDataReader reader)
        //pass in connection and reader
        {
            //http://stackoverflow.com/questions/18113278/populate-a-datagridview-with-sql-query-results

            try
            {
                connection.Open();//open connection to db


                //Name, Age, Height, RunningDistance, MaxiumumSpeed
                //new command
                //SqlCommand command = new SqlCommand("SELECT * FROM Player", connection);
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM PlayerData", connection);
                SqlCommandBuilder command = new SqlCommandBuilder(adapter);



                DataSet ds = new DataSet();
                adapter.Fill(ds);

                return ds;


            }
            catch
            {

            }
            
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



        //update age
        //changes since previous version - reader has been removed as it was not needed
        internal void updateAge(SqlConnection connection, int player, int a)
        //pass in connection, reader, player id, age
        {
            try
            {
                connection.Open();

                //set variables
                int id = player;
                int age = a;

                //set string
                string insert = @"UPDATE PlayerData SET Age = @age WHERE PlayerID = @player";
                //new connection
                SqlCommand insertCommand = new SqlCommand(insert, connection);

                //set values
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
        //changes since previous version - reader has been removed as it was not needed
        internal void updateDistance(SqlConnection connection, int player, int d)
        //pass in connection, reader, player id, age
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
        //changes since previous version - reader has been removed as it was not needed
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

    }
}
