using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NEW.LSP.Logic
{
    public class Security
    {
        public static string GetRandomKey(int len)
        {
            int maxSize = len;
            char[] chars = new char[30];
            string a = "1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data) { result.Append(chars[b % (chars.Length)]); }
            return result.ToString();
        }
        public static string Encrypt(string s)
        {
            try
            {
                AesManaged crypto = new AesManaged();
                crypto.IV = new byte[] { 19, 193, 42, 65, 139, 27, 247, 241, 15, 56, 237, 56, 178, 190, 250, 23 };
                crypto.Key = new byte[] { 163, 92, 37, 27, 145, 27, 27, 211, 232, 125, 131, 128, 26, 15, 56, 237, 56, 178, 190, 250, 23, 23, 21, 21, 15, 56, 237, 56, 178, 190, 250, 23 };

                MemoryStream data = new MemoryStream();
                CryptoStream encryptedStream = new CryptoStream(data, crypto.CreateEncryptor(), CryptoStreamMode.Write);
                StreamWriter dest = new StreamWriter(encryptedStream);
                dest.Write(s);
                dest.Flush();
                encryptedStream.FlushFinalBlock();
                data.Position = 0;
                byte[] result = new byte[data.Length + 1];
                data.Read(result, 0, (int)data.Length);
                return Convert.ToBase64String(result);
            }
            catch
            {
                return string.Empty;
            }

        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public static string Decrypt(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            try
            {
                AesManaged crypto = new AesManaged();
                crypto.IV = new byte[] { 19, 193, 42, 65, 139, 27, 247, 241, 15, 56, 237, 56, 178, 190, 250, 23 };
                crypto.Key = new byte[] { 163, 92, 37, 27, 145, 27, 27, 211, 232, 125, 131, 128, 26, 15, 56, 237, 56, 178, 190, 250, 23, 23, 21, 21, 15, 56, 237, 56, 178, 190, 250, 23 };


                byte[] result = Convert.FromBase64String(s);
                MemoryStream data = new MemoryStream();
                CryptoStream encryptedStream = new CryptoStream(data, crypto.CreateDecryptor(), CryptoStreamMode.Write);
                encryptedStream.Write(result, 0, result.Length - 1);
                encryptedStream.FlushFinalBlock();
                data.Position = 0;
                result = new byte[data.Length];
                data.Read(result, 0, (int)data.Length);
                string retStr = "";
                for (int i = 0; i < (int)data.Length; i++)
                {
                    retStr += Convert.ToChar(result[i]);
                }
                return retStr;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
