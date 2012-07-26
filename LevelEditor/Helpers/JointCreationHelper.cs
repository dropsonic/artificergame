using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics.Joints;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;

namespace LevelEditor.Helpers
{
    class JointParameters
    {
        public Body bodyA;
        public Body bodyB;
        public Vector2 localAnchorA;
        public Vector2 localAnchorB;
        public Vector2 worldAnchorA;
        public Vector2 worldAnchorB;
        public Vector2 axisFirst;
        public Vector2 axisSecond;
        
    }

    public class JointCreationHelper
    {
        private JointType _jointType;
        private int _step = 0;
        private JointParameters _jointParameters;
        private World _world;
        private Joint _joint;
        public Joint CreatedJoint
        {
            get { return _joint; }
        }
        private string _currentStateMessage;
        public string CurrentStateMessage
        {
            get { return _currentStateMessage; }
        }

        public JointCreationHelper(JointType jointType,World world)
        {
            _jointType = jointType;
            _world = world;
            NextStep(Vector2.Zero);
        }
        public void NextStep(Vector2 position)
        {
            if (_step == 0)
            {
                _jointParameters = new JointParameters();
                _joint = null;
            }
            switch(_jointType)
            {
                case JointType.Angle:
                    NextStepAngleJoint(position);
                    break;
                case JointType.Distance:
                    NextStepDistanceJoint(position);
                    break;
                case JointType.FixedAngle:
                    NextStepFixedAngleJoint(position);
                    break;
                case JointType.FixedDistance:
                    NextStepFixedDistanceJoint(position);
                    break;
                case JointType.FixedFriction:
                    NextStepFixedFrictionJoint(position);
                    break;
                case JointType.FixedLine:
                    NextStepFixedLineJoint(position);
                    break;
                case JointType.FixedMouse:
                    NextStepFixedMouseJoint(position);
                    break;
                case JointType.FixedPrismatic:
                    NextStepFixedPrismaticJoint(position);
                    break;
                case JointType.FixedRevolute:
                    NextStepFixedRevoluteJoint(position);
                    break;
                case JointType.Friction:
                    NextStepFrictionJoint(position);
                    break;
                case JointType.Gear:
                    NextStepGearJoint(position);
                    break;
                case JointType.Line:
                    NextStepLineJoint(position);
                    break;
                case JointType.Prismatic:
                    NextStepPrismaticJoint(position);
                    break;
                case JointType.Pulley:
                    NextStepPulleyJoint(position);
                    break;
                case JointType.Revolute:
                    NextStepRevoluteJoint(position);
                    break;
                case JointType.Rope:
                    NextStepRopeJoint(position);
                    break;
                case JointType.Slider:
                    NextStepSliderJoint(position);
                    break;
                case JointType.Weld:
                    NextStepWeldJoint(position);
                    break;
                    
            }
        }

        private void NextStepAngleJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating angle joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null) 
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose BodyB...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null) 
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. ANGLE JOINT CREATED";
                    _jointParameters.bodyB = bodyB;
                    _joint = new AngleJoint(_jointParameters.bodyA, _jointParameters.bodyB);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepDistanceJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating distance joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null) 
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose LocalAnchorA...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Vector2 localAnchorA = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("AnchorA has been selected. Position - {0}, local position - {1}. Choose BodyB...", position.ToString(), localAnchorA.ToString());
                    _jointParameters.localAnchorA = localAnchorA;
                    _step++;
                    break;
                case 3:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null) 
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose LocalAnchorB...";
                    _jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 4:
                    Vector2 localAnchorB = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyB);
                    _currentStateMessage = string.Format("AnchorB has been selected. Position - {0}, local position - {1}. DISTANCE JOINT CREATED.", position.ToString(), localAnchorB.ToString());
                    _jointParameters.localAnchorB = localAnchorB;
                    _joint = new DistanceJoint(_jointParameters.bodyA, _jointParameters.bodyB, _jointParameters.localAnchorA, _jointParameters.localAnchorB);
                    _step=0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedAngleJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed angle joint. Choose Body...";
                    _step++;
                    break;
                case 1:
                    Body body = CommonHelpers.FindBody(position, _world);
                    if (body == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose Body...";
                        break;
                    }
                    _currentStateMessage = "Body has been selected. FIXED ANGLE JOINT CREATED";
                    _jointParameters.bodyA = body;
                    _joint = new FixedAngleJoint(_jointParameters.bodyA);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedDistanceJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed distance joint. Choose Body...";
                    _step++;
                    break;
                case 1:
                    Body body = CommonHelpers.FindBody(position, _world);
                    if (body == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose Body...";
                        break;
                    }
                    _currentStateMessage = "Body has been selected. Choose body anchor...";
                    _jointParameters.bodyA = body;
                    _step++;
                    break;
                case 2:
                    Vector2 bodyAnchor = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("Body anchor has been selected. Position - {0}, local position - {1}. Choose world anchor...", position.ToString(), bodyAnchor.ToString());
                    _jointParameters.localAnchorA = bodyAnchor;
                    _step++;
                    break;
                case 3:
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. FIXED DISTANCE JOINT CREATED.", position.ToString());
                    _jointParameters.worldAnchorA = position;
                    _joint = new FixedDistanceJoint(_jointParameters.bodyA, _jointParameters.localAnchorA, _jointParameters.worldAnchorA);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedFrictionJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed friction joint. Choose Body...";
                    _step++;
                    break;
                case 1:
                    Body body = CommonHelpers.FindBody(position, _world);
                    if (body == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose Body...";
                        break;
                    }
                    _currentStateMessage = "Body has been selected. Choose body anchor...";
                    _jointParameters.bodyA = body;
                    _step++;
                    break;
                case 2:
                    _currentStateMessage = "Body anchor has been selected. FIXED FRICTION JOINT CREATED";
                    _jointParameters.localAnchorA = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _joint = new FixedFrictionJoint(_jointParameters.bodyA, _jointParameters.localAnchorA);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedLineJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed line joint. Choose Body...";
                    _step++;
                    break;
                case 1:
                    Body body = CommonHelpers.FindBody(position, _world);
                    if (body == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose Body...";
                        break;
                    }
                    _currentStateMessage = "Body has been selected. Choose world anchor...";
                    _jointParameters.bodyA = body;
                    _step++;
                    break;
                case 2:
                    Vector2 worldAnchor = position;
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. Detecting axis. Select first axis point...", position.ToString());
                    _jointParameters.worldAnchorA = worldAnchor;
                    _step++;
                    break;
                case 3:
                    _currentStateMessage = string.Format("First axis point has been selected. Position - {0}. Detecting axis. Select second axis point...", position.ToString());
                    _jointParameters.axisFirst = position;
                    _step++;
                    break;
                case 4:
                    Vector2 axis = position - _jointParameters.axisFirst;
                    axis.Normalize();
                    _jointParameters.axisSecond = position;
                    _currentStateMessage = string.Format("Second axis point has been selected. Position - {0}, axis - {1}. FIXED LINE JOINT CREATED.", position.ToString(), axis.ToString());
                    _joint = new FixedLineJoint(_jointParameters.bodyA, _jointParameters.worldAnchorA, axis);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedMouseJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed mouse joint. Choose Body...";
                    _step++;
                    break;
                case 1:
                    Body body = CommonHelpers.FindBody(position, _world);
                    if (body == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose Body...";
                        break;
                    }
                    _currentStateMessage = "Body has been selected. Select world anchor...";
                    _jointParameters.bodyA = body;
                    _step++;
                    break;
                case 2:
                    Vector2 worldAnchor = position;
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. FIXED MOUSE JOINT CREATED.", position.ToString());
                    _jointParameters.worldAnchorA = worldAnchor;
                    _joint = new FixedMouseJoint(_jointParameters.bodyA, _jointParameters.worldAnchorA);
                    _step=0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedPrismaticJoint(Vector2 position)
        {

            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed prismaitc joint. Choose Body...";
                    _step++;
                    break;
                case 1:
                    Body body = CommonHelpers.FindBody(position, _world);
                    if (body == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose Body...";
                        break;
                    }
                    _currentStateMessage = "Body has been selected. Choose world anchor...";
                    _jointParameters.bodyA = body;
                    _step++;
                    break;
                case 2:
                    Vector2 worldAnchor = position;
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. Detecting axis. Select first axis point...", position.ToString());
                    _jointParameters.worldAnchorA = worldAnchor;
                    _step++;
                    break;
                case 3:
                    _currentStateMessage = string.Format("First axis point has been selected. Position - {0}. Detecting axis. Select second axis point...", position.ToString());
                    _jointParameters.axisFirst = position;
                    _step++;
                    break;
                case 4:
                    Vector2 axis = (position - _jointParameters.axisFirst);
                    axis.Normalize();
                    _jointParameters.axisSecond = position;
                    _currentStateMessage = string.Format("Second axis point has been selected. Position - {0}, axis - {1}. FIXED PRISMATIC JOINT CREATED.", position.ToString(), axis.ToString());
                    _joint = new FixedPrismaticJoint(_jointParameters.bodyA, _jointParameters.worldAnchorA, axis);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedRevoluteJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed revolute joint. Choose Body...";

                    _step++;
                    break;
                case 1:
                    Body body = CommonHelpers.FindBody(position, _world);
                    if (body == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose Body...";
                        break;
                    }
                    _currentStateMessage = "Body has been selected. Choose body anchor...";
                    _jointParameters.bodyA = body;
                    _step++;
                    break;
                case 2:
                    Vector2 bodyAnchor = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("Body anchor has been selected. Position - {0}, local position - {1}. Choose world anchor...", position.ToString(), bodyAnchor.ToString());
                    _jointParameters.localAnchorA = bodyAnchor;
                    _step++;
                    break;
                case 3:
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. FIXED DISTANCE JOINT CREATED.", position.ToString());
                    _jointParameters.worldAnchorA = position;
                    _joint = new FixedRevoluteJoint(_jointParameters.bodyA, _jointParameters.localAnchorA, _jointParameters.worldAnchorA);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFrictionJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating friction joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose LocalAnchorA...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Vector2 localAnchorA = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("AnchorA has been selected. Position - {0}, local position - {1}. Choose BodyB...", position.ToString(), localAnchorA.ToString());
                    _jointParameters.localAnchorA = localAnchorA;
                    _step++;
                    break;
                case 3:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose LocalAnchorB...";
                    _jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 4:
                    Vector2 localAnchorB = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyB);
                    _currentStateMessage = string.Format("AnchorB has been selected. Position - {0}, local position - {1}. FRICTION JOINT CREATED.", position.ToString(), localAnchorB.ToString());
                    _jointParameters.localAnchorB = localAnchorB;
                    _joint = new FrictionJoint(_jointParameters.bodyA, _jointParameters.bodyB, _jointParameters.localAnchorA, _jointParameters.localAnchorB);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
            
        }

        private void NextStepGearJoint(Vector2 position)
        {
            throw new NotImplementedException("GearJoint");
        }

        private void NextStepLineJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating Line joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose BodyB...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose world anchor...";
                    _jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 3:
                    Vector2 worldAnchor = position;
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. Detecting axis. Choose first axis point...", position.ToString());
                    _jointParameters.worldAnchorA = worldAnchor;
                    _step++;
                    break;
                case 4:
                    _currentStateMessage = string.Format("First axis point has been selected. Position - {0}. Detecting axis. Select second axis point...", position.ToString());
                    _jointParameters.axisFirst = position;
                    _step++;
                    break;
                case 5:
                    Vector2 axis = (position - _jointParameters.axisFirst);
                    axis.Normalize();
                    _jointParameters.axisSecond = position;
                    _currentStateMessage = string.Format("Second axis point has been selected. Position - {0}, axis - {1}. LINE JOINT CREATED.", position.ToString(), axis.ToString());
                    _joint = new LineJoint(_jointParameters.bodyA, _jointParameters.bodyB, _jointParameters.worldAnchorA, axis);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepPrismaticJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating prismatic joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose LocalAnchorA...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Vector2 localAnchorA = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("AnchorA has been selected. Position - {0}, local position - {1}. Choose BodyB...", position.ToString(), localAnchorA.ToString());
                    _jointParameters.localAnchorA = localAnchorA;
                    _step++;
                    break;
                case 3:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose LocalAnchorB...";
                    _jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 4:
                    Vector2 localAnchorB = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyB);
                    _currentStateMessage = string.Format("AnchorB has been selected. Position - {0}, local position - {1}. Detecting axis. Select first axis point...", position.ToString(), localAnchorB.ToString());
                    _jointParameters.localAnchorB = localAnchorB;
                    _step++;
                    break;
                case 5:
                    _currentStateMessage = string.Format("First axis point has been selected. Position - {0}. Detecting axis. Select second axis point...", position.ToString());
                    _jointParameters.axisFirst = position;
                    _step++;
                    break;
                case 6:
                    Vector2 axis = (position - _jointParameters.axisFirst);
                    axis.Normalize();
                    _jointParameters.axisSecond = position;
                    _currentStateMessage = string.Format("Second axis point has been selected. Position - {0}, axis - {1}. PRISMATIC JOINT CREATED.", position.ToString(), axis.ToString());
                    _joint = new PrismaticJoint(_jointParameters.bodyA, _jointParameters.bodyB, _jointParameters.localAnchorA, _jointParameters.localAnchorB,axis);
                    _step = 0;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepPulleyJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating pulley joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose LocalAnchorA...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Vector2 localAnchorA = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("LocalAnchorA has been selected. Position - {0}, local position - {1}. Choose GroundAnchorA...", position.ToString(), localAnchorA.ToString());
                    _jointParameters.localAnchorA = localAnchorA;
                    _step++;
                    break;
                case 3:
                    Vector2 groundAnchorA = position;
                    _currentStateMessage = string.Format("GroundAnchorA has been selected. Position - {0}. Choose BodyB...", position.ToString());
                    _jointParameters.worldAnchorA = groundAnchorA;
                    _step++;
                    break;
                case 4:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose LocalAnchorB...";
                    _jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 5:
                    Vector2 localAnchorB = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyB);
                    _currentStateMessage = string.Format("LocalAnchorB has been selected. Position - {0}, local position - {1}. Choose GroundAnchorB.", position.ToString(), localAnchorB.ToString());
                    _jointParameters.localAnchorB = localAnchorB;
                    _step++;
                    break;
                case 6:
                    Vector2 groundAnchorB = position;
                    _currentStateMessage = string.Format("GroundAnchorB has been selected. Position - {0}. PULLEY JOINT CREATED.", position.ToString());
                    _jointParameters.worldAnchorB = groundAnchorB;
                    _joint = new PulleyJoint(_jointParameters.bodyA, _jointParameters.bodyB, _jointParameters.worldAnchorA, _jointParameters.worldAnchorB, _jointParameters.localAnchorA, _jointParameters.localAnchorB, 1f);
                    _step=0;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepRevoluteJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating revolute joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose LocalAnchorA...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Vector2 localAnchorA = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("AnchorA has been selected. Position - {0}, local position - {1}. Choose BodyB...", position.ToString(), localAnchorA.ToString());
                    _jointParameters.localAnchorA = localAnchorA;
                    _step++;
                    break;
                case 3:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose LocalAnchorB...";
                    _jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 4:
                    Vector2 localAnchorB = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyB);
                    _currentStateMessage = string.Format("AnchorB has been selected. Position - {0}, local position - {1}. REVOLUTE JOINT CREATED.", position.ToString(), localAnchorB.ToString());
                    _jointParameters.localAnchorB = localAnchorB;
                    _joint = new RevoluteJoint(_jointParameters.bodyA, _jointParameters.bodyB, _jointParameters.localAnchorA, _jointParameters.localAnchorB);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepRopeJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating rope joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose LocalAnchorA...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Vector2 localAnchorA = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("AnchorA has been selected. Position - {0}, local position - {1}. Choose BodyB...", position.ToString(), localAnchorA.ToString());
                    _jointParameters.localAnchorA = localAnchorA;
                    _step++;
                    break;
                case 3:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose LocalAnchorB...";
                    _jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 4:
                    Vector2 localAnchorB = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyB);
                    _currentStateMessage = string.Format("AnchorB has been selected. Position - {0}, local position - {1}. ROPE JOINT CREATED.", position.ToString(), localAnchorB.ToString());
                    _jointParameters.localAnchorB = localAnchorB;
                    _joint = new RopeJoint(_jointParameters.bodyA, _jointParameters.bodyB, _jointParameters.localAnchorA, _jointParameters.localAnchorB);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepSliderJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating slider joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose LocalAnchorA...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Vector2 localAnchorA = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("AnchorA has been selected. Position - {0}, local position - {1}. Choose BodyB...", position.ToString(), localAnchorA.ToString());
                    _jointParameters.localAnchorA = localAnchorA;
                    _step++;
                    break;
                case 3:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose LocalAnchorB...";
                    _jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 4:
                    Vector2 localAnchorB = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyB);
                    _currentStateMessage = string.Format("AnchorB has been selected. Position - {0}, local position - {1}. SLIDER JOINT CREATED.", position.ToString(), localAnchorB.ToString());
                    _jointParameters.localAnchorB = localAnchorB;
                    _joint = new SliderJoint(_jointParameters.bodyA, _jointParameters.bodyB, _jointParameters.localAnchorA, _jointParameters.localAnchorB,1f,2f);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }

        }

        private void NextStepWeldJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating weld joint. Choose BodyA...";
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose LocalAnchorA...";
                    _jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Vector2 localAnchorA = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyA);
                    _currentStateMessage = string.Format("AnchorA has been selected. Position - {0}, local position - {1}. Choose BodyB...", position.ToString(), localAnchorA.ToString());
                    _jointParameters.localAnchorA = localAnchorA;
                    _step++;
                    break;
                case 3:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null)
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose LocalAnchorB...";
                    _jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 4:
                    Vector2 localAnchorB = CommonHelpers.CalculateLocalPoint(position, _jointParameters.bodyB);
                    _currentStateMessage = string.Format("AnchorB has been selected. Position - {0}, local position - {1}. WELD JOINT CREATED.", position.ToString(), localAnchorB.ToString());
                    _jointParameters.localAnchorB = localAnchorB;
                    _joint = new WeldJoint(_jointParameters.bodyA, _jointParameters.bodyB, _jointParameters.localAnchorA, _jointParameters.localAnchorB);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }
    }
}

