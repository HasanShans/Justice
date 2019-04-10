using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace Justice.App_Code
{
    public static class Payment
    {
        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i <= NumberChars - 1; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i <= buff.Length - 1; i++)
            {
                sbinary += buff[i].ToString("X2");
            }
            return sbinary;
        }
        public static string Encode(string input, string key)
        {
            dynamic keyByte = StringToByteArray(key);
            System.Security.Cryptography.HMACSHA1 hmacsha1 = new System.Security.Cryptography.HMACSHA1(keyByte);
            dynamic messageBytes = Encoding.UTF8.GetBytes(input);
            hmacsha1.ComputeHash(messageBytes);
            return ByteToString(hmacsha1.Hash).ToLower();
        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        public static String CreateNonce()
        {
            Random rnd = new Random();
            String NONCE = CreateMD5(rnd.Next().ToString());
            NONCE = NONCE.Substring(0, 16).ToLower();
            return NONCE;
        }
        public static String GetToSign(String AMOUNT, String CURRENCY, String ORDER, String DESC, String MERCH_NAME, String MERCH_URL, String TERMINAL, String EMAIL, String TRTYPE, String COUNTRY, String MERCH_GMT, String OPER_TIME, String NONCE, String BACKREF)
        {
            String to_sign = AMOUNT.Length.ToString() + AMOUNT + CURRENCY.Length.ToString() + CURRENCY +
                ORDER.Length.ToString() + ORDER + DESC.Length.ToString() + DESC + MERCH_NAME.Length.ToString() + MERCH_NAME + MERCH_URL.Length.ToString() +
                MERCH_URL + "-" + TERMINAL.Length.ToString() + TERMINAL + EMAIL.Length.ToString() + EMAIL + TRTYPE.Length.ToString() +
                TRTYPE + COUNTRY.Length.ToString() + COUNTRY + MERCH_GMT.Length.ToString() + MERCH_GMT + OPER_TIME.Length.ToString() + OPER_TIME +
                NONCE.Length.ToString() + NONCE + BACKREF.Length.ToString() + BACKREF;
            return to_sign;
        }
    }
}