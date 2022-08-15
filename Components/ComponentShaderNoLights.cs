using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenGL_Game.Scenes;
using OpenGL_Game.OBJLoader;

namespace OpenGL_Game.Components
{
    /// <summary>
    /// The shader class for objects that have no light altering. It works purely on ambient light. 
    /// This is only used on the skybox as that needs consistent lighting across its face
    /// </summary>
    class ComponentShaderNoLights : ComponentShader
    {
        public int uniform_stex;
        public int uniform_mmodelviewproj;
        public int uniform_mmodel;
        public int uniform_diffuse;


        public ComponentShaderNoLights() : base("Game Files/Shaders/vs.glsl", "Game Files/Shaders/fs_nolights.glsl")
        {
            uniform_stex = GL.GetUniformLocation(pgmID, "s_texture");
            uniform_mmodelviewproj = GL.GetUniformLocation(pgmID, "ModelViewProjMat");
            uniform_mmodel = GL.GetUniformLocation(pgmID, "ModelMat");
            uniform_diffuse = GL.GetUniformLocation(pgmID, "v_diffuse");
        }

        public override void ApplyShader(Matrix4 Model, Geometry geometry)
        {
            GL.UseProgram(pgmID);

            GL.Uniform1(uniform_stex, 0);
            GL.ActiveTexture(TextureUnit.Texture0);

            GL.UniformMatrix4(uniform_mmodel, false, ref Model);
            Matrix4 modelViewProjection = Model * GameScene.gameInstance.camera.view * GameScene.gameInstance.camera.projection;
            GL.UniformMatrix4(uniform_mmodelviewproj, false, ref modelViewProjection);

            geometry.Render(uniform_diffuse);

            GL.UseProgram(0);
        }
    }
}
