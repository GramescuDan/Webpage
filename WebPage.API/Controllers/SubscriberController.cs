using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPage.DAL.Abstractions.IConfig;
using WebPage.Domain.Models.SendGrid;

namespace WebPage.API.Controllers
{
    [Route("/api/[controller]")]
    public class SubscriberController:ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubscriberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<Subscriber>> Post([FromBody]Subscriber email)
        {
            email.Id = Guid.NewGuid().ToString();
            return Ok(await _unitOfWork.Subscribers.AddAsync(email));
        }
    }
}