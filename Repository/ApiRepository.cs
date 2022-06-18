using Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Employees.Repository
{
    public class ApiRepository
    {

        private HttpClient client = new HttpClient();
        private const string GET_EP = "emps";
        private const string POST_EP = "add-emp";
        private const string PUT_EP = "upd-emp";
        private const string DELETE_EP = "del-emp";
        
        public ApiRepository()
        {
            client.BaseAddress = new Uri(@"https://localhost:44375/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<Employee>> GetAllEmployees()
        {
            var result = await client.GetAsync(GET_EP);
            List<Employee> emps = new List<Employee>();
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                emps = await result.Content.ReadAsAsync<List<Employee>>();

            return emps;
        }

        public async Task<HttpStatusCode> AddEmployee(Employee emp)
        {
            var result = await client.PostAsJsonAsync(POST_EP,emp);
            return result.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateEmployee(Employee emp)
        {
            var result = await client.PutAsJsonAsync(PUT_EP, emp);
            return result.StatusCode;
        }
        public async Task<Employee> GetEmployee(int id)
        {
            var result = await client.GetAsync(GET_EP + "/" + id);
            Employee emp = null;
            if (result.IsSuccessStatusCode)
                emp = await result.Content.ReadAsAsync<Employee>();
            return emp;
        }

        public async Task<HttpStatusCode> DeleteEmployee(int id)
        {
            var result = await client.DeleteAsync(DELETE_EP + "/" + id);
            return result.StatusCode;
        }

    }
}
