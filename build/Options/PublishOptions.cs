using System.ComponentModel.DataAnnotations;

namespace Build.Options;

[Serializable]
public sealed record PublishOptions
{
    public string? Version { get; init; }
    [Required] public string ChangelogFile { get; init; } = null!;
}