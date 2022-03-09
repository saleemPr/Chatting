using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatting.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}