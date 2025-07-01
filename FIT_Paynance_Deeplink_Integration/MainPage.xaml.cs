using CommunityToolkit.Mvvm.Messaging;
using FIT_Paynance_Deeplink_Integration.Models;

namespace FIT_Paynance_Deeplink_Integration
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            WeakReferenceMessenger.Default.Register<PaymentCallBackMessage>(this, (r, m) =>
            {
                DisplayAlert("Payment Result", $"Callback received: {m.Value}", "OK");
            });

        }

        private async void OnPaymnetButtonClicked(object sender, EventArgs e)
        {

            var uri = new Uri("paynance://sideapp/gateway" +
                    "?ownerAppPackage=hu.fit.paynance" +
                    "&ownerAppDeepLinkCallback=paynance_intent://response" +
                    "&sessionId=92e6e172-b3b2-4a94-bf77-0c868f4e32ba" + //valid UUIDv4
                    "&sourceCode=ST32976223228C5MHHPV3FSMD" +
                    "&terminalId=Swift2Pro-NMS212NG1420F0213" +
                    "&cashRegisterId=FIT_Cash_Register_ID" +
                    "&amount=1000" +
                    "&currencyCode=348" +
                    "&merchantReference=FIT_Merchant_Reference" +
                    "&customerTrns=FIT_Customer_Reference" +
                    "&tipAmount=0" +
                    "&action=sale");

            await Launcher.Default.OpenAsync(uri);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            WeakReferenceMessenger.Default.Unregister<PaymentCallBackMessage>(this);
        }

    }

}
