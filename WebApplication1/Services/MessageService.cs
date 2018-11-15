using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MessageService : IMessageService
    {
        private MessageModel _messageModel;

        public MessageService(IOptions<MessageModel> messageModel)
        {
            _messageModel = messageModel.Value;
        }

        public string GetMessage()
        {
            var response = $"{_messageModel.Greeting} {_messageModel.Message}";
            return response;
        }
    }
}
