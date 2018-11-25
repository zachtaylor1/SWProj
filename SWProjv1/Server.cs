using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SWProjv1
{
    class Server
    {
        static SqlConnection sql;
        public static SqlCommand command;

        public static bool Init()
        {
            try
            {
                sql = new SqlConnection("Data Source =ZACHMAC\\SQLEXPRESS; Initial Catalog = SEProjectDB ; Integrated Security = SSPI");
                sql.Open();
                command = sql.CreateCommand();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static void setCommand(String type, String searchTerm)
        {
            if (type.Equals("Room"))
                command.CommandText = "SELECT * FROM " + type;
            else if (type.Equals("Student"))
                command.CommandText = "SELECT * FROM Student, User_T WHERE Student.UserID = User_T.UserID";
        }

        public static List<ListBoxItem> runQuery(String type)
        {
            List<ListBoxItem> results = new List<ListBoxItem>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                switch (type)
                {
                    case "SWProjv1.Room":
                        String roomSide;
                        try
                        {
                            roomSide = reader.GetString(1).Trim();
                        }
                        catch (Exception excep)
                        {
                            roomSide = "";
                        }
                        Room room = new Room(
                            reader.GetString(0).Trim(),
                            roomSide,
                            reader.GetString(2).Trim(),
                            reader.GetString(3).Trim(),
                            reader.GetString(4).Trim(),
                            reader.GetString(5).Trim()
                        );
                        room.setListBoxItem();
                        results.Add(room.listboxitem);
                        break;
                    case "SWProjv1.Student":
                        Student student = new Student(
                                
                            );
                        break;
                }
            }
            reader.Close();
            return results;
        }
    }
}
