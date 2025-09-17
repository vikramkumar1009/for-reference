﻿using Newtonsoft.Json;
using Dlplone.LMS.Domain;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.PortableExecutable;

/// <summary>
/// A generic wrapper class to REST API calls
/// </summary>
/// <typeparam name="T"></typeparam>
public  class HttpService : IHttpService
{
    /// <summary>
    /// For getting the resources from a web api
    /// </summary>
    /// <param name="url">API Url</param>
    /// <returns>A Task with result object of type T</returns>
    public  async Task<T> Get<T>(string url, Dictionary<string, string> headers = null)
    {
        T result = default(T);
        using (var httpClient = new HttpClient())
        {
            AddHeaders(headers, httpClient);
            var response = httpClient.GetAsync(new Uri(url)).Result;
            response.EnsureSuccessStatusCode();
            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;
                result = JsonConvert.DeserializeObject<T>(x.Result);
            });
        }

        return result;
    }

    /// <summary>
    /// For creating a new item over a web api using POST
    /// </summary>
    /// <param name="apiUrl">API Url</param>
    /// <param name="postObject">The object to be created</param>
    /// <returns>A Task with created item</returns>
    public  async Task<TO> PostRequest<TI, TO>(string apiUrl, TI postObject, Dictionary<string, string> headers = null)
    {
        TO result = default(TO);
        JsonContent content = JsonContent.Create(postObject);

        using (var client = new HttpClient())
        {
            AddHeaders(headers, client);
            var response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
            {
                if (x.IsFaulted)
                    throw x.Exception;
                result = JsonConvert.DeserializeObject<TO>(x.Result);
            });
        }

        return result;
    }

    /// <summary>
    /// For updating an existing item over a web api using PUT
    /// </summary>
    /// <param name="apiUrl">API Url</param>
    /// <param name="putObject">The object to be edited</param>
    public  async Task PutRequest<T>(string apiUrl, T putObject, Dictionary<string, string> headers = null)
    {
        JsonContent content = JsonContent.Create(putObject);
        using (var client = new HttpClient())
        {
            AddHeaders(headers, client);
            var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }
    }

    private void AddHeaders(Dictionary<string,string> headers , HttpClient httpClient)
    {
        if (headers != null)
        {
            httpClient.DefaultRequestHeaders.Clear();
            foreach (var header in headers)
            {

                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}