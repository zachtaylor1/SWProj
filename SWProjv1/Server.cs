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
                command.CommandText = "SELECT * FROM Room WHERE (building LIKE '" + searchTerm + "%' OR buildingLocation LIKE '" + searchTerm + "%')";
            else if (type.Equals("Student"))
                command.CommandText = "SELECT * FROM Student, User_T WHERE Student.UserID = User_T.UserID AND Student.userID= Student.studentID AND (User_T.firstName LIKE '" + searchTerm + "%' OR lastName LIKE '" + searchTerm + "%' OR studentID like '" + searchTerm + "%')";
            else if (type.Equals("Message"))
                command.CommandText = "SELECT * FROM Message, User_T WHERE messageAcknowledge = 0 AND recieverUserID = '" + User.userID + "' AND USer_T.userID = '" + User.userID + "' AND (User_T.firstName LIKE '" + searchTerm + "%' OR lastName LIKE '" + searchTerm + "%')";
            //command.CommandText = "SELECT * FROM Message, User_T WHERE messageAcknowledge = 0 AND recieverUserID IN (SELECT recieverUserID FROM Message, Admin WHERE recieverUserID=userID)  AND user_T.userID=Message.senderUserID;";
            else if (type.Equals("Key"))
                command.CommandText = "SELECT * FROM Message, User_T, Student WHERE recieverUserID = '000000000000000' AND messageAcknowledge = '0' AND senderUserID = User_T.userID AND Student.userID = Message.senderUserID AND (User_T.firstName LIKE '" + searchTerm + "%' OR lastName LIKE '" + searchTerm + "%')";
            else if (type.Equals("RA Application"))
                command.CommandText = "select * from RAApplication,Student,User_T where isAcknowledged = 0 AND RAApplication.studentID = Student.studentID AND Student.userID = User_T.userID AND (User_T.firstName LIKE '" + searchTerm + "%' OR lastName LIKE '" + searchTerm + "%')";
            else if (type.Equals("Furniture"))
                command.CommandText = "SELECT * FROM Furniture WHERE RoomID LIKE '" + searchTerm + "'";
            else if (type.Equals("Audit"))
                command.CommandText = "SELECT * FROM Audit";
            else
                command.CommandText = "SELECT 'Uh oh!'";
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
                            reader.GetString(0).Trim(),
                            reader.GetBoolean(3),
                            "123",//reader.GetString(2).Trim(),
                            "0000000000001",//reader.GetString(1).Trim(),
                            reader.GetString(7).Trim(),
                            reader.GetString(9).Trim(),
                            reader.GetString(8).Trim(),
                            reader.GetString(5).Trim(),
                            reader.GetString(6).Trim(),
                            reader.GetDateTime(10).ToString().Trim()
                            );
                        student.setListBoxItem();
                        results.Add(student.listboxitem);
                        break;
                    case "SWProjv1.Message":
                        Message message = new Message(
                            reader.GetString(1).Trim(),
                            reader.GetString(2).Trim(),
                            reader.GetString(3).Trim(),
                            reader.GetDateTime(4).ToString().Trim(),
                            reader.GetString(8).Trim() + " " + reader.GetString(9).Trim(),
                            reader.GetInt32(0).ToString()
                            );
                        message.setListBoxItem();
                        results.Add(message.listboxitem);
                        break;
                    case "SWProjv1.RA Application":
                        RAApplicationData rad = new RAApplicationData(
                            reader.GetString(11).Trim() + " " + reader.GetString(12).Trim(),
                            reader.GetBoolean(1),
                            reader.GetBoolean(2),
                            reader.GetInt32(3),
                            reader.GetString(4).Trim()
                            );
                        rad.setListBoxItem();
                        results.Add(rad.listboxitem);
                        break;
                    case "SWProjv1.Key":
                        TempKey key = new TempKey(
                            reader.GetString(8).Trim() + " " + reader.GetString(9).Trim(),
                            reader.GetString(0).Trim(),
                            reader.GetString(13).Trim()
                            );
                        key.setListBoxItem();
                        results.Add(key.listboxitem);
                        break;
                    case "SWProjv1.Audit":
                        Audit audit = new Audit(
                            reader.GetString(1).Trim(),
                            reader.GetString(2).Trim()
                        );
                        audit.setListBoxItem();
                        results.Add(audit.listboxitem);
                        break;
                    default:
                        break;
                }
            }
            reader.Close();
            return results;
        }
        public static void Executer(String command)
        {
            SqlCommand cmd = new SqlCommand(command, sql);
            cmd.ExecuteNonQuery();
        }
        public static String[] studentHomeQuery(Student student)
        {
            SqlCommand cmd = new SqlCommand("SELECT userID FROM User_T WHERE username = '" + student.username + "' AND password = '" + student.password + "'", sql);
            SqlDataReader red = cmd.ExecuteReader();
            red.Read();
            User.userID = red.GetString(0);
            red.Close();
            cmd.CommandText = ("SELECT studentID FROM Student WHERE userID = '" + Student.userID + "'");
            red = cmd.ExecuteReader();
            red.Read();
            User.userID = red.GetString(0);
            red.Close();
            cmd.CommandText = ("SELECT * FROM RoomHistory, Room WHERE RoomHistory.studentID = '" + Student.userID + "' AND RoomHistory.roomID = Room.roomID");
            red = cmd.ExecuteReader();
            red.Read();
            String[] x = { red.GetString(6).Trim(), red.GetString(9).Trim() + red.GetString(5).Trim(), red.GetDateTime(2).ToString().Trim().Split()[0], red.GetString(7).Trim(), red.GetString(8).Trim() };
            red.Close();
            return x;
        }
        public static String[] adminHomeQuery(Admin admin)
        {
            //SELECT Admin.userID, Admin.employeeID FROM Admin,User_T WHERE Admin.userID = User_T.userID and username = 'yonda' and password = 'Yonda100'
            SqlCommand cmd = new SqlCommand("SELECT Admin.userID, Admin.employeeID FROM Admin,User_T WHERE Admin.userID = User_T.userID and username = '" + admin.username + "'", sql);
            SqlDataReader red;
            red = cmd.ExecuteReader();
            red.Read();
            String[] x = { red.GetString(0), red.GetString(1) };
            User.userID = x[0];
            admin.adminID = x[1];
            return x;
        }
        public static void SendMessage(string text1, string text2, string userID)
        {
            SqlCommand cmd = new SqlCommand("EXEC CreateMessage '" + text2 + "','" + userID + "','" + text1 + "'", sql);
            cmd.ExecuteNonQuery();
        }
        public static List<Furniture> getFurniture(String roomID)
        {

            List<Furniture> results = new List<Furniture>();
            setCommand("Furniture", roomID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                results.Add(new Furniture(
                            reader.GetInt32(2).ToString(),
                            reader.GetString(1).Trim(),
                            reader.GetString(0).Trim()
                            ));
            }reader.Close();
            return results;
        }

        public static int LogInQuery(String username, String password)
        {
            Init();
            command.CommandText = "LogInProc";
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@uname", username));
            command.Parameters.Add(new SqlParameter("@pword", password));
            command.Parameters.Add(new SqlParameter("@result", System.Data.SqlDbType.Int)).Direction = System.Data.ParameterDirection.Output;
            command.ExecuteNonQuery();
            int result = Convert.ToInt32(command.Parameters["@result"].Value);
            return result;
        }

        public static string getcommandtext()
        {
            return command.CommandText;
        }

        public static List<ListBoxItem> getRoomHistory(String roomID)
        {
            command.CommandText = "SELECT * FROM RoomHistory, Student, User_T WHERE RoomHistory.studentID = Student.studentID AND Student.userID = User_t.userID AND RoomHistory.RoomID = " + roomID;
            SqlDataReader reader = command.ExecuteReader();
            List<ListBoxItem> ll = new List<ListBoxItem>();
            while (reader.Read())
            {
                ListBoxItem item = new ListBoxItem();
                String s = reader.GetString(11).Trim()+" "+ reader.GetString(12).Trim();
                s+="    "+reader.GetString(1).Trim();
                s+="    "+reader.GetDateTime(2).ToString();
                s+="    "+reader.GetDateTime(3).ToString();
                item.Content = s;
                ll.Add(item);
            }
            return ll;
        }

        public static void delFurniture(String serialNum)
        {
            command.CommandText = "DELETE FROM Furniture WHERE serialNumber = " + serialNum;
            command.ExecuteNonQuery();
        }

        public static void addFurniture(String roomID, String serialNum, String name)
        {
            command.CommandText = "EXEC FurnitureAdd '" + roomID + "', '" + name + "', " + serialNum;//"INSERT INTO Furniture VALUES (" + roomID + "," + serialNum + "," + name + ")";
            command.ExecuteNonQuery();
        }

        public static String getRoommateName(String roommateID)
        {
            command.CommandText = "SELECT * FROM Student, User_T WHERE Student.UserID = User_T.UserID AND Student.userID= Student.studentID AND Student.studentID = " + roommateID;
            SqlDataReader reader = command.ExecuteReader();
            String s="";
            while (reader.Read())
            {
                s = reader.GetString(7).Trim() + " " + reader.GetString(9).Trim() + " " + reader.GetString(8).Trim();
            }reader.Close();
            return s;
        }

        public static void addAudit(String title, String description)
        {
            SqlCommand cmd = new SqlCommand("EXEC addAudit '" + title + "','" + description + "'");
            cmd.ExecuteNonQuery();
        }
    }
}
