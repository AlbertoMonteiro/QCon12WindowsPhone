using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AlbertoMonteiroWP7Tools.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QCon12.Mobile.Utils;

namespace QCon12.Mobile.Requests
{
    public abstract class ServiceRequest<T>
    {
        protected readonly string controller;
        private string additional;
        private int count = 0;
#if DEBUG
        protected string URL = @"http://192.168.25.2/qcon12/api/";
        protected JsonSerializerSettings settings;
#else
        protected string URL = @"http://qcon12sp.azurewebsites.net/api/";
#endif


        protected ServiceRequest(string controller = "")
        {
            settings = new JsonSerializerSettings();
            this.controller = controller;
        }

        public async Task<List<T>> List()
        {
            return await DownloadAndDeserialize<List<T>>();
        }

        public async Task<T> Get(int id)
        {
            additional = "/" + id;
            return await DownloadAndDeserialize<T>();
        }

        private async Task<TR> DownloadAndDeserialize<TR>()
        {
            var instance = default(TR);
            GlobalLoading.Instance.PushLoading();
            var keepTrying = true;
            while (keepTrying)
            {
                var request = new WebClient();
                var uri = new Uri(URL + controller + additional);
                try
                {
                    var str = await request.DownloadStringTaskAsync(uri);
#if DEBUG
                    Thread.Sleep(1000);
#endif
                    var serializer = JsonSerializer.Create(settings);
                    using (var stringReader = new StringReader(str))
                    {
                        instance = serializer.Deserialize<TR>(new JsonTextReader(stringReader));
                        stringReader.Close();
                        keepTrying = false;
                    }
                }
                catch (Exception e)
                {
                    if (count++ < 3)
                        keepTrying = true;
                }
            }
            GlobalLoading.Instance.PopLoading();
            return instance;
        }
    }
}
