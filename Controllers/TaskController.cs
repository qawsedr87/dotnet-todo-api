using Microsoft.AspNetCore.Mvc;
using TodoBackend.Services;
using Task = TodoBackend.Models.Task;

namespace TodoBackend.Controller;

[ApiController]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public class TaskController : ControllerBase
{
    private ITaskService _service;

    public TaskController(ITaskService service)
    {
        _service = service;
    }

    /// <summary>
    /// Returns a group of Tasks.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <returns>A group of specific Task</returns>
    [HttpGet]
    public IActionResult GetAll()
    {
        var tasks = _service.GetAll();
        return Ok(tasks);
    }

    /// <summary>
    /// Returns a specific of Task matching the given Id.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="id">The first name to search for</param>
    /// <returns>A specific Task</returns>
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var task = _service.GetById(id);
        return Ok(task);
    }

    /// <summary>
    /// Creates a Task.
    /// </summary>
    /// <param name="newTask"></param>
    /// <returns>A newly created Task</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /task
    ///     {
    ///        "name": "string",
    ///        "description": "string",
    ///        "createdTime": "2022-12-10T16:08:02.927Z",
    ///        "lastUpdatedTime": "2022-12-10T16:08:02.927Z",
    ///        "startedTime": "2022-12-10T16:08:02.927Z",
    ///        "dueTime": "2022-12-10T16:08:02.927Z",
    ///        "tags": [
    ///            {
    ///            "name": "string",
    ///            "description": "string"
    ///            }
    ///        ],
    ///        "stage": "Done",
    ///        "progress": 0,
    ///        "priority": "High",
    ///        "creator": "string",
    ///        "assignee": "string"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateTask(Task newTask)
    {
        var tasks = _service.CreateTask(newTask);
        return CreatedAtAction(nameof(CreateTask), new { id = tasks.Id }, tasks);
    }

    /// <summary>
    /// Update a specific of Task matching the given Id.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <param name="id">The Id to search for</param>
    /// <param name="updateTask">The newly updated Task</param>
    /// <returns>A newly updated Task</returns>
    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, Task updateTask)
    {
        var task = _service.UpdateTask(id, updateTask);
        return Ok(task);
    }

    /// <summary>
    /// Deletes a specific Task.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var tasks = _service.DeleteTask(id);
        return Ok(tasks);
    }
}