﻿/*
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
               0.54f , 0.29f , 0.0f, 
               0.0f , 0.611f , 0.0392f,
               0.45f , 0.29f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.45f , 0.06f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.45f , 0.06f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.54f , 0.06f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.54f , 0.29f , 0.0f,
               0.0f , 0.611f , 0.0392f,

               //right hand
               0.54f,0.06f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.45f,0.06f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.54f,-0.17f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.45f,-0.17f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.54f,-0.17f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.45f,0.06f,0.0f,
               255f/255f, 204f/255f, 115f/255f,

               //right shirt
               0.45f , 0.38f,0.0f,
               0.0f , 0.611f , 0.0392f,
               0.25f , 0.38f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.25f, -0.055f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.25f, -0.055f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.45f, -0.055f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.45f , 0.38f,0.0f,
               0.0f , 0.611f , 0.0392f,

               //upper chest
               0.25f , 0.38f , 0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.09f , 0.38f, 0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.09f,0.29f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.09f,0.29f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.25f,0.29f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.25f , 0.38f , 0.0f,
               255f/255f, 204f/255f, 115f/255f,

               //top
               0.25f,0.29f,0.0f,
               255f, 255f, 255f,
               0.09f,0.29f,0.0f,
               255f, 255f, 255f,
               0.09f, -0.055f , 0.0f,
               255f, 255f, 255f,
               0.09f, -0.055f , 0.0f,
               255f, 255f, 255f,
               0.25f,-0.055f,0.0f,
               255f, 255f, 255f,
               0.25f,0.29f,0.0f,
               255f, 255f, 255f,

               //Left Shirt
               0.09f,0.38f,0.0f,
               0.0f , 0.611f , 0.0392f,
               -0.11f , 0.38f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               -0.11f , -0.055f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               -0.11f , -0.055f , 0.0f,
               0.0f , 0.611f , 0.0392f,
               0.09f,-0.055f,0.0f,
               0.0f , 0.611f , 0.0392f,
               0.09f,0.38f,0.0f,
               0.0f , 0.611f , 0.0392f,

               //left hand of shirt
               -0.11f,0.29f,0.0f,
               0.0f , 0.611f , 0.0392f,
               -0.2f,0.29f,0.0f,
               0.0f , 0.611f , 0.0392f,
               -0.2f,0.06f,0.0f,
               0.0f , 0.611f , 0.0392f,
               -0.2f,0.06f,0.0f,
               0.0f , 0.611f , 0.0392f,
               -0.11f,0.06f,0.0f,
               0.0f , 0.611f , 0.0392f,
               -0.11f,0.29f,0.0f,
               0.0f , 0.611f , 0.0392f,

               //left hand
               -0.11f,0.06f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               -0.2f,0.06f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               -0.2f,-0.17f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               -0.2f,-0.17f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               -0.11f,-0.17f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               -0.11f,0.06f,0.0f,
               255f/255f, 204f/255f, 115f/255f,

               //bottom of head
               0.17f,0.6f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.01f,0.38f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.35f,0.38f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               
               //top of head
               0.17f,0.6f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.01f,0.82f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.35f,0.82f,0.0f,
               255f/255f, 204f/255f, 115f/255f,

               //left part of head
               0.17f,0.6f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.01f,0.82f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.009f,0.81f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.008f,0.80f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.007f,0.79f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.006f,0.78f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.005f,0.77f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.004f,0.76f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.003f,0.75f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.002f,0.74f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.001f,0.73f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0009f,0.72f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0008f,0.71f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0007f,0.70f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0006f,0.69f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0005f,0.68f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0004f,0.67f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0003f,0.66f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0002f,0.65f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0001f,0.64f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.00009f,0.63f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.00008f,0.62f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.00007f,0.61f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.00006f,0.60f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.00006f,0.59f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.00007f,0.58f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.00008f,0.57f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.00009f,0.56f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0001f,0.55f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0002f,0.54f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0003f,0.53f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0004f,0.52f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0005f,0.51f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0006f,0.50f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0007f,0.49f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0006f,0.48f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0007f,0.47f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0008f,0.46f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.0009f,0.45f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.001f,0.44f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.002f,0.43f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.006f,0.42f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.007f,0.41f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.008f,0.40f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.009f,0.39f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.01f,0.38f,0.0f,
               255f/255f, 204f/255f, 115f/255f,

               //right part of the head
               0.17f,0.6f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.35f,0.82f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.36f,0.81f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.361f,0.80f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.362f,0.79f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.363f,0.78f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.364f,0.77f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.365f,0.76f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.366f,0.75f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.367f,0.74f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.368f,0.73f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.369f,0.72f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.370f,0.71f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.371f,0.70f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.372f,0.69f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.373f,0.68f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.374f,0.67f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.375f,0.66f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.376f,0.65f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.377f,0.64f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.378f,0.63f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.379f,0.62f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.380f,0.61f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.380f,0.60f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.380f,0.59f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.379f,0.58f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.378f,0.57f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.377f,0.56f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.376f,0.55f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.375f,0.54f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.374f,0.53f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.373f,0.52f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.372f,0.51f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.371f,0.50f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.370f,0.49f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.369f,0.48f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.368f,0.47f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.367f,0.46f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.366f,0.45f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.365f,0.44f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.364f,0.43f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.363f,0.42f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.362f,0.41f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.361f,0.40f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.360f,0.39f,0.0f,
               255f/255f, 204f/255f, 115f/255f,
               0.35f,0.38f,0.0f,
               255f/255f, 204f/255f, 115f/255f

               //hair


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
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 0 , 6);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 6 , 6);

            //right shirt
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 12 , 6);

            //upper chest
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 18 , 6);

            //Top
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 24, 6);

            //Left Shirt
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 30, 6);

            //Left arm
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 36, 6);
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 42, 6);

            //botton of head
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 48, 3);

            //top of head
            Gl.glDrawArrays(Gl.GL_TRIANGLES, 51, 3);

            //left part of head
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 54, 46);

            //right part of head
            Gl.glDrawArrays(Gl.GL_TRIANGLE_FAN, 100, 46);

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
