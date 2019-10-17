using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.WriteLine(FormatString(name));
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
    }
}
    