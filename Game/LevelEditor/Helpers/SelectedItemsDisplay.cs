﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using FarseerPhysics.DebugViews;

namespace LevelEditor.Helpers
{
    class SelectedItemsDisplay
    {
        List<GameObject> _selectedGameObjects;
        List<GameObjectPart> _selectedGameObjectParts;
        List<Joint> _selectedJoints;

        const int CircleSegments = 64;
        PrimitiveBatch _primitiveBatch;

        public bool DrawAssociatedJoints
        { get; set; }


        public List<Joint> SelectedJoints
        {
            get
            {
                return _selectedJoints;
            }
            set
            {
                _selectedJoints.Clear();
                _selectedJoints = value;
            }
        }

        public List<GameObject> SelectedGameObjects
        {
            get
            {
                return _selectedGameObjects;
            }
            set
            {
                _selectedGameObjects.Clear();
                _selectedGameObjects = value;
            }
        }

        public List<GameObjectPart> SelectedGameObjectParts
        {
            get
            {
                return _selectedGameObjectParts;
            }
            set
            {
                _selectedGameObjectParts.Clear();
                _selectedGameObjectParts = value;
            }
        }

        public SelectedItemsDisplay(GraphicsDevice device)
        {
            _primitiveBatch = new PrimitiveBatch(device);
            _selectedJoints = new List<Joint>();
            _selectedGameObjects = new List<GameObject>();
            _selectedGameObjectParts = new List<GameObjectPart>();
        }

        private void DrawJoint(Joint joint)
        {
            if (!joint.Enabled)
                return;

            Body b1 = joint.BodyA;
            Body b2 = joint.BodyB;
            Transform xf1, xf2;
            b1.GetTransform(out xf1);

            Vector2 x2 = Vector2.Zero;

            if (!joint.IsFixedType())
            {
                b2.GetTransform(out xf2);
                x2 = xf2.Position;
            }

            Vector2 p1 = joint.WorldAnchorA;
            Vector2 p2 = joint.WorldAnchorB;
            Vector2 x1 = xf1.Position;

            Color color = new Color(0.5f, 0.8f, 0.8f);
            color = Color.Red;
            switch (joint.JointType)
            {
                case JointType.Distance:
                    DrawSegment(p1, p2, color);
                    break;
                case JointType.Pulley:
                    PulleyJoint pulley = (PulleyJoint)joint;
                    Vector2 s1 = pulley.GroundAnchorA;
                    Vector2 s2 = pulley.GroundAnchorB;
                    DrawSegment(s1, p1, color);
                    DrawSegment(s2, p2, color);
                    DrawSegment(s1, s2, color);
                    break;
                case JointType.FixedMouse:
                    DrawPoint(p1, 1.0f, new Color(0.0f, 1.0f, 0.0f));
                    DrawSegment(p1, p2, new Color(0.8f, 0.8f, 0.8f));
                    break;
                case JointType.Revolute:
                    //DrawSegment(x2, p1, color);
                    DrawSegment(p2, p1, color);
                    DrawSolidCircle(p2, 0.5f, Vector2.Zero, Color.Green);
                    DrawSolidCircle(p1, 0.5f, Vector2.Zero, Color.Blue);
                    break;
                case JointType.FixedAngle:
                    //Should not draw anything.
                    break;
                case JointType.FixedRevolute:
                    DrawSegment(x1, p1, color);
                    DrawSolidCircle(p1, 0.5f, Vector2.Zero, Color.Blue);
                    break;
                case JointType.FixedLine:
                    DrawSegment(x1, p1, color);
                    DrawSegment(p1, p2, color);
                    break;
                case JointType.FixedDistance:
                    DrawSegment(x1, p1, color);
                    DrawSegment(p1, p2, color);
                    break;
                case JointType.FixedPrismatic:
                    DrawSegment(x1, p1, color);
                    DrawSegment(p1, p2, color);
                    break;
                case JointType.Gear:
                    DrawSegment(x1, x2, color);
                    break;
                //case JointType.Weld:
                //    break;
                default:
                    DrawSegment(x1, p1, color);
                    DrawSegment(p1, p2, color);
                    DrawSegment(x2, p2, color);
                    break;
            }
        }

        private void DrawCircle(Vector2 center, float radius, Color color)
        {
            if (!_primitiveBatch.IsReady())
            {
                throw new InvalidOperationException("BeginCustomDraw must be called before drawing anything.");
            }
            const double increment = Math.PI * 2.0 / CircleSegments;
            double theta = 0.0;

            for (int i = 0; i < CircleSegments; i++)
            {
                Vector2 v1 = center + radius * new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                Vector2 v2 = center +
                             radius *
                             new Vector2((float)Math.Cos(theta + increment), (float)Math.Sin(theta + increment));

                _primitiveBatch.AddVertex(v1, color, PrimitiveType.LineList);
                _primitiveBatch.AddVertex(v2, color, PrimitiveType.LineList);

                theta += increment;
            }
        }

        private void DrawSolidCircle(Vector2 center, float radius, Vector2 axis, Color color)
        {
            if (!_primitiveBatch.IsReady())
            {
                throw new InvalidOperationException("BeginCustomDraw must be called before drawing anything.");
            }
            const double increment = Math.PI * 2.0 / CircleSegments;
            double theta = 0.0;

            Color colorFill = color * 0.5f;

            Vector2 v0 = center + radius * new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
            theta += increment;

            for (int i = 1; i < CircleSegments - 1; i++)
            {
                Vector2 v1 = center + radius * new Vector2((float)Math.Cos(theta), (float)Math.Sin(theta));
                Vector2 v2 = center +
                             radius *
                             new Vector2((float)Math.Cos(theta + increment), (float)Math.Sin(theta + increment));

                _primitiveBatch.AddVertex(v0, colorFill, PrimitiveType.TriangleList);
                _primitiveBatch.AddVertex(v1, colorFill, PrimitiveType.TriangleList);
                _primitiveBatch.AddVertex(v2, colorFill, PrimitiveType.TriangleList);

                theta += increment;
            }
            DrawCircle(center, radius, color);

            DrawSegment(center, center + axis * radius, color);
        }

        private void DrawSegment(Vector2 start, Vector2 end, Color color)
        {
            if (!_primitiveBatch.IsReady())
            {
                throw new InvalidOperationException("BeginCustomDraw must be called before drawing anything.");
            }

            Vector2 axis = Vector2.Transform(end - start, Matrix.CreateRotationZ(MathHelper.ToRadians(90)));
            axis.Normalize();
            for (int i = -2; i <= 2; i++)
            {
                Vector2 offset =  new Vector2((float)(axis.X*i*0.1),(float)(axis.Y*i*0.1));
                _primitiveBatch.AddVertex(new Vector2(start.X + offset.X, start.Y + offset.Y), color, PrimitiveType.LineList);
                _primitiveBatch.AddVertex(new Vector2(end.X + offset.X, end.Y + offset.Y), color, PrimitiveType.LineList);
            }
        }

        private void DrawPoint(Vector2 p, float size, Color color)
        {
            Vector2[] verts = new Vector2[4];
            float hs = size / 2.0f;
            verts[0] = p + new Vector2(-hs, -hs);
            verts[1] = p + new Vector2(hs, -hs);
            verts[2] = p + new Vector2(hs, hs);
            verts[3] = p + new Vector2(-hs, hs);

            DrawSolidPolygon(verts, 4, color, true);
        }

        private void DrawSolidPolygon(Vector2[] vertices, int count, Color color, bool outline)
        {
            if (!_primitiveBatch.IsReady())
            {
                throw new InvalidOperationException("BeginCustomDraw must be called before drawing anything.");
            }
            if (count == 2)
            {
                DrawPolygon(vertices, count, color);
                return;
            }

            Color colorFill = color * (outline ? 0.5f : 1.0f);

            for (int i = 1; i < count - 1; i++)
            {
                _primitiveBatch.AddVertex(vertices[0], colorFill, PrimitiveType.TriangleList);
                _primitiveBatch.AddVertex(vertices[i], colorFill, PrimitiveType.TriangleList);
                _primitiveBatch.AddVertex(vertices[i + 1], colorFill, PrimitiveType.TriangleList);
            }

            if (outline)
            {
                DrawPolygon(vertices, count, color);
            }
        }

        private void DrawPolygon(Vector2[] vertices, int count, Color color)
        {
            if (!_primitiveBatch.IsReady())
            {
                throw new InvalidOperationException("BeginCustomDraw must be called before drawing anything.");
            }
            for (int i = 0; i < count - 1; i++)
            {
                _primitiveBatch.AddVertex(vertices[i], color, PrimitiveType.LineList);
                _primitiveBatch.AddVertex(vertices[i + 1], color, PrimitiveType.LineList);
            }

            _primitiveBatch.AddVertex(vertices[count - 1], color, PrimitiveType.LineList);
            _primitiveBatch.AddVertex(vertices[0], color, PrimitiveType.LineList);
        }

        public void DrawSelectedItems(ref Matrix projection)
        {
            Matrix view = Matrix.Identity;
            _primitiveBatch.Begin(ref projection,ref view);
            foreach (Joint joint in _selectedJoints)
                DrawJoint(joint);
            _primitiveBatch.End();
        }


    }
}
