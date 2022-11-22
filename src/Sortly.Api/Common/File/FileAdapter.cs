namespace Sortly.Api.Common.File
{
    public interface IFileAdapter
    {
        /// <summary>
        /// <see cref="System.IO.File.Exists"/>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        bool Exists(string path);

        /// <summary>
        /// <see cref="System.IO.File.ReadAllBytes(string)"/>
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        byte[] ReadAllBytes(string path);
    }

    public class FileAdapter : IFileAdapter
    {
        public bool Exists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public byte[] ReadAllBytes(string path) 
        {
            return System.IO.File.ReadAllBytes(path);
        }
    }
}
