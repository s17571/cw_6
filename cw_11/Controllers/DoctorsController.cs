using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cw_11.Models;

namespace cw_11.Controllers
{
    [Route("Doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        HospitalContext context;

        public DoctorController(HospitalContext hospitalContext)
        {
            this.context = hospitalContext;
        }


        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            Doctor doctor = context.Find<Doctor>(id);
            if (doctor == null)
                return this.NotFound("No such doctor");
            else return this.Ok(doctor);
        }


        [HttpPost]
        public IActionResult PostDoctor(Doctor doctor)
        {
            try
            {
                context.Add<Doctor>(doctor);
                context.SaveChanges();
                return CreatedAtAction("getDoctor", new { 
                    id = doctor.IdDoctor 
                }, doctor);
            }
            catch (DbUpdateException)
            {
                return this.BadRequest("Bad Request");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            Doctor doctor = context.Doctors.Find(id);
            if (doctor != null)
            {
                context.Remove<Doctor>(doctor);
                context.SaveChanges();
                return Ok($"Doctor removed");
            }
            return NotFound("No such doctor");

        }


        [HttpPut("{id}")]
        public IActionResult PutDoctor(int id, Doctor doctor)
        {
            if (context.Doctors.Any(entity => entity.IdDoctor == id))
            {
                doctor.IdDoctor = id;
                context.Update<Doctor>(doctor);
                context.SaveChanges();
                return CreatedAtAction("GetDoctor", new { id = doctor.IdDoctor }, doctor);
            }
            else return NotFound("No such doctor");
        }

    }
}