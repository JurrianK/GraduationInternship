using System;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using DnbDataImporter.Interfaces;

using Microsoft.Win32.SafeHandles;

namespace DnbDataImporter
{
    public sealed class DnbDataSetImporter : IDisposable, IDnbDataSetImporter
    {
        private readonly string resourceBaseUrl;
        private readonly HttpClient httpClient;
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private bool disposed = false;

        public DnbDataSetImporter(string resourceBaseUrl)
        {
            this.resourceBaseUrl = resourceBaseUrl;
            this.httpClient = new HttpClient();
        }

        public DnbDataSetImporter(string resourceBaseUrl, HttpClient httpClient)
        {
            this.resourceBaseUrl = resourceBaseUrl;
            this.httpClient = httpClient;
        }

        ~DnbDataSetImporter()
        {
            Dispose();
        }

        public async Task<string> LoadDataSet(string resourceId)
        {
            if (string.IsNullOrEmpty(this.resourceBaseUrl))
            {
                throw new ArgumentException("Constructor was called with a null/empty resource url.");
            }

            if (string.IsNullOrEmpty(resourceId))
            {
                throw new ArgumentNullException(
                    nameof(resourceId),
                    $"{nameof(resourceId)} cannot be null.");
            }

            var response = await this.httpClient
                               .GetAsync($"{this.resourceBaseUrl}{resourceId}")
                               .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var contentStream = await response.Content
                                    .ReadAsStreamAsync()
                                    .ConfigureAwait(false);

            using (var streamReader = new StreamReader(contentStream))
            {
                return await streamReader.ReadToEndAsync().ConfigureAwait(false);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                this.handle.Dispose();
                this.httpClient?.Dispose();
            }

            this.disposed = true;
        }
    }
}