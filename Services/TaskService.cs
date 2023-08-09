using Microsoft.EntityFrameworkCore;
using TodoBackend.Data;
using Task = TodoBackend.Models.Task;

namespace TodoBackend.Services;

public interface ITaskService
{
    IEnumerable<Task> GetAll();
    Task GetById(int id);
    Task CreateTask(Task newTask);
    Task UpdateTask(int id, Task updateTask);
    IEnumerable<Task> DeleteTask(int id);
}

public class TaskService : ITaskService
{
    private readonly TaskContext _context;
    private readonly ILogger<Task> _logger;

    public TaskService(TaskContext context, ILogger<Task> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task CreateTask(Task newTask)
    {
        // TODO: validate
        newTask.CreatedTime = DateTime.Now;
        newTask.LastUpdatedTime = DateTime.Now;

        // assumed to be a valid object
        _context.Tasks.Add(newTask);
        _context.SaveChanges();

        return newTask;
    }

    public IEnumerable<Task> DeleteTask(int id)
    {
        var task = getTask(id);

        _context.Tasks.Remove(task);
        _context.SaveChanges();

        return GetAll();
    }

    public IEnumerable<Task> GetAll()
    {
        return _context.Tasks.Include(t => t.Tags);
    }

    public Task GetById(int id)
    {
        return getTask(id);
    }

    public Task UpdateTask(int id, Task updateTask)
    {
        var task = getTask(id);

        // TODO: validate
        // TODO: except Id, others are mutable(Name, Description, StartedTime, DueTime, tags, Stage, Progress, Priority, Assignee)
        task.Name = updateTask.Name;
        task.Description = updateTask.Description;
        task.StartedTime = updateTask.StartedTime;
        task.DueTime = updateTask.DueTime;
        task.LastUpdatedTime = DateTime.Now;
        task.Tags = updateTask.Tags;
        task.Stage = updateTask.Stage;
        task.Progress = updateTask.Progress;
        task.Priority = updateTask.Priority;
        task.Assignee = updateTask.Assignee;

        _context.Tasks.Update(task);
        _context.SaveChanges();

        return GetById(task.Id);
    }

    // helper methods
    private Task getTask(int id)
    {
        var task = _context.Tasks
        .Include(t => t.Tags)
        .Where(task => task.Id.Equals(id)).FirstOrDefault();
        if (task is null) throw new KeyNotFoundException("Task not found");

        return task;
    }
}