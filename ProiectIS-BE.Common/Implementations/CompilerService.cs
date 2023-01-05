using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ProiectIS_BE.Common.Interfaces;
using ProiectIS_BE.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Common.Implementations
{
    public class CompilerService : ICompilerService
    {
        static HttpClient client = new HttpClient();

        public CompilerService()
        {
            client.BaseAddress = new Uri("https://api.jdoodle.com/");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task<CompilerResponseModel> GetCodeExecutionResponse(CompilerRequestModel model)
        { 
            var jsonString = JsonConvert.SerializeObject(model, 
                new JsonSerializerSettings {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("v1/execute", jsonContent);

            response.EnsureSuccessStatusCode();
            
            var serializedResponse = await response.Content.ReadAsAsync<CompilerResponseModel>();
            
            return serializedResponse;
        }
    }
}
