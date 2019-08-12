using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalrRDemo.ConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
               .WithUrl("http://localhost:59565/ChatHub")
               .Build();

            try
            {
                await connection.StartAsync();
                Console.WriteLine("Connection started");


                System.Threading.Thread.Sleep(3000);
                await connection.InvokeAsync("SendMessage",
                  "Console_User", "Hey, i am here.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error, " + ex.Message);
            }
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Console.WriteLine($"{user}: {message}");
            });


            Console.Read();
        }
    }
}
