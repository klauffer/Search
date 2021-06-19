﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Search.FuzzySearch;

namespace Search
{
    /// <summary>
    /// helper class to provide an easy way to setup the Search inside of the DotNet DI system
    /// </summary>
    public static class DotNetDI
    {
        /// <summary>
        /// Sets up the DI mappings for the DotNet DI system
        /// </summary>
        /// <param name="service">the DotNet Di ServiceCollection</param>
        /// <param name="fuzzySearchType">the type of search algorithm to be run</param>
        public static void AddSearch(this IServiceCollection service, FuzzySearchType fuzzySearchType)
        {
            service.AddTransient(provider => 
                new SearchEngine(fuzzySearchType, provider.GetService<ILogger>()));
        }
    }
}
