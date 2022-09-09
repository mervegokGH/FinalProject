using FinalProject.Application.Services.Interfaces;
using FinalProject.Application.Services.PaximumServices.Interfaces;
using FinalProject.Domain.Reservations;
using FinalProject.Shared.PaximumModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FinalProject.Shared.PaximumModels.PriceSearchRequest;
using static FinalProject.Shared.PaximumModels.SetReservationInfoRequest;

namespace FinalProject.Application.Services.Concretes
{
    public class PaximumService : IPaximumService
    {
        private readonly AuthenticationRequest _authenticationRequest;


        private readonly IAuthenticationService _authenticationService;
        private readonly IBeginTransactionService _beginTransactionService;
        private readonly ICommitTransactionService _commitTransactionService;
        private readonly IGetArrivalAutoCompleteService _getArrivalAutoCompleteService;
        private readonly IGetProductInfoService _getProductInfoService;
        private readonly IPriceSearchService _priceSearchService;
        private readonly ISetReservationInfoService _setReservationInfoService;

        public static string Token;


        public PaximumService(IOptions<AuthenticationRequest> authenticationRequest, IAuthenticationService authenticationService, IBeginTransactionService beginTransactionService, ICommitTransactionService commitTransactionService, IGetArrivalAutoCompleteService getArrivalAutoCompleteService, IGetProductInfoService getProductInfoService, IPriceSearchService priceSearchService, ISetReservationInfoService setReservationInfoService)
        {
            _authenticationRequest = authenticationRequest.Value;

            _authenticationService = authenticationService;
            _getArrivalAutoCompleteService = getArrivalAutoCompleteService;
            _priceSearchService = priceSearchService;
            _getProductInfoService = getProductInfoService;
            _beginTransactionService = beginTransactionService;
            _setReservationInfoService = setReservationInfoService;
            _commitTransactionService = commitTransactionService;

            AuthenticationAsync();
        }

        //Returns a token each time a request is made to PaximumService.
        private void AuthenticationAsync()
        {
            string methodAdress = "/api/authenticationservice/login";
            string token = string.Empty;
            string response = _authenticationService.Consume(_authenticationRequest, methodAdress, token).Result;

            AuthenticationResponse.Root myDeserializedClass = JsonConvert.DeserializeObject<AuthenticationResponse.Root>(response);

            Token = myDeserializedClass.body.token;

        }


        //Returns cities as a dictionary. It uses GetArrivalAutoCompleteService sub-service.
        public Task<Dictionary<int, string>> GetArrivalAutoCompleteAsync(string city)
        {
            string methodAdress = "/api/productservice/getarrivalautocomplete";

            GetArrivalAutoCompleteRequest getArrivalAutoCompleteRequest = new GetArrivalAutoCompleteRequest()
            {
                ProductType = 2,
                Query = city,
                Culture = "en-US"
            };

            var response = _getArrivalAutoCompleteService.Consume(getArrivalAutoCompleteRequest, methodAdress, Token).Result;


            GetArrivalAutoCompleteResponse.Root myDeserializedClass = JsonConvert.DeserializeObject<GetArrivalAutoCompleteResponse.Root>(response);

            var result = myDeserializedClass.body.items;

            Dictionary<int, string> citiesResult = new Dictionary<int, string>();

            foreach (var item in result)
            {
                if (item.country.id == "TR")
                {
                    if (!citiesResult.ContainsValue(item.city.name))
                    {
                        citiesResult.Add(int.Parse(item.city.id), item.city.name);
                    }
                }
            }
            return Task.FromResult(citiesResult);
        }

        //Returns hotels as a list which includes dictionaries. It uses PriceSearchService sub-service.
        public Task<List<Dictionary<string, string>>> PriceSearchAsync(int cityId)

        {
            string methodAdress = "/api/productservice/pricesearch";

            PriceSearchRequest priceSearchRequest = new PriceSearchRequest()
            {
                arrivalLocations = new List<ArrivalLocation> { new ArrivalLocation { id = "23494", type = 2 } },
                roomCriteria = new List<RoomCriterion> { new RoomCriterion { adult = 1 } },
            };

            var response = _priceSearchService.Consume(priceSearchRequest, methodAdress, Token).Result;



            PriceSearchResponse.Root myDeserializedClass = JsonConvert.DeserializeObject<PriceSearchResponse.Root>(response);

            var result = myDeserializedClass.body.hotels;

            List<Dictionary<string, string>> hotels = new List<Dictionary<string, string>>();

            foreach (var item in result)
            {
                if (!hotels.Any(x => x.ContainsValue(item.id)))
                {
                    Dictionary<string, string> ItemId = new Dictionary<string, string>();

                    ItemId.Add("ItemId", item.id);
                    ItemId.Add("HotelName", item.name);
                    ItemId.Add("HotelLocation", item.location.name);
                    ItemId.Add("Description", item.description.text);
                    ItemId.Add("OfferId", item.offers[0].offerId);
                    ItemId.Add("ThumbnailFull", item.thumbnailFull);
                    ItemId.Add("Stars", item.stars.ToString());
                    ItemId.Add("BoardName", item.offers[0].rooms[0].boardName);
                    ItemId.Add("RoomName", item.offers[0].rooms[0].roomName);
                    ItemId.Add("OwnerProvider", item.provider.ToString());
                    ItemId.Add("Price", item.offers[0].price.amount.ToString());
                    ItemId.Add("PriceCurrency", item.offers[0].price.currency.ToString());

                    hotels.Add(ItemId);
                }
            }
            return Task.FromResult(hotels);
        }

        //Returns the hotel details as a dictionary. It uses GetProductInfoService sub-service.
        public Task<Dictionary<string, string>> GetProductInfoAsync(string ItemId, string ownerProvider)
        {
            string methodAdress = "/api/productservice/getproductinfo";
            //productType is a 
            GetProductInfoRequest getProductInfoRequest = new GetProductInfoRequest()
            {
                productType = 2,
                ownerProvider = int.Parse(ownerProvider),
                product = ItemId,
                culture = "en-US"
            };

            var response = _getProductInfoService.Consume(getProductInfoRequest, methodAdress, Token).Result;

            GetProductInfoResponse.Root myDeserializedClass = JsonConvert.DeserializeObject<GetProductInfoResponse.Root>(response);

            var result = myDeserializedClass.body.hotel;

            Dictionary<string, string> hotelDetails = new Dictionary<string, string>();

            hotelDetails.Add("Name", result.name);
            hotelDetails.Add("Thumbnail", result.thumbnail);
            hotelDetails.Add("ThumbnailFull", result.thumbnailFull);
            hotelDetails.Add("Stars", result.stars.ToString());

            //Address check
            if (result.address.addressLines.Count != 0)
            {
                hotelDetails.Add("Address", result.address.addressLines[0]);
                if (result.address.addressLines.Count != 0)
                    hotelDetails.Add("PostalCode", result.address.addressLines[1]);
            }
            //Images check
            if(result.seasons[0].mediaFiles.Count != 0)
            {
                hotelDetails.Add("ImageCount", result.seasons[0].mediaFiles.Count.ToString());

                for (int i = 0; i < result.seasons[0].mediaFiles.Count; i++)
                {
                    hotelDetails.Add($"Image_{i}", result.seasons[0].mediaFiles[i].urlFull);
                }
            }
            else
            {
                hotelDetails.Add("ImageCount", "0");
            }

            return Task.FromResult(hotelDetails);
        }


        //Returns a transaction id to be used in commit SendReservation process.. It uses BeginTransactionService sub-service.
        public Task<string> BeginTransactionAsync(string offerId)
        {
            string methodAdress = "/api/bookingservice/begintransaction";

            BeginTransactionRequest beginTransaction = new BeginTransactionRequest()
            {
                offerIds = new List<string> { offerId.ToString() },
                currency = "EUR",
                culture = "en-US"
                

            };

            var response = _beginTransactionService.Consume(beginTransaction, methodAdress, Token).Result;

            BeginTransactionResponse.Root myDeserializedClass = JsonConvert.DeserializeObject<BeginTransactionResponse.Root>(response);

            string result = myDeserializedClass.body!=null? myDeserializedClass.body.transactionId:"";
            
            return Task.FromResult(result);
        }

        //Returns a Reservation Number If the reservation process is successful at the end of all these reservation processes. If not, returns an emty string
        public Task<string> SendReservationAsync(string TransactionId, Reservation reservation)
        {
            // SetReservationInfo process. It returns a transaction id to be used in commit transaction process.
            #region SetReservationInfo
            string methodAdress = "/api/bookingservice/setreservationinfo";

            SetReservationInfoRequest setReservationInfoRequest = new SetReservationInfoRequest()
            {
                transactionId = TransactionId,
                travellers = new List<Traveller> {
                            new Traveller {
                                travellerId = "1",
                                type = 1,
                                title = 1,
                                passengerType = 1,
                                name = reservation.Name,
                                surname = reservation.Surname,
                                isLeader = true,
                                birthDate =  new DateTime(1995, 06, 12),
                                nationality = new Nationality { twoLetterCode = "DE"},
                                identityNumber = "",
                                passportInfo = new PassportInfo{serial = "a",number = "13",expireDate = new DateTime(2030, 06, 12), issueDate = new DateTime(2020, 06, 12),citizenshipCountryCode = ""},
                                address = new Address {contactPhone= new ContactPhone {countryCode = "90",areaCode = "506",phoneNumber = "3504854" }, email = reservation.Email, address = "", zipCode = "", phone = "", city = new City {id = "", name = "" }, country = new Country { id = "", name = "" } },
                                destinationAddress = {},
                                orderNumber = 1,
                                documents = new List<object>{},
                                insertFields = new List<object>{},
                                status = 0,
                            }
                        }
            };

            var response = _setReservationInfoService.Consume(setReservationInfoRequest, methodAdress, Token).Result;

            SetReservationInfoResponse.Root myDeserializedClass = JsonConvert.DeserializeObject<SetReservationInfoResponse.Root>(response);

            string _transactionId = myDeserializedClass.body.transactionId;

            #endregion

            // CommitTransaction process. It returns a reservation number if the reservation was successful.
            #region CommitTransaction
            string methodAdressCommit = "/api/bookingservice/committransaction";

            CommitTransactionRequest commitTransactionRequest = new CommitTransactionRequest()
            {
                transactionId = _transactionId,
            };

            var responseCommit = _commitTransactionService.Consume(commitTransactionRequest, methodAdressCommit, Token).Result;

            CommitTransactionResponse.Root myDeserializedClassCommit = JsonConvert.DeserializeObject<CommitTransactionResponse.Root>(responseCommit);

            bool result = myDeserializedClass.header.success==true && myDeserializedClass.body!=null?true:false;
            string reservationNumber = string.Empty;
            if (result)
                reservationNumber = myDeserializedClassCommit.body.reservationNumber;
            #endregion

            return Task.FromResult(reservationNumber);
        }


    }
}