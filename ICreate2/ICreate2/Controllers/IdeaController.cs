using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ICreate2.Models;
using ICreate2.Controllers;
using Newtonsoft.Json;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ICreate2.Controllers
{
    [Route("api/[controller]")]
    public class IdeaController : Controller
    {
        private readonly ICreateContext _md;

        public IdeaController(ICreateContext context)
        {
            _md = context;

            if (_md.IdeaMaster.Count() == 0)
            {
                _md.IdeaMaster.Add(new IdeaMaster { Id = 1, Name = "Test" ,MetricScore= "4/5/" });
                _md.BatchHistory.Add(new BatchHistory { Id = 1, BatchNumber= 1 });            
                _md.SaveChanges();
            }
        }        

        [HttpPost("/idea/", Name = "CreateIdea")]
        public IActionResult CreateIdea([FromBody]IdeaMaster idea)
        {
            
            if (idea==null)
            {
                return BadRequest();
            }
            _md.IdeaMaster.Add(new IdeaMaster() {
                Id = idea.Id,
                Name = idea.Name,
                Owner = idea.Owner,
                Title = idea.Title,
                Description = idea.Description,
                IdeaTypeId = 0,
                RenewedBy = "",
                DelFlg = "N",
                DelBy = "",
                Notification = idea.Notification,
                Responsible = "icreate",
                ITUnit = "CBA",
                SubmittedBy = idea.SubmittedBy,
                Attached = idea.Attached,
                OwnerPhoneNumber = idea.OwnerPhoneNumber,
                IdeaStatus = IdeaStatusList.submitted,
                ForwardDate = idea.ForwardDate,
                CCAddress = idea.CCAddress,
                CommentReview = "",
                Country = "NG",
                State = "LAG",
                BatchNumber = _md.BatchHistory.OrderByDescending(t => t.BatchNumber).Select(i => i.BatchNumber).FirstOrDefault(),
                MetricScore = "4/4/",
                TotalScore = 0
            });
            _md.SaveChanges();
            return CreatedAtRoute("GetIdea", new { id = idea.Id }, idea);
        }

        [HttpGet("/batch/{id}", Name = "GetBatch")]
        public IActionResult GetBatch(int id)
        {
            var b = _md.BatchHistory.
                OrderByDescending(t => t.BatchNumber).
                Select(i => i.BatchNumber).FirstOrDefault();
            if (b == 0)
            {
                return NotFound();
            }
           return new ObjectResult(b);

        }

        [HttpGet("/idea/{id}", Name = "GetIdea")]        
        public IActionResult GetIdea(int id)
        {
            var idea = _md.IdeaMaster.FirstOrDefault(t => t.Id == id);           
            
            if (idea == null)
            {
                return NotFound();
            }
            return new ObjectResult( new
            {
                idea.Name, idea.Owner,idea.Title, idea.Description,idea.Responsible, idea.Attached, idea.OwnerPhoneNumber,
                idea.IdeaStatus,idea.CommentReview,idea.Country,idea.State,idea.DateSubmitted,idea.TotalScore
            }
            );
            
        }     

            /*[HttpGet("/test/{id}", Name = "testm")]
            public double Test(int id)
            {
                //return RankIdea(id);
            }*/

            public bool RankIdea(int id)
        {
            MetricController tempmd = new MetricController(_md);

            var currentbatch = _md.BatchHistory.OrderByDescending(t => t.BatchNumber).Select(i=>i.BatchNumber)
                .FirstOrDefault();
            var score = _md.IdeaMaster.Where(i=>i.Id==id).Select(t => t.MetricScore).FirstOrDefault();
            var scoreArray = score.Split('/');
            double total = 0;
            double totalweight = 0;

            for (int i=0; i<(scoreArray.Length)-1;i++)
            {
                var weight = _md.Metric.Where(m => m.Id == (i+1)).Select(t => t.Weight).FirstOrDefault();
                totalweight += weight;
                total += weight * int.Parse(scoreArray[i]);
            }

             

            var im = _md.IdeaMaster.Where(i => i.Id == id).FirstOrDefault();

            if (im != null)
            {
                im.TotalScore =  total / totalweight;
                im.BatchNumber = currentbatch;
                im.IdeaStatus = IdeaStatusList.underreview;
                _md.SaveChanges();
            }            
             else
                return false;

            return true;
        }

        [HttpGet("/idea/pendingforreview", Name = "GetPendingIdea")]
        public IActionResult GetPendingIdea()
        {
            var idea = _md.IdeaMaster.Where(t => t.IdeaStatus == IdeaStatusList.submitted);

            if (idea == null)
            {
                return NotFound();
            }
            return new ObjectResult(idea.Select(t => 
            new{
                t.Name, t.Owner,t.Title, t.Description,t.Responsible, t.Attached, t.OwnerPhoneNumber,
                t.IdeaStatus,t.CommentReview,t.Country,t.State,t.DateSubmitted,t.TotalScore}
            ));
        }

        [HttpGet("/idea/pendingforproject", Name = "PendingIdea")]
        public IActionResult ShowPendingIdea()
        {
            var result = _md.IdeaMaster.Where(i=>i.IdeaStatus== 0);
            if (result == null )
            {
                return NotFound();
            }
            return new ObjectResult(result);
        }

        [HttpGet("/reviewidea/{id}", Name = "ReviewIdea")]
        public IActionResult ReviewIdea(int id)
        {
            var idea = _md.IdeaMaster.FirstOrDefault(t => t.Id == id);
            var metrics = _md.Metric
                         .Select(m=>m.Name)
                ;
            if (idea == null && metrics==null)
            {
                return NotFound();
            }            
            return new ObjectResult(new {idea,metrics});
        }

        [HttpPost("/reviewidea/{id}", Name = "ScoreIdea")]
        public IActionResult ReviewIdea([FromBody]IdeaMetric ideametrics)
        {
            if (ideametrics == null )
            {
                return BadRequest();
            }

            string metricsresult = "";                  

             foreach (var f in ideametrics.Metric)
             {
                 metricsresult += f.Weight.ToString() + "/";
             }     

             //get each idea as an enumerable, then assign the metricresult(string) to each metricscore 
             //field for the entity IdeaMaster
              _md.IdeaMaster.Where(i => i.Id == ideametrics.Idea).
                 ToList().ForEach(x=>x.MetricScore=metricsresult);              
              _md.SaveChanges();               
                
                RankIdea(ideametrics.Idea);
                
            return CreatedAtRoute("GetIdea", new { id = ideametrics.Idea });
           

        }

        

    }
}
