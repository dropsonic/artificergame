using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics.Joints;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;

namespace LevelEditor.Helpers
{
    interface IJointParameters {}
    class DistanceJointParameters:IJointParameters
    {
        public Body bodyA;
        public Body bodyB;
        public Vector2 localAnchorA;
        public Vector2 localAnchorB;
    }
    class AngleJointParameters:IJointParameters
    {
        public Body bodyA;
        public Body bodyB;
    }
    class FixedAngleJointParameters:IJointParameters
    {
        public Body body;
    }
    class FixedDistanceJointParameters:IJointParameters
    {
        public Body body;
        public Vector2 bodyAnchor;
        public Vector2 worldAnchor;
    }
    class FixedFrictionJointParameters:IJointParameters
    {
        public Body body;
        public Vector2 localAnchor;
    }
    class FixedLineJointParameters:IJointParameters
    {
        public Body body;
        public Vector2 worldAnchor;
        public Vector2 axisFirst;
        public Vector2 axisSecond;
    }
    class FixedMouseJointParameters:IJointParameters
    {
        public Body body;
        public Vector2 worldAnchor;
    }
    class FixedPrismaticJointParameters : IJointParameters
    {
        public Body body;
        public Vector2 worldAnchor;
        public Vector2 axisFirst;
        public Vector2 axisSecond;
    }
    class FixedRevoluteJointParameters : IJointParameters
    {
        public Body body;
        public Vector2 bodyAnchor;
        public Vector2 worldAnchor;
    }

    public class JointCreationHelper
    {
        private JointType _jointType;
        private int _step = 0;
        private IJointParameters _jointParameters;
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
            AngleJointParameters jointParameters = (AngleJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating angle joint. Choose BodyA...";
                    _jointParameters = new AngleJointParameters();
                    _joint = null;
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
                    jointParameters.bodyA = bodyA;
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
                    jointParameters.bodyB = bodyB;
                    _joint = new AngleJoint(jointParameters.bodyA,jointParameters.bodyB);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepDistanceJoint(Vector2 position)
        {
            DistanceJointParameters jointParameters = (DistanceJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating distance joint. Choose BodyA...";
                    _jointParameters = new DistanceJointParameters();
                    _joint = null;
                    _step++;
                    break;
                case 1:
                    Body bodyA = CommonHelpers.FindBody(position, _world);
                    if (bodyA == null) 
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyA...";
                        break;
                    }
                    _currentStateMessage = "BodyA has been selected. Choose AnchorA...";
                    jointParameters.bodyA = bodyA;
                    _step++;
                    break;
                case 2:
                    Vector2 localAnchorA = CommonHelpers.CalculateLocalPoint(position, jointParameters.bodyA);
                    _currentStateMessage = string.Format("AnchorA has been selected. Position - {0}, local position - {1}. Choose BodyB...", position.ToString(), localAnchorA.ToString());
                    jointParameters.localAnchorA = localAnchorA;
                    _step++;
                    break;
                case 3:
                    Body bodyB = CommonHelpers.FindBody(position, _world);
                    if (bodyB == null) 
                    {
                        _currentStateMessage = "Cant find body in this position. Choose BodyB...";
                        break;
                    }
                    _currentStateMessage = "BodyB has been selected. Choose AnchorB...";
                    jointParameters.bodyB = bodyB;
                    _step++;
                    break;
                case 4:
                    Vector2 localAnchorB = CommonHelpers.CalculateLocalPoint(position, jointParameters.bodyB);
                    _currentStateMessage = string.Format("AnchorB has been selected. Position - {0}, local position - {1}. DISTANCE JOINT CREATED.", position.ToString(), localAnchorB.ToString());
                    jointParameters.localAnchorB = localAnchorB;
                    _joint = new DistanceJoint(jointParameters.bodyA, jointParameters.bodyB, jointParameters.localAnchorA, jointParameters.localAnchorB);
                    _step=0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedAngleJoint(Vector2 position)
        {
            FixedAngleJointParameters jointParameters = (FixedAngleJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed angle joint. Choose Body...";
                    _jointParameters = new FixedAngleJointParameters();
                    _joint = null;
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
                    jointParameters.body = body;
                    _joint = new FixedAngleJoint(jointParameters.body);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedDistanceJoint(Vector2 position)
        {
            FixedDistanceJointParameters jointParameters = (FixedDistanceJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed distance joint. Choose Body...";
                    _jointParameters = new FixedDistanceJointParameters();
                    _joint = null;
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
                    jointParameters.body = body;
                    _step++;
                    break;
                case 2:
                    Vector2 bodyAnchor = CommonHelpers.CalculateLocalPoint(position, jointParameters.body);
                    _currentStateMessage = string.Format("Body anchor has been selected. Position - {0}, local position - {1}. Choose world anchor...", position.ToString(), bodyAnchor.ToString());
                    jointParameters.bodyAnchor = bodyAnchor;
                    _step++;
                    break;
                case 3:
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. FIXED DISTANCE JOINT CREATED.", position.ToString());
                    jointParameters.worldAnchor = position;
                    _joint = new FixedDistanceJoint(jointParameters.body, jointParameters.bodyAnchor, jointParameters.worldAnchor);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedFrictionJoint(Vector2 position)
        {
            FixedFrictionJointParameters jointParameters = (FixedFrictionJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed friction joint. Choose Body...";
                    _jointParameters = new FixedFrictionJointParameters();
                    _joint = null;
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
                    jointParameters.body = body;
                    _step++;
                    break;
                case 2:
                    _currentStateMessage = "Body anchor has been selected. FIXED FRICTION JOINT CREATED";
                    jointParameters.localAnchor = CommonHelpers.CalculateLocalPoint(position, jointParameters.body);
                    _joint = new FixedFrictionJoint(jointParameters.body, jointParameters.localAnchor);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedLineJoint(Vector2 position)
        {
            FixedLineJointParameters jointParameters = (FixedLineJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed line joint. Choose Body...";
                    _jointParameters = new FixedLineJointParameters();
                    _joint = null;
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
                    jointParameters.body = body;
                    _step++;
                    break;
                case 2:
                    Vector2 worldAnchor = position;
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. Detecting axis. Select first axis point...", position.ToString());
                    jointParameters.worldAnchor = worldAnchor;
                    _step++;
                    break;
                case 3:
                    _currentStateMessage = string.Format("First axis point has been selected. Position - {0}. Detecting axis. Select second axis point...", position.ToString());
                    jointParameters.axisFirst = position;
                    _step++;
                    break;
                case 4:
                    Vector2 axis = position - jointParameters.axisFirst;
                    axis.Normalize();
                    jointParameters.axisSecond = position;
                    _currentStateMessage = string.Format("Second axis point has been selected. Position - {0}, axis - {1}. FIXED LINE JOINT CREATED.", position.ToString(), axis.ToString());
                    _joint = new FixedLineJoint(jointParameters.body, jointParameters.worldAnchor, axis);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedMouseJoint(Vector2 position)
        {
            FixedMouseJointParameters jointParameters = (FixedMouseJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed mouse joint. Choose Body...";
                    _jointParameters = new FixedMouseJointParameters();
                    _joint = null;
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
                    jointParameters.body = body;
                    _step++;
                    break;
                case 2:
                    Vector2 worldAnchor = position;
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. FIXED MOUSE JOINT CREATED.", position.ToString());
                    jointParameters.worldAnchor = worldAnchor;
                    _joint = new FixedMouseJoint(jointParameters.body, jointParameters.worldAnchor);
                    _step=0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedPrismaticJoint(Vector2 position)
        {
            FixedPrismaticJointParameters jointParameters = (FixedPrismaticJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed prismaitc joint. Choose Body...";
                    _jointParameters = new FixedPrismaticJointParameters();
                    _joint = null;
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
                    jointParameters.body = body;
                    _step++;
                    break;
                case 2:
                    Vector2 worldAnchor = position;
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. Detecting axis. Select first axis point...", position.ToString());
                    jointParameters.worldAnchor = worldAnchor;
                    _step++;
                    break;
                case 3:
                    _currentStateMessage = string.Format("First axis point has been selected. Position - {0}. Detecting axis. Select second axis point...", position.ToString());
                    jointParameters.axisFirst = position;
                    _step++;
                    break;
                case 4:
                    Vector2 axis = (position - jointParameters.axisFirst);
                    axis.Normalize();
                    jointParameters.axisSecond = position;
                    _currentStateMessage = string.Format("Second axis point has been selected. Position - {0}, axis - {1}. FIXED PRISMATIC JOINT CREATED.", position.ToString(), axis.ToString());
                    _joint = new FixedPrismaticJoint(jointParameters.body, jointParameters.worldAnchor, axis);
                    _step = 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Unknown join creation step");
            }
        }

        private void NextStepFixedRevoluteJoint(Vector2 position)
        {
            FixedRevoluteJointParameters jointParameters = (FixedRevoluteJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating fixed revolute joint. Choose Body...";
                    _jointParameters = new FixedRevoluteJointParameters();
                    _joint = null;
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
                    jointParameters.body = body;
                    _step++;
                    break;
                case 2:
                    Vector2 bodyAnchor = CommonHelpers.CalculateLocalPoint(position, jointParameters.body);
                    _currentStateMessage = string.Format("Body anchor has been selected. Position - {0}, local position - {1}. Choose world anchor...", position.ToString(), bodyAnchor.ToString());
                    jointParameters.bodyAnchor = bodyAnchor;
                    _step++;
                    break;
                case 3:
                    _currentStateMessage = string.Format("World anchor has been selected. Position - {0}. FIXED DISTANCE JOINT CREATED.", position.ToString());
                    jointParameters.worldAnchor = position;
                    _joint = new FixedRevoluteJoint(jointParameters.body, jointParameters.bodyAnchor, jointParameters.worldAnchor);
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
                    _currentStateMessage = string.Format("BodyA (local position - {0}). Choose BodyB...", position.ToString());
                    _step++;
                    break;
                case 1:
                    _currentStateMessage = string.Format("BodyB (local position - {0}). {1} joint created.", position.ToString(), _jointType.ToString());
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished";
                    break;
            }
        }
        private void NextStepGearJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = string.Format("BodyA (local position - {0}). Choose BodyB...", position.ToString());
                    _step++;
                    break;
                case 1:
                    _currentStateMessage = string.Format("BodyB (local position - {0}). {1} joint created.", position.ToString(), _jointType.ToString());
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished";
                    break;
            }
        }
        private void NextStepLineJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = string.Format("BodyA (local position - {0}). Choose BodyB...", position.ToString());
                    _step++;
                    break;
                case 1:
                    _currentStateMessage = string.Format("BodyB (local position - {0}). {1} joint created.", position.ToString(), _jointType.ToString());
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished";
                    break;
            }
        }
        private void NextStepPrismaticJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = string.Format("BodyA (local position - {0}). Choose BodyB...", position.ToString());
                    _step++;
                    break;
                case 1:
                    _currentStateMessage = string.Format("BodyB (local position - {0}). {1} joint created.", position.ToString(), _jointType.ToString());
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished";
                    break;
            }
        }
        private void NextStepPulleyJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = string.Format("BodyA (local position - {0}). Choose BodyB...", position.ToString());
                    _step++;
                    break;
                case 1:
                    _currentStateMessage = string.Format("BodyB (local position - {0}). {1} joint created.", position.ToString(), _jointType.ToString());
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished";
                    break;
            }
        }
        private void NextStepRevoluteJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = string.Format("BodyA (local position - {0}). Choose BodyB...", position.ToString());
                    _step++;
                    break;
                case 1:
                    _currentStateMessage = string.Format("BodyB (local position - {0}). {1} joint created.", position.ToString(), _jointType.ToString());
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished";
                    break;
            }
        }
        private void NextStepRopeJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = string.Format("BodyA (local position - {0}). Choose BodyB...", position.ToString());
                    _step++;
                    break;
                case 1:
                    _currentStateMessage = string.Format("BodyB (local position - {0}). {1} joint created.", position.ToString(), _jointType.ToString());
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished";
                    break;
            }
        }
        private void NextStepSliderJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = string.Format("BodyA (local position - {0}). Choose BodyB...", position.ToString());
                    _step++;
                    break;
                case 1:
                    _currentStateMessage = string.Format("BodyB (local position - {0}). {1} joint created.", position.ToString(), _jointType.ToString());
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished";
                    break;
            }
        }
        private void NextStepWeldJoint(Vector2 position)
        {
            switch (_step)
            {
                case 0:
                    _currentStateMessage = string.Format("BodyA (local position - {0}). Choose BodyB...", position.ToString());
                    _step++;
                    break;
                case 1:
                    _currentStateMessage = string.Format("BodyB (local position - {0}). {1} joint created.", position.ToString(), _jointType.ToString());
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished";
                    break;
            }
        }
    }
}

