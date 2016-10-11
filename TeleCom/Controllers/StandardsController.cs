using System.Collections.Generic;
using System.Web.Http;
using TeleCom.Core;
using TeleCom.DataAccess;

namespace TeleCom.Controllers
{
    public class StandardsController : ApiController
    {
        // GET api/Standard
        public IEnumerable<Standard> Get()
        {
            return StandardsRepository.GetAll();
        }

        // GET api/Standards/5
        public Standard Get(int id)
        {
            return StandardsRepository.GetById(id);
        }

        // POST api/Standards
        public void Post([FromBody]Standard value)
        {
            StandardsRepository.Insert(value);
        }

        // PUT api/Standards/5
        public void Put(int id, [FromBody]Standard value)
        {
            StandardsRepository.Update(value);
        }

        // DELETE api/Standards/5
        public void Delete(int id)
        {
            StandardsRepository.Delete(id);
        }
    }
}