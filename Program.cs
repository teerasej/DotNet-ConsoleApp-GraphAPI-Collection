using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.IO;
using Flurl.Http;
using Microsoft.Graph.Auth;
using Microsoft.Graph;

namespace GraphAPI_2
{
    class Program
    {

        private static readonly string _clientId = "38478b47-0715-4ce9-8d56-90ff0d503ce4";
        static async Task Main(string[] args)
        {

            string[] scopes = new string[] {
                "User.Read",
                "Mail.Read"
            };

            var app = PublicClientApplicationBuilder
                .Create(_clientId)
                .WithRedirectUri("http://localhost")
                .Build();

            var provider = new InteractiveAuthenticationProvider(app, scopes);
            var client = new GraphServiceClient(provider);

            var me = await client.Me.Request().GetAsync();

            Console.WriteLine($"[Job title] {me.JobTitle}");
            Console.WriteLine($"[Display Name] {me.DisplayName}");

          
            var emails = await client.Me.Messages.Request()
            .OrderBy($"{nameof(Message.ReceivedDateTime)}")
            .Filter($"{nameof(Message.ReceivedDateTime)} lt 2020-09-09")
            //.Filter($"{nameof(Message.IsRead)} eq true")
            .GetAsync();

            foreach (var email in emails)
            {
                Console.WriteLine($"Recieved: {email.ReceivedDateTime:G}");
                Console.WriteLine($"Subject: {email.Subject}");
            }
          
        }   
    }
}
