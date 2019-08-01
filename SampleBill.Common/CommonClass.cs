using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SampleBill.Common
{
    public class CommonClass
    {
        public class Common
        {
            //public static T GetJsonResponse<T>(StringBuilder jsonResult, DbDataReader reader, string parserString)
            //{
            //    //Check reader has some rows
            //    try
            //    {
            //        if (!reader.HasRows)
            //        {
            //            //If reader has no rows then set blank [] in json builder object
            //            return (T)Activator.CreateInstance(typeof(T));
            //        }
            //        else
            //        {
            //            //If reader has rows, then get the value of each row and add it in to the json builder object
            //            while (reader.Read())
            //            {
            //                //Append value row in string builder object
            //                jsonResult.Append(reader.GetValue(0).ToString());
            //            }
            //        }

            //        //Create object of JObject class and parse the json result
            //        JObject jsonResponse = JObject.Parse(jsonResult.ToString());
            //        var objResponse = jsonResponse[parserString];
            //        if (objResponse != null)
            //            return JsonConvert.DeserializeObject<T>(Convert.ToString(objResponse));

            //        return (T)Activator.CreateInstance(typeof(T));
            //    }
            //    catch (Exception ex)
            //    {
            //        return (T)Activator.CreateInstance(typeof(T));
            //    }
            //}

            public static T GetJsonResponse<T>(StringBuilder jsonResult, DbDataReader reader, string parserString)
            {
                //Check reader has some rows
                try
                {
                    //If reader has rows, then get the value of each row and add it in to the json builder object
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Append value row in string builder object
                            jsonResult.Append(reader.GetValue(0).ToString());
                        }

                        //Create object of JObject class and parse the json result
                        JObject jsonResponse = JObject.Parse(jsonResult.ToString());
                        var objResponse = jsonResponse[parserString];
                        if (objResponse != null)
                            return JsonConvert.DeserializeObject<T>(Convert.ToString(objResponse));

                        return (T)Activator.CreateInstance(typeof(T));
                    }

                    return Enumerable.Empty<T>().FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return (T)Activator.CreateInstance(typeof(T));
                }
            }

            public static DateTime GetCurrentDateTime
            {
                get
                {
                    var utcTime = DateTime.Now.ToUniversalTime();
                    var tzi = TimeZoneInfo.FindSystemTimeZoneById("Taipei Standard Time");
                    var convertedTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);


                    return convertedTime;
                }
            }

            public static string ImageUrl
            {
                get
                {
                    return "https://DynamicSolimages.s3-us-west-2.amazonaws.com/";
                }
            }
        }
    }
}
