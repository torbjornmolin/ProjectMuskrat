using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SensorsDataPersistence;

namespace SensorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorValueController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/guid
        [HttpGet("{id}")]
        public ActionResult<SensorData> Get(Guid guid)
        {
            IDataAccess dataAccess = new DataAccess();
            return dataAccess.GetSensorData(guid);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] SensorData value)
        {
            IDataAccess dataAccess = new DataAccess();
            dataAccess.SaveSensorData(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
