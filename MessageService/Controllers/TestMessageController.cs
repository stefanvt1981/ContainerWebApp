using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestMessageController : ControllerBase
    {
        [HttpGet]
        public ActionResult<MessageModel> Get()
        {
            return MessageModel.CreateMessage($"Hi Anon!");
        }

        [HttpGet("{name}")]
        public ActionResult<MessageModel> Get(string name)
        {
            return MessageModel.CreateMessage($"Hi {name}!");
        }
    }
}