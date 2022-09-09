using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Shared.PaximumModels
{
    public class SetReservationInfoRequest
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public string transactionId { get; set; }
        public List<Traveller> travellers { get; set; }
        public string reservationNote { get; set; } = "Reservation note";
        public string agencyReservationNumber { get; set; } = "Agency reservation number text";

        public class Address
        {
            public ContactPhone contactPhone { get; set; }
            public string email { get; set; } = "";
            public string address { get; set; } = "";
            public string zipCode { get; set; } = "";
            public City city { get; set; }
            public Country country { get; set; }
            public string phone { get; set; } = "";
        }

        public class City
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class ContactPhone
        {
            public string countryCode { get; set; } = "90";
            public string areaCode { get; set; } = "555";
            public string phoneNumber { get; set; } = "5555555555";
        }

        public class Country
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class DestinationAddress
        {
        }

        public class Nationality
        {
            public string twoLetterCode { get; set; } = "DE";
        }

        public class PassportInfo
        {
            public string serial { get; set; } = "a";
            public string number { get; set; } = "19";
            public DateTime expireDate { get; set; } = new DateTime(2030, 06, 12);
            public DateTime issueDate { get; set; } = new DateTime(2020, 06, 12);
            public string citizenshipCountryCode { get; set; } = "DE";
        }

        public class Traveller
        {
            public string travellerId { get; set; } = "2";
            public int type { get; set; } = 1;
            public int title { get; set; } = 3;
            public int passengerType { get; set; } = 1;
            public string name { get; set; } = "Name";
            public string surname { get; set; } = "Surname";
            public bool isLeader { get; set; } = false;
            public DateTime birthDate { get; set; } = new DateTime(1995, 06, 12);
            public Nationality nationality { get; set; }
            public string identityNumber { get; set; } = "";
            public PassportInfo passportInfo { get; set; }
            public Address address { get; set; }
            public DestinationAddress destinationAddress { get; set; }
            public int orderNumber { get; set; }
            public List<object> documents { get; set; }
            public List<object> insertFields { get; set; }
            public int status { get; set; }
        }



    }
}
