using System;
using System.Collections.Generic;
using FarseerPhysics.Collision;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
using FarseerPhysics.Common.PolygonManipulation;

namespace FarseerTools
{
    public enum ObjectType
    {
        Circle,
        Ellipse,
        Arc,
        Gear,
        Capsule,
        Rectangle,
        RoundedRectangle,
        CustomShape
    }

    public class AssetCreator
    {
        public const int CircleSegments = 128;
        private GraphicsDevice _device;
        private BasicEffect _effect;
        private Dictionary<string, Texture2D> _materials = new Dictionary<string, Texture2D>();
        private Dictionary<string, Texture2D> _shapes = new Dictionary<string, Texture2D>();

        public bool UseTexture { get; set; }
        public bool DrawOutline { get; set; }
        
        public AssetCreator(GraphicsDevice device, ContentManager content)
        {
            _device = device;
            _effect = new BasicEffect(_device);
            UseTexture = false;
            DrawOutline = false;
        }

        public static Vector2 CalculateOrigin(Body b)
        {
            Vector2 lBound = new Vector2(float.MaxValue);
            AABB bounds;
            Transform trans;
            b.GetTransform(out trans);

            for (int i = 0; i < b.FixtureList.Count; ++i)
            {
                for (int j = 0; j < b.FixtureList[i].Shape.ChildCount; ++j)
                {
                    b.FixtureList[i].Shape.ComputeAABB(out bounds, ref trans, j);
                    Vector2.Min(ref lBound, ref bounds.LowerBound, out lBound);
                }
            }
            // calculate body offset from its center and add a 1 pixel border
            // because we generate the textures a little bigger than the actual body's fixtures
            return ConvertUnits.ToDisplayUnits(b.Position - lBound) + new Vector2(1f);
        }

        public void LoadMaterial(string key, Texture2D material)
        {
            _materials[key] = material;
        }

        public void LoadShape(string key, Texture2D shape)
        {
            _shapes[key] = shape;
        }


        public Texture2D TextureFromShape(Shape shape, string type, Color color, float materialScale)
        {
            switch (shape.ShapeType)
            {
                case ShapeType.Circle:
                    return CircleTexture(shape.Radius, type, color, materialScale);
                case ShapeType.Polygon:
                    return TextureFromVertices(((PolygonShape) shape).Vertices, type, color, materialScale);
                default:
                    throw new NotSupportedException("The specified shape type is not supported.");
            }
        }

        public Texture2D TextureFromVertices(Vertices vertices, string materialType, Color color, float materialScale)
        {
            // copy vertices
            Vertices verts = new Vertices(vertices);

            // scale to display units (i.e. pixels) for rendering to texture
            Vector2 scale = ConvertUnits.ToDisplayUnits(Vector2.One);
            verts.Scale(ref scale);

            // translate the boundingbox center to the texture center
            // because we use an orthographic projection for rendering later
            AABB vertsBounds = verts.GetCollisionBox();
            verts.Translate(-vertsBounds.Center);

            List<Vertices> decomposedVerts;
            if (!verts.IsConvex())
            {
                decomposedVerts = EarclipDecomposer.ConvexPartition(verts);
                //decomposedVerts = SeidelDecomposer.ConvexPartition(verts,0.01f);
                //decomposedVerts = SeidelDecomposer.ConvexPartitionTrapezoid(verts,0.01f);
                //decomposedVerts = FlipcodeDecomposer.ConvexPartition(verts);
                //decomposedVerts = CDTDecomposer.ConvexPartition(verts);
                //decomposedVerts = BayazitDecomposer.ConvexPartition(verts);
            }
            else
            {
                decomposedVerts = new List<Vertices>();
                decomposedVerts.Add(verts);
            }
            List<VertexPositionColorTexture[]> verticesFill =
                new List<VertexPositionColorTexture[]>(decomposedVerts.Count);
            float textureScale = materialScale;
            materialScale /= _materials[materialType].Width;

            for (int i = 0; i < decomposedVerts.Count; ++i)
            {
                verticesFill.Add(new VertexPositionColorTexture[3 * (decomposedVerts[i].Count - 2)]);
                for (int j = 0; j < decomposedVerts[i].Count - 2; ++j)
                {
                    // fill vertices
                    verticesFill[i][3 * j].Position = new Vector3(decomposedVerts[i][0], 0f);
                    verticesFill[i][3 * j + 1].Position = new Vector3(decomposedVerts[i].NextVertex(j), 0f);
                    verticesFill[i][3 * j + 2].Position = new Vector3(decomposedVerts[i].NextVertex(j + 1), 0f);
                    verticesFill[i][3 * j].TextureCoordinate = decomposedVerts[i][0] * materialScale;
                    verticesFill[i][3 * j + 1].TextureCoordinate = decomposedVerts[i].NextVertex(j) * materialScale;
                    verticesFill[i][3 * j + 2].TextureCoordinate = decomposedVerts[i].NextVertex(j + 1) * materialScale;
                    verticesFill[i][3 * j].Color = verticesFill[i][3 * j + 1].Color = verticesFill[i][3 * j + 2].Color = color;
                }
            }

            // calculate outline
            VertexPositionColor[] verticesOutline = new VertexPositionColor[2 * verts.Count];
            for (int i = 0; i < verts.Count; ++i)
            {
                verticesOutline[2 * i].Position = new Vector3(verts[i], 0f);
                verticesOutline[2 * i + 1].Position = new Vector3(verts.NextVertex(i), 0f);
                verticesOutline[2 * i].Color = verticesOutline[2 * i + 1].Color = Color.Black;
            }

            Vector2 vertsSize = new Vector2(vertsBounds.UpperBound.X - vertsBounds.LowerBound.X,
                                            vertsBounds.UpperBound.Y - vertsBounds.LowerBound.Y);
            return UseTexture ? RenderTexture((int)vertsSize.X, (int)vertsSize.Y, _materials[materialType], verticesFill, verticesOutline, textureScale) :
                                RenderMaterial((int)vertsSize.X, (int)vertsSize.Y, _materials[materialType], verticesFill, verticesOutline);
        }

        public Texture2D CircleTexture(float radius, string type, Color color, float materialScale)
        {
            return EllipseTexture(radius, radius, type, color, materialScale);
        }

        public Texture2D EllipseTexture(float radiusX, float radiusY, string materialType, Color color,
                                        float materialScale)
        {
            VertexPositionColorTexture[] verticesFill = new VertexPositionColorTexture[3 * (CircleSegments - 2)];
            VertexPositionColor[] verticesOutline = new VertexPositionColor[2 * CircleSegments];
            const float segmentSize = MathHelper.TwoPi / CircleSegments;
            float theta = segmentSize;

            radiusX = ConvertUnits.ToDisplayUnits(radiusX);
            radiusY = ConvertUnits.ToDisplayUnits(radiusY);
            float textureScale = materialScale;
            materialScale /= _materials[materialType].Width;
            Vector2 start = new Vector2(radiusX, 0f);

            for (int i = 0; i < CircleSegments - 2; ++i)
            {
                Vector2 p1 = new Vector2(radiusX * (float)Math.Cos(theta), radiusY * (float)Math.Sin(theta));
                Vector2 p2 = new Vector2(radiusX * (float)Math.Cos(theta + segmentSize),
                                         radiusY * (float)Math.Sin(theta + segmentSize));
                // fill vertices
                verticesFill[3 * i].Position = new Vector3(start, 0f);
                verticesFill[3 * i + 1].Position = new Vector3(p1, 0f);
                verticesFill[3 * i + 2].Position = new Vector3(p2, 0f);
                verticesFill[3 * i].TextureCoordinate = start * materialScale;
                verticesFill[3 * i + 1].TextureCoordinate = p1 * materialScale;
                verticesFill[3 * i + 2].TextureCoordinate = p2 * materialScale;
                verticesFill[3 * i].Color = verticesFill[3 * i + 1].Color = verticesFill[3 * i + 2].Color = color;

                
                // outline vertices
                if (i == 0)
                {
                    verticesOutline[0].Position = new Vector3(start, 0f);
                    verticesOutline[1].Position = new Vector3(p1, 0f);
                    verticesOutline[0].Color = verticesOutline[1].Color = Color.Black;
                }
                if (i == CircleSegments - 3)
                {
                    verticesOutline[2 * CircleSegments - 2].Position = new Vector3(p2, 0f);
                    verticesOutline[2 * CircleSegments - 1].Position = new Vector3(start, 0f);
                    verticesOutline[2 * CircleSegments - 2].Color =
                        verticesOutline[2 * CircleSegments - 1].Color = Color.Black;
                }
                verticesOutline[2 * i + 2].Position = new Vector3(p1, 0f);
                verticesOutline[2 * i + 3].Position = new Vector3(p2, 0f);
                verticesOutline[2 * i + 2].Color = verticesOutline[2 * i + 3].Color = Color.Black;

                theta += segmentSize;
            }

            List<VertexPositionColorTexture[]> fill = new List<VertexPositionColorTexture[]>(1);
            fill.Add(verticesFill);
            return UseTexture ? RenderTexture((int)(radiusX * 2f), (int)(radiusY * 2f), _materials[materialType], fill, verticesOutline, textureScale) :
                                RenderMaterial((int)(radiusX * 2f), (int)(radiusY * 2f), _materials[materialType], fill, verticesOutline);
        }

        private Texture2D RenderMaterial(int width, int height, Texture2D material,
                                        List<VertexPositionColorTexture[]> verticesFill,
                                        VertexPositionColor[] verticesOutline)
        {
            Matrix halfPixelOffset = Matrix.CreateTranslation(-0.5f, -0.5f, 0f);
            
            RenderTarget2D texture = new RenderTarget2D(_device, width + 2, height + 2, false, SurfaceFormat.Color,
                                                        DepthFormat.None, 8,
                                                        RenderTargetUsage.DiscardContents);

            _device.RasterizerState = RasterizerState.CullNone;
            _device.SamplerStates[0] = SamplerState.LinearWrap;
            _device.SetRenderTarget(texture);
            _device.Clear(Color.Transparent);
            _effect.Projection = Matrix.CreateOrthographic(width + 2f, -height - 2f, 0f, 1f);
            _effect.View = halfPixelOffset;
            // render shape;
            _effect.TextureEnabled = true;
            _effect.Texture = material;
            _effect.VertexColorEnabled = true;
            _effect.Techniques[0].Passes[0].Apply();
            for (int i = 0; i < verticesFill.Count; ++i)
            {
                _device.DrawUserPrimitives(PrimitiveType.TriangleList, verticesFill[i], 0, verticesFill[i].Length / 3);
            }

            if (DrawOutline)
            {
                // render outline;
                _effect.TextureEnabled = false;
                _effect.Techniques[0].Passes[0].Apply();
                _device.DrawUserPrimitives(PrimitiveType.LineList, verticesOutline, 0, verticesOutline.Length / 2);
            }
            _device.SetRenderTarget(null);
             return texture;
        }

        private Texture2D RenderTexture(int width, int height, Texture2D texture,
                                        List<VertexPositionColorTexture[]> verticesFill,
                                        VertexPositionColor[] verticesOutline,float textureScale = 1)
        {
            #region BlendState alternative
            /*RenderTarget2D outputTexture = new RenderTarget2D(_device, width+2, height+2, false, SurfaceFormat.Color,
                                                        DepthFormat.None, 8,
                                                        RenderTargetUsage.DiscardContents);

            float textureWidth = width * textureScale / 2;
            float textureHeight = height * textureScale / 2;
            VertexPositionColorTexture[] rectangleTexture = new VertexPositionColorTexture[4];
            rectangleTexture[0] = new VertexPositionColorTexture();
            rectangleTexture[0].Position = new Vector3(-textureWidth, textureHeight, 0);
            rectangleTexture[0].TextureCoordinate = new Vector2(0, 1);
            rectangleTexture[0].Color = Color.White;
            rectangleTexture[1] = new VertexPositionColorTexture();
            rectangleTexture[1].Position = new Vector3(textureWidth, textureHeight, 0);
            rectangleTexture[1].TextureCoordinate = new Vector2(1, 1);
            rectangleTexture[1].Color = Color.White;
            rectangleTexture[2] = new VertexPositionColorTexture();
            rectangleTexture[2].Position = new Vector3(-textureWidth, -textureHeight, 0);
            rectangleTexture[2].TextureCoordinate = new Vector2(0, 0);
            rectangleTexture[2].Color = Color.White;
            rectangleTexture[3] = new VertexPositionColorTexture();
            rectangleTexture[3].Position = new Vector3(textureWidth, -textureHeight, 0);
            rectangleTexture[3].TextureCoordinate = new Vector2(1, 0);
            rectangleTexture[3].Color = Color.White;

            
            bool transparent = (verticesFill[0][0].Color == Color.Transparent);

            BasicEffect bassicEffect = new BasicEffect(_device);
            bassicEffect.World = Matrix.Identity;
            bassicEffect.View = Matrix.CreateTranslation(-0.5f, -0.5f, 0f);
            bassicEffect.Projection = Matrix.CreateOrthographic(width+2, -height-2, 0f, 1f);
           
            _device.RasterizerState = RasterizerState.CullNone;
            _device.SamplerStates[0] = SamplerState.LinearClamp;
            _device.SetRenderTarget(outputTexture);
            _device.Clear(Color.Transparent);

            bassicEffect.TextureEnabled = false;
            bassicEffect.VertexColorEnabled = !transparent;
            bassicEffect.Techniques[0].Passes[0].Apply();
            for (int i = 0; i < verticesFill.Count; ++i)
            {
                _device.DrawUserPrimitives(PrimitiveType.TriangleList, verticesFill[i], 0, verticesFill[i].Length / 3);
            }

            BlendState crossBlend = new BlendState();
            crossBlend.ColorWriteChannels = ColorWriteChannels.All;
            crossBlend.ColorSourceBlend = Blend.DestinationAlpha;
            crossBlend.AlphaSourceBlend = Blend.DestinationAlpha;
            if (transparent)
            {
                crossBlend.ColorDestinationBlend = Blend.Zero;
                crossBlend.AlphaDestinationBlend = Blend.Zero;
            }
            else
            {
                crossBlend.ColorDestinationBlend = Blend.InverseSourceAlpha;
                crossBlend.AlphaDestinationBlend = Blend.InverseSourceAlpha;
            }

            _device.BlendState = crossBlend;
            bassicEffect.TextureEnabled = true;
            bassicEffect.Texture = texture;
            bassicEffect.Techniques[0].Passes[0].Apply();
            _device.DrawUserPrimitives(PrimitiveType.TriangleStrip, rectangleTexture, 0, 2);
            _device.BlendState = BlendState.AlphaBlend;

            if (DrawOutline)
            {
                bassicEffect.VertexColorEnabled = true;
                bassicEffect.TextureEnabled = false;
                bassicEffect.Techniques[0].Passes[0].Apply();
                _device.DrawUserPrimitives(PrimitiveType.LineList, verticesOutline, 0, verticesOutline.Length / 2);
            }
            _device.SetRenderTarget(null);
             */
            #endregion
            RenderTarget2D outputTexture = new RenderTarget2D(_device, width + 2, height + 2, false, SurfaceFormat.Color,
                                                        DepthFormat.Depth24Stencil8, 8,
                                                        RenderTargetUsage.DiscardContents);

            float textureWidth = 1 + width * textureScale / 2;
            float textureHeight = 1 + height * textureScale / 2;
            VertexPositionColorTexture[] rectangleTexture = new VertexPositionColorTexture[4];
            rectangleTexture[0] = new VertexPositionColorTexture();
            rectangleTexture[0].Position = new Vector3(-textureWidth, textureHeight, 0);
            rectangleTexture[0].TextureCoordinate = new Vector2(0, 1);
            rectangleTexture[0].Color = Color.White;
            rectangleTexture[1] = new VertexPositionColorTexture();
            rectangleTexture[1].Position = new Vector3(textureWidth, textureHeight, 0);
            rectangleTexture[1].TextureCoordinate = new Vector2(1, 1);
            rectangleTexture[1].Color = Color.White;
            rectangleTexture[2] = new VertexPositionColorTexture();
            rectangleTexture[2].Position = new Vector3(-textureWidth, -textureHeight, 0);
            rectangleTexture[2].TextureCoordinate = new Vector2(0, 0);
            rectangleTexture[2].Color = Color.White;
            rectangleTexture[3] = new VertexPositionColorTexture();
            rectangleTexture[3].Position = new Vector3(textureWidth, -textureHeight, 0);
            rectangleTexture[3].TextureCoordinate = new Vector2(1, 0);
            rectangleTexture[3].Color = Color.White;

            DepthStencilState drawShape;
            drawShape = new DepthStencilState();
            drawShape.StencilEnable = true;
            drawShape.StencilFunction = CompareFunction.Always;
            drawShape.StencilPass = StencilOperation.Replace;
            drawShape.ReferenceStencil = 1;
            drawShape.DepthBufferEnable = false;

            DepthStencilState drawTexture;
            drawTexture = new DepthStencilState();
            drawTexture.StencilEnable = true;
            drawTexture.StencilFunction = CompareFunction.Equal;
            drawTexture.ReferenceStencil = 1;
            drawTexture.StencilPass = StencilOperation.Keep;
            drawTexture.DepthBufferEnable = false;

            BasicEffect bassicEffect = new BasicEffect(_device);
            bassicEffect.World = Matrix.Identity;
            bassicEffect.View = Matrix.CreateTranslation(-0.5f, -0.5f, 0f);
            bassicEffect.Projection = Matrix.CreateOrthographic(width + 2, -height - 2, 0f, 1f);

            _device.RasterizerState = RasterizerState.CullNone;
            _device.SamplerStates[0] = SamplerState.LinearClamp;
            _device.SetRenderTarget(outputTexture);
            _device.Clear(Color.Transparent);
            
            bassicEffect.TextureEnabled = false;
            bassicEffect.VertexColorEnabled = true;
            _device.DepthStencilState = drawShape;
            bassicEffect.Techniques[0].Passes[0].Apply();
            for (int i = 0; i < verticesFill.Count; ++i)
            {
                _device.DrawUserPrimitives(PrimitiveType.TriangleList, verticesFill[i], 0, verticesFill[i].Length / 3);
            }

            bassicEffect.TextureEnabled = true;
            bassicEffect.Texture = texture;
            _device.DepthStencilState = drawTexture;
            bassicEffect.Techniques[0].Passes[0].Apply();
            _device.DrawUserPrimitives(PrimitiveType.TriangleStrip, rectangleTexture, 0, 2);

            _device.DepthStencilState = DepthStencilState.Default;
            if (DrawOutline)
            {
                bassicEffect.VertexColorEnabled = true;
                bassicEffect.TextureEnabled = false;
                bassicEffect.Techniques[0].Passes[0].Apply();
                _device.DrawUserPrimitives(PrimitiveType.LineList, verticesOutline, 0, verticesOutline.Length / 2);
            }

            _device.SetRenderTarget(null);
            return outputTexture as Texture2D;
        }
        
        /// <summary>Takes a list of fixtures with convex polygons.</summary>
        /// <returns>Returns Texture2D.</returns>
        public Texture2D TextureFromFixtures(List<Fixture> fixtures, string type, Color color, float materialScale)
        {
            AABB collisionBox  = ((PolygonShape)fixtures[0].Shape).Vertices.GetCollisionBox();
            List<VertexPositionColorTexture[]> verticesFill = new List<VertexPositionColorTexture[]>();
            List<VertexPositionColor[]> verticesOutline = new List<VertexPositionColor[]>();
            materialScale /= _materials[type].Width; 
            Vector2 scale = ConvertUnits.ToDisplayUnits(Vector2.One);
            Vector2 textureOffset = new Vector2(0.99f, 0.99f);            
            for(int i =0; i<fixtures.Count;i++)
            {
                if (((PolygonShape)fixtures[i].Shape).Vertices.GetCollisionBox().LowerBound.X < collisionBox.LowerBound.X)
                    collisionBox.LowerBound.X = ((PolygonShape)fixtures[i].Shape).Vertices.GetCollisionBox().LowerBound.X;
                if (((PolygonShape)fixtures[i].Shape).Vertices.GetCollisionBox().LowerBound.Y < collisionBox.LowerBound.Y)
                    collisionBox.LowerBound.Y = ((PolygonShape)fixtures[i].Shape).Vertices.GetCollisionBox().LowerBound.Y;
                if (((PolygonShape)fixtures[i].Shape).Vertices.GetCollisionBox().UpperBound.X > collisionBox.UpperBound.X)
                    collisionBox.UpperBound.X = ((PolygonShape)fixtures[i].Shape).Vertices.GetCollisionBox().UpperBound.X;
                if (((PolygonShape)fixtures[i].Shape).Vertices.GetCollisionBox().UpperBound.Y > collisionBox.UpperBound.Y)
                    collisionBox.UpperBound.Y = ((PolygonShape)fixtures[i].Shape).Vertices.GetCollisionBox().UpperBound.Y;

                Vertices vert = new Vertices(((PolygonShape)fixtures[i].Shape).Vertices);
                vert.Scale(ref scale);

                verticesOutline.Add(new VertexPositionColor[2 * vert.Count]);
                for (int j = 0; j < vert.Count; ++j)
                {
                    verticesOutline[i][2 * j].Position = new Vector3(vert[j], 0f);
                    verticesOutline[i][2 * j + 1].Position = new Vector3(vert.NextVertex(j), 0f);
                    verticesOutline[i][2 * j].Color = verticesOutline[i][2 * j + 1].Color = Color.Black;
                }

                
                vert.Scale(ref textureOffset);
                verticesFill.Add(new VertexPositionColorTexture[3 * (vert.Count - 2)]);
                for (int j = 0; j < vert.Count - 2; ++j)
                {
                    // fill vertices
                    verticesFill[i][3 * j].Position = new Vector3(vert[0], 0f);
                    verticesFill[i][3 * j + 1].Position = new Vector3(vert.NextVertex(j), 0f);
                    verticesFill[i][3 * j + 2].Position = new Vector3(vert.NextVertex(j + 1), 0f);
                    verticesFill[i][3 * j].TextureCoordinate = vert[0] * materialScale;
                    verticesFill[i][3 * j + 1].TextureCoordinate = vert.NextVertex(j) * materialScale;
                    verticesFill[i][3 * j + 2].TextureCoordinate = vert.NextVertex(j + 1) * materialScale;
                    verticesFill[i][3 * j].Color = verticesFill[i][3 * j + 1].Color = verticesFill[i][3 * j + 2].Color = color;
                }
            }

            int width = (int)(ConvertUnits.ToDisplayUnits(collisionBox.UpperBound.X - collisionBox.LowerBound.X));
            int height = (int)(ConvertUnits.ToDisplayUnits(collisionBox.UpperBound.Y - collisionBox.LowerBound.Y));



            Matrix halfPixelOffset = Matrix.CreateTranslation(-0.5f, -0.5f, 0f);
            PresentationParameters pp = _device.PresentationParameters;
            RenderTarget2D texture = new RenderTarget2D(_device, width + 2, height + 2, false, SurfaceFormat.Color,
                                                        DepthFormat.None, pp.MultiSampleCount,
                                                        RenderTargetUsage.DiscardContents);
            _device.RasterizerState = RasterizerState.CullNone;
            _device.SamplerStates[0] = SamplerState.AnisotropicWrap;
            _device.SetRenderTarget(texture);
            _device.Clear(Color.Transparent);
            _effect.Projection = Matrix.CreateOrthographic(width + 2f, -height - 2f, 0f, 1f);
            _effect.View = halfPixelOffset;
            _effect.TextureEnabled = false;
            _effect.VertexColorEnabled = true;
            _effect.Techniques[0].Passes[0].Apply();
            for (int i = 0; i < verticesFill.Count; ++i)
                _device.DrawUserPrimitives(PrimitiveType.LineList, verticesOutline[i], 0, verticesOutline[i].Length / 2);
            _effect.TextureEnabled = true;
            _effect.Texture = _materials[type];
            _effect.Techniques[0].Passes[0].Apply();
            for (int i = 0; i < verticesFill.Count; ++i)
                _device.DrawUserPrimitives(PrimitiveType.TriangleList, verticesFill[i], 0, verticesFill[i].Length / 3);

            _device.SetRenderTarget(null);
            return texture;
        }

        public void ShapeFromTexture(string shape, float scale,Color color, out Texture2D outputTexture, out Vertices vertices)
        {
            Texture2D shapeTexture = _shapes[shape];
            uint[] data = new uint[shapeTexture.Width * shapeTexture.Height];
            shapeTexture.GetData(data);
            Vertices textureVertices = PolygonTools.CreatePolygon(data, shapeTexture.Width, false);
            AABB vertsBounds = textureVertices.GetCollisionBox();
            Vector2 origin = vertsBounds.Center;
            textureVertices.Translate(-origin);
            int width = (int)((vertsBounds.UpperBound.X - vertsBounds.LowerBound.X)*scale);
            int height = (int)((vertsBounds.UpperBound.Y - vertsBounds.LowerBound.Y)*scale);
            textureVertices = SimplifyTools.ReduceByDistance(textureVertices, 4f);
            Vector2 vertScale = ConvertUnits.ToSimUnits(Vector2.One) * scale;
            textureVertices.Scale(ref vertScale);
            vertices = new Vertices(textureVertices);
            RenderTarget2D renderTarget = new RenderTarget2D(_device, width + 2, height + 2, false, SurfaceFormat.Color,
                                                       DepthFormat.None, 8,
                                                       RenderTargetUsage.DiscardContents);
            SpriteBatch batch = new SpriteBatch(_device);
            _device.SetRenderTarget(renderTarget);
            _device.Clear(Color.Transparent);
            batch.Begin(SpriteSortMode.Immediate,null,SamplerState.LinearClamp,null,RasterizerState.CullNone);
            batch.Draw(shapeTexture, new Vector2(renderTarget.Width / 2, renderTarget.Height / 2), null, color, 0, origin, scale, SpriteEffects.None, 0f);
            batch.End();
            _device.SetRenderTarget(null);
            outputTexture = renderTarget as Texture2D;
        }

        public void ShapeFromTexture(string shape, float scale, string materialType, Color color, float materialScale, out Texture2D outputTexture, out Vertices vertices)
        {
            Texture2D shapeTexture = _shapes[shape];
            uint[] data = new uint[shapeTexture.Width * shapeTexture.Height];
            shapeTexture.GetData(data);
            Vertices textureVertices = PolygonTools.CreatePolygon(data, shapeTexture.Width, false);
            Vector2 centroid = -textureVertices.GetCentroid();
            textureVertices.Translate(ref centroid);
            Vector2 origin = -centroid;
            textureVertices = SimplifyTools.ReduceByDistance(textureVertices, 4f);
            Vector2 vertScale = new Vector2(ConvertUnits.ToSimUnits(1)) * scale;
            textureVertices.Scale(ref vertScale);
            vertices = new Vertices(textureVertices);
            outputTexture = TextureFromVertices(textureVertices, materialType, color, materialScale);
        }

        public Texture2D CreateRotatedTexture(Sprite sprite, float radians)
        {
            /*
            radians = MathHelper.ToRadians(MathHelper.ToDegrees(radians) - (((int)MathHelper.ToDegrees(radians)) / (int)90) * 90);
            width = (int)(Math.Cos(radians) * sprite.Texture.Width);
            height = (int)(Math.Sqrt(sprite.Texture.Width * sprite.Texture.Width + sprite.Texture.Height * sprite.Texture.Height)*Math.Cos(MathHelper.ToRadians(90)-radians-Math.Atan(sprite.Texture.Height/sprite.Texture.Width)));
             */

            Vector2 boundsHelper = Vector2.Transform(new Vector2(sprite.Texture.Width / 2, sprite.Texture.Height / 2), Matrix.CreateRotationZ(radians));
            double angleOffset = Math.Sqrt(2)*Math.Min(sprite.Texture.Height, sprite.Texture.Width)+1;
            int width = (int)(Math.Abs(boundsHelper.X * 2) + angleOffset);
            int height = (int)(Math.Abs(boundsHelper.Y * 2) + angleOffset);

            RenderTarget2D outputTexture = new RenderTarget2D(_device, width + 2, height + 2, false, SurfaceFormat.Color,
                                                        DepthFormat.Depth24Stencil8, 8,
                                                        RenderTargetUsage.DiscardContents);
            

            Matrix halfPixelOffset = Matrix.CreateTranslation(-0.5f, -0.5f, 0f);
            SpriteBatch batch = new SpriteBatch(_device);
            _device.SetRenderTarget(outputTexture);
            _device.Clear(Color.Transparent);
            batch.Begin(SpriteSortMode.Immediate, null, SamplerState.LinearClamp, null, RasterizerState.CullNone);
            batch.Draw(sprite.Texture, new Vector2(outputTexture.Width/2, outputTexture.Height/2), null, Color.White, radians, sprite.Origin, 1f,SpriteEffects.None, 0f);
            batch.End(); 

            _device.SetRenderTarget(null);
            return outputTexture;
        }
    }
}