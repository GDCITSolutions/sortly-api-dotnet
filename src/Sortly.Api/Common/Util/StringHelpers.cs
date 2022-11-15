namespace Sortly.Api.Common.Util
{
    public class StringHelpers
    {
        public static string FormatQueryParameterAddition(string currentParameters, string parameter)
        {
           return currentParameters[currentParameters.Length - 1] != '?'
                ? $"&{parameter}"
                : parameter;
        }
    }
}
