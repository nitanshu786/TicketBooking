using Booking.Data;
using Booking.DTOMapping;
using Booking.Model;
using Booking.Repository;
using Booking.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;

namespace Booking
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
            string cs = Configuration.GetConnectionString("constr");
            services.AddDbContext<ApplicationDbContext>(ioption => ioption.UseSqlServer(cs));
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwagerOptions>();
            services.Configure<SMTPConfigModel>(Configuration.GetSection("SMTPConfig"));
          
            services.AddScoped<ITicketRepo, TicketRepo>();
            services.AddScoped<IBookingRepo, BookingRepo>();
            services.AddScoped<IRegister, RegisterUser>();
          
            services.AddAutoMapper(typeof(MappingProfile));


            services.AddScoped<IEmailSender, EmailSender>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Booking", Version = "v1" });
            });
            //core

            services.AddCors(options =>
            {
                options.AddPolicy(name: "MyCores",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            //JwtToken Token
            var appsettingSection = Configuration.GetSection("JwtToken");
            services.Configure<JwtToken>(appsettingSection);
            var appsetting = appsettingSection.Get<JwtToken>();
            var Key = Encoding.ASCII.GetBytes(appsetting.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booking v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors("MyCores");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
