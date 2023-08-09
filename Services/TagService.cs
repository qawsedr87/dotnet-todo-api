using TodoBackend.Data;
using TodoBackend.Models;

namespace TodoBackend.Services;

public interface ITagService
{
    void CreateTag(Tag newTag);
    void DeleteTag(int id);
    Tag GetById(int id);

}

public class TagService : ITagService
{
    private readonly TaskContext _context;

    public TagService(TaskContext context)
    {
        _context = context;
    }

    public void CreateTag(Tag newTag)
    {
        // TODO: validate
        newTag.CreatedTime = DateTime.Now;
        newTag.LastUpdatedTime = DateTime.Now;

        var tag = _context.Tags.Add(newTag);
        _context.SaveChanges();
    }

    public void DeleteTag(int id)
    {
        var tag = _context.Tags.Find(id);
        if (tag is null) throw new KeyNotFoundException("Tag Not Found");

        _context.Tags.Remove(tag);
        _context.SaveChanges();
    }

    public Tag GetById(int id)
    {
        var tag = _context.Tags.Find(id);
        if (tag is null) throw new KeyNotFoundException("Tag Not Found");

        return tag;

    }
}