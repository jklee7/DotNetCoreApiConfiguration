using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1
{
    [Route("/")]
    public class DemoController :  Controller
    {
        private IMessageService _messageService;

        public DemoController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult GetHello()
        {
            var response = _messageService.GetMessage();
            return Ok(response);
        }
    }
}
