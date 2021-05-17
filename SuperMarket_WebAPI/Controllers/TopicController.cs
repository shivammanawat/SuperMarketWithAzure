using Microsoft.AspNetCore.Mvc;
using SuperMarket.Models;
using Supermarket_WebAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly IMessagePublisher messagePublisher;
        public TopicController(IMessagePublisher messagePublisher)
        {
            this.messagePublisher = messagePublisher;
        }

        [HttpPost(template: "product")] 
        public async Task PublishProductMessage([FromBody] ProductsDataModel product)
        {
            await messagePublisher.PublisherMessage(product);
        }

    }
}
