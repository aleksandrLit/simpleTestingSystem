using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace simpleTestingSystem.Services
{
    class SerializeUtils
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SerializeUtils));
        private static BinaryFormatter formatter = new BinaryFormatter();

        public static void serialize(object[] serializeObjects, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, serializeObjects);
            }
        }

        public static object deserialize(string fileName)
        {
            object deserializeObjects = null;
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                try
                {
                    deserializeObjects = formatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    logger.Error("Deserialize file not found " + e.StackTrace);
                }
            }
            return deserializeObjects;
        }
    }
}
