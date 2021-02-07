using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleSkillsShowcase.Core.Interfaces;
using SimpleSkillsShowcase.Core.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimpleSkillsShowcase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly ILogger<NoteController> _logger;
        private readonly INoteService _noteService;

        public NoteController(ILogger<NoteController> logger, INoteService noteService)
        {
            _logger = logger;
            _noteService = noteService;
        }

        /// <summary>
        /// Get Note by Id
        /// </summary>
        /// <param name="id">Note Id</param>
        /// <returns>Note View Model</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _noteService.GetAsync(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _noteService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(NoteRequestModel note)
        {
            if (note != null)
            {
                try
                {
                    var result = _noteService.Add(note);
                    return Ok(result);
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"Error on Note Add: Input{note}, Error{e}");
                    return BadRequest(e);
                }
            }
            else
            {
                // with errors
                return BadRequest();
            }
        }

        //[HttpPost]
        //public IActionResult AddWithFeatures(NoteRequestModel note)
        //{
        //    // eventually add validation factory of some sort and/or service factory
        //    //var errors = _noteValidator.Add(note);
        //    if (note != null)
        //    {
        //        try
        //        {
        //            var result = _noteService.Add(note);
        //            return Ok(result);
        //        }

        //        catch (Exception e)
        //        {
        //            _logger.LogInformation($"Error on Note Add: Input{note}, Error{e}");
        //            return BadRequest(e);
        //        }
        //    }
        //    else
        //    {
        //        // with errors
        //        return BadRequest();
        //    }
        //}

        [HttpPut]
        public IActionResult Update(NoteRequestModel note)
        {
            var result = _noteService.Update(note);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _noteService.Delete(id);

            return Ok(result);
        }
    }
}