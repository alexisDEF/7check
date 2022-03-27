using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using _7Check.ViewModels;
using Newtonsoft.Json;
using Xamarin.Essentials;
using _7Check.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace _7Check.Service
{
    class ApiService
{
        partial class Login
        {
            public string Email;
            public string Password;

            public Login(string email, string password)
            {
                Email = email;
                Password = password;
            }
        }
        public static async Task<bool> LoginUser(string email, string password)
        {
            Console.WriteLine("ApiService_LoginUser()-begin");
   

            Login login = new Login(email, password);
            Console.WriteLine("ApiService_LoginUser()-new user " + email+" "+ password);
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            Console.WriteLine(json);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            Console.WriteLine("Before credentials sent " + content.Headers.ContentDisposition.Parameters);
            //Console.WriteLine("Before credentials sent " + content.Headers.ContentDisposition);
            HttpResponseMessage response = await httpClient.PostAsync(AppSettings.ApiUrl + "login", content);
            Console.WriteLine("After credentials sent " + response.Content);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("ApiService_LoginUser()- success status = " + response.IsSuccessStatusCode);
                return false;
            }
            var jsonResult = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TokenModel>(jsonResult);

            Preferences.Set("token", result.Success.token);
            Preferences.Set("userId", result.user.Id.ToString());
            Preferences.Set("userName", result.user.Firstname);
            return true;
        }

        public static async Task<List<TodoModel>> GetTodos(string path)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + path);
            Preferences.Set("getTodo", response);
            return JsonConvert.DeserializeObject<List<TodoModel>>(response);
        }

        public static async Task<bool> AllUpdateTodo(List<TodoModel> todo)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/todos/all/update", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return false;

            return true;
        }

        public static async Task<bool> AllStoreTodo(List<TodoModel> todo)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/todos/all/store", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return false;

            return true;
        }

        public static async Task<TodoModel> PostTodo(List<TodoModel> todo)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/todos", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<TodoModel>("[]");

            return JsonConvert.DeserializeObject<TodoModel>(jsonResult);
        }


        public static async Task<bool> AllDeleteTodo(List<TodoModel> todo)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/todos/all/delete", content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return false;

            return true;
        }


        /*public static async Task<TodoModel> PutTodo(List<TodoModel> todo)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/todos/" + todo.id, content);
            var jsonResult = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return JsonConvert.DeserializeObject<TodoModel>(jsonResult);

            return JsonConvert.DeserializeObject<TodoModel>(jsonResult);
        }
*/

        public static async Task<bool> LogoutAccount()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await httpClient.GetAsync(AppSettings.ApiUrl + "api/logout");
            if (!response.IsSuccessStatusCode) return false;

            Preferences.Set("token", string.Empty);
            Preferences.Set("userId", string.Empty);
            Preferences.Set("userName", string.Empty);

            return true;
        }
    }

}

