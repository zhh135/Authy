using System;
using System.Collections.Specialized;


namespace Authy.Model
{
    public enum AlgorithmOption
    {
        SHA1 = 0,
        SHA256 = 1,
        SHA512 = 3
    }

    public class TOTPModel
    {
        public string Secret { get { return _secret; } }
        public string Account {  get { return _account; } }
        public string Issuser { get { return _issuer; } }
        public int Digits { get { return _digits; } }
        public int Period { get { return _period; } }
        public AlgorithmOption AlgorithmOption { get { return _algorithmOption; } }

        private readonly string _secret;
        private readonly string _account;
        private readonly string _issuer;
        private readonly int _digits = 6;
        private readonly int _period = 30;
        private readonly AlgorithmOption _algorithmOption = AlgorithmOption.SHA1;

        public TOTPModel(string uriString)
        {
            try
            {
                Uri uri = new Uri(uriString);
                if (uri.Host != "totp") throw new Exception("This URI is not correct TOTP format.");
                string[] label = uri.Segments[1].Split(':');
                if (label.Length == 2)
                {
                    _account = Uri.UnescapeDataString(label[0]);
                    _issuer = Uri.UnescapeDataString(label[1]);
                }
                else
                {
                    _account = uri.Segments[1];
                }
                NameValueCollection queryDictionary = System.Web.HttpUtility.ParseQueryString(uri.Query);
                _secret = queryDictionary["secret"] ?? _secret;
                _algorithmOption = (AlgorithmOption)Enum.Parse(typeof(AlgorithmOption), queryDictionary["algorithm"] ?? "SHA1");
                _digits = queryDictionary["digits"] == "8" ? 8 : 6;
                _period = queryDictionary["period"] == "60" ? 60 : 30;
                _issuer = queryDictionary["issuer"];
            }
            catch 
            {
            }
        }

        public TOTPModel(string secret, string account, string issuer, string algorithm, int digits, int period)
        {
            _secret = secret;
            _account = account;
            _issuer = issuer;
            _algorithmOption = (AlgorithmOption)Enum.Parse(typeof(AlgorithmOption), algorithm ?? "SHA1");
            _digits = digits == 8 ? 8 : 6;
            _period = period == 60 ? 60 : 30;
        }
    }
}
