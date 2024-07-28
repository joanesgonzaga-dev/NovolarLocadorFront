using Microsoft.Extensions.DependencyInjection;
using NovolarLocadorFront.Globals;
using NovolarLocadorFront.Models.Proprietario;
using NovolarLocadorFront.Services;
using System;

namespace NovolarLocadorFront.Utils
{
    /// <summary>
    /// Esta classe tem a finalidade de permitir que serviços Singleton acessem serviços de Scoped
    /// </summary>
    public class StateManager
    {
        IServiceProvider _serviceProvider;
        ApplicationGlobals _applicationGlobals;
        public StateManager(IServiceProvider serviceProvider, ApplicationGlobals applicationGlobals)
        {
            _serviceProvider = serviceProvider;
            _applicationGlobals = applicationGlobals;
        }

        public async void ResetaEstadoProprietario(int id)
        {
            //_applicationGlobals.Reset();

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    ProprietarioService scopedService = scope.ServiceProvider.GetRequiredService<ProprietarioService>();
                    //_applicationGlobals.Proprietario = await scopedService.GetProprietarioById(id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
