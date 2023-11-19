using HealthManagementBackend.Models;
using HealthManagementBackend.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthManagementBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorStore doctorService;

        // GET: api/<DoctorController>
        public DoctorController(IDoctorStore doctorService)
        {
            this.doctorService = doctorService;
        }
        [HttpGet]
        public ActionResult<List<Doctor>> Get()
        {
            return doctorService.Get();
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public ActionResult<Doctor> Get(string id)
        {
            var doctor = doctorService.Get(id);

            if (doctor == null)
            {
                return NotFound($"Doctor with Id = {id} not found");
            }

            return doctor;
        }

        // POST api/<DoctorController>
        [HttpPost]
        public ActionResult<Patient> Post([FromBody] Doctor doctor)
        {
            doctorService.Create(doctor);

            return CreatedAtAction(nameof(Get), new { id = doctor.DoctorId }, doctor);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public ActionResult<Patient> Put(string id, [FromBody] Doctor doctor)
        {
            var existingDoctor = doctorService.Get(id);

            if (existingDoctor == null)
            {
                return NotFound($"Doctor with Id = {id} not found");
            }

            doctorService.Update(id, doctor);

            return NoContent();
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var doctor = doctorService.Get(id);

            if (doctor == null)
            {
                return NotFound($"Doctor with Id = {id} not found");
            }

            doctorService.Remove(doctor.DoctorId);

            return Ok($"Doctor with Id = {id} deleted");
        }
    }
}
