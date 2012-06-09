using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AlbertoMonteiroWP7Tools.Controls;
using Newtonsoft.Json;

namespace QCon12.Mobile.Requests
{
    public abstract class AzureServiceRequest<T>
    {
        protected readonly string controller;
#if DEBUG
        protected const string URL = @"http://192.168.25.2/qcon12/api/";
#else
        protected const string URL = @"http://qcon12sp.azurewebsites.net/api/";
#endif


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
            GlobalLoading.Instance.PushLoading();
            
            var str = await request.DownloadStringTaskAsync(new Uri(URL + controller));
#if DEBUG
            Thread.Sleep(1000); 
#endif
            var settings = new JsonSerializerSettings();
            var serializer = JsonSerializer.Create(settings);
            var stringReader = new StringReader(str);
            var instance = serializer.Deserialize<TR>(new JsonTextReader(stringReader));
            GlobalLoading.Instance.PopLoading();
            return instance;
        }
    }
}
