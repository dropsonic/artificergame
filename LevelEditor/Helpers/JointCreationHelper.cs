using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics.Joints;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;

namespace LevelEditor.Helpers
{
    interface IJointParameters
    {}
    class DistanceJointParameters:IJointParameters
    {
        public Body bodyA;
        public Body bodyB;
        public Vector2 localAnchorA;
        public Vector2 localAnchorB;
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
                    NextStepDistanceJoint(position);
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
        private void NextStepDistanceJoint(Vector2 position)
        {
            DistanceJointParameters jointParameters = (DistanceJointParameters)_jointParameters;
            switch (_step)
            {
                case 0:
                    _currentStateMessage = "Creating distance joint. Choose BodyA...";
                    _jointParameters = new DistanceJointParameters();
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
                    Vector2 localAnchorA = Vector2.Transform(position - jointParameters.bodyA.Position, 
                                                            Matrix.CreateRotationZ(-jointParameters.bodyA.Rotation));
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
                    Vector2 localAnchorB = Vector2.Transform(position - jointParameters.bodyB.Position,
                                                            Matrix.CreateRotationZ(-jointParameters.bodyB.Rotation));
                    _currentStateMessage = string.Format("AnchorB has been selected. Position - {0}, local position - {1}. JointCreated.", position.ToString(), localAnchorB.ToString());
                    jointParameters.localAnchorB = localAnchorB;
                    _joint = new DistanceJoint(jointParameters.bodyA, jointParameters.bodyB, jointParameters.localAnchorA, jointParameters.localAnchorB);
                    _step++;
                    break;
                default:
                    _currentStateMessage = "Creation Finished. Reset";
                    _joint = null;
                    _step = 0;
                    break;
            }
        }
        private void NextStepFixedAngleJoint(Vector2 position)
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
        private void NextStepFixedDistanceJoint(Vector2 position)
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
        private void NextStepFixedFrictionJoint(Vector2 position)
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
        private void NextStepFixedLineJoint(Vector2 position)
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
        private void NextStepFixedMouseJoint(Vector2 position)
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
        private void NextStepFixedPrismaticJoint(Vector2 position)
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
        private void NextStepFixedRevoluteJoint(Vector2 position)
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
