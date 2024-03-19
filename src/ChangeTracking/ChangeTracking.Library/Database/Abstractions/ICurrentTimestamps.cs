namespace ChangeTracking.Library.Database.Abstractions;

public interface ICurrentTimestamps
{
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
}
