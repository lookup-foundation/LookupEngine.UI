sealed partial class Build
{
    /// <summary>
    ///     Publish a new GitHub release.
    /// </summary>
    Target PublishGitHub => _ => _
        .DependsOn(Compile)
        .Requires(() => ReleaseVersion)
        .OnlyWhenStatic(() => IsServerBuild)
        .Executes(() =>
        {
            CreateChangelogBuilder();
        });
}