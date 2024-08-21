using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XuongMay_BE.Contract.Repositories.Entities;
using XuongMay_BE.Contract.Services.IService;
using XuongMay_BE.Core.App;
using XuongMay_BE.Core.Query;

namespace XuongMay_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = AppRole.LineManager + "," + AppRole.Administrator)]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _TasksService;

        public TasksController(ITasksService TasksService)
        {
            _TasksService = TasksService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTaskss([FromQuery] QueryObject query)
        {
            IList<Tasks> tasks = await _TasksService.GetAll();
            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return Ok(tasks.Skip(skipNumber).Take(query.PageSize));
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
