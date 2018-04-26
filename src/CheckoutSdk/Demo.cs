using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Checkout.Payments;
using Checkout.Webhooks;

namespace Checkout
{
    public class Demo
    {
        IApiClient api = new ApiClient(new CheckoutConfiguration("sk_xxx", sandbox: true));

        public async Task FullCardPayment()
        {
            var request = new CardPaymentRequest(
                100,
                Currency.GBP,
                new CardSource("4242424242424242", 1, 2012)
            );

            ApiResponse<CardPaymentResponse> response = await api.Payments.RequestAsync(request);

            if (response.RequiresRedirect())
            {
                Redirect(response.Result.GetRedirectUrl()); // Doesn't require knowledge or rel types
            }
            else if (response.Result.Approved)
            {
                var cardId = response.Result.Source.Id;
                PaymentApproved();
            }
            else
            {
                PaymentDeclined();
            }
        }

        public async Task TokenPayment()
        {
            var token = "tok_xxx";

            var request = new TokenPaymentRequest(100, Currency.GBP, new TokenSource(token));
            ApiResponse<CardPaymentResponse> response = await api.Payments.RequestAsync(request);

            // returns a card response
            var cardId = response.Result.Source.Id;
        }

        public async Task AlternativePaymentRequest()
        {
            var source = new AlternativePaymentSource("chococoin")
            {
                { "foo", "bar" },
                { "iban", "1234545" }
            };

            var request = new AlternativePaymentRequest(100, Currency.GBP, source);
            ApiResponse<AlternativePaymentResponse> response = await api.Payments.RequestAsync(request);
        }

        public async Task AlternativePaymentRequestFromDictionary()
        {
            var props = new Dictionary<string, object>
            {
                { "foo", "bar" },
                { "iban", "1234545" }
            };

            // The reason for using dictionary is it's likely how the merchant will integrate many APMs, 
                // using our JS helper libs to invoke their API

            var source = new AlternativePaymentSource("giropay", props);

            var request = new AlternativePaymentRequest(100, Currency.GBP, source);
            ApiResponse<AlternativePaymentResponse> response = await api.Payments.RequestAsync(request);

            var iban = response.Result.Source["iban"];
        }


        public async Task Webhooks()
        {
            var webhooks = await api.Webhooks.GetAllAsync();
            var webhook = await api.Webhooks.GetAsync("wh_xxx");

            await api.Webhooks.RegisterAsync(new WebhookRequest());
        }

        public void Redirect(string url)
        {

        }

        public void PaymentApproved()
        {

        }

        public void PaymentDeclined()
        {

        }
    }
}