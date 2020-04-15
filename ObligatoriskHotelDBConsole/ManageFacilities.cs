using ObligatoriskHotelDBOpgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskHotelDBConsole
{
    class ManageFacilities
    {
        const string ServerUrl = "HTTP://localhost:59385";
        
        public void ReadFacilities()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = client.GetAsync("api/facilities").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var facilities = response.Content.ReadAsAsync<IEnumerable<Facility>>().Result;
                        foreach (var facility in facilities)
                        {
                            Console.WriteLine(facility);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            Console.ReadKey();
        }

        public void CreateFacility(Facility obj)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                var response = client.PostAsJsonAsync("api/facilities", obj).Result;
                    Console.WriteLine($"{obj.Name} has been inserted. \n");

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void DeleteFaciltiy(int id)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {

                    var response = client.DeleteAsync($"api/facilities/{id}").Result;

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void UpdateFacility(int id, Facility obj)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                try
                {

                    var response = client.PutAsJsonAsync($"api/facilities/{id}", obj).Result;
                    Console.WriteLine("Updated.");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
