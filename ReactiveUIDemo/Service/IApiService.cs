using ReactiveUIDemo.RestClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactiveUIDemo.Service
{
    public interface IApiService
    {
        IRestApiClient Speculative { get; }

        /// <summary>
        /// Gets our rest client used by user initiated requests.
        /// </summary>
        IRestApiClient UserInitiated { get; }

        /// <summary>
        /// Gets our rest client used for background initiated requests.
        /// </summary>
        IRestApiClient Background { get; }
    }
}
