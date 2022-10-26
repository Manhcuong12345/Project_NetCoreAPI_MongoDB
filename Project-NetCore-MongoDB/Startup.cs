using Microsoft.OpenApi.Models;
using Project_NetCore_MongoDB.Models;
using Project_NetCore_MongoDB.Repository;
using Project_NetCore_MongoDB.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Project_NetCore_MongoDB.Repository.Interface;
using Project_NetCore_MongoDB.Services.Interface;
using Project_NetCore_MongoDB.Common;

namespace Project_NetCore_MongoDB
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

            // Default Policy
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = ".Net Core With MongoDB CRUD API", Version = "v1" });
                // To Enable authorization using Swagger (JWT)    
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = Configuration.GetSection("Authentication:Issuer").Value,
                            ValidAudience = Configuration.GetSection("Authentication:Audience").Value,
                            IssuerSigningKey = JwtSecurityKey.Create(Configuration.GetSection("Authentication:SecurityKey").Value)
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };
                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Member",
                   policy => policy.RequireClaim("MembershipId"));
            });

            //services.AddMvc();

            //Midderware
            services.Configure<DbConfiguration>(Configuration.GetSection("MongoDbConnection"));
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IProductsRepository, ProductsRepository>();

            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // Default Policy
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MongoDB CRUD API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

           
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           // app.UseMvc();
        }
    }
}
