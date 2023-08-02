// See https://aka.ms/new-console-template for more information

using FlightControl.Simulator;
using System.Net.Http.Json;

HttpClient client = new();   

Random random = new();

System.Timers.Timer timer = new(random.Next(4000,7000));
timer.Elapsed += (s, e) => PostPlan();
timer.Start();

Console.ReadLine();

async void PostPlan()
{
    var plan = new FlightDto();
    await client.PostAsJsonAsync("https://localhost:7198/api/Plane", plan);
    Console.WriteLine("added plane");
}
