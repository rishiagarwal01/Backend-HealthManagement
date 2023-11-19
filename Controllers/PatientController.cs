using HealthManagementBackend.Models;
using HealthManagementBackend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IHealthStore healthService;

        public PatientController(IHealthStore healthService)
        {
            this.healthService=healthService;
        }
        // GET: api/<PatientController>
        [HttpGet]
        public ActionResult<List<Patient>> Get()
        {
            return healthService.Get();
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public ActionResult<Patient> Get(string id)
        {
            var patient = healthService.Get(id);

            if (patient == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            return patient;
        }

        // POST api/<PatientController>
        [HttpPost]
        public ActionResult<Patient> Post([FromBody] Patient patient)
        {
            healthService.Create(patient);

            return CreatedAtAction(nameof(Get), new { id = patient.PatientId }, patient);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{id}")]
        public ActionResult<Patient> Put(string id, [FromBody] Patient patient)
        {
            var existingPatient = healthService.Get(id);

            if (existingPatient == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            healthService.Update(id, patient);

            return NoContent();
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var patient = healthService.Get(id);

            if (patient == null)
            {
                return NotFound($"Patient with Id = {id} not found");
            }

            healthService.Remove(patient.PatientId);

            return Ok($"Patient with Id = {id} deleted");
        }
    }
}
