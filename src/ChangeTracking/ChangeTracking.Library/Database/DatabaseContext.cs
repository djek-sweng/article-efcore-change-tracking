﻿namespace ChangeTracking.Library.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Note> Notes { get; set; } = null!;

    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("Notes");
            entity.HasKey(note => note.Id);
            entity.Property(note => note.Message).HasMaxLength(255);
        });

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var dateTime = DateTime.UtcNow;

        var entriesAdded = ChangeTracker.Entries()
            .Where(entry => entry.State == EntityState.Added)
            .ToList();

        entriesAdded.ForEach(entry =>
            entry.Property(nameof(ICurrentTimestamps.CreatedAt)).CurrentValue = dateTime);

        var entriesModified = ChangeTracker.Entries()
            .Where(entry => entry.State == EntityState.Modified)
            .ToList();

        entriesModified.ForEach(entry =>
            entry.Property(nameof(ICurrentTimestamps.UpdatedAt)).CurrentValue = dateTime);

        return base.SaveChangesAsync(cancellationToken);
    }
}
