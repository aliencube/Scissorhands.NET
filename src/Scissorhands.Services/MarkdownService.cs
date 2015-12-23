﻿using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Aliencube.Scissorhands.Services
{
    /// <summary>
    /// This represents the service entity for markdown.
    /// </summary>
    public class MarkdownService : IMarkdownService
    {
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkdownService"/> class.
        /// </summary>
        public MarkdownService()
        {
        }

        /// <summary>
        /// Reads file and return the content as string.
        /// </summary>
        /// <param name="filepath">Fully qualified file path.</param>
        /// <returns>Returns the content as string.</returns>
        public async Task<string> ReadAsync(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath))
            {
                return null;
            }

            using (var stream = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                var contents = await reader.ReadToEndAsync();
                return contents;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}