using System;
using System.Net;
using System.Net.Http;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Lambda
{
    public class Function
    {
        public APIGatewayProxyResponse Handler(
            APIGatewayProxyRequest request,
            ILambdaContext context)
        {
            try
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int) HttpStatusCode.OK
                };
            }
            catch (Exception)
            {
                return new APIGatewayProxyResponse()
                       {
                           StatusCode = (int)HttpStatusCode.InternalServerError
                       };    
            }
        }
    }
}