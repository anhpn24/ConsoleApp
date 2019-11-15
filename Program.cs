using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //string name;
            //Console.Write("Enter your name: ");
            //name = Console.ReadLine();
            //Console.WriteLine(FormatString(name));
            //Console.Read();

            string day;
            string month;
            string year;
            Console.Write("Enter day: ");
            day = Console.ReadLine();
            Console.Write("Enter month: ");
            month = Console.ReadLine();
            Console.Write("Enter year: ");
            year = Console.ReadLine();

            //GetLeapYearAndDayOfWeek(Convert.ToInt32(day), Convert.ToInt32(month), Convert.ToInt32(year));
            var arr1 = GetCalendar1(Convert.ToInt32(month), Convert.ToInt32(year), 1);
            var strOutput1 = "";
            for (int i = 0; i < arr1.Length; i++)
            {
                strOutput1 = strOutput1 + arr1[i].ToString() + "   ";
            }

            var arr2 = GetCalendar1(Convert.ToInt32(month), Convert.ToInt32(year), 2);
            var strOutput2 = "";
            for (int i = 0; i < arr2.Length; i++)
            {
                strOutput2 = strOutput2 + arr2[i].ToString() + "   ";
            }

            var arr3 = GetCalendar1(Convert.ToInt32(month), Convert.ToInt32(year), 3);
            var strOutput3 = "";
            for (int i = 0; i < arr3.Length; i++)
            {
                strOutput3 = strOutput3 + arr3[i].ToString() + "   ";
            }

            var arr4 = GetCalendar1(Convert.ToInt32(month), Convert.ToInt32(year), 4);
            var strOutput4 = "";
            for (int i = 0; i < arr4.Length; i++)
            {
                strOutput4 = strOutput4 + arr4[i].ToString() + "   ";
            }

            var arr5 = GetCalendar1(Convert.ToInt32(month), Convert.ToInt32(year), 5);
            var strOutput5 = "";
            for (int i = 0; i < arr5.Length; i++)
            {
                strOutput5 = strOutput5 + arr5[i].ToString() + "   ";
            }

            var arr6 = GetCalendar1(Convert.ToInt32(month), Convert.ToInt32(year), 6);
            var strOutput6 = "";
            for (int i = 0; i < arr6.Length; i++)
            {
                strOutput6 = strOutput6 + arr6[i].ToString() + "   ";
            }

            Console.WriteLine(strOutput1 + "\r\n" + strOutput2 + "\r\n" + strOutput3 + "\r\n" + strOutput4 + "\r\n" + strOutput5 + "\r\n" + strOutput6);

            Console.Read();
        }

        private static string FormatString(string strInput)
        {
            string result = string.Empty;

            // Convert thành chuỗi chữ thường
            strInput = strInput.Trim().ToLower();

            // Duyệt chuỗi
            for (int i = 0; i < strInput.Length; i++)
            {
                // Ký tự đầu tiên của chuỗi sẽ được viết hoa
                if (i == 0)
                {
                    result += strInput[i].ToString().ToUpper();
                }
                else
                {
                    result += strInput[i];
                }

                // Nếu ký tự đang được duyệt là khoảng trắng => thực hiện kiểm tra các ký tự có là khoảng trắng sau ký tự này                
                if (strInput[i].ToString() == " ")
                {
                    // Thực hiện lặp cho đến khi tìm thấy vị trí của ký tự đầu tiên không phải khoảng trắng sau ký tự đang duyệt               
                    while (strInput[i].ToString() == " ")
                    {
                        i++;
                    }

                    // Viết hoa và gán ký tự đầu tiên không phải khoảng trắng tìm được sau khi lặp vào chuỗi kết quả
                    result += strInput[i].ToString().ToUpper();
                }
            }

            return result;
        }
        
        private static void GetLeapYearAndDayOfWeek(int day, int month, int year)
        {
            if (Isleap(Convert.ToInt32(year)))
            {
                Console.WriteLine("Leap Year");
            }
            else
            {
                Console.WriteLine("Not Leap Year");
            }

            var rel = ZellerCongruence(Convert.ToInt32(day), Convert.ToInt32(month), Convert.ToInt32(year));
            switch (rel)
            {
                case 0: Console.WriteLine("Saturday.\n"); break;
                case 1: Console.WriteLine("Sunday.\n"); break;
                case 2: Console.WriteLine("Monday. \n"); break;
                case 3: Console.WriteLine("Tuesday. \n"); break;
                case 4: Console.WriteLine("Wednesday. \n"); break;
                case 5: Console.WriteLine("Thurday. \n"); break;
                case 6: Console.WriteLine("Friday. \n"); break;
                default: Console.WriteLine("Undefine"); break;
            }
        }

        private static int ZellerCongruence(int day, int month, int year)
        {
            int h, q, m, k, j;
            if (month == 1)
            {
                month = 13;
                year--;
            }
            if (month == 2)
            {
                month = 14;
                year--;
            }
            q = day;
            m = month;
            k = year % 100;
            j = year / 100;
            h = q + 13 * (m + 1) / 5 + k + k / 4 + j / 4 + 5 * j;
            h = h % 7;
            return h;
        }

        private static bool Isleap(int year)
        {
            // Trả về true nếu
            // chia hết cho 4 nhưng không chia hết cho 100 
            // hoặc chia hết cho 400
            return (((year % 4 == 0) && (year % 100 != 0)) ||
                    (year % 400 == 0));
        }

        private static int DayInMonth(int month, int year)
        {
            int addDay = Isleap(year) ? 1 : 0;
            return (month == 2) ? (28 + addDay) : 31 - (month - 1) % 7 % 2;
        }

        /// <summary>
        /// SUN - MON - TUE - WED - THU - FRI - SAT
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private static int[] GetCalendar1(int month, int year, int iWeek)
        {
            var startIndex = ZellerCongruence(1, month, year);
            startIndex = startIndex - 1;
            var endIndex = DayInMonth(month, year);
            var result = new int[42];
            for (var i = startIndex; i < endIndex + startIndex; i++)
            {
                result[i] = (i - startIndex) + 1;
            }

            var resultLast = new int[7];
            int index = 0;
            int iStart = 7 * (iWeek - 1);
            int iEnd = 7 * (iWeek);
            for (int i = iStart; i < iEnd; i++)
            {
                resultLast[index] = result[i];
                index = index + 1;
            }

            return resultLast;
        }

        /// <summary>
        /// SAT - SUN - MON - TUE - WED - THU - FRI 
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private static int[] GetCalendar2(int month, int year)
        {
            var startIndex = ZellerCongruence(1, month, year);
            var endIndex = DayInMonth(month, year);
            var result = new int[42];
            for (var i = startIndex; i < endIndex + startIndex; i++)
            {
                result[i] = (i - startIndex) + 1;
            }
            return result;
        }
    }
}
    