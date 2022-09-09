using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Shared.PaximumModels
{
    public class SetReservationInfoResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class AdditionalFields
        {
            public string travellerTypeOrder { get; set; }
            public string travellerUniqueID { get; set; }
            public string tourVisio_TravellerId { get; set; }
            public string paximum_TravellerId { get; set; }
            public DateTime birthDateFrom { get; set; }
            public DateTime birthDateTo { get; set; }
            public string smsLimit { get; set; }
            public string priceChanged { get; set; }
            public string allowSalePriceEdit { get; set; }
            public string sendFlightSms { get; set; }
            public string isRefundable { get; set; }
            public string reservableInfo { get; set; }
            public string isEditable { get; set; }
        }

        public class Address
        {
            public ContactPhone contactPhone { get; set; }
            public string email { get; set; }
            public string address { get; set; }
            public string zipCode { get; set; }
            public City city { get; set; }
            public Country country { get; set; }
            public string phone { get; set; }
            public List<string> addressLines { get; set; }
        }

        public class Agency
        {
            public string code { get; set; }
            public string name { get; set; }
            public Country country { get; set; }
            public Address address { get; set; }
            public bool ownAgency { get; set; }
            public bool aceExport { get; set; }
        }

        public class AgencyAmountToPay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class AgencyBalance
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class AgencyCommission
        {
            public float percent { get; set; }
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class AgencyEB
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class AgencyPriceToPay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class AgencySupplementCommission
        {
            public float percent { get; set; }
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class AgencyUser
        {
            public Office office { get; set; }
            public Operator @operator { get; set; }
            public Market market { get; set; }
            public Agency agency { get; set; }
            public string name { get; set; }
            public string code { get; set; }
        }

        public class ArrivalCity
        {
            public string code { get; set; }
            public string name { get; set; }
            public float type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public float provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class ArrivalCountry
        {
            public string code { get; set; }
            public string internationalCode { get; set; }
            public string name { get; set; }
            public float type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public float provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class AvailableTitle
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Body
        {
            public string transactionId { get; set; }
            public DateTime expiresOn { get; set; }
            public ReservationData reservationData { get; set; }
            public float status { get; set; }
            public float transactionType { get; set; }
        }

        public class BrokerCommission
        {
            public float percent { get; set; }
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class CancellationPolicy
        {
            public DateTime beginDate { get; set; }
            public DateTime dueDate { get; set; }
            public Price price { get; set; }
            public float provider { get; set; }
        }

        public class City
        {
            public string id { get; set; }
            public string name { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public float provider { get; set; }
            public bool isTopRegion { get; set; }
            public string code { get; set; }
            public float type { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
        }

        public class ContactPhone
        {
            public string countryCode { get; set; }
            public string phoneNumber { get; set; }
        }

        public class Country
        {
            public string id { get; set; }
            public string name { get; set; }
            public string internationalCode { get; set; }
            public float provider { get; set; }
            public bool isTopRegion { get; set; }
            public string code { get; set; }
            public float type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
        }

        public class DepartureCity
        {
            public string code { get; set; }
            public string name { get; set; }
            public float type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public float provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class DepartureCountry
        {
            public string code { get; set; }
            public string internationalCode { get; set; }
            public string name { get; set; }
            public float type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public float provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class DestinationAddress
        {
        }

        public class Discount
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Geolocation
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class GeoLocation2
        {
            public string longitude { get; set; }
            public string latitude { get; set; }
        }

        public class Header
        {
            public string requestId { get; set; }
            public bool success { get; set; }
            public DateTime responseTime { get; set; }
            public List<Message> messages { get; set; }
        }

        public class HotelDetail
        {
            public Address address { get; set; }
            public TransferLocation transferLocation { get; set; }
            public float stopSaleGuaranteed { get; set; }
            public float stopSaleStandart { get; set; }
            public Geolocation geolocation { get; set; }
            public Location location { get; set; }
            public Country country { get; set; }
            public City city { get; set; }
            public string thumbnail { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Location
        {
            public string code { get; set; }
            public string name { get; set; }
            public float type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public float provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Market
        {
            public string code { get; set; }
            public string name { get; set; }
        }

        public class Message
        {
            public float id { get; set; }
            public string code { get; set; }
            public float messageType { get; set; }
            public string message { get; set; }
        }

        public class Nationality
        {
            public string name { get; set; }
            public string twoLetterCode { get; set; }
            public string threeLetterCode { get; set; }
            public string numericCode { get; set; }
            public string isdCode { get; set; }
        }

        public class NetPrice
        {
            public double amount { get; set; }
            public string currency { get; set; }
        }

        public class Office
        {
            public string code { get; set; }
            public string name { get; set; }
        }

        public class Operator
        {
            public string code { get; set; }
            public string name { get; set; }
            public bool agencyCanDiscountCommission { get; set; }
        }

        public class PassengerAmountToPay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class PassengerBalance
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class PassengerEB
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class PassengerPriceToPay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class PassportInfo
        {
            public string serial { get; set; }
            public string number { get; set; }
            public DateTime expireDate { get; set; }
            public DateTime issueDate { get; set; }
            public string citizenshipCountryCode { get; set; }
        }

        public class PaymentDetail
        {
            public List<PaymentPlan> paymentPlan { get; set; }
            public List<object> paymentInfo { get; set; }
        }

        public class PaymentPlan
        {
            public float paymentNo { get; set; }
            public DateTime dueDate { get; set; }
            public Price price { get; set; }
            public bool paymentStatus { get; set; }
        }

        public class Price
        {
            public double amount { get; set; }
            public string currency { get; set; }
            public float percent { get; set; }
        }

        public class PriceToPay
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class PromotionAmount
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class ReservableInfo
        {
            public bool reservable { get; set; }
        }

        public class ReservationData
        {
            public List<Traveller> travellers { get; set; }
            public ReservationInfo reservationInfo { get; set; }
            public List<Service> services { get; set; }
            public PaymentDetail paymentDetail { get; set; }
            public List<object> invoices { get; set; }
        }

        public class ReservationInfo
        {
            public string bookingNumber { get; set; }
            public Agency agency { get; set; }
            public AgencyUser agencyUser { get; set; }
            public DateTime beginDate { get; set; }
            public DateTime endDate { get; set; }
            public string note { get; set; }
            public string agencyReservationNumber { get; set; }
            public SalePrice salePrice { get; set; }
            public SupplementDiscount supplementDiscount { get; set; }
            public PassengerEB passengerEB { get; set; }
            public AgencyEB agencyEB { get; set; }
            public PassengerAmountToPay passengerAmountToPay { get; set; }
            public AgencyAmountToPay agencyAmountToPay { get; set; }
            public Discount discount { get; set; }
            public AgencyBalance agencyBalance { get; set; }
            public PassengerBalance passengerBalance { get; set; }
            public AgencyCommission agencyCommission { get; set; }
            public BrokerCommission brokerCommission { get; set; }
            public AgencySupplementCommission agencySupplementCommission { get; set; }
            public PromotionAmount promotionAmount { get; set; }
            public PriceToPay priceToPay { get; set; }
            public AgencyPriceToPay agencyPriceToPay { get; set; }
            public PassengerPriceToPay passengerPriceToPay { get; set; }
            public TotalPrice totalPrice { get; set; }
            public float reservationStatus { get; set; }
            public float confirmationStatus { get; set; }
            public float paymentStatus { get; set; }
            public List<object> documents { get; set; }
            public List<object> otherDocuments { get; set; }
            public ReservableInfo reservableInfo { get; set; }
            public float paymentFrom { get; set; }
            public DepartureCountry departureCountry { get; set; }
            public DepartureCity departureCity { get; set; }
            public ArrivalCountry arrivalCountry { get; set; }
            public ArrivalCity arrivalCity { get; set; }
            public DateTime createDate { get; set; }
            public AdditionalFields additionalFields { get; set; }
            public string additionalCode1 { get; set; }
            public string additionalCode2 { get; set; }
            public string additionalCode3 { get; set; }
            public string additionalCode4 { get; set; }
            public float agencyDiscount { get; set; }
            public bool hasAvailablePromotionCode { get; set; }
        }

        public class Root
        {
            public Header header { get; set; }
            public Body body { get; set; }
        }

        public class SalePrice
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class Service
        {
            public string id { get; set; }
            public float type { get; set; }
            public Price price { get; set; }
            public float passengerType { get; set; }
            public float orderNumber { get; set; }
            public string note { get; set; }
            public DepartureCountry departureCountry { get; set; }
            public DepartureCity departureCity { get; set; }
            public ArrivalCountry arrivalCountry { get; set; }
            public ArrivalCity arrivalCity { get; set; }
            public ServiceDetails serviceDetails { get; set; }
            public string partnerServiceId { get; set; }
            public bool isMainService { get; set; }
            public bool isRefundable { get; set; }
            public bool bundle { get; set; }
            public List<CancellationPolicy> cancellationPolicies { get; set; }
            public List<object> documents { get; set; }
            public string encryptedServiceNumber { get; set; }
            public List<object> priceBreakDowns { get; set; }
            public float commission { get; set; }
            public ReservableInfo reservableInfo { get; set; }
            public float unit { get; set; }
            public List<object> conditionalSpos { get; set; }
            public float confirmationStatus { get; set; }
            public float serviceStatus { get; set; }
            public float productType { get; set; }
            public bool createServiceTypeIfNotExists { get; set; }
            public string code { get; set; }
            public string name { get; set; }
            public DateTime beginDate { get; set; }
            public DateTime endDate { get; set; }
            public float adult { get; set; }
            public float child { get; set; }
            public float infant { get; set; }
            public NetPrice netPrice { get; set; }
            public bool includePackage { get; set; }
            public bool compulsory { get; set; }
            public bool isExtraService { get; set; }
            public string supplierCode { get; set; }
            public string supplier { get; set; }
            public float provider { get; set; }
            public List<string> travellers { get; set; }
            public bool thirdPartyRecord { get; set; }
            public float recordId { get; set; }
            public AdditionalFields additionalFields { get; set; }
        }

        public class ServiceDetails
        {
            public string serviceId { get; set; }
            public string thumbnail { get; set; }
            public HotelDetail hotelDetail { get; set; }
            public float night { get; set; }
            public string room { get; set; }
            public string board { get; set; }
            public string accom { get; set; }
            public Geolocation geoLocation { get; set; }
        }

        public class SupplementDiscount
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class TotalPrice
        {
            public float amount { get; set; }
            public string currency { get; set; }
        }

        public class TransferLocation
        {
            public string code { get; set; }
            public string name { get; set; }
            public float type { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string parentId { get; set; }
            public string countryId { get; set; }
            public float provider { get; set; }
            public bool isTopRegion { get; set; }
            public string id { get; set; }
        }

        public class Traveller
        {
            public string travellerId { get; set; }
            public float type { get; set; }
            public float title { get; set; }
            public List<AvailableTitle> availableTitles { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public bool isLeader { get; set; }
            public DateTime birthDate { get; set; }
            public float age { get; set; }
            public Nationality nationality { get; set; }
            public string identityNumber { get; set; }
            public PassportInfo passportInfo { get; set; }
            public Address address { get; set; }
            public DestinationAddress destinationAddress { get; set; }
            public List<Service> services { get; set; }
            public float gender { get; set; }
            public float orderNumber { get; set; }
            public DateTime birthDateFrom { get; set; }
            public DateTime birthDateTo { get; set; }
            public List<string> requiredFields { get; set; }
            public List<object> documents { get; set; }
            public float passengerType { get; set; }
            public AdditionalFields additionalFields { get; set; }
            public List<object> insertFields { get; set; }
            public float status { get; set; }
        }


    }
}
