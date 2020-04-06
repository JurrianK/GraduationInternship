using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

using ImprovedDnbDataImporter.Interfaces;

using Microsoft.Win32.SafeHandles;

namespace ImprovedDnbDataImporter.Implementations
{
    public class DnbDataImporter : IDnbDataImporter, IDisposable
    {
        private const string DnbStatisticsApiBaseUrl = "https://statistiek.api.dnb.nl/api/dataset/resourcecsv?id=";

        private readonly HttpClient httpClient;

        private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private bool isDisposed;

        public DnbDataImporter()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<string> Import(string csvResourceId)
        {
            var asyncResult = await this.httpClient
                .GetAsync(DnbStatisticsApiBaseUrl + csvResourceId)
                .ConfigureAwait(false);

            asyncResult.EnsureSuccessStatusCode();

            return await asyncResult.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (this.isDisposed)
            {
                return;
            }
            
            if (disposing)
            {
                this.httpClient?.Dispose();
                this.handle?.Dispose();
            }

            this.isDisposed = true;
        }
    }
}