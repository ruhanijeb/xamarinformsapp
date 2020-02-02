using Fusillade;
using ReactiveUIDemo.Helper;
using ReactiveUIDemo.RestClient;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ReactiveUIDemo.Service
{
    public class ApiService : IApiService
    {
        private readonly Lazy<IRestApiClient> _background;
        private readonly Lazy<IRestApiClient> _userInitiated;
        private readonly Lazy<IRestApiClient> _speculative;
        public string ApiBaseAddress { get; } = "https://api.themoviedb.org/3";
        public ApiService(string apiBaseAddress = null)
        {
            IRestApiClient CreateClient(HttpMessageHandler httpMessageHandler)
            {
                var client = new HttpClient(httpMessageHandler)
                {
                    BaseAddress = new Uri(apiBaseAddress ?? ApiBaseAddress)
                };
                return RestService.For<IRestApiClient>(client);

            }
            _background = new Lazy<IRestApiClient>(() =>
            {
#if DEBUG
                return CreateClient(new RateLimitedHttpMessageHandler(new HttpLogging(), Priority.Background));
#else
                return CreateClient(new RateLimitedHttpMessageHandler(new HttpClientHandler(), Priority.Background));
#endif
            });
            _userInitiated = new Lazy<IRestApiClient>(() =>
            {
#if DEBUG
                return CreateClient(new RateLimitedHttpMessageHandler(new HttpLogging(), Priority.Background));
#else
                return CreateClient(new RateLimitedHttpMessageHandler(new HttpClientHandler(), Priority.Background));
#endif

            });
            _speculative = new Lazy<IRestApiClient>(() =>
            {
#if DEBUG
                return CreateClient(new RateLimitedHttpMessageHandler(new HttpLogging(), Priority.Background));
#else
                return CreateClient(new RateLimitedHttpMessageHandler(new HttpClientHandler(), Priority.Background));
#endif

            });
        }

        public IRestApiClient Speculative => _speculative.Value;

        public IRestApiClient UserInitiated => _userInitiated.Value;

        public IRestApiClient Background => _background.Value;
    }
}
