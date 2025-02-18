using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Services;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Utils;

namespace NovolarLocadorFront
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static Proprietario Proprietario { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddSingleton<ApplicationGlobals>();
            services.AddRazorPages();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMemoryCache();
            services.AddScoped<ILocadorService, LocadorService>();
            services.AddScoped<IImovelService, ImovelService>();
            services.AddHttpClient<IProprietarioService, ProprietarioService>(
                c =>
                c.BaseAddress = new Uri(Configuration["ServicesURLs:LocadorManager-API"])
                );
            services.AddScoped<ProprietarioService, ProprietarioService>();
            services.AddScoped<DespesaService, DespesaService>();
            services.AddScoped<IDespesaService, DespesaService>();
            services.AddScoped<SessionService, SessionService>();
            services.AddScoped<IRepasseService, RepasseService>();
            services.AddScoped<IIndicadoresService, IndicadoresService>();
            services.AddScoped<ContratoAluguelService, ContratoAluguelService>();
            services.AddHttpContextAccessor(); // Registra o IHttpContextAccessor
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            //app.MapRazorPages();
            var applicationGlobals = app.ApplicationServices.GetRequiredService<ApplicationGlobals>();
          
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            ServiceLocator.SetServiceProvider(app.ApplicationServices);
        }
    }
}
