namespace Sortly.Api.Common.Exceptions
{
    public class SortlyValidationException : Exception
    {
        public SortlyValidationException(string message) : base (message) { }
    }
}
