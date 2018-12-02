using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FillDatabase2
{
    class Filler
    {
        static int FURNITURE_PER_ROOM = 10;
        static int NUM_RAAPPLICATION = 20;
        static int NUM_APPLICATION = 25;
        static int NUM_USER = 1000;
        static int NUM_TEMP_KEY = 100;
        static int ASSIGNED_KEY = 10;

        static String[] FNames = { "Abby", "Ben", "Charlie", "Danielle", "Edgar", "Faith", "Greg", "Henry", "India", "Juan", "Kathy", "Liam", "Mandy", "Nate", "Ophelia", "Pedro", "Qwerty", "Robert", "Stacy", "Tuck", "Ula", "Vinesh", "Wendy", "Xavier", "Yonda", "Zach" };
        static String[] LNames = { "Adams", "Barter", "Cockburn", "DiAngelo", "Eisenhower", "Fogerty", "Gallant", "Hilbert", "Iroquois", "Jay", "Kavanaugh", "Limburgh", "McDonald", "Niro", "Obama", "Peterson", "Quill", "Robertson", "Stallone", "Tominson", "Umbridge", "Vanderson", "Washington", "Xanthopoulos", "Yates", "Zhou" };
        //27
        static String[] adjective = { "Red", "Green", "Blue", "Yellow", "Large", "Small", "Sharp", "Neutral", "Ambiguous", "Pedantic", "Multi-Fabric", "Clean", "New", "Used", "Tall", "Shapely", "Modern", "Dingy", "Stained", "Perfect", "Cozy", "Round", "Wet", "Dry", "Sharp", "Q-Shaped", "Ancient" };
        //20
        static String[] noun = { "Single Bed", "Double Bed", "Lamp", "Desk", "Coat Rack", "Chair", "Table", "Microwave", "Refridgerator", "Rug", "Couch", "Dresser", "Phone Book", "Television", "Vacuum", "Cabinet", "Shelf", "Mirror", "Extention Cord", "Toaster Oven" };
        static SqlConnection sql;
        static void Main(string[] args)
        {
                                                    //MO CHANGE THIS
            sql = new SqlConnection("Data Source = JAKES-LAPTOP\\SQLEXPRESS; Initial Catalog = SEProjectDB ; Integrated Security = SSPI");
            sql.Open();
            Console.WriteLine("Connected");
            ClearMessage();
            ClearRoomHistory();
            ClearFurniture();
            ClearTempKey();
            ClearRoom();
            ClearRAApplication();
            ClearApplication();
            ClearUserType();
            ClearUsers();
            FillUsers();
            FillUserType();
            FillApplication();
            FIllRAApplication();
            FillRoom();
            FillTempKey();
            FillFurniture();
            FillRoomHistory();
            FillMessage();
            Console.WriteLine("Database has been Cleared and Reset. Press any key to Exit");
            Console.ReadKey();
        }
        static void ClearTempKey()
        {
            Console.WriteLine("Clearing Temp Keys");
            SqlCommand cmd = new SqlCommand("DELETE FROM TempKey WHERE keyID NOT LIKE '0000000%'", sql);
            cmd.ExecuteNonQuery();
        }
        static void FillTempKey()
        {
            Console.WriteLine("Filling Temp Keys");
            SqlCommand cmd = new SqlCommand("", sql);
            for (int i = 0; i < NUM_TEMP_KEY; i++)
            {
                cmd.CommandText = "INSERT INTO TempKey VALUES(" + i.ToString() + ", 0, NULL, NULL, NULL, NULL, NULL, NULL)";
                cmd.ExecuteNonQuery();
            }
            int prev = -1;
            int[] RAID = { 150, 225, 375, 450, 525, 675, 75, 750, 825, 975 };
            cmd.CommandText = "";
            for (int i = 0; i < ASSIGNED_KEY; i++)
            {
                Random r = new Random();

                int keyID = r.Next(0, NUM_TEMP_KEY);
                int RAIDindex = r.Next(0, 9);
                while (keyID == prev)
                {
                    keyID = r.Next(0, NUM_TEMP_KEY);
                    RAIDindex = r.Next(0, 9);
                }
            }
        }
        static void FillApplication()
        {
            Console.WriteLine("Filling Application");
            SqlCommand cmd = new SqlCommand("", sql);
            int prev = -1;
            List<int> used = new List<int>();
            Random r = new Random();

            for (int i = 0; i < NUM_APPLICATION; i++)
            {
                int stunum = r.Next(0, NUM_USER);
                while (stunum == prev || stunum % 100 == 0 || stunum % 75 == 0 || used.Contains(stunum))
                    stunum = r.Next(0, NUM_USER);
                used.Add(stunum);
                SqlCommand command = new SqlCommand("SELECT firstName, lastName, otherName FROM User_T, Student WHERE User_T.userID = Student.userID AND studentID = '" + stunum.ToString() + "'", sql);
                SqlDataReader read = command.ExecuteReader();
                String fname, mname, lname;
                read.Read();
                fname = read.GetString(0);
                lname = read.GetString(1);
                mname = read.GetString(2);
                read.Close();
                String gender = "M";
                if (stunum % 3 == 0) gender = "F"; else if (stunum % 3 == 1) gender = "O";
                String building = "Mackay";
                if (mname.Contains("e")) building = "Dunn";
                int smoke = (int)Math.Round(r.NextDouble());

                cmd.CommandText += "EXEC SubmitApplication '" + stunum.ToString() + "', '" + fname + "', '" + lname + "', '" + mname + "', 2017, '" + gender + "', '" + fname.Trim() + stunum.ToString() + "@unb.ca', '100 Tucker Park Road', 'Saint John', 'New Brunswick', 'Canada', 'E1E 3L2', '1', '506', '310-3030', '" + building + "'," + ((stunum % 11) % 2).ToString() + " , " + ((stunum % 17) % 2).ToString() + ", " + ((stunum % 13) % 2).ToString() + "," + ((stunum % 7) % 2).ToString() + " , " + ((stunum % 23) % 2).ToString() + "," + smoke.ToString() + " , 'Introverted', '7:00 PM', '6:00AM', 'Loud', 1, 'Messy'," + (stunum % 2).ToString() + " ,0 , 'N/A', 'N/A', 'Half';";
            }
            cmd.ExecuteNonQuery();
        }
        static void FIllRAApplication()
        {
            Console.WriteLine("Filling RA Applications");
            SqlCommand cmd = new SqlCommand("", sql);
            int prev = -1;
            List<int> used = new List<int>();
            Random r = new Random();

            for (int i = 0; i < NUM_RAAPPLICATION; i++)
            {
                int raid = r.Next(1, NUM_USER);
                while (raid == prev || used.Contains(raid) || raid % 100 == 0 || raid % 75 == 0)
                    raid = r.Next(1, NUM_USER);
                used.Add(raid);
                cmd.CommandText = "EXEC NewRAApplication '" + raid.ToString() + "'";
                cmd.ExecuteNonQuery();

            }
        }
        static void ClearApplication()
        {
            Console.WriteLine("Clearing Application");
            SqlCommand cmd = new SqlCommand("DELETE FROM Application WHERE studentID NOT LIKE '000000%'", sql);
            cmd.ExecuteNonQuery();
        }
        static void ClearRAApplication()
        {
            Console.WriteLine("Clearing RAApplication");
            SqlCommand cmd = new SqlCommand("DELETE FROM RAApplication WHERE studentID NOT LIKE '000000%'", sql);
            cmd.ExecuteNonQuery();
        }
        static void FillFurniture()
        {
            Console.WriteLine("Filling Furniture");
            SqlCommand cmd = new SqlCommand("", sql);
            Random r = new Random();
            Random s = new Random();

            for (int i = 0; i < 180; i++)
            {
                int prev = -1;
                for (int j = 0; j < FURNITURE_PER_ROOM; j++)
                {

                    int ad = r.Next(0, 27);
                    int no = s.Next(0, 20);
                    if (prev != ad)
                    {
                        cmd.CommandText = "EXEC FurnitureAdd '" + i.ToString() + "', ' A " + adjective[ad] + " " + noun[no] + "'";
                        cmd.ExecuteNonQuery();
                        prev = ad;
                    }
                    else
                    {
                        j--;
                    }
                }
            }
        }
        static void ClearFurniture()
        {
            Console.WriteLine("Clearing Furniture");

            SqlCommand cmd = new SqlCommand("DELETE FROM Furniture WHERE serialNumber <> 1000000", sql);
            cmd.ExecuteNonQuery();
        }
        static void FillRoomHistory()
        {
            Console.WriteLine("Filling Room Histories");

            List<int> usedstunum = new List<int>();
            SqlCommand cmd = new SqlCommand("", sql);
            String RoomID, studentid, dateEntered, dateLeft;
            Random r = new Random();

            for (int i = 0; i < 160; i++)
            {//roomid, studentid, dateEntered, dateLeft
                int studentNumber = r.Next(0, NUM_USER);
                while (studentNumber % 100 == 0 || studentNumber % 75 == 0 || usedstunum.Contains(studentNumber))
                {
                    studentNumber = r.Next(0, NUM_USER);
                }
                SqlDateTime entered = new SqlDateTime(2017, 9, 2);
                SqlDateTime left = new SqlDateTime(2018, 5, 19);
                usedstunum.Add(studentNumber);
                cmd.CommandText = "INSERT INTO RoomHistory VALUES('" + i.ToString() + "','" + studentNumber.ToString() + "','" + entered.ToSqlString().ToString() + "','" + left.ToSqlString().ToString() + "')";
                cmd.ExecuteNonQuery();
            }
        }
        static void FillRoom()
        {
            Console.WriteLine("Filling Rooms");

            SqlCommand cmd = new SqlCommand("", sql);
            for (int i = 0; i < 40; i += 2)
            {

                cmd.CommandText = "INSERT INTO Room VALUES('" + i.ToString() + "','" + "A" + "','Mackay','(506)386-1234','100 Tucker Park Road','" + "1" + (i / 2).ToString() + "')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Room VALUES('" + (i + 1).ToString() + "','" + "B" + "','Mackay','(506)386-1234','100 Tucker Park Road','" + "1" + (i / 2).ToString() + "')";
                cmd.ExecuteNonQuery();
            }
            for (int i = 40; i < 80; i += 2)
            {
                cmd.CommandText = "INSERT INTO Room VALUES('" + i.ToString() + "','" + "A" + "','Mackay','(506)386-1234','100 Tucker Park Road','" + "2" + (i / 2).ToString() + "')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Room VALUES('" + (i + 1).ToString() + "','" + "B" + "','Mackay','(506)386-1234','100 Tucker Park Road','" + "2" + (i / 2).ToString() + "')";
                cmd.ExecuteNonQuery();
            }
            for (int i = 80; i < 120; i += 2)
            {
                String A = "A";
                if (i % 4 == 0)
                    A = "B";
                cmd.CommandText = "INSERT INTO Room VALUES('" + i.ToString() + "','" + "A" + "','Mackay','(506)386-1234','100 Tucker Park Road','" + "3" + (i / 2).ToString() + "')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Room VALUES('" + (i + 1).ToString() + "','" + "B" + "','Mackay','(506)386-1234','100 Tucker Park Road','" + "3" + (i / 2).ToString() + "')";
                cmd.ExecuteNonQuery();
            }
            for (int i = 120; i < 180; i++)
            {
                int roomnumber = i - 20;
                cmd.CommandText = "INSERT INTO Room VALUES('" + i.ToString() + "','N/A','Dunn','(506)386-1234','100 Tucker Park Road','" + roomnumber.ToString() + "')";
                cmd.ExecuteNonQuery();

            }
        }
        static void ClearRoom()
        {
            Console.WriteLine("Clearing Rooms");

            SqlCommand cmd = new SqlCommand("DELETE FROM Room WHERE roomID NOT LIKE '0000000000%'", sql);
            cmd.ExecuteNonQuery();
        }
        static void ClearRoomHistory()
        {
            Console.WriteLine("Clearing Room Histories");

            SqlCommand cmd = new SqlCommand("DELETE FROM RoomHistory WHERE roomID <> 'DSFSDF'", sql);
            cmd.ExecuteNonQuery();
        }
        static void FillMessage()
        {
            Console.WriteLine("Filling Messages");

            SqlCommand cmd = new SqlCommand("", sql);
            Random r = new Random();

            int prev = -1;
            for (int i = 0; i < 2000; i++)
            {
                int r2 = prev;
                while (r2 == prev)
                    r2 = r.Next(0, NUM_USER);
                prev = r2;

                cmd.CommandText = "EXEC CreateMessage 'This is an example of a Message Text" + i.ToString() + "', '" + (i % 1000).ToString() + "', '" + r2.ToString() + "'";
                cmd.ExecuteNonQuery();
            }
        }
        static void ClearMessage()
        {
            Console.WriteLine("Clearing Messages");

            SqlCommand cmd = new SqlCommand("", sql);
            cmd.CommandText = "DELETE FROM Message WHERE messageID <> 1323123";
            cmd.ExecuteNonQuery();
        }
        static void ClearUserType()
        {
            Console.WriteLine("Clearing User Type");

            SqlCommand cmd = new SqlCommand("", sql);

            cmd.CommandText = "DELETE FROM Admin WHERE userID = employeeID;";
            cmd.CommandText += "DELETE FROM RA WHERE studentID = RAID;";
            cmd.CommandText += "DELETE FROM Student WHERE studentID = userID;";
            cmd.ExecuteNonQuery();
        }
        static void FillUserType()
        {
            Console.WriteLine("Filling User Type");
            for (int i = 1; i < NUM_USER; i++)
            {
                SqlCommand cmd = new SqlCommand("", sql);
                if (i % 100 == 0)
                {
                    cmd.CommandText = "INSERT INTO Admin VALUES('" + i.ToString() + "','" + i.ToString() + "')";
                }
                else
                {
                    cmd.CommandText = "INSERT INTO Student VALUES('" + i.ToString() + "'," + "NULL" + "," + "NULL" + "," + 0 + ",'" + i.ToString() + "');";
                    if (i % 75 == 0)
                    {
                        cmd.CommandText += "INSERT INTO RA VALUES('" + i.ToString() + "','" + i.ToString() + "')";
                    }
                }
                cmd.ExecuteNonQuery();
            }
        }
        static void FillUsers()
        {
            Console.WriteLine("Filling Users");
            int prev = -1;
            SqlCommand cmd = new SqlCommand("", sql);
            Random r = new Random();

            for (int i = 1; i < NUM_USER; i++)
            {
                int F = ((int)(r.NextDouble() * 26));
                int L = ((int)(r.NextDouble() * 26));
                int M = ((int)(r.NextDouble() * 26));
                while (F == prev)
                {
                    F = ((int)(r.NextDouble() * 26));
                    L = ((int)(r.NextDouble() * 26));
                    M = ((int)(r.NextDouble() * 26));
                }
                cmd.CommandText = "INSERT INTO USER_T VALUES( '" + FNames[F] + i.ToString() + "','" + FNames[F].ToLower() + "','" + FNames[F] + "','" + LNames[L] + "','" + FNames[M] + "' , '" + new System.Data.SqlTypes.SqlDateTime(1999, i % 12 + 1, i % 28 + 1) + "', '" + i.ToString() + "')";
                //username password firstname lastname middlename DOB, userID\
                cmd.ExecuteNonQuery();
                prev = F;
            }
        }
        static void ClearUsers()
        {
            Console.WriteLine("Clearing Users");

            for (int i = 0; i < 26; i++)
            {
                SqlCommand cmd = new SqlCommand("", sql);
                cmd.CommandText = "DELETE FROM User_T WHERE firstName = '" + FNames[i] + "'";
                cmd.ExecuteNonQuery();
            }
        }
    }
}