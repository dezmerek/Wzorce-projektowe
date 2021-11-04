using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WzorzecFasada
{

    interface IUserService
    {
        void CreateUser(string email);
        void RemoveUser(string email);
        string CountUsers();
    }

    static class EmailNotification
    {
        public static void SendEmail(string to, string subject)
        {
            Console.WriteLine($"{subject} {to}");
        }
    }

    class UserRepository
    {
        private readonly List<string> users = new List<string>
        {
            "john.doe@gmail.com", "sylvester.stallone@gmail.com"
        };

        public bool IsEmailFree(string email)
        {
            if (users.Any(a => a == email))
            {
                return false;
            }
            return true;
        }

        public void AddUser(string email)
        {
            users.Add(email);
        }
        public string CountUsers()
        {
            return $"Aktualna liczba adresow: {users.Count()}";
        }
        public void RemoveUser(string email)
        {
            users.Remove(email);
        }
    }

    static class Validators
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
        }
    }

    class UserService : IUserService
    {
        private readonly UserRepository userRepository = new UserRepository();
        public void CreateUser(string email)
        {
            if (!Validators.IsValidEmail(email))
            {
                throw new ArgumentException("Błędny email");
            }
            if (!userRepository.IsEmailFree(email))
            {
                throw new ArgumentException("Podany email juz istnieje ");
            }

            userRepository.AddUser(email);
            EmailNotification.SendEmail(email, "Welcome to our service");
        }
        public string CountUsers()
        {
            return userRepository.CountUsers();
        }
        public void RemoveUser(string email)
        {
            userRepository.RemoveUser(email);
            EmailNotification.SendEmail(email, "Goodbye");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new UserService();
            Console.WriteLine(userService.CountUsers());
            userService.CreateUser("someemail@gmail.com");
            Console.WriteLine(userService.CountUsers());
            userService.RemoveUser("john.doe@gmail.com");
            Console.WriteLine(userService.CountUsers());
        }
    }
}