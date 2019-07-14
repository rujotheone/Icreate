using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ICreate2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICreate2.Controllers
{
    [Route("api/[controller]")]
    public class MetricController : Controller
    {
        private readonly ICreateContext _md;

        public MetricController(ICreateContext context)
        {
            _md = context;

            if (_md.Metric.Count() == 0)
            {
                _md.Metric.Add(new Metric { Id = 1, Name = "Cost" , Weight=4 });
                _md.Metric.Add(new Metric { Id = 2, Name = "Personnel" , Weight = 5});
                _md.SaveChanges();
            }
        }

        [HttpPost("/metric/", Name = "CreateMetric")]
        public IActionResult CreateMetric([FromBody]Metric metric)
        {
            if (metric == null)
            {
                return BadRequest();
            }
            _md.Metric.Add(metric);
            _md.SaveChanges();
            return CreatedAtRoute("GetMetric", new { id = metric.Id }, metric);
        }

        [HttpGet("/metric/{id}", Name = "GetMetric")]
        public IActionResult GetMetric(int id)
        {
            var metric = _md.Metric.FirstOrDefault(t => t.Id == id);
            if (metric == null)
            {
                return NotFound();
            }
            return new ObjectResult( metric);
        }

        [HttpDelete("/deletemetric/{id}", Name = "DeleteMetric")]
        public IActionResult DeleteMetric(int id)
        {
            var metric = _md.Metric.FirstOrDefault(t => t.Id == id);
            if (metric == null)
            {
                return NotFound();
            }

            _md.Metric.Remove(metric);
            _md.SaveChanges();
            return new NoContentResult();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "valuex", "valuey" };
        }

    }
}
