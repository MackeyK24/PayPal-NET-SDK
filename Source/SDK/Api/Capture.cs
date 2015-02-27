//==============================================================================
//
//  This file was auto-generated by a tool using the PayPal REST API schema.
//  More information: https://developer.paypal.com/docs/api/
//
//==============================================================================
using Newtonsoft.Json;
using PayPal.Util;

namespace PayPal.Api
{
    public class Capture : PayPalResourceObject
    {
        /// <summary>
        /// Identifier of the Capture transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
        public string id { get; set; }

        /// <summary>
        /// Amount being captured. If no amount is specified, amount is used from the authorization being captured. If amount is same as the amount that's authorized for, the state of the authorization changes to captured. If not, the state of the authorization changes to partially_captured. Alternatively, you could indicate a final capture by setting the is_final_capture flag to true.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "amount")]
        public Amount amount { get; set; }

        /// <summary>
        /// whether this is a final capture for the given authorization or not. If it's final, all the remaining funds held by the authorization, will be released in the funding instrument.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "is_final_capture")]
        public bool? is_final_capture { get; set; }

        /// <summary>
        /// State of the capture transaction.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state")]
        public string state { get; set; }

        /// <summary>
        /// ID of the Payment resource that this transaction is based on.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parent_payment")]
        public string parent_payment { get; set; }

        /// <summary>
        /// Transaction fee applicable for this payment.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transaction_fee")]
        public Currency transaction_fee { get; set; }

        /// <summary>
        /// Time the resource was created in UTC ISO8601 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "create_time")]
        public string create_time { get; set; }

        /// <summary>
        /// Time the resource was last updated in UTC ISO8601 format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "update_time")]
        public string update_time { get; set; }

        /// <summary>
        /// Obtain the Capture transaction resource for the given identifier.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="captureId">Identifier of the Capture Resource to obtain the data for.</param>
        /// <returns>Capture</returns>
        public static Capture Get(APIContext apiContext, string captureId)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(captureId, "captureId");

            // Configure and send the request
            var pattern = "v1/payments/capture/{0}";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { captureId });
            return PayPalResource.ConfigureAndExecute<Capture>(apiContext, HttpMethod.GET, resourcePath);
        }

        /// <summary>
        /// Creates (and processes) a new Refund Transaction added as a related resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public Refund Refund(APIContext apiContext, Refund refund)
        {
            return Capture.Refund(apiContext, this.id, refund);
        }

        /// <summary>
        /// Creates (and processes) a new Refund Transaction added as a related resource.
        /// </summary>
        /// <param name="apiContext">APIContext used for the API call.</param>
        /// <param name="captureId">ID of the captured payment resource to refund.</param>
        /// <param name="refund">Refund</param>
        /// <returns>Refund</returns>
        public static Refund Refund(APIContext apiContext, string captureId, Refund refund)
        {
            // Validate the arguments to be used in the request
            ArgumentValidator.ValidateAndSetupAPIContext(apiContext);
            ArgumentValidator.Validate(captureId, "captureId");
            ArgumentValidator.Validate(refund, "refund");

            // Configure and send the request
            var pattern = "v1/payments/capture/{0}/refund";
            var resourcePath = SDKUtil.FormatURIPath(pattern, new object[] { captureId });
            return PayPalResource.ConfigureAndExecute<Refund>(apiContext, HttpMethod.POST, resourcePath, refund.ConvertToJson());
        }
    }
}
