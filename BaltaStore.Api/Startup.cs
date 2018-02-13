using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Infra.StoreContext.DataContests;
using BaltaStore.Infra.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Elmah.Io.AspNetCore;

namespace BaltaStore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //apos adicionar o pacote MVC
            services.AddMvc();
            services.AddResponseCaching();
            //Compacta Requisições
            services.AddResponseCompression();

            services.AddScoped<BaltaDataContext, BaltaDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailServices, EmailServices>();
            services.AddTransient<CustomerHandler,CustomerHandler>();

            //Adiciona a Ducumentação da API
            services.AddSwaggerGen(x => 
            {
                x.SwaggerDoc("v1", new Info { Title = "Balta Store", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            //Usar o pacote MVC
            app.UseMvc();
            //Compacta Requisições
            app.UseResponseCompression();

            //Usar o Swagger
            app.UseSwagger();
            //Configura o arquivo da documentacao
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Balta Store V1");
            });

#pragma warning disable CS0618 // Type or member is obsolete
            app.UseElmahIo("2e05a4650c054177ba8842e82fce7d65", new Guid("df129a54-1e6d-4ab8-996e-9ecacda4f1a6"));
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
