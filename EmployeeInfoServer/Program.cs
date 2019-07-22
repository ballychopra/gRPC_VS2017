using System;
using Grpc.Core;
using Employeeinfo;
using System.Threading.Tasks;

namespace EmployeeInfoServer
{
    class EmployeeInfoImpl: employeeinfoservice.employeeinfoserviceBase
    {
        public override Task<EmployeeInfoResponse> getEmployeeInfo(EmployeeInfoRequest request, ServerCallContext context)
        {
            //return base.GetEmployeeInfo(request, context);
            
            return GetEmployeeInfo(request);
        }

        private Task<EmployeeInfoResponse> GetEmployeeInfo(EmployeeInfoRequest request)
        {
            EmployeeInfoResponse response = new EmployeeInfoResponse();
            if (request.ID == "1")
            {
                response.Id = "1";
                response.Name = "Baljinder Singh";
            }
            else if(request.ID=="2")
            {
                response.Id = "2";
                response.Name = "Another Employee 2";
            }

            return Task.FromResult <EmployeeInfoResponse>(response);
        }

    }


    class Program
    {
        const int PORT = 5055;

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Server  server = new Server()
            {
                Ports = { new ServerPort("localhost", PORT, ServerCredentials.Insecure) },
                Services = { employeeinfoservice.BindService(new EmployeeInfoImpl()) }
            };

            server.Start();
            Console.WriteLine($"Employee info service is listening on port {PORT}");
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
