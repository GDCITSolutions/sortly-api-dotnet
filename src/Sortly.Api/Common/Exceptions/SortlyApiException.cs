namespace Sortly.Api.Common.Exceptions
{
    public class SortlyApiException : Exception
    {
        public SortlyApiException(string message) : base (message) { }
    }
}
