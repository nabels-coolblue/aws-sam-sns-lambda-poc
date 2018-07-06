using System;
using System.Data.Common;
using System.Net;
using System.Net.Http;
using Amazon.Lambda.SQSEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Lambda
{
    public class Lambda
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public string Handler(SQSEvent sqsEvent)
        {
                foreach (var record in sqsEvent.Records)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(record));
                }

            throw new Exception("Something bad happened :(");
        }
    }
}