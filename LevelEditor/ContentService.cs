using Microsoft.Xna.Framework.Content;
using System.Threading;
using LevelEditor;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System;
using System.Collections.Generic;
namespace LevelEditor
{
    class ContentService
    {
        private static ContentService contentService;
        private ContentManager content;
        private ServiceContainer services;
        public ContentManager Content
        {
            get { return content; }
        }
        //IServiceProvider containing IGraphicsDeviceService. This can be used with components such as the ContentManager, which use this service to look up the GraphicsDevice.
        public ServiceContainer Services
        {
            get { return services; }
        }

        private ContentService(IGraphicsDeviceService graphicsDeviceService, string rootDir)
        {
            services = new ServiceContainer();
            // Register the service, so ContentManager can find it.
            services.AddService<IGraphicsDeviceService>(graphicsDeviceService);
            content = new ContentManager(Services, rootDir);
        }

        public static ContentService GetContentService(IGraphicsDeviceService graphicsDeviceService,string rootDir)
        {
            if (contentService == null)
            {
                contentService = new ContentService(graphicsDeviceService, rootDir);
            }
            return contentService;
        }

        public static ContentService GetContentService(IGraphicsDeviceService graphicsDeviceService)
        {
            if (contentService == null)
            {
                contentService = new ContentService(graphicsDeviceService, GetContentPath());
            }
            return contentService;
        }

        public static ContentService GetContentService()
        {
            if (contentService == null)
            {
                throw new Exception("No GraphicsDeviceService initialized");
            }
            return contentService;
        }

        public static string GetContentPath()
        {
            return Environment.CurrentDirectory+"\\Content";
        }

        public static string GetMaterial(string material = null)
        {
            return "Textures\\Materials\\"+material;
        }

    }
}