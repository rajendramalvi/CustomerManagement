using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.CommonMethod
{
    /// <summary>
    /// All type of common generic method comes in this class.
    /// </summary>
    /// <typeparam name="T">generics.</typeparam>
    public class CommonMethods<T>
    {

        /// <summary>
        /// Common method to call rthird party api.
        /// </summary>
        /// <typeparam name="T">Genric type.</typeparam>
        /// <param name="apiUrl">url.</param>
        /// <param name="method">http method type.</param>
        /// <param name="data">dynamic object.</param>
        /// <returns>response.</returns>
        public T CallApi<T>(string apiUrl, HttpMethod method, object? data = null)
        {
            try
            {
                var httpClient = new HttpClient();

                // Create the request message
                var requestMessage = new HttpRequestMessage(method, apiUrl);

                // If the request is a POST and has data, serialize the data and add it to the request body
                if (method == HttpMethod.Post && data != null)
                {
                    var json = JsonConvert.SerializeObject(data);
                    requestMessage.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                }

                // Send the request and get the response
                var response = httpClient.SendAsync(requestMessage).Result;

                // If the response is successful, deserialize it into an object of type T and return it
                if (response != null && response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception ex)
            {

            }
            return JsonConvert.DeserializeObject<T>(string.Empty);
        }
    }
}
