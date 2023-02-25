using DF_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DF_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DFController : ControllerBase
    {
        // GET: api/<DFController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "test1", "test" };
        }


        // POST api/<DFController>
        [HttpPost]
        public ActionResult Post([FromBody] RequestModel requestModel)
        {
         
            
            if ( !string.IsNullOrEmpty(requestModel.ToString()))
            {

                // set the path to mydocuments of windows

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "capturedResult");


                using (StreamWriter outputFile = new StreamWriter(path))
                {

                    outputFile.WriteLine(JsonSerializer.Serialize( requestModel.Metadata));
                    outputFile.WriteLine(JsonSerializer.Serialize("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~"));
                    outputFile.WriteLine(JsonSerializer.Serialize(requestModel.DFmodel));


                }
            }
            else
            {
                // Show error message
                return BadRequest("bad request");
            }

            return Ok();
        }

    }
}
