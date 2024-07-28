using NovolarLocadorFront.Globals;

namespace NovolarLocadorFront.Utils
{
    /// <summary>
    /// Serviço para acesso à classe singleton AplicationGlobals sem uso de D.I
    /// </summary>
    public static class ServiceLocator
    {
        public static ApplicationGlobals _applicationGlobals
        {
            get
            {
                return _serviceProvider.GetRequiredService<ApplicationGlobals>();
            }
        }

        private static IServiceProvider _serviceProvider;

        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
