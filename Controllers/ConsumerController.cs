using ConsumerMicroservice.Models;
using ConsumerMicroservice.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace ConsumerMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerController : Controller
    {
        private readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ConsumerController));
        private readonly IConsumerService _consumerService;

        private readonly IHttpClientFactory _clientFactory;

        public ConsumerController(IConsumerService consumerService, IHttpClientFactory clientFactory)
        {
            _consumerService = consumerService;
            _clientFactory = clientFactory;
        }
        private async Task<HttpResponseMessage> CheckTokenValidity(string scheme, string token)
        {
            // var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:5001/api/Auth/Verify");
            // request.Headers.Add("Accept", "application/json");
            // request.Headers.Add("Authorization", token);
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new HttpRequestMessage(HttpMethod.Post, "https://authmicroservicepas.azurewebsites.net/api/Auth/Login");

            HttpResponseMessage response = await client.SendAsync(request);


            return response;

        }
        [HttpPost]
        [Route("CreateConsumerBusiness")]
        public async Task<IActionResult> CreateConsumerBusiness(ConsumerBusiness consumerBusiness, [FromHeader] string authorization)
        {
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var rslt = await CheckTokenValidity(headerValue.Scheme, headerValue.Parameter);
                if (rslt != null && rslt.StatusCode != HttpStatusCode.OK)
                {
                    return Unauthorized("Authorization Failed! Might be due to invalid token!");
                }
            }
            _log4net.Info("CreateConsumerBusiness Method Called");
            var result = _consumerService.CreateConsumerBusiness(consumerBusiness);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateConsumerBusiness")]
        public async Task<IActionResult> UpdateConsumerBusiness(ConsumerBusiness consumerBusiness, [FromHeader] string authorization)
        {

            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var rslt = await CheckTokenValidity(headerValue.Scheme, headerValue.Parameter);
                if (rslt != null && rslt.StatusCode != HttpStatusCode.OK)
                {
                    return Unauthorized("Authorization Failed! Might be due to invalid token!");
                }
            }
            _log4net.Info("UpdateConsumerBusiness Method Called");
            var result = _consumerService.UpdateConsumerBusiness(consumerBusiness);
            return Ok(result);
        }


        [HttpPost]
        [Route("CreateBusinessProperty")]
        public async Task<IActionResult> CreateBusinessProperty(BusinessProperty businessProperty, [FromHeader] string authorization)
        {
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var rslt = await CheckTokenValidity(headerValue.Scheme, headerValue.Parameter);
                if (rslt != null && rslt.StatusCode != HttpStatusCode.OK)
                {
                    return Unauthorized("Authorization Failed! Might be due to invalid token!");
                }
            }
            _log4net.Info("CreateBusinessProperty Method Called");
            var result = _consumerService.CreateBusinessProperty(businessProperty);
            return Ok(result);
        }


        [HttpPut]
        [Route("UpdateBusinessProperty")]
        public async Task<IActionResult> UpdateBusinessProperty(BusinessProperty businessProperty, [FromHeader] string authorization)
        {   
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var rslt = await CheckTokenValidity(headerValue.Scheme, headerValue.Parameter);
                if (rslt != null && rslt.StatusCode != HttpStatusCode.OK)
                {
                    return Unauthorized("Authorization Failed! Might be due to invalid token!");
                }
             }

            _log4net.Info("UpdateBusinessProperty Method Called");
            var result = _consumerService.UpdateBusinessProperty(businessProperty);
            return Ok(result);
        }

        [HttpGet]
        [Route("viewConsumerBusiness/{ConsumerId}/{BusinessId}")]
        public async Task<IActionResult> ViewConsumerBusiness(string ConsumerId, string BusinessId, [FromHeader] string authorization)
        {
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var rslt = await CheckTokenValidity(headerValue.Scheme, headerValue.Parameter);
                if (rslt != null && rslt.StatusCode != HttpStatusCode.OK)
                {
                    return Unauthorized("Authorization Failed! Might be due to invalid token!");
                }
            }

            _log4net.Info("ViewConsumerBusiness Method Called");
            var result = _consumerService.ViewConsumerBusiness(ConsumerId, BusinessId);
            if (result.Equals(null))
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("viewConsumerProperty/{ConsumerId}/{PropertyId}")]
        public async Task<IActionResult> ViewConsumerProperty(string ConsumerId,string PropertyId, [FromHeader] string authorization)
        {
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var rslt = await CheckTokenValidity(headerValue.Scheme, headerValue.Parameter);
                if (rslt != null && rslt.StatusCode != HttpStatusCode.OK)
                {
                    return Unauthorized("Authorization Failed! Might be due to invalid token!");
                }
            }
            if (ConsumerId==null || PropertyId==null)
            {
                return NotFound();
            }
            _log4net.Info("ViewConsumerProperty Method Called");
            var result = _consumerService.ViewConsumerProperty(ConsumerId, PropertyId);
            if(result.Equals(null))
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
