using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TestWebService.Services.Interface;
using TestWebService.Models;

namespace TestWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]     //url api/college
    [Produces("application/json")]
    public class CollegeController : ControllerBase
    {
        private ICollegeService _collegeService;

        public CollegeController(ICollegeService collegeService)
        {
            //collegeService is the instance of the CollegeService added in Startup.cs
            _collegeService = collegeService;
        }

        [HttpGet("GetList")]        //define the API/route  ->  api/college/getlist
        public IEnumerable<College> GetColleges()
        {
            return _collegeService.GetColleges().ToList();
        }

        [HttpGet("GetList/Inactive")]        //define the API/route  ->  api/college/getlist/inactive
        public IEnumerable<College> GetInactiveColleges()
        {
            return _collegeService.GetInactiveColleges().ToList();
        }

        [HttpGet("Get/{id}")]       //define the API/route  ->  api/college/get/2
        public IActionResult GetCollege(int id)
        {           
            College toCheck = _collegeService.GetCollege(id);
            if (toCheck != null)
                return new OkObjectResult(toCheck);     //returns an HTTP status of 200 with the corresponding record
            else
                return new NotFoundObjectResult(new { result = "College record not found." });    //returns an HTTP status of 404 with the corresponding message
        }

        [HttpPost("Add")]          //define the API/route   ->  api/college/add
        public IActionResult AddCollege([FromBody] College college)     //college record should be submitted via the UI
        {
            //validate record to add
            if (college.CollegeCode == null || college.CollegeCode == "")
                return new BadRequestObjectResult(new { result = "College code required." });       //returns an HTTP status of 400 with the corresponding message
            else if (college.CollegeName == null || college.CollegeName == "")
                return new BadRequestObjectResult(new { result = "College name required." });       
            else
            {
                if (_collegeService.IsCollegeExist(college))
                    return new BadRequestObjectResult(new { result = "College record already existing." });
                else
                {
                    int status = _collegeService.AddCollege(college);
                    string message = (status == 1) ? "success" : "failed";
                    return new OkObjectResult(new { result = message });        //returns an HTTP status of 200 with the corresponding message
                }
            }
        }

        [HttpPut("Edit")]       //define the API/route      ->  api/college/edit
        public IActionResult UpdateCollege([FromBody]College college)   //college record should be submitted via the UI
        {
            //validate record to update
            if (college.CollegeCode == null || college.CollegeCode == "")
                return new BadRequestObjectResult(new { result = "College code required." });       //returns an HTTP status of 400 with the corresponding message
            else if (college.CollegeName == null || college.CollegeName == "")
                return new BadRequestObjectResult(new { result = "College name required." });
            else
            {
                College origCollege = _collegeService.GetCollege(college.CollegeID);
                if (origCollege == null)
                    return new NotFoundObjectResult(new { result = "College record not found." });  //returns an HTTP status of 404 with the corresponding message
                else if (_collegeService.IsCollegeExist(college))
                {
                    //get existing college record by college name
                    College existCollege = _collegeService.GetCollege(college.CollegeName);
                    if(existCollege.CollegeID != college.CollegeID)          //check if college record exists other than the record to update
                        return new BadRequestObjectResult(new { result = "College record already existing." });
                }
                
                //proceed with the update if college record is valid
                int status = _collegeService.UpdateCollege(college);
                string message = (status == 1) ? "success" : "failed";
                return new OkObjectResult(new { result = message });        //returns an HTTP status of 200 with the corresponding message
            }
        }

        [HttpDelete("Delete/{id}")]  //define the API/route      ->  api/college/delete/7
        public IActionResult DeleteCollege(int id)
        {
            College toCheck = _collegeService.GetCollege(id);
            if (toCheck != null)
            {
                int status = _collegeService.DeleteCollege(id);
                string message = (status == 1) ? "success" : "failed";
                return new OkObjectResult(new { result = message });        //returns an HTTP status of 200 with the corresponding message
            }
            else
                return new NotFoundObjectResult(new { result = "College record not found." });    //returns an HTTP status of 404 with the corresponding message
        }

        [HttpPut("Deactivate/{id}")]  //define the API/route      ->  api/college/deactivate/7
        public IActionResult DeactivateCollege(int id)
        {
            College toCheck = _collegeService.GetCollege(id);
            if (toCheck != null)
            {
                int status = _collegeService.DeactivateCollege(id);
                string message = (status == 1) ? "success" : "failed";
                return new OkObjectResult(new { result = message });        //returns an HTTP status of 200 with the corresponding message
            }
            else
                return new NotFoundObjectResult(new { result = "College record not found." });    //returns an HTTP status of 404 with the corresponding message
        }

        [HttpPut("Activate/{id}")]  //define the API/route      ->  api/college/activate/7
        public IActionResult ActivateCollege(int id)
        {
            College toCheck = _collegeService.GetCollege(id);
            if (toCheck != null)
            {
                int status = _collegeService.ActivateCollege(id);
                string message = (status == 1) ? "success" : "failed";
                return new OkObjectResult(new { result = message });        //returns an HTTP status of 200 with the corresponding message
            }
            else
                return new NotFoundObjectResult(new { result = "College record not found." });    //returns an HTTP status of 404 with the corresponding message
        }
    }
}