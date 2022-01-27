// See https://aka.ms/new-console-template for more information

using System;
using System.IO;

namespace EmailChecker // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine("Hello, this appication will check if your file" +
                " has invalid email");
            Console.WriteLine("Please enter you File Name: ");

            string name = Console.ReadLine();
            string results = listFilesInDirectory(Environment.CurrentDirectory, name);

            //Error Checking
            if (results == "0")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File Can not be found, Please try again.");
            }
            if (results == "-1")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Files in Current Directory.");
            }

            //Process the CSV

           string[] emails = readEmails(results, 3);
            
            //make list of Good and bad emails   
            string[] goodEmails = {};
            string[] badEmails= {};
        

            foreach (string email in emails)
            {
                if (IsValidEmail(email)){
                   goodEmails.Append(email);
                }
                else
                {
                    badEmails.Append(email);
                }
            }

            Console.WriteLine("Here are the list of Good Emails:");
            Console.WriteLine(goodEmails);
            Console.WriteLine("Here are the list of Bad Emails:");
            Console.WriteLine(badEmails);


            Console.ForegroundColor = ConsoleColor.White;
        }

        static string listFilesInDirectory(string workingDirectory, string name)
        {
            name = name.ToLower() + ".csv";

            string[] filePaths = Directory.GetFiles(workingDirectory, "*.*", SearchOption.TopDirectoryOnly);
            
            if (filePaths.Length == 0)
            {
                return "-1";
            }
            foreach (string filePath in filePaths)
            {
                if ( filePath.ToLower() == name)
                    {
                        return workingDirectory + filePath;
                    }
            }

            return "0";
        
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static string[] readEmails(string filepath, int position)
        {
            position--;
            try
            {
                string[] lines = File.ReadAllLines(@filepath);
                string[] emails = new string[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    emails.Append(line.Split(',', position));
                    
                }
                return email;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
           
        }
    }


}

