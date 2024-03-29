﻿using Microsoft.AspNetCore.SignalR.Client;
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


                var uniqueConnectionId = await connection.InvokeAsync<string>("GetUniqueConnectionId");
                Console.WriteLine("My Unique connection id: " + uniqueConnectionId);

                System.Threading.Thread.Sleep(3000);
                await connection.InvokeAsync("SendMessage", "Console_User", "Hey, i am here.");

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


            while (true)
            {
                Console.WriteLine("Write a message and press Enter to send. Press E to exit.");
                var message = Console.ReadLine();
                if (message.ToLower() != "e")
                {
                    await connection.InvokeAsync("SendMessage", "Console_User", message);
                }
                else {
                    return;
                }
            }


        }
    }
}
