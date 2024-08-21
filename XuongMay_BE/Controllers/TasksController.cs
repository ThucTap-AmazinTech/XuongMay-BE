using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Services.IService;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _TasksService;

        public TasksController(ITasksService TasksService)
        {
            _TasksService = TasksService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTaskss()
        {
            IList<Tasks> categories = await _TasksService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasksById(string id)
        {
            Tasks tasks = await _TasksService.GetById(id);
            if (tasks is null)
                return NotFound("Tasks not found!");
            return Ok(tasks);
        }


        [HttpPost]
        public async Task<IActionResult> AddTasks([FromBody] Tasks tasks)
        {
            await _TasksService.Add(tasks);
            return Ok(await _TasksService.GetAll());
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTasks(string id)
        {
            try
            {
                await _TasksService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Tasks not found!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTasks(Tasks tasks)
        {
            try
            {
                await _TasksService.Update(tasks);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Tasks not found!");
            }
        }
    }
}
