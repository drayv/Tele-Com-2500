using System.Collections.Generic;
using System.Web.Http;
using TeleCom.Core;
using TeleCom.DataAccess;

namespace TeleCom.Controllers
{
    public class RatesController : ApiController
    {
        // GET api/Rate
        public IEnumerable<Rate> Get()
        {
            return RatesRepository.GetAll();
        }

        // GET api/Rates/5
        public Rate Get(int id)
        {
            return RatesRepository.GetById(id);
        }

        // POST api/Rates
        public void Post([FromBody]Rate value)
        {
            RatesRepository.Insert(value);
        }

        // PUT api/Rates/5
        public void Put(int id, [FromBody]Rate value)
        {
            RatesRepository.Update(value);
        }

        // DELETE api/Rates/5
        public void Delete(int id)
        {
            RatesRepository.Delete(id);
        }
    }
}