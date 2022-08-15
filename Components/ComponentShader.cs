using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenGL_Game.Managers;
using OpenGL_Game.OBJLoader;

namespace OpenGL_Game.Components
{
    /// <summary>
    /// The base shader class
    /// </summary>
    abstract class ComponentShader : IComponent
    {
        public int pgmID;
        int fsID;
        int vsID;

        public ComponentShader(string vertexShaderName, string fragmentShaderName)
        {
            pgmID = GL.CreateProgram();
            vsID = ResourceManager.LoadShader(vertexShaderName, ShaderType.VertexShader);
            fsID = ResourceManager.LoadShader(fragmentShaderName, ShaderType.FragmentShader);

            GL.AttachShader(pgmID, vsID);
            GL.AttachShader(pgmID, fsID);
            GL.LinkProgram(pgmID);
            Console.WriteLine(GL.GetProgramInfoLog(pgmID));
        }

        public abstract void ApplyShader(Matrix4 Model, Geometry geometry);

        public ComponentTypes ComponentType
        {
            get { return ComponentTypes.COMPONENT_SHADER; }
        }
    }
}
