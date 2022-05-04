using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMariaDbJugadores.Services
{
    public class ServiceAWSS3
    {
        private string bucketName;
        private IAmazonS3 awsClient;
        public ServiceAWSS3(IAmazonS3 client)
        {
            this.awsClient = client;
            this.bucketName = "bucketjugadores/jugadores";
        }
        public async Task<bool> UploadFileAsync(Stream stream, string fileName)
        {
            PutObjectRequest request = new PutObjectRequest
            {
                InputStream = stream,
                Key = fileName,
                BucketName = this.bucketName
            };
            PutObjectResponse response = await this.awsClient.PutObjectAsync(request);
            if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
