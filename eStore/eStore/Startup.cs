using Application.IService;
using Application.Mappings;
using Application.Service;
using AutoMapper;
using eStore.Infrastructure.Persistence.Context;
using Infrastructure;
using Infrastructure.Configurations;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace eStore
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
            AddRepositories(services);
            RegisterMapper(services, Configuration);

            BaseConnection.Instance(Configuration);

            services.AddAutoMapper(typeof(UsersMapping));
            // config JSON format
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(x => x.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null); // JSON response with capital letter name

            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //Add Service
            services.AddTransient<IEUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepo>();


            services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<UploadConfigurations>(Configuration.GetSection(nameof(UploadConfigurations)));
            services.Configure<JwtIssuerOptions>(Configuration.GetSection(nameof(JwtIssuerOptions)));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "eStore_api", Version = "v1" });
                c.EnableAnnotations();
            });

            //services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<laptopWebContext>().AddDefaultTokenProviders();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }

        private static void RegisterMapper(IServiceCollection services, IConfiguration configuration)
        {
            //var urlServerDomain = configuration.GetSection("JwtIssuerOptions:Audience");
            //var urlServer = urlServerDomain?.Value;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsersMapping());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseCors("CorsPolicy");

            // Add authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "eStore v1"));
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
