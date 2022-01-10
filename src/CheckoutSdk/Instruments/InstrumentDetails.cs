﻿using Checkout.Common;

namespace Checkout.Instruments
{
    public class InstrumentDetails
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Fingerprint { get; set; }

        public int? ExpiryMonth { get; set; }

        public int? ExpiryYear { get; set; }

        public string Name { get; set; }

        public string Scheme { get; set; }

        public string Last4 { get; set; }

        public string Bin { get; set; }

        public string CardType { get; set; }

        public string CardCategory { get; set; }

        public string Issuer { get; set; }

        public CountryCode? IssuerCountry { get; set; }

        public string ProductId { get; set; }

        public string ProductType { get; set; }

        public InstrumentAccountHolder AccountHolder { get; set; }
    }
}