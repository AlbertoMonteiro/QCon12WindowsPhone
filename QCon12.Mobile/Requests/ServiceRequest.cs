﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AlbertoMonteiroWP7Tools.Controls;
using Newtonsoft.Json;

namespace QCon12.Mobile.Requests
{
    public abstract class ServiceRequest<T>
    {
        protected readonly string controller;
        protected string additional;
        protected int count = 0;
        protected JsonSerializerSettings settings;
#if DEBUG
        protected string URL = @"http://192.168.25.2/qcon12/api/";
#else
        protected string URL = @"http://qcon12sp.azurewebsites.net/api/";
#endif

        protected ServiceRequest(string controller = "")
        {
            settings = new JsonSerializerSettings();
            this.controller = controller;
        }

        public async Task<List<T>> List(int skip = 0)
        {
            if (skip != 0)
                additional = "/?$skip=" + skip;
            return await DownloadAndDeserialize<List<T>>();
        }

        public async Task<T> Get(int id)
        {
            additional = "/" + id;
            return await DownloadAndDeserialize<T>();
        }

        protected async Task<TR> DownloadAndDeserialize<TR>()
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
                        keepTrying = false;
                }
            }
            GlobalLoading.Instance.PopLoading();
            return instance;
        }
    }
}