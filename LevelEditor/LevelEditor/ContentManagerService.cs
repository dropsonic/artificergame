using Microsoft.Xna.Framework.Content;
using System.Threading;
using LevelEditor;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LevelEditor
{
    class ContentManagerService
    {
        private static ContentManagerService contentManagerService;
        private ContentManager content;
        private ServiceContainer services;
        static string rootDirectory = "LevelEditorContent";
        public ContentManager Content
        {
            get { return content; }
        }

        //IServiceProvider containing IGraphicsDeviceService. This can be used with components such as the ContentManager, which use this service to look up the GraphicsDevice.
        public ServiceContainer Services
        {
            get { return services; }
        }

        private ContentManagerService(IGraphicsDeviceService graphicsDeviceService, string rootDir)
        {
            services = new ServiceContainer();
            // Register the service, so ContentManager can find it.
            services.AddService<IGraphicsDeviceService>(graphicsDeviceService);
            content = new ContentManager(Services, rootDir);
        }

        public static ContentManagerService GetContentManagerService(IGraphicsDeviceService graphicsDeviceService,string rootDir)
        {
            if (contentManagerService == null)
            {
                contentManagerService = new ContentManagerService(graphicsDeviceService, rootDir);
            }
            return contentManagerService;
        }

        public static ContentManagerService GetContentManagerService(IGraphicsDeviceService graphicsDeviceService)
        {
            if (contentManagerService == null)
            {
                contentManagerService = new ContentManagerService(graphicsDeviceService, rootDirectory);
            }
            return contentManagerService;
        }

        public static ContentManagerService GetContentManagerService()
        {
            if (contentManagerService == null)
            {
                throw new Exception("No GraphicsDeviceService initialized");
            }
            return contentManagerService;
        }

    }
}