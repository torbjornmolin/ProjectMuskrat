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
        static IDataAccess dataAccess = new DataAccess("/home/torbjorn/sensorData.json");
        // GET api/SensorValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(dataAccess.GetAllData());
        }

        // GET api/values/guid
        [HttpGet("{id}")]
        public ActionResult<SensorData> Get(Guid? id)
        {
            return dataAccess.GetSensorData(id.Value);
        }

        // POST api/values
        [HttpPost]
        public SensorData Post([FromBody] SensorData value)
        {
            dataAccess.SaveSensorData(value);
            return value;
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
