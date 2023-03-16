using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs;

namespace webjobapp_test_latest
{
    public class Functions
    {
        public static void ProcessBlob([BlobTrigger("textos/{name}.{txt}", Connection = "AzureWebJobsStorage")] BlobBaseClient blobClient, string name, ILogger log)
        {
            log.LogInformation($"Processing blob {name}");

            var blobContents = blobClient.Download();
            // Do something with the blob contents

            blobClient.Delete();
            log.LogInformation($"Deleted blob {name}");
        }
    }
}
