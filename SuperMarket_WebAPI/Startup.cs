using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SuperMarket.Client;
using SuperMarket.Logging;
using SuperMarket.Repository;
using SuperMarket.Service;
using Supermarket_WebAPI.Service;
using Microsoft.Azure.ServiceBus;
using Azure.Storage.Blobs;

namespace SuperMarket_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<PaymentGatewayClient>();

            services.AddSingleton<IStockRepository, StockRepository>();
            services.AddSingleton<IStockService, StockService>();
            services.AddHttpClient<IPaymentGatewayClient, PaymentGatewayClient>();
            services.AddSingleton<IDiscountRepository, DiscountRepository>();
            services.AddSingleton<IDiscountService, DiscountService>();

            services.AddSingleton<ILogger, Logger>();


            //services.AddSingleton<ITopicClient>(serviceProvider => new TopicClient(connectionString: Configuration.GetValue<string>("servicebus:connectionstring"), entityPath: Configuration.GetValue<string>("serviceBus:topicname")));
            //services.AddSingleton<IMessagePublisher, MessagePublisher>();

            //services.AddScoped<IFileManager, FileManager>();

            //services.AddScoped(_ =>
            //{
            //    return new BlobServiceClient(Configuration.GetSection("servicebus").GetSection("AzureBlobStorage").Value);
            //});

            services.AddControllers();


            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
