﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace  Helpers.Xml
{
    public static class XmlHelper
    {
        //public static T Deserialize<T>(string input) where T : class
        //{
        //    System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

        //    using (StringReader sr = new StringReader(input))
        //    {
        //        return (T)ser.Deserialize(sr);
        //    }
        //}

        public static List<T> Deserialize<T>(string input) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Rows"));
            StringReader stringReader = new StringReader(input);
            List<T> productList = (List<T>)serializer.Deserialize(stringReader);

            return productList;
        }

        public static string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}
