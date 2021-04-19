using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace tar3_server.Models.DAL
{
    public class DBServices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        public DBServices()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }

        //--------------------------------------------------------------------------------------------------
        // This method inserts a student to the student table 
        //--------------------------------------------------------------------------------------------------
        public int Insert(ingredients ingredients)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(ingredients);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //--------------------------------------------------------------------
        // Build the Insert command String
        //--------------------------------------------------------------------
        private String BuildInsertCommand(ingredients ingredients)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}','{2}')", ingredients.Name, ingredients.Image, ingredients.Calories);
            String prefix = "INSERT INTO ingredients_G_2021 " + "( [name], [image],[calories]) ";
            command = prefix + sb.ToString();

            return command;
        }
        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }

        public List<ingredients> ReadIng()
        {
            SqlConnection con = null;
            List<ingredients> INGList = new List<ingredients>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM ingredients_G_2021";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    ingredients b = new ingredients();

                    b.Id = Convert.ToInt32(dr["id"]);
                    b.Name = (string)dr["name"];
                    b.Image= (string)dr["image"];
                    b.Calories = Convert.ToDouble(dr["calories"]);
                    INGList.Add(b);
                }

                return INGList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }


        //========================================================dish
        public int InsertDish(dish dish)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(dish);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //--------------------------------------------------------------------
        // Build the Insert command String
        //--------------------------------------------------------------------
        private String BuildInsertCommand(dish dish)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}','{2}','{3}')", dish.Name, dish.Image, dish.CookingType,dish.Time);
            String prefix = "INSERT INTO dish_g_2021 " + "( [name], [image],[cookingType],[time]) ";
            command = prefix + sb.ToString();

            return command;
        }


        public List<dish> ReadDish()
        {
            SqlConnection con = null;
            List<dish> dishList = new List<dish>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM dish_g_2021";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    dish b = new dish();

                    b.Id = Convert.ToInt32(dr["id"]);
                    b.Name = (string)dr["name"];
                    b.Image = (string)dr["image"];
                    b.CookingType = (string)dr["cookingType"];
                    b.Time= Convert.ToDouble(dr["time"]);
                    dishList.Add(b);
                }

                return dishList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        //-------------------------------------------------ing dish

        public int InsertIng2Dish(inginDish inginDish)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(inginDish);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
        private String BuildInsertCommand(inginDish inginDish)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}')", inginDish.DishId, inginDish.IngId);
            String prefix = "INSERT INTO dish_g_2021 " + "( [dishId], [ingId]) ";
            command = prefix + sb.ToString();

            return command;
        }


        //=================================matala 4 memos
        public int Insertmemo(memos memos)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(memos);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //--------------------------------------------------------------------
        // Build the Insert command String
        //--------------------------------------------------------------------
        private String BuildInsertCommand(memos memos)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}')", memos.TypeId, memos.Text);
            String prefix = "INSERT INTO memos_g_2021 " + "( [type_id], memo_text) ";
            command = prefix + sb.ToString();

            return command;
        }
        //---------------------------------------------------------------------------------
        // Create the SqlCommand
        //---------------------------------------------------------------------------------
        

        public List<memos> Readmemos()
        {
            SqlConnection con = null;
            List<memos> memoList = new List<memos>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM memos_g_2021";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    memos b = new memos();

                    b.Id = Convert.ToInt32(dr["memo_id"]);
                    b.TypeId = Convert.ToInt32(dr["type_id"]);
                    b.Text = (string)dr["memo_text"];

                    memoList.Add(b);
                }

                return memoList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }
        //-------------------------------------------------------------------פרוייקט גמר
        public List<report> Readreport(string date)
        {
            SqlConnection con = null;
            List<report> INGList = new List<report>();

            try
            {
                con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

                String selectSTR = "SELECT * FROM report_g_2021 where date='"+date+"'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    report b = new report();

                    b.Report_num = Convert.ToInt32(dr["report_num"]);
                    b.Date = Convert.ToDateTime(dr["date"]);
                    b.Time= Convert.ToDateTime("8:00");
                    b.Text= (string)dr["text"];
                    b.Area = (string)dr["area"];
                    b.Link = (string)dr["link"];
                    b.Author = (string)dr["author"];
                    b.Beach = (string)dr["beach"];
                    INGList.Add(b);
                }

                return INGList;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

            }

        }

        public int InsertReport(report r)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(r);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }

        //--------------------------------------------------------------------
        // Build the Insert command String
        //--------------------------------------------------------------------
        private String BuildInsertCommand(report r)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}','{2}','{3}','{4}','{5}','{6}')", "2021/04/19", r.Time.ToString("HH:mm"), r.Text,r.Area,r.Link,r.Author,r.Beach);
            String prefix = "INSERT INTO report_g_2021 " + "(date,time,text,area,link,author,beach) ";
            command = prefix + sb.ToString();

            return command;
        }

       // public List<report> Readcoment()
       // {
          //  SqlConnection con = null;
          //  List<coment> comentList = new List<coment>();

         //   try
          //  {
          //      con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

             //   String selectSTR = "SELECT * FROM report_g_2021";
             //   SqlCommand cmd = new SqlCommand(selectSTR, con);

                // get a reader
            //    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            //    while (dr.Read())
            //    {   // Read till the end of the data into a row
              //      coment b = new coment();

            //        b.Coment_num = Convert.ToInt32(dr["coment_num"]);
                //    b.Report_num = Convert.ToInt32(dr["report_num"]); ;
                //    b.Time = Convert.ToDateTime("12:30");
               //     b.Date = Convert.ToDateTime(dr["date"]);
                //    b.Text = (string)dr["text"];
                   
                //    b.Author = (string)dr["author"];

               //     comentList.Add(b);
             //   }

               // return comentList;
          //  }
         //   catch (Exception ex)
           // {
          //      // write to log
             //   throw (ex);
         //   }
         //   finally
         //   {
            //    if (con != null)
            //    {
             //       con.Close();
            //    }

          //  }

       // }

    }
}