namespace StageTracker.Shared.ModelsEF;

public class Remark
{
    public int? Id { get; set; }
    public required string Message { get; set; } = string.Empty;

    //Used in WPF applications to display the original
    //To implement in RemarkDto in WPF applications
    //[NotMapped]
    //public string OriginalMessage { get; set; } = string.Empty;

    public int StudentId { get; set; }
    public required Student Student { get; set; }

    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    //Same than OriginalMessage
    //[NotMapped]
    //public bool IsEditing { get; set; } = false;
}
