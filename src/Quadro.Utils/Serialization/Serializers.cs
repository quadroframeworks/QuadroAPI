﻿using Newtonsoft.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CPXML
{
	public static class Serializers
    {


        // Return a deep clone of an object of type T.
        public static T DeepClone<T>(this T obj)
        {
            if (obj == null)
                throw new NullReferenceException();

            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
            var serializeSettings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj, serializeSettings), deserializeSettings);
        }
    

        public static String GetRootElement(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            return xmlDoc.DocumentElement.Name;
        }

        public static String GetRootElement(Stream stream)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(stream);
            return xmlDoc.DocumentElement.Name;
        }


        public static string SerializeToString<T>(object o)
        {
            using (var sw = new Utf8StringWriter())
            {
                using (var xw = XmlWriter.Create(sw, new XmlWriterSettings() { Encoding = Encoding.UTF8 }))
                {
                    var ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(xw, o, ns);
                    xw.Close();
                }
                sw.Close();
                return sw.ToString();
            }
        }




        public static void SerializeToFile<T>(object o, string filename)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, o, ns);
            writer.Close();
         }


        public static T DeSerializeStringNoRoot<T>(string xml)
        {

            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(xml);
            object obj = deserializer.Deserialize(reader);
            T XmlData = (T)obj;
            reader.Close();

            return XmlData;

        }

        public static T DeSerializeString<T>(string xml)
        {

            string rootelement = typeof(T).Name;
            XmlSerializer deserializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootelement));
            TextReader reader = new StringReader(xml);
            object obj = deserializer.Deserialize(reader);
            T XmlData = (T)obj;
            reader.Close();

            return XmlData;

        }
        /// <summary>
        /// De-serializes an XML file to an orders collection.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static T DeSerializeFile<T>(string filename)
        {

          
            if (File.Exists(filename))
            {

                try
                {

                    string rootelement = typeof(T).Name;
                    XmlSerializer deserializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootelement));
                    TextReader reader = new StreamReader(filename);
                    object obj = deserializer.Deserialize(reader);
                    T XmlData = (T)obj;
                    reader.Close();

                    return XmlData;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {

             
                Exception filenotfound = new FileNotFoundException();
                throw (filenotfound);
            }

        }


        public static void Serialize<T>(T t, string fileName)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(fileName);
            serializer.Serialize(writer, t, ns);
            writer.Close();
        }

        public static void Serialize<T>(object o, string filename)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter writer = new StreamWriter(filename);
            serializer.Serialize(writer, o, ns);
            writer.Close();

        }

        /// <summary>
        /// De-serializes an XML file to an orders collection.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static T DeSerialize<T>(string filename)
        {


            if (File.Exists(filename))
            {

                try
                {

                    string rootelement = typeof(T).Name;
                    XmlSerializer deserializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootelement));
                    TextReader reader = new StreamReader(filename);
                    object obj = deserializer.Deserialize(reader);
                    T XmlData = (T)obj;
                    reader.Close();

                    return XmlData;

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                throw new FileNotFoundException(filename + " not found.");
            }


        }

    }

    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
