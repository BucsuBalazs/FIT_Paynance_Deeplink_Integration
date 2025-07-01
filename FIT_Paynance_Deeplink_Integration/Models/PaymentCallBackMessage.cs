using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.Messaging.Messages;

namespace FIT_Paynance_Deeplink_Integration.Models
{
    class PaymentCallBackMessage : ValueChangedMessage<string>
    {
        public PaymentCallBackMessage(string value) : base(value) { }
    }
}
