using Sortly.Api.Model.Abstractions;
using System.IO.Abstractions;

namespace Sortly.Api.Http
{
    public interface IPayloadResolver 
    {
        /// <summary>
        /// Resolve to either a multipart form payload or a json payload
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        HttpContent ResolveMultiPart(IPhotoRequest request);
    }

    public class PayloadResolver : IPayloadResolver
    {
        private readonly IFileSystem _fileSystem;

        public PayloadResolver(IFileSystem fileSystem) 
        {
            _fileSystem = fileSystem;
        }

        public HttpContent ResolveMultiPart(IPhotoRequest request) 
        {
            return request.AsHttpPayload(_fileSystem);
        }
    }
}
