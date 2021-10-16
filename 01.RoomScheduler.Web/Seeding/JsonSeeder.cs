using JsonNet.ContractResolvers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomScheduler.Web.Seeding
{
    public class JsonSeeder
    {
        public static void Seed(string json, IServiceProvider serviceProvider)
        {
            JsonSerializerSettings settings = new() { ContractResolver = new PrivateSetterContractResolver() };


        }
    }
}
