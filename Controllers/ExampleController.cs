using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using $safeprojectname$.Models.DTO;
using $safeprojectname$.Repositories;

namespace $safeprojectname$.Controllers
{
    public class ExampleController : ApiController
    {
        private IRepository Repository;
        
        public ExampleController(IRepository repository) : base()
        {
            Repository = repository;
        }


        // Endpoint Method (GET, POST, PUT, DELETE)
        [HttpPost]
        // ActionName For Endpoint URL
        [ActionName("exampletask")]
        public async Task<HttpResponseMessage> ExampleTaskAsync()
        {
            try
            {
                // Read Request Body
                var request = await Request.Content.ReadAsAsync<Dto>();
                // If Request Body is Empty
                if (request == null)
                    return JsonResponse.ParameterIncorrect(Request);
                // If Required Parameter is Empty
                if (string.IsNullOrEmpty(request.Parameter1))
                    return JsonResponse.ParameterIncorrect(Request);

                // Fetch Data
                var res = await Repository.ExampleTaskAsync(request);
                // If Data Fetch Success
                if (res.Any())
                    return JsonResponse.Success(Request, res);
                else return JsonResponse.DataInvalid(Request);
            }
            catch (JsonReaderException)
            {
                // Return If Read Json Body Fail
                return JsonResponse.ParameterIncorrect(Request);
            }
            catch (Exception ex)
            {

                // Source Code Error
                return JsonResponse.Error(Request, "Error Occured: " + ex.Message);
            }
        }

        [HttpPost]
        [ActionName("exampletaskpaginated")]
        public async Task<HttpResponseMessage> ExamplePaginatedTaskAsync()
        {
            try
            {
                var request = await Request.Content.ReadAsAsync<PaginatedDto>();
                if (request == null)
                    return JsonResponse.ParameterIncorrect(Request);
                if (string.IsNullOrEmpty(request.Parameter1))
                    return JsonResponse.ParameterIncorrect(Request);

                var res = await Repository.ExamplePaginatedTaskAsync(request);
                if (res.Any())
                    return JsonResponse.Paginated(Request, request.Page, res);
                else return JsonResponse.DataInvalid(Request);
            }
            catch (JsonReaderException)
            {
                return JsonResponse.ParameterIncorrect(Request);
            }
            catch (Exception ex)
            {
                return JsonResponse.Error(Request, "Error Occured: " + ex.Message);
            }
        }

    }
}