/*
    Nada Ahmed Fathalla
    2021170580
    CS
    Section 7
*/
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
                // right hand of shirt
               0.6f , 0.29f , 0.0f, 
               0.0f , 0.611f , 0.0392f,
               0.51f , 0.29f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.51f , 0.06f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.51f , 0.06f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.6f , 0.06f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.6f , 0.29f , 0.0f,
               0.0f , 0.611f , 0.0392f,

               //right hand
               0.6f,0.06f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.51f,0.06f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.6f,-0.17f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.51f,-0.17f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.6f,-0.17f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.51f,0.06f,0.0f,
               255f/255f, 204f/255f, 115f/255f,

               //right shirt
               0.51f , 0.38f,0.0f,
               0.0f , 0.611f , 0.0392f,
               0.31f , 0.38f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.31f, -0.055f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.31f, -0.055f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.51f, -0.055f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.51f , 0.38f,0.0f,
               0.0f , 0.611f , 0.0392f,
            };

            

            vertexBufferID = GPU.GenerateBuffer(points);
           
        }

        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            sh.UseShader();
            
            Gl.glEnableVertexAttribArray(0);
            Gl.glEnableVertexAttribArray(1);

            Gl.glVertexAttribPointer(0, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, IntPtr.Zero);
            Gl.glVertexAttribPointer(1, 3, Gl.GL_FLOAT, Gl.GL_FALSE, sizeof(float) * 6, (IntPtr)(sizeof(float) * 3));
            
            //right arm
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0, 6);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 6, 6);

            //right shirt
            Gl.glDrawArrays(Gl.GL_TRIANGLES,12 , 6);

            Gl.glDisableVertexAttribArray(1);
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
