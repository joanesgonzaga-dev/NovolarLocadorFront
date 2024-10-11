using NovolarLocadorFront.Globals;

namespace NovolarLocadorFront.Utils
{
    /// <summary>
    /// Serviço para acesso à classe singleton AplicationGlobals sem uso de D.I
    /// </summary>
    public static class ServiceLocator
    {
        private static IServiceProvider _serviceProvider;

        public static ApplicationGlobals _applicationGlobals
        {
            get
            {
                return _serviceProvider.GetRequiredService<ApplicationGlobals>();
            }
        }

        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
