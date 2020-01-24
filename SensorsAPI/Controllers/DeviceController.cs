using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SensorsDataPersistence;
using SensorsAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace SensorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class DeviceController : ControllerBase
    {
        static IDataAccess<DeviceData> dataAccess = new DataAccess<DeviceData>("/home/torbjorn/deviceData.json");
        // GET api/Device
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(dataAccess.GetAllData());
        }

        // GET api/Device/{id}
        [HttpGet("{id}")]
        public ActionResult<DeviceData> Get(Guid? id)
        {
            return dataAccess.GetData(id.Value);
        }

        // POST api/Device
        [HttpPost]
        public DeviceData Post([FromBody] DeviceDataPostModel value)
        {
            int newId = dataAccess.GetAllData().Any() ? dataAccess.GetAllData().Max(d => d.DeviceID) + 1 : 0;
            var deviceData = new DeviceData()
            {
                Identifier = Guid.NewGuid(),
                DeviceID = newId,
                SavedAt = DateTime.UtcNow,
                Description = value.Description ?? string.Empty,
                Location = value.Location ?? string.Empty
            };
            dataAccess.SaveData(deviceData);
            return deviceData;
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