using Sortly.Api.Model.Request;
using System.IO.Abstractions;

namespace Sortly.Api.Model.Abstractions
{
    /// <summary>
    /// Contract describing special requests that contain photos to upload
    /// </summary>
    public interface IPhotoRequest
    {
        /// <summary>
        /// If there is at least one photo that is a path, the request needs to be transformed into
        /// a multipart form.
        /// 
        /// If not, a normal JSON payload is returned.
        /// </summary>
        /// <param name="_fileSystem"></param>
        /// <returns></returns>
        public HttpContent AsHttpPayload(IFileSystem _fileSystem);
    }
}
