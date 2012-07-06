using Microsoft.Xna.Framework.Content;
using System.Threading;
using WinFormsGraphicsDevice;
using Microsoft.Xna.Framework.Graphics;
namespace WinFormsGraphicsDevice
{
    class ContentManagerService
    {
        private static ContentManagerService contentManagerService;
        private ContentManager contentManager;
        private ServiceContainer services;
        public ContentManager ContentManager
        {
            get { return contentManager; }
        }

        //IServiceProvider containing IGraphicsDeviceService. This can be used with components such as the ContentManager, which use this service to look up the GraphicsDevice.
        public ServiceContainer Services
        {
            get { return services; }
        }

        private ContentManagerService(IGraphicsDeviceService graphicsDeviceService, string rootDirectory)
        {
            services = new ServiceContainer();
            // Register the service, so ContentManager can find it.
            services.AddService<IGraphicsDeviceService>(graphicsDeviceService);
            contentManager = new ContentManager(Services, rootDirectory);
        }

        public static ContentManagerService GetContentManagerService(IGraphicsDeviceService graphicsDeviceService,string rootDirectory)
        {
            if (contentManagerService == null)
            {
                contentManagerService = new ContentManagerService(graphicsDeviceService, rootDirectory);
            }
            return contentManagerService;
        }

    }
}