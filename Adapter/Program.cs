using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace WzorzecAdapter
{
    //KOD Z ZEWNĘTRZNEJ BIBLIOTEKI
    public class UsersApi
    {
        public async Task<string> GetUsersXmlAsync()
        {
            var apiResponse =
                "<?xml version= \"1.0\" encoding= \"UTF-8\"?><users><user name=\"John\" surname=\"Doe\"/><user name=\"John\" surname=\"Wayne\"/><user name=\"John\" surname=\"Rambo\"/></users>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(apiResponse);

            return await Task.FromResult(doc.InnerXml);
        }
    }

    public class MyApi
    {
        public string GetUsersCsv()
        {
            List<string> listA = new List<string>();
            using (var reader = new StreamReader(@"users.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                }
            }

            return string.Join(" ", listA);
        }
    }


    public interface IUserRepository
    {
        List<string> GetUserNames();
    }

    public class UsersRepositoryAdapter : IUserRepository
    {
        private UsersApi _adaptee = null;

        public UsersRepositoryAdapter(UsersApi adaptee)
        {
            _adaptee = adaptee;
        }

        public List<string> GetUserNames()
        {
            string incompatibleApiResponse = this._adaptee
                .GetUsersXmlAsync()
                .GetAwaiter()
                .GetResult();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(incompatibleApiResponse);

            var rootEl = doc.LastChild;

            List<string> userNames = new List<string>();

            if (rootEl.HasChildNodes)
            {
                foreach (XmlNode user in rootEl.ChildNodes)
                {
                    userNames.Add(user.Attributes["name"].InnerText + user.Attributes["surname"].InnerText);
                }
            }

            return userNames;
        }
    }

    public class MyUserRepositoryAdapter : IUserRepository
    {
        private MyApi _adaptee = null;

        public MyUserRepositoryAdapter(MyApi adaptee)
        {
            _adaptee = adaptee;
        }

        public List<string> GetUserNames()
        {
            return _adaptee.GetUsersCsv().Split(' ').ToList();
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            MyApi userRepository = new MyApi();

            IUserRepository adapter = new MyUserRepositoryAdapter(userRepository);

            List<string> users = adapter.GetUserNames();
            var starNum = 1;
            foreach (var userName in users)
            {
                Console.WriteLine($"{starNum},{userName.Replace(",", ",")}");
                starNum++;
            }
        }
    }
}