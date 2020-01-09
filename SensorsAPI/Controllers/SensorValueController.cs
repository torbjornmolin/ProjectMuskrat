﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SensorsAPI.Models;
using SensorsDataPersistence;

namespace SensorsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorValueController : ControllerBase
    {
        static IDataAccess<SensorData> dataAccess = new DataAccess<SensorData>("/home/torbjorn/sensorData.json");
        // GET api/SensorValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(dataAccess.GetAllData());
        }

        // GET api/SensorValues/guid
        [HttpGet("{id}")]
        public ActionResult<SensorData> Get(Guid? id)
        {
            return dataAccess.GetData(id.Value);
        }
        // GET api/SensorValues/by/date
        [HttpGet("by/date/{id}")]
        public ActionResult<IEnumerable<SensorData>> Get(DateTime? id)
        {
            return Ok(dataAccess.GetAllData().Where(s => s.SavedAt.Date == id?.Date));
        }
        // POST api/values
        [HttpPost]
        public SensorData Post([FromBody] SensorDataPostModel value)
        {
            var sensorData = new SensorData()
            {
                Identifier = Guid.NewGuid(),
                SensorId = value.SensorId,
                SavedAt = DateTime.UtcNow,
                Value = value.Value,
                ValueType = value.ValueType,
            };
            dataAccess.SaveData(sensorData);
            return sensorData;
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