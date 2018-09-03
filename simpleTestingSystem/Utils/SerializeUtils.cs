using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace simpleTestingSystem.Services
{
    class SerializeUtils
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SerializeUtils));
        private static BinaryFormatter formatter = new BinaryFormatter();

        private const string cryptoKey =
            "Q4JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";
        private const int keySize = 256;
        private const int ivSize = 16;

        public static void serialize(object[] serializeObjects, string fileName)
        {
            byte[] key = Convert.FromBase64String(cryptoKey);

            using (FileStream file = new FileStream(fileName, FileMode.Create))
            {
                using (CryptoStream cryptoStream = CreateEncryptionStream(key, file))
                {
                    WriteObjectToStream(cryptoStream, serializeObjects);
                }
            }
        }

        public static object deserialize(string fileName)
        {
            object deserializeObjects = null;
            if (!File.Exists(fileName))
            {
                logger.Error(string.Format("Deserialize file with name-'{0}' not found", fileName));
            }
            else
            {
                byte[] key = Convert.FromBase64String(cryptoKey);
                using (FileStream file = new FileStream(fileName, FileMode.Open))
                using (CryptoStream cryptoStream = CreateDecryptionStream(key, file))
                {
                    deserializeObjects = ReadObjectFromStream(cryptoStream);
                }
            }
            return deserializeObjects;
        }

        public static void WriteObjectToStream(Stream outputStream, object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return;
            }

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(outputStream, obj);
        }

        public static object ReadObjectFromStream(Stream inputStream)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            object obj = binForm.Deserialize(inputStream);
            return obj;
        }

        public static CryptoStream CreateEncryptionStream(byte[] key, Stream outputStream)
        {
            byte[] iv = new byte[ivSize];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(iv);
            }

            outputStream.Write(iv, 0, iv.Length);

            Rijndael rijndael = new RijndaelManaged();
            rijndael.KeySize = keySize;

            CryptoStream encryptor = new CryptoStream(
                outputStream,
                rijndael.CreateEncryptor(key, iv),
                CryptoStreamMode.Write);
            return encryptor;
        }

        public static CryptoStream CreateDecryptionStream(byte[] key, Stream inputStream)
        {
            byte[] iv = new byte[ivSize];

            if (inputStream.Read(iv, 0, iv.Length) != iv.Length)
            {
                throw new ApplicationException("Failed to read IV from stream.");
            }

            Rijndael rijndael = new RijndaelManaged();
            rijndael.KeySize = keySize;

            CryptoStream decryptor = new CryptoStream(
                inputStream,
                rijndael.CreateDecryptor(key, iv),
                CryptoStreamMode.Read);
            return decryptor;
        }
    }
}
