﻿using Essensoft.AspNetCore.Payment.Security;
using Org.BouncyCastle.Crypto;

namespace Essensoft.AspNetCore.Payment.WeChatPay
{
    public class WeChatPayOptions
    {
        public const string DefaultClientName = "Payment.WechatPay.Client";
        public const string CertificateClientName = "Payment.WechatPay.CertificateClient";

        /// <summary>
        /// 应用账号(公众账号ID/小程序ID/企业号CorpId)
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// API秘钥
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// RSA公钥 企业付款到银行卡
        /// </summary>
        internal AsymmetricKeyParameter PublicKey;
        private string rsaPublicKey;
        public string RsaPublicKey
        {
            get
            {
                return rsaPublicKey;
            }
            set
            {
                rsaPublicKey = value;
                if (!string.IsNullOrEmpty(rsaPublicKey))
                {
                    PublicKey = RSAUtilities.GetPublicKeyParameterFormAsn1PublicKey(rsaPublicKey);
                }
            }
        }
    }
}
