using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WindGenerator.Managers;
using WindGenerator.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WindGenerator.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WindDatasController : ControllerBase {
        private readonly WindGeneratorsManagers _Manager = new WindGeneratorsManagers();

        private DBWindGeneratorsManager _DBManager = new DBWindGeneratorsManager();
        // GET: api/<WindDatasController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<WindDataGenerator>> Get([FromQuery] int? speed) {
            IEnumerable<WindDataGenerator> result = null;
            //result = _Manager.GetAll(speed);
            result = _DBManager.GetAll(speed);
            if (result != null){
                return Ok(result);
            }

            return NotFound();
        }

        // GET api/<WindDatasController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<WindDatasController>
        [HttpPost]
        public ActionResult<WindDataGenerator> Post([FromBody] WindDataGenerator newWindData){
            WindDataGenerator result = new WindDataGenerator();

            if (newWindData.Direction == "" || newWindData.Speed < 0){
                return BadRequest(newWindData);
            }

            //result = _Manager.AddWindData(newWindData);
            result = _DBManager.AddWindData(newWindData);

            return Created("api/WindDatas/" + newWindData.Id, newWindData);
        }

        // PUT api/<WindDatasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<WindDatasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
