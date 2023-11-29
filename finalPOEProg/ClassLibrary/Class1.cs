using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.CodeDom.Compiler;
using System.Xml.Linq;



namespace ClassLibrary
{
    public class Class1
    {
             
        SqlConnection conn = new SqlConnection("Data Source=(localDB)\\ProjectModels;Initial Catalog= ModuleApps;Integrated Security=True;");
        public Boolean check = false;

        public int Property
        {
            get => default;
            set
            {
            }
        }

        public string users(string username, string password)
        {
            //declaring a temp variable for a returning mess
            //open connection 
            string message = "";
            if (password != null)
            {
                string hashedPassword = HashPassword(password);

                try
                {
                    conn.Open();
                    //query to insert the user from the database
                    string query = "INSERT INTO usertrack VALUES ('" + username + "', '" + hashedPassword + "');";
                    SqlCommand excutes = new SqlCommand(query, conn);
                    excutes.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    message = " Error" + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
            return message;
        }

        public Boolean login(string username, string password)
        {
            string message = "";
            if (password != null && username != "")
            {
                string hashedPassword = HashPassword(password);

                try
                {
                    // open connection
                    conn.Open();

                    string query = "select * from usertrack where username = '" + username + "'  AND  password = '" + hashedPassword + "';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter get_user = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    get_user.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        check = true;
                        message = "User found: " + table.Rows[0]["username"].ToString();
                    }
                    else
                    {
                        check = false;
                        message = "User not found";
                    }
                }
                catch (Exception ex)
                {
                    // Error occurred, handle the exception
                    message = "Error: " + ex.Message;
                }
                finally
                {
                    // close connection
                    conn.Close();
                }
            }
            return check;

        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public void Module(string Code, string Name, int Credits, int ClassHour, int SelfStudyHours, string Startdate, string username)
        {
            string message = "";
            try
            {
                //query to insert into database

                string query = "insert into studymodu values('" + Code + "' , '" + Name + "' , '" + Credits + "' , '" + ClassHour + "' ,'" + SelfStudyHours + "' , '" + Startdate + "', '" + username + "')";
                //open connection
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                message = "module sucessfully  added";
                ;
            }
            catch (Exception ex)
            {
                message = " Error :" + ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

        public void get_module(List<string> id, List<string> Code, List<string> Name, List<string> Credits, List<string> ClassHour, List<string> SelfStudyHours, List<string> Startdate, string username)
        {
            //string message = "";

            string query = "select * from studymodu where username = '" + username + "'";
            conn.Open();
            SqlDataAdapter runs = new SqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            runs.Fill(table);
            SqlCommand reads = new SqlCommand(query, conn);
            SqlDataReader checks = reads.ExecuteReader();

            //while loop to count the values
            int count = 0;

            while (checks.Read())
            {

                //adding modules info into the generics
                id.Add(table.Rows[count]["id"].ToString());
                Code.Add(table.Rows[count]["Code"].ToString());
                Name.Add(table.Rows[count]["Name"].ToString());
                Credits.Add(table.Rows[count]["Credits"].ToString());
                ClassHour.Add(table.Rows[count]["ClassHour"].ToString());
                SelfStudyHours.Add(table.Rows[count]["SelfStudyHours"].ToString());
                Startdate.Add(table.Rows[count]["Startdate"].ToString());
                count++;
            }


            conn.Close();
        }

        public string minusHour(string idS, string onHours)
        {
            conn.Open();

            string checkId = "select * from studymodu where id = '" + idS + "';";

            SqlDataAdapter runs = new SqlDataAdapter(checkId, conn);

            DataTable table = new DataTable();

            runs.Fill(table);


            string ho = table.Rows[0]["SelfStudyHours"].ToString();

            if (ho.Contains("-") || ho.Equals("hours used up"))
            {
                ho = "hours used up";
            }
            else
            {
                double has = int.Parse(ho) - int.Parse(onHours);

                ho = "" + has;
            }

            string did = "update studymodu set SelfStudyHours ='" + ho + "' where id='" + idS + "';";

            SqlCommand reads = new SqlCommand(did, conn);
            reads.ExecuteNonQuery();

            conn.Close();



            return ho;
        }

       
        }
    }


