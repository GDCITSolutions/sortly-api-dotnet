namespace Sortly.Api.Model.Response
{
    /// <summary>
    /// Store header return values for rate limit headers
    /// </summary>
    public class RateLimit
    {
        /// <summary>
        /// Maximum number of requests allowed within the 15-minute window
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Number of requests remaining in the current 15-minute window
        /// </summary>
        public int Remaining { get; set; }

        /// <summary>
        /// The time at which the current rate limit window resets.(in seconds)
        /// </summary>
        public int Reset { get; set; }
    }
}
