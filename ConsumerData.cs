using ConsumerMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumerMicroservice
{
    public class ConsumerData
    {
        public static List<Consumer> ConsumerList = new List<Consumer>()

        {
           new Consumer()
            {
                ConsumerId = "C01",
                ConsumerName = "Nitish",
                Email = "st@gmail.com",
                Pan = "ABC1234567",
                BusinessOverview = "Sole Proprietorships",
                ValidityofConsumer = 2 ,
                AgentId = 1,
                AgentName = "Namrata"
            },
            new Consumer()
            {
                ConsumerId = "C02",
                ConsumerName = "Harsh",
                Email = "HN@gmail.com",
                Pan = "ABC1144567",
                BusinessOverview = "Corporations" ,
                ValidityofConsumer = 2 ,
                AgentId = 1,
                AgentName = "Namrata"
            },
            
        };
    }
}
