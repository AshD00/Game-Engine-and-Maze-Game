using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenGL_Game.Managers;
using OpenGL_Game.OBJLoader;

namespace OpenGL_Game.Components
{
    /// <summary>
    /// The collision component class for spherical objects. This is also used for walls as I could not complete the line/line collision code
    /// </summary>
    class ComponentCollisionSphere : IComponent
    {
        float radius;

        public ComponentCollisionSphere(float x)
        {
            radius = x;
        }

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_SPHERECOLLISION; }
        }
    }
    class ComponentCollisionLine : IComponent
    {
        float size;
        public ComponentCollisionLine(float x)
        {
            size = x;
        }
        public float Size
        {
            get { return size; }
            set { size = value; }
        }
        public float dist(Vector3 camPos, Vector3 pointPos)
        {
            float deltaX = camPos.X - pointPos.X;
            float deltaY = camPos.Y - pointPos.Y;
            float deltaZ = camPos.Z - pointPos.Z;

            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_LINECOLLISION; }
        }
    }
}
