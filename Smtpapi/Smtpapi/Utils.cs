﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SendGrid.SmtpApi
{

    /// <summary>
    /// 
    /// </summary>
    public class Utils
    {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectToSerialize"></param>
        /// <returns></returns>
        public static string Serialize<T>(T objectToSerialize)
        {
            var serializer = new DataContractJsonSerializer(objectToSerialize.GetType());
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, objectToSerialize);
                var jsonData = Encoding.UTF8.GetString(stream.ToArray(), 0, (int)stream.Length);
                return jsonData;                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionaryToSerialize"></param>
        /// <returns></returns>
        public static string SerializeDictionary(IDictionary<String, String> dictionaryToSerialize)
        {
            return "{"+String.Join(",",dictionaryToSerialize.Select(kvp => Serialize(kvp.Key) + ":" + Serialize(kvp.Value)))+"}";
        }
    }
}
