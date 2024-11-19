namespace Serviceberry;

/// <summary>
/// Represents a queue for job processing.
/// </summary>
public interface IJobQueue
{
    /// <summary>
    /// Enqueues a job for processing as soon as possible.
    /// </summary>
    /// <param name="args">The arguments for the job.</param>
    /// <param name="priority">
    /// Determines the priority of the job within this queue.
    /// Jobs with higher priority values are processed before jobs with lower priority values.
    /// Jobs with the same priority are processed in the order they were enqueued.
    /// When null, the default priority for the queue is used.
    /// </param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <typeparam name="TArgs">
    /// Type of the arguments.
    /// <para>
    /// Job arguments only need to meet 3 criteria:
    /// <list type="bullet">
    ///   <item>
    ///     <description>Be a reference type.</description>
    ///   </item>
    ///   <item>
    ///     <description>Implement the <see cref="IJobArgs"/> marker interface.</description>
    ///   </item>
    ///   <item>
    ///     <description>
    ///       Be serializable by <see cref="System.Text.Json.JsonSerializer"/>.
    ///     </description>
    ///   </item>
    /// </list>
    /// </para>
    /// </typeparam>
    /// <returns>A task representing a unique identifier for the created job.</returns>
    Task<Guid> EnqueueAsync<TArgs>( TArgs args, double? priority = null, CancellationToken cancellationToken = default ) where TArgs : class;
}
