using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Models.Model;
using Models.Repositories;
using RestSharp;
using RestSharp.Authenticators;

namespace PushNotifications
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AssetsRepository assetRepository = new AssetsRepository();
            EmployeeRepository employeeRepository = new EmployeeRepository();

            IEnumerable<Asset> assets = assetRepository.All();

            while (true)
            {
                foreach (var item in assets)
                {
                    if (!string.IsNullOrEmpty(item.Employee))
                    {
                        Employee employee = employeeRepository.GetByName(item.Employee);
                        if ((DateTime.Now - item.WarrantyExpiryDate).TotalDays < 1)
                        {
                            Console.WriteLine(SendEmail(employee.Email).Content.ToString());
                        }
                    }
                }
                Thread.Sleep(82800000);
            }
        }
        public static IRestResponse SendEmail(string email)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");

            client.Authenticator =
                new HttpBasicAuthenticator("api",
                    "52539874f3fdbec462c6f2a20ebea5a1-20ebde82-4e3f6518");

            RestRequest request = new RestRequest();

            request.AddParameter("domain", "sandbox9f0a5291b69a4ef381207ed80dc22280.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Support <mailgun@sandbox9f0a5291b69a4ef381207ed80dc22280.mailgun.org>");
            request.AddParameter("to", email);
            request.AddParameter("subject", "Your license expires tomorrow!");
            request.AddParameter("text", "Please update your license.");

            request.Method = Method.POST;

            return client.Execute(request);
        }
    }
}