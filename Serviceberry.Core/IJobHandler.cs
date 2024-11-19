using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Serviceberry;

/// <summary>
/// Defines a handler for a job.
/// <para>
/// Job handlers must be registered as a <see cref="IJobHandler{TArgs}"/> service type with a lifetime of
/// <see cref="ServiceLifetime.Scoped"/>.
/// </para>
/// </summary>
/// <typeparam name="TArgs">Arguments for the job.</typeparam>
[SuppressMessage("ReSharper", "TypeParameterCanBeVariant")]
public interface IJobHandler<TArgs> where TArgs : class, IJobArgs
{
    /// <summary>
    /// Handles execution of a job.
    /// </summary>
    /// <param name="args">Arguments for the job.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task that can be awaited for completion of the job.</returns>
    Task HandleAsync( TArgs args, CancellationToken cancellationToken );
}
