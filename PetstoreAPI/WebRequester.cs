﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PetStoreAPI
{



    public sealed class WebRequester : IWebRequest
    {
        /// <summary>
        /// using HTTP Web request makes a request. Returns a list of PetName Objects.
        /// </summary>
        /// <param name="url">The input URL for the program, Passed as a string because converting it to a URL is not needed. There's no editing taking place.</param>
        /// <returns>
        /// Deserialized list of PetName objects, Currently just the pet names.
        /// </returns>

        public List<PetName> JsonDeSerializer(string url)
        {
            using var client = new HttpClient();
            var response = client.GetStringAsync(url);

            List<PetName> petname = JsonConvert.DeserializeObject<List<PetName>>(response.Result);
            return petname;
        }
    }
}
