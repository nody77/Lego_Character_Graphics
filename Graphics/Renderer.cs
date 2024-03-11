using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Graphics
{
    class Renderer
    {
        Shader sh;
        uint vertexBufferID;
        public void Initialize()
        {
            string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            sh = new Shader(projectPath + "\\Shaders\\SimpleVertexShader.vertexshader",
                projectPath + "\\Shaders\\SimpleFragmentShader.fragmentshader");
            Gl.glClearColor(0.5f, 0.87f, 0.91f, 1);
            
            float[] points =
            {
                0.7f , 0.1f , 0 , //right up corner
                0.7f , -0.1f , 0 , //right down corner
                -0.3f , 0.1f , 0 , // left up corner
                -0.5f , 0.1f , 0 ,
                0.5f , -0.1f , 0 ,
                -0.5f, -0.1f, 0 
            };
            vertexBufferID = GPU.GenerateBuffer(points);
        }

        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            sh.UseShader();
            //
            Gl.glEnableVertexAttribArray(0);
            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, (sizeof(float))*3, IntPtr.Zero);
            //
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 3);
            
            Gl.glDisableVertexAttribArray(0);
        }
        public void Update()
        {

        }
        public void CleanUp()
        {
            sh.DestroyShader();
        }
    }
}
