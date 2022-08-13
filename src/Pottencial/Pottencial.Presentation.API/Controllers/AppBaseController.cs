using Microsoft.AspNetCore.Mvc;

namespace Pottencial.Presentation.API.Controllers
{
    public class AppBaseController : ControllerBase
    {
        protected readonly IServiceProvider _serviceProvider;
        public AppBaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType) ?? throw new ArgumentNullException("Erro interno ao requisitar serviços de aplicação");
        }
    }
}
