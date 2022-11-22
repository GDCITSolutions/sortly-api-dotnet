using Sortly.Api.Common.Enums;

namespace Sortly.Api.Model.Request
{
    /// <summary>
    /// Some endpoints have a "photos" property that can contain a path, web url, or a blob.
    /// 
    /// All of these types can resolve to a string so the type will dictate how Content should be interpreted.
    /// </summary>
    public class PhotoRequest
    {
        public PhotoRequestType PhotoRequestType { get; set; }

        public string Content { get; set; }
    }
}
