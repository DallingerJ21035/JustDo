namespace JustDoDb;

public class TodoTask
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string RawInput { get; set; } = null!;
    public DateTime? DueDate { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
}