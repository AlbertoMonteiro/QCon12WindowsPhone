using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QCon12.Phone.Requests
{
    public abstract class AzureServiceRequest<T>
    {
        protected readonly string controller;
        protected const string URL = @"http://qcon12sp.azurewebsites.net/api/";

        protected AzureServiceRequest(string controller)
        {
            this.controller = controller;
        }

        public async Task<List<T>> List()
        {
            return await DownloadAndDeserialize<List<T>>();
        }

        public async Task<T> Get(int id)
        {
            return await DownloadAndDeserialize<T>();
        }

        private async Task<TR> DownloadAndDeserialize<TR>()
        {
            var request = new WebClient();

            var str = await request.DownloadStringTaskAsync(new Uri(URL + controller));

            var settings = new JsonSerializerSettings();
            var serializer = JsonSerializer.Create(settings);
            var stringReader = new StringReader(str);
            var instance = serializer.Deserialize<TR>(new JsonTextReader(stringReader));

            return instance;
        }
    }
}
