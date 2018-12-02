using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                MessageBox.Show("Error Connecting to Database. Please ensure the Connection String is correct. \n\n" + e.Message);
                return false;
            }
        }

        public static void setCommand(String type, String searchTerm)
        {
            command.Parameters.Clear();
            if (type.Equals("Room"))
                command.CommandText = "SELECT * FROM Room WHERE (building LIKE '" + searchTerm + "%' OR buildingLocation LIKE '" + searchTerm + "%')";
            else if (type.Equals("Student"))
                command.CommandText = "SELECT * FROM Student, User_T WHERE Student.UserID = User_T.UserID AND Student.userID= Student.studentID AND (User_T.firstName LIKE '" + searchTerm + "%' OR lastName LIKE '" + searchTerm + "%' OR studentID like '" + searchTerm + "%')";
            else if (type.Equals("Message"))
                command.CommandText = "SELECT * FROM Message, User_T WHERE messageAcknowledge = 0 AND recieverUserID = '" + User.userID + "' AND USer_T.userID = senderUserID AND (User_T.firstName LIKE '" + searchTerm + "%' OR lastName LIKE '" + searchTerm + "%')";
            //command.CommandText = "SELECT * FROM Message, User_T WHERE messageAcknowledge = 0 AND recieverUserID IN (SELECT recieverUserID FROM Message, Admin WHERE recieverUserID=userID)  AND user_T.userID=Message.senderUserID;";
            else if (type.Equals("Key"))
                command.CommandText = "SELECT * FROM Message, User_T, Student, Room WHERE recieverUserID = '000000000000000' AND Student.roomID=Room.RoomID AND messageAcknowledge = '0' AND senderUserID = User_T.userID AND Student.userID = Message.senderUserID AND (User_T.firstName LIKE '" + searchTerm + "%' OR lastName LIKE '" + searchTerm + "%')";
            else if (type.Equals("RA Application"))
                command.CommandText = "select * from RAApplication,Student,User_T where isAcknowledged = 0 AND RAApplication.studentID = Student.studentID AND Student.userID = User_T.userID AND (User_T.firstName LIKE '" + searchTerm + "%' OR lastName LIKE '" + searchTerm + "%')";
            else
                command.CommandText = "SELECT 'Uh oh!'";
            //command.Parameters.Add(new SqlParameter("@searchTerm", searchTerm));
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
                        String roommateNum, roomNum;
                        try { roommateNum = reader.GetString(2).Trim(); }
                        catch (Exception) { roommateNum = ""; }
                        try { roomNum = reader.GetString(1).Trim(); }
                        catch (Exception) { roomNum = ""; }
                        Student student = new Student(
                            reader.GetString(0).Trim(),
                            reader.GetBoolean(3),
                            roommateNum,
                            roomNum,
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
                            reader.GetString(23).Trim()+" "+ reader.GetString(20).Trim(),
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
            red.Close();
            return x;
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
            command.CommandText = "SELECT * FROM RoomHistory, Student, User_T WHERE RoomHistory.studentID = Student.studentID AND Student.userID = User_t.userID AND RoomHistory.RoomID = '" + roomID+"'";
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
            }reader.Close();
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
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM Student, User_T WHERE Student.UserID = User_T.UserID AND Student.userID= Student.studentID AND Student.studentID = " + roommateID;
            SqlDataReader reader = command.ExecuteReader();
            String s="";
            while (reader.Read())
            {
                s = reader.GetString(7).Trim() + " " + reader.GetString(9).Trim() + " " + reader.GetString(8).Trim();
            }reader.Close();
            return s;
        }

        public static void SendMessage(string text1, string text2, string userID)
        {
            //SqlCommand cmd = new SqlCommand("EXEC CreateMessage '"+text2+"','"+ userID +"','"+text1+"'", sql);
            SqlCommand cmd = new SqlCommand("EXEC CreateMessage @text2,@userID,@text1", sql);
            cmd.Parameters.Add(new SqlParameter("@text2", text2));
            cmd.Parameters.Add(new SqlParameter("@text1", text1));
            cmd.Parameters.Add(new SqlParameter("@userID", userID));
            cmd.ExecuteNonQuery();
        }

        public static void addAudit(String title, String description)
        {
            SqlCommand cmd = new SqlCommand("EXEC addAudit @title,@description");
            cmd.Parameters.Add(new SqlParameter("@title", title));
            cmd.Parameters.Add(new SqlParameter("@description", description));
            cmd.ExecuteNonQuery();
        }


        private static void setCommandApplication(String type, String parameter) //parameter is schoolYear or applicationID
        {
            if (type.Equals("Application"))
                command.CommandText = "SELECT * FROM Application WHERE Application.studentID NOT IN " +
                    "(SELECT studentID FROM RoomHistory WHERE dateEntered > '" + parameter + "')";
            else if (type.Equals("Sport"))
                command.CommandText = "SELECT * FROM Sport WHERE applicationID = '" + parameter + "'";
            else if (type.Equals("musicType"))
                command.CommandText = "SELECT * FROM musicType WHERE applicationID = '" + parameter + "'";
            else if (type.Equals("Hobby"))
                command.CommandText = "SELECT * FROM Hobby WHERE applicationID = '" + parameter + "'";
        }



        public static List<ResApplicationForm> runQueryApplication(int schoolYear) //collects the most recent year of applications
        {
            String schoolString = schoolYear.ToString();
            setCommandApplication("Application", schoolString);

            List<ResApplicationForm> applications = new List<ResApplicationForm>();
            MessageBox.Show(command.CommandText);
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ResApplicationForm a0 = new ResApplicationForm();
                String applicationID = reader.GetInt32(0).ToString();
                a0.applicationID = applicationID;
                a0.studentID = reader.GetString(1).Trim();
                a0.firstName = reader.GetString(2).Trim();
                a0.lastName = reader.GetString(3).Trim();
                a0.otherName = reader.GetString(4).Trim();
                a0.schoolYear = schoolYear;
                a0.gender = reader.GetString(6).Trim();
                a0.email = reader.GetString(7).Trim();
                a0.streetAddress = reader.GetString(8).Trim();
                a0.city = reader.GetString(9).Trim();
                a0.region = reader.GetString(10).Trim();
                a0.country = reader.GetString(11).Trim();
                a0.postalCode = reader.GetString(12).Trim();
                a0.phoneCountryCode = reader.GetString(13).Trim();
                a0.phoneAreaCode = reader.GetString(14).Trim();
                a0.phoneNumber = reader.GetString(15).Trim();
                a0.preferBuilding = reader.GetString(16).Trim();
                a0.smokes = reader.GetBoolean(17);
                a0.liveWithSmoke = reader.GetBoolean(18);
                a0.drinks = reader.GetBoolean(19);
                a0.liveWithDrink = reader.GetBoolean(20);
                a0.marijuana = reader.GetBoolean(21);
                a0.liveWithMarijuana = reader.GetBoolean(22);
                a0.socialLevel = reader.GetString(23).Trim();
                a0.bedtime = reader.GetString(24).Trim();
                a0.wakeUp = reader.GetString(25).Trim();
                a0.volumeLevel = reader.GetString(26).Trim();
                a0.overnightVisitors = reader.GetBoolean(27);
                a0.cleanliness = reader.GetString(28).Trim();
                a0.studiesInRoom = reader.GetBoolean(29);
                a0.roommateRequest = reader.GetBoolean(30);
                a0.roommateName = reader.GetString(31).Trim();
                a0.roommateID = reader.GetString(32).Trim();
                a0.mealPlan = reader.GetString(33).Trim();

                applications.Add(a0);
            }
            reader.Close();

            foreach (ResApplicationForm a0 in applications)
            {
                setCommandApplication("Sport", a0.applicationID); //gets Sports table
                reader = command.ExecuteReader();
                List<String> sports = new List<String>();
                while (reader.Read())
                    sports.Add(reader.GetString(1));
                a0.sports = sports.ToArray();
                reader.Close();

                setCommandApplication("musicType", a0.applicationID); //gets Music table
                reader = command.ExecuteReader();
                List<String> music = new List<String>();
                while (reader.Read())
                    music.Add(reader.GetString(1));
                a0.music = music.ToArray();
                reader.Close();

                setCommandApplication("Hobby", a0.applicationID); //gets Hobbies table
                reader = command.ExecuteReader();
                List<String> hobbies = new List<String>();
                while (reader.Read())
                    hobbies.Add(reader.GetString(1));
                a0.hobbies = hobbies.ToArray();
                reader.Close();
            }

            return applications;
        }

        public static String getEmptyRoomID(String dorm, String year)
        {
            String emptyRooms = "select DISTINCT Room.roomID from Room, RoomHistory where " +
                "(Room.roomID = RoomHistory.roomID AND RoomHistory.dateLeft IS NOT NULL AND RoomHistory.dateLeft > '"+year+"')" +
                " OR (Room.roomID NOT IN (SELECT roomID FROM RoomHistory)) AND Room.building = '"+dorm+"'";
            command.CommandText = emptyRooms;

            int times = 0;
            String roomID = "'''";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read() && times == 0)
            {
                roomID = reader.GetString(0).Trim();
                times++;
            }
            reader.Close();

            return roomID;
        }

        public static String getRoomNum(String dorm, String year)
        {
            String roomID = getEmptyRoomID(dorm, year);
            String emptyRooms = "select buildingLocation from Room where roomID = '" + roomID + "'";
            command.CommandText = emptyRooms;

            int times = 0;
            String roomNum = "'''";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read() && times == 0)
            {
                roomNum = reader.GetString(0).Trim();
                times++;
            }
            reader.Close();

            return roomNum;
        }

        public static String getAdjoiningID(String roomID, String roomNum)
        {
            String adjoining = "select roomID from Room where roomID != '" + roomID + "' AND buildingLocation = '" + roomNum + "'";
            command.CommandText = adjoining;

            int times = 0;
            String adRoomID = "'''";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read() && times == 0)
            {
                adRoomID = reader.GetString(0).Trim();
                times++;
            }
            reader.Close();

            return adRoomID;
        }

        public static void assignRoom(String studentID, String roomID)
        {
            DateTime dateTime = DateTime.Now;
            String formatted = dateTime.ToString("yyyy-MM-dd");
            command.CommandType = System.Data.CommandType.Text;
            String insertStmt = "INSERT INTO RoomHistory values ('" + roomID + "', '" + studentID + "', '" + formatted + "', NULL)";
            command.CommandText = insertStmt;
            command.ExecuteNonQuery();
        }

        public static void Blacklist(String studentID, bool bl)
        {
            command.CommandType = System.Data.CommandType.Text;
            if(bl) command.CommandText = "UPDATE Student SET blacklisted = 1 WHERE studentID = '" + studentID + "'";
            else command.CommandText = "UPDATE Student SET blacklisted = 0 WHERE studentID = '" + studentID + "'";
            command.ExecuteNonQuery();
        }

        public static List<ListBoxItem> getStudentHistory(String studentNum)
        {
            command.CommandText = "SELECT * FROM RoomHistory, Room WHERE studentID = '" + studentNum + "'";
            command.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = command.ExecuteReader();
            List<ListBoxItem> ll = new List<ListBoxItem>();
            while (reader.Read())
            {
                String s = reader.GetString(9).Trim() + reader.GetString(5).Trim() + " " + reader.GetString(6).Trim();
                s += "  " + reader.GetString(2).Trim() + "   " + reader.GetString(3).Trim();
                ListBoxItem lb = new ListBoxItem();
                lb.Content = s;
                ll.Add(lb);
            }
            reader.Close();
            return ll;
        }
    }
}
