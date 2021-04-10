using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Projet_Xamarin.Service
{
    public static class HttpService
    {
        static HttpClient client;
        public static HttpClient GetInstance()
        {
            if (client == null)
            {
                client = new HttpClient();
            }
            return client;
        }
    }
}
