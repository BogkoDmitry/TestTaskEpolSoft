using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestTaskApi.Entities;
using TestTaskApi.Infrastructure.db;

namespace TestTastApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {

        private readonly ILogger<PatientController> _logger;
        private readonly TestTaskContext _context;

        public PatientController(ILogger<PatientController> logger, TestTaskContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        [HttpGet("GetAll")]
        public async Task<ActionResult<Patient>> GetAll()
        {
            var patients = _context.Patients.AsNoTracking().ToList();

            return Ok(patients);
        }

        /// <summary>
        /// Get specific patient by Id
        /// </summary>
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Patient>> GetById([FromRoute] Guid id)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        /// <summary>
        /// Get specific patient by birthdate condition
        /// </summary>
        [HttpGet("SearchByBirthData/{searchCondition}")]
        public async Task<ActionResult<List<Patient>>> SearhByBirthDate([FromRoute] string searchCondition)
        {
            var conditions = searchCondition.Split("&");

            IQueryable<Patient> query = _context.Patients;

            foreach (var condition in conditions)
            {
                var equlityOperator = condition.Substring(0, 2);

                var isParsed = DateTime.TryParse(condition.Substring(2), out var date);

                if (!isParsed)
                {
                    return BadRequest();
                }

                Expression<Func<Patient, bool>> func = equlityOperator switch
                {
                    "eq" => x => x.BirthDate == date,
                    "ne" => x => x.BirthDate != date,
                    "lt" => x => x.BirthDate < date,
                    "gt" => x => x.BirthDate > date,
                    "le" => x => x.BirthDate <= date,
                    "ge" => x => x.BirthDate >= date,
                    _ => throw new ArgumentOutOfRangeException(),
                };

                query = query.Where(func);
            }

            var patients = query.ToList();

            return Ok(patients);
        }

        /// <summary>
        /// Add new patient
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Patient>> Add([FromBody] Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return Ok(patient);            
        }

        /// <summary>
        /// Edit specific patient
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Patient updatedPatient)
        {
            var patient = _context.Patients.FirstOrDefault(patient => patient.Id == updatedPatient.Id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.BirthDate = updatedPatient.BirthDate;
            patient.Active = updatedPatient.Active;
            patient.Gender = updatedPatient.Gender;
            patient.Name.Use = updatedPatient.Name?.Use;
            patient.Name.Family = updatedPatient.Name?.Family;
            patient.Name.Given = updatedPatient.Name?.Given;

            _context.Update(patient);
            await _context.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Removes specific patient by Id
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var patient = _context.Patients.FirstOrDefault(patient => patient.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
