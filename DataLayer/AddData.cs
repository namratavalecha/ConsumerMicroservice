using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConsumerMicroservice.Data;
using ConsumerMicroservice.Models;

namespace ConsumerMicroservice.DataLayer
{
    public class AddData
    {
        public AddData( ) { }
        public static void Initialize(ApplicationDbContext context)
        {
            List<Business> bus = getBusiness();
            List<Consumer> con = getConsumer();
            List<Property> pro = getProperty();
            for (int i = 0; i < bus.Count; i++)
            {
                context.businesses.Add(bus[i]);
            }
            for (int i = 0; i < con.Count; i++)
            {
                context.consumers.Add(con[i]);
            }
            for (int i = 0; i < pro.Count; i++)
            {
                context.properties.Add(pro[i]);
            }
            context.SaveChanges();
                
            
        }
        private static List<Business> getBusiness()
        {
            return new List<Business>() {
                new Business()
           {
                BusinessId = "B01",
                BusinessType = "Pharmacy",
                AnnualTurnOver = 1000000,
                TotalEmployees = 100,
                CapitalInvested = 200000
           },
           new Business()
           {
                BusinessId = "B02",
                BusinessType = "Food",
                AnnualTurnOver = 2000000,
                TotalEmployees = 150,
                CapitalInvested = 1000000
           },
           new Business()
           {
                BusinessId = "B03",
                BusinessType = "Food",
                AnnualTurnOver = 1200000,
                TotalEmployees = 50,
                CapitalInvested = 200000
           }
            };
        }
        
        private static List<Consumer> getConsumer()
        {
            return new List<Consumer>() {
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

        private static List<Property> getProperty()
        {
            return new List<Property>() {
                new Property()
            {

                PropertyId = "P01",
                BuildingSqft = 2000,
                BuildingType = "Owner",
                BuildingStoreys = 5,
                BuildingAge = 2,
                CostOfTheAsset =9,
                SalvageValue =3,
                UsefulLifeOfTheAsset =3
    }
            };
        }
    }

}
