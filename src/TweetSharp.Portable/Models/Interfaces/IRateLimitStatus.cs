using System;

namespace TweetSharp
{
    public interface IRateLimitStatus
    {
        /// <summary>
        /// Gets the current number of resource uses available
        /// </summary>
        int RemainingUses { get; }
        /// <summary>
        /// Gets the next time the <see cref="RemainingUses"/> is due to be refreshed
        /// </summary>
        DateTime NextReset { get; }
    }
}