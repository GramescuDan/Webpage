using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Models.SendGrid;
using WebPage.Infrastructure.SendGrid;

namespace WebPage.API.Controllers
{
    [Route("/api/[controller]")]
    public class SubscriberController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClient _client;
        public SubscriberController(IUnitOfWork unitOfWork,IClient client)
        {
            _unitOfWork = unitOfWork;
            _client = client;
        }

        [HttpPost]
        public async Task<ActionResult<Subscriber>> Post([FromBody]Subscriber email)
        {
            email.Id = Guid.NewGuid().ToString();
            var entity= await _unitOfWork.Subscribers.AddAsync(email);
            await _unitOfWork.CompleteAsync();
            return Created("http://localhost:5000/Subscribers/Get", entity);
        }

        [HttpGet]
        public async Task Send()
        {
            var email = _client.Compose("This is a test", null, null);
            await _client.Send(email);
        }
        
    }
}