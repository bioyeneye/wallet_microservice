using System;
using System.Collections.Generic;
using System.Text;

namespace WalletMicroservice.Common.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public bool ValidateIssuer { get; set; }
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public bool ValidateAudience { get; set; }
        public string Scheme { get; set; }

        //todo: include cors implementations
    }

}
