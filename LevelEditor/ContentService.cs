using Microsoft.Xna.Framework.Content;
using System.Threading;
using LevelEditor;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System;
using System.Collections.Generic;
using FarseerTools;
using Microsoft.Xna.Framework;
namespace LevelEditor
{
    class ContentService
    {
        private static ContentService contentService;
        private ContentManager content;
        private ServiceContainer services;

        private AssetCreator assetCreator;
        public AssetCreator AssetCreator
        {
            get { return assetCreator; }
        }
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
            assetCreator = new AssetCreator(graphicsDeviceService.GraphicsDevice,content);
             
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

        public static string GetShape(string shape = null)
        {
            return "Textures\\Shapes\\" + shape;
        }

        public Texture2D LoadTexture(string fileLocation)
        {
            GraphicsDevice graphicsDevice = ((GraphicsDeviceService)services.GetService(typeof(IGraphicsDeviceService))).GraphicsDevice;
            Texture2D file = null;
            RenderTarget2D result = null;
            using (Stream titleStream = TitleContainer.OpenStream(fileLocation))
            {
                file = Texture2D.FromStream(graphicsDevice, titleStream); 
            }
            //НИЧЕГО НЕ ТРОГАТЬ
            //Setup a render target to hold our final texture which will have premulitplied alpha values
            //result = new RenderTarget2D(graphicsDevice, file.Width, file.Height);
            graphicsDevice.Reset();
            result = new RenderTarget2D(graphicsDevice, file.Width, file.Height, false, SurfaceFormat.Color, DepthFormat.None, 0, RenderTargetUsage.DiscardContents);

            graphicsDevice.SetRenderTarget(result);
            graphicsDevice.Clear(Color.Black);

            //Multiply each color by the source alpha, and write in just the color values into the final texture
            BlendState blendColor = new BlendState();
            blendColor.ColorWriteChannels = ColorWriteChannels.Red | ColorWriteChannels.Green | ColorWriteChannels.Blue;
            blendColor.AlphaDestinationBlend = Blend.Zero;
            blendColor.ColorDestinationBlend = Blend.Zero;
            blendColor.AlphaSourceBlend = Blend.SourceAlpha;
            blendColor.ColorSourceBlend = Blend.SourceAlpha;

            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
            spriteBatch.Begin(SpriteSortMode.Immediate, blendColor);
            spriteBatch.Draw(file, file.Bounds, Color.White);
            spriteBatch.End();

            //Now copy over the alpha values from the PNG source texture to the final one, without multiplying them
            BlendState blendAlpha = new BlendState();
            blendAlpha.ColorWriteChannels = ColorWriteChannels.Alpha;
            //blendAlpha.AlphaDestinationBlend = Blend.Zero;
            blendAlpha.ColorDestinationBlend = Blend.Zero;
            //blendAlpha.AlphaSourceBlend = Blend.One;
            blendAlpha.ColorSourceBlend = Blend.One;

            spriteBatch.Begin(SpriteSortMode.Immediate, blendAlpha);
            spriteBatch.Draw(file, file.Bounds, Color.White);
            spriteBatch.End();

            //Release the GPU back to drawing to the screen
            graphicsDevice.SetRenderTarget(null);


            return result as Texture2D;

        }

    }
}