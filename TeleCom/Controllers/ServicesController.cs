using System.Collections.Generic;
using System.Web.Http;
using TeleCom.Core;
using TeleCom.DataAccess;

namespace TeleCom.Controllers
{
    public class ServicesController : ApiController
    {
        // GET api/Service
        public IEnumerable<Service> Get()
        {
            return ServicesRepository.GetAll();
        }

        // GET api/Services/5
        public Service Get(int id)
        {
            return ServicesRepository.GetById(id);
        }

        // POST api/Services
        public void Post([FromBody]Service value)
        {
            ServicesRepository.Insert(value);
        }

        // PUT api/Services/5
        public void Put(int id, [FromBody]Service value)
        {
            ServicesRepository.Update(value);
        }

        // DELETE api/Services/5
        public void Delete(int id)
        {
            ServicesRepository.Delete(id);
        }
    }
}