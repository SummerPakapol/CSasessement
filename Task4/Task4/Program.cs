using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Tensorflow;
using static Tensorflow.Binding;
using Tensorflow.Keras;
using Tensorflow.Keras.Datasets;

namespace Task4
{
     class Program
    {
        static void Main(string[] args)
        {
            var current = System.DateTime.Now;
            Console.WriteLine(current);
        }
    }

    class Object {
        private string name { get; set; }
        private int age { get; set; }
        private double value { get; set; }
        private bool isActive { get; set; }
		//etc.

		static HttpClient client = new HttpClient();
		static async Task<Object> getRequest(string Uri)
        {

            Object object1 = null;
			HttpResponseMessage response = await client.GetAsync("http://....");
            if(response.IsSuccessStatusCode) object1 = await response.Content.ReadFromJsonAsync<Object>();
            return object1;
		}
	}


    
    
    }
   

	
    
