using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrary
{


    public class EncryptionHelper
    {
        private AesCryptoServiceProvider aesCrypto;
        private readonly byte[] key = Encoding.UTF8.GetBytes("bjbdhfbdfjbdjfbdxjfbxdhfbhdxbfhdx");

        public EncryptionHelper()
        {
            aesCrypto = new AesCryptoServiceProvider();
            aesCrypto.Key = key ;
            aesCrypto.GenerateIV();
        }

        public byte[] Encrypt(string plainText)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesCrypto.CreateEncryptor(), CryptoStreamMode.Write))
            {
                byte[] messageBytes = Encoding.UTF8.GetBytes(plainText);
                cryptoStream.Write(messageBytes, 0, messageBytes.Length);
                cryptoStream.FlushFinalBlock();
                return memoryStream.ToArray();
            }
        }

        public string Decrypt(byte[] encryptedData)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesCrypto.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cryptoStream.Write(encryptedData, 0, encryptedData.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public byte[] GetIV()
        {
            return aesCrypto.IV;
        }

        public void SetIV(byte[] iv)
        {
            if (iv.Length != aesCrypto.IV.Length)
            {
                throw new ArgumentException("Invalid IV length");
            }
            Array.Copy(iv, aesCrypto.IV, iv.Length);
        }

        public byte[] GetKey()
        {
            return aesCrypto.Key;
        }

        public void SetKey(byte[] key)
        {
            if (key.Length != aesCrypto.Key.Length)
            {
                throw new ArgumentException("Invalid key length");
            }
            Array.Copy(key, aesCrypto.Key, key.Length);
        }
    }
}
