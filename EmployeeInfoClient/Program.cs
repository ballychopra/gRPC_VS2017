using System;
using Grpc.Core;
using Employeeinfo;

namespace EmployeeInfoClient
{
    class Program
    {
        static void Main(string[] args)
        {

            // Channel channel = new Channel("127.0.0.1:454545", ChannelCredentials.Insecure);
            Channel channel = new Channel("localhost:454545", ChannelCredentials.Insecure);
            string empID = string.Empty;

            var client = new employeeinfoservice.employeeinfoserviceClient(channel);
            //ConsoleKeyInfo ki = Console.ReadKey();
            ConsoleKeyInfo choice ;
                
            //Console.Write("test");
            do
            {
                Console.Clear();
                Console.Write("Enter Employee ID: ");
                empID = Console.ReadLine();

                var request = new EmployeeInfoRequest() { ID = empID };

                var response = client.getEmployeeInfo(request);
                Console.WriteLine($"Response from server{Environment.NewLine}ID: {response.Id} {Environment.NewLine}Name: {response.Name}");

                Console.WriteLine("");
                Console.Write("Try another employee (y/n)? ");

                choice = Console.ReadKey();
                Console.WriteLine();
               // request.ID  = Console.Read().ToString();
            } while (choice.Key != ConsoleKey.N );


            channel.ShutdownAsync().Wait();
        }
    }
    
}
