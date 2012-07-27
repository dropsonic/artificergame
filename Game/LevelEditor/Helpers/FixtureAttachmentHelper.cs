using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics.Joints;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Common;
using FarseerTools;
using FarseerPhysics.Factories;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Collision.Shapes;

namespace LevelEditor.Helpers
{
    public class FixtureAttachmentHelper
    {
        private Body _prototypeBody;
        private Vertices _initialShapeVertices;
        
        private Body _foundBody;
        private List<Shape> _resultShapeList;
        
        private World _world;
        private int _step = 0;
        private string _statusMessage;
        public string StatusMessage
        {
            get { return _statusMessage; }
        }
        private bool _finished = false;
        public bool Finished
        {
            get { return _finished; }
        }
        public bool ShowPreview
        {
            get
            {
                return _step == 2 ? true : false;

            }
        }
        
        public void GetAttachmentResult(out Body body, out List<Shape> shapeList)
        {
            body = _foundBody;
            shapeList = _resultShapeList;
        }



        public FixtureAttachmentHelper(Vertices vertices, Body prototypeBody, World world)
        {
            _world = world;
            _initialShapeVertices = vertices;
            _prototypeBody = prototypeBody;
            NextStep(Vector2.Zero);
        }
        public void NextStep(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _finished = false; 
                    _statusMessage = "Attaching fixture to body. Choose body...";
                    _step++;
                    break;
                case 1:
                    _foundBody = CommonHelpers.FindBody(position, _world);
                    if (_foundBody == null)
                    {
                        _statusMessage = "Cant find body in this position. Choose Body...";
                        break;
                    }
                    _statusMessage = "Body has been selected. Choose fixture position...";
                    _step++;
                    break;
                case 2:
                    Vector2 offset = CommonHelpers.CalculateLocalPoint(position, _foundBody);
                    Vertices _tempShapeVertices = new Vertices(_initialShapeVertices);
                    _tempShapeVertices.Rotate(-_foundBody.Rotation);
                    _tempShapeVertices.Rotate(_prototypeBody.Rotation);
                    _tempShapeVertices.Translate(ref offset);

                    List<Vertices> decomposedVerts = EarclipDecomposer.ConvexPartition(_tempShapeVertices);
                    _resultShapeList = new List<Shape>(decomposedVerts.Count);

                    foreach (Vertices vertices in decomposedVerts)
                    {
                        if (vertices.Count == 2)
                            _resultShapeList.Add(new EdgeShape(vertices[0], vertices[1]));
                        else
                            _resultShapeList.Add(new PolygonShape(vertices, _prototypeBody.Density == null ? 1f : (float)_prototypeBody.Density));
                    }
                    _statusMessage = "Fixture has been created.";
                    _finished = true;
                    _step = 0;
                    break;
            }
        }
    }
}
#region Possible solution with body. cant move EdgeShape
/*
foreach (Fixture fix in _prototypeBody.FixtureList)
{
    switch (fix.Shape.ShapeType)
    {
        case ShapeType.Circle:
            break;
        case ShapeType.Edge:
            {
                EdgeShape tempShape = (EdgeShape)fix.Shape.Clone();
                break;
            }
        case ShapeType.Loop:
            {
                LoopShape tempShape = (LoopShape)fix.Shape.Clone();

                tempShape.Vertices.Rotate(-_foundBody.Rotation);
                tempShape.Vertices.Rotate(_prototypeBody.Rotation);
                tempShape.Vertices.Translate(ref offset);

                break;
            }
        case ShapeType.Polygon:
            {
                PolygonShape tempShape = (PolygonShape)fix.Shape.Clone();

                tempShape.Vertices.Rotate(-_foundBody.Rotation);
                tempShape.Vertices.Rotate(_prototypeBody.Rotation);
                tempShape.Vertices.Translate(ref offset);

                tempShape.Normals.Rotate(-_foundBody.Rotation);
                tempShape.Normals.Rotate(_prototypeBody.Rotation);
                tempShape.Normals.Translate(ref offset);

                _resultShapeList.Add(tempShape);
                break;
            }
        default:
            throw new Exception("Unknown shape type");
    }
}
*/
#endregion