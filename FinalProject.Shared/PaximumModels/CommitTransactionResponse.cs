using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Shared.PaximumModels
{
    public class CommitTransactionResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Body
        {
            public string reservationNumber { get; set; }
            public string encryptedReservationNumber { get; set; }
            public string transactionId { get; set; }
        }

        public class Header
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public DateTime responseTime { get; set; }
            public List<Message> messages { get; set; }
        }

        public class Message
        {
            public int id { get; set; }
            public string code { get; set; }
            public int messageType { get; set; }
            public string message { get; set; }
        }

        public class Root
        {
            public Header header { get; set; }
            public Body body { get; set; }
        }


    }
}
