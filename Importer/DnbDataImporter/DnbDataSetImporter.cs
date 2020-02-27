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
        private const string ResourceUrl = "https://statistiek.api.dnb.nl/api/dataset/resourcecsv?id=";

        private readonly HttpClient httpClient;
        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private bool disposed = false;

        public DnbDataSetImporter()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<string> LoadDataSet(string resourceId)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new ArgumentNullException(
                    nameof(resourceId),
                    $"{nameof(resourceId)} cannot be null.");
            }

            try
            {
                var response = await this.httpClient
                                   .GetAsync($"{ResourceUrl}{resourceId}")
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
            catch (HttpRequestException)
            {
                throw;
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