using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App2.Core.Models;

namespace App2.Core.Services
{
  
    public class DataService
    {
        private  static HttpDataService _httpDataService;

       
        private static async Task<IEnumerable<User>> AllUsersAsync()
        {
            _httpDataService = new HttpDataService();
            var users = await _httpDataService.GetAsync<List<User>>("https://jsonplaceholder.typicode.com/users/");
            return (IEnumerable<User>)users;
        }

        private static async Task<IEnumerable<Todo>> AlArticlesAsync(int userid)
        {
            _httpDataService = new HttpDataService();
            var todos = await _httpDataService.GetAsync<List<Todo>>("https://jsonplaceholder.typicode.com/todos?userId="+ userid);
            return (IEnumerable<Todo>)todos;
        }


        public static async Task<IEnumerable<User>> GetGridDataUsersAsync()
        {
             return await AllUsersAsync();
        }
        public static async Task<IEnumerable<Todo>> GetGridDataTodosAsync(int userid)
        {
            return await AlArticlesAsync(userid);
        }


        
    }
}
