using System;

namespace BusinessEntities
{
    public class MessageModel
    {
        public string Message { get; set; }
        public DateTime CurrentTime { get; set; }
        public string Host { get; set; }
        public string UserName { get; set; }

        public MessageModel(string message)
        {
            Message = message;
            CurrentTime = DateTime.Now;
            Host = Environment.MachineName;
            UserName = Environment.UserName;
        }

        public static MessageModel CreateMessage(string message)
        {
            return  new MessageModel(message);
        }
    }
}
