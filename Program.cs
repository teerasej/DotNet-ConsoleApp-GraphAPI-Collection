using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.IO;

namespace GraphAPI_2
{
    class Program
    {

        private static readonly string _clientId = "38478b47-0715-4ce9-8d56-90ff0d503ce4";
        static async Task Main(string[] args)
        {

            string[] scopes = new string[] {
                "User.Read"
            };

            var app = PublicClientApplicationBuilder
                .Create(_clientId)
                .WithRedirectUri("http://localhost")
                .Build();

        }   
    }
}
