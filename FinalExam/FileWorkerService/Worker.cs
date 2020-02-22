using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using FileWorkerService.Repository;
using FileWorkerService.Service;
using FileWorkerService.UnitWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FileWorkerService
{


    public class Worker : BackgroundService
    {
        private static IServiceProvider _serviceProvider;
        private readonly ILogger<Worker> _logger;
        private HttpClient _client;

        private IFileService fileService;

        public IConfiguration Configuration { get; }
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<UnitOfWork>(x => new UnitOfWork());

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFileService, FileService>();
            services
            .AddScoped<IFileRepository, FileRepository>();

            _serviceProvider = services.BuildServiceProvider();

            fileService = _serviceProvider.GetRequiredService<IFileService>();

        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
              ConfigureServices();
            _client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _client.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var fileName = fileService.GetFIleName();
                _logger.LogInformation("Server is up. Working with file Name = " + fileName);

                var s3Client = new AmazonS3Client();
                var s3Request = new GetObjectRequest
                {
                    BucketName = "atmahad",
                    Key = fileName
                };
                var filepath = $"download/{fileName}";
                var response = await s3Client.GetObjectAsync(s3Request);
                var token = new CancellationToken();
                await response.WriteResponseStreamToFileAsync(filepath, false, token);
                
               
                await Task.Delay(6000, stoppingToken);
            }
        }       
    }
}
