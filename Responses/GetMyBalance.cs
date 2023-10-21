using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EldoradoBot.Responses
{
    public class GetMyBalance
    {
        public class Balance
        {
            [JsonPropertyName("amount")]
            public double amount { get; set; }

            [JsonPropertyName("currency")]
            public string currency { get; set; }
        }

        public class BalanceInUSD
        {
            [JsonPropertyName("amount")]
            public double amount { get; set; }

            [JsonPropertyName("currency")]
            public string currency { get; set; }
        }

        public class Root
        {
            [JsonPropertyName("userPaymentPrivateDTO")]
            public UserPaymentPrivateDTO userPaymentPrivateDTO { get; set; }

            [JsonPropertyName("eurPaymentProviderStrategy")]
            public string eurPaymentProviderStrategy { get; set; }

            [JsonPropertyName("usPaymentProviderStrategy")]
            public string usPaymentProviderStrategy { get; set; }

            [JsonPropertyName("rowPaymentProviderStrategy")]
            public string rowPaymentProviderStrategy { get; set; }

            [JsonPropertyName("gbpCurrencyPaymentProviderStrategy")]
            public string gbpCurrencyPaymentProviderStrategy { get; set; }

            [JsonPropertyName("audPaymentProviderStrategy")]
            public string audPaymentProviderStrategy { get; set; }

            [JsonPropertyName("cadPaymentProviderStrategy")]
            public string cadPaymentProviderStrategy { get; set; }
        }

        public class UserPaymentPrivateDTO
        {
            [JsonPropertyName("balance")]
            public Balance balance { get; set; }

            [JsonPropertyName("creditCardPaymentMethod")]
            public string creditCardPaymentMethod { get; set; }

            [JsonPropertyName("id")]
            public string id { get; set; }

            [JsonPropertyName("balanceInUSD")]
            public BalanceInUSD balanceInUSD { get; set; }

            [JsonPropertyName("pendingReviews")]
            public List<object> pendingReviews { get; set; }

            [JsonPropertyName("verifiedIdReviews")]
            public object verifiedIdReviews { get; set; }

            [JsonPropertyName("pendingOrder")]
            public object pendingOrder { get; set; }

            [JsonPropertyName("isPayoneerLinked")]
            public bool isPayoneerLinked { get; set; }

            [JsonPropertyName("hasMadeSaleIncome")]
            public bool hasMadeSaleIncome { get; set; }

            [JsonPropertyName("hasVerifiedId")]
            public bool hasVerifiedId { get; set; }

            [JsonPropertyName("cardPayRecurringPaymentCardLastFourDigits")]
            public object cardPayRecurringPaymentCardLastFourDigits { get; set; }

            [JsonPropertyName("checkoutRecurringPaymentCardLastFourDigits")]
            public object checkoutRecurringPaymentCardLastFourDigits { get; set; }
        }



    }
}
