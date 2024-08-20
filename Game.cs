using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea_opentk
{
    internal class Game : GameWindow
    {


        private readonly float[] vertices =
        {
            //Triangulo
            /*
            -0.5f, -0.5f, 0.0f, // Bottom-left vertex
            0.5f, -0.5f, 0.0f, // Bottom-right vertex
            0.0f,  0.5f, 0.0f  // Top vertex
            */
            
            // Cuadrado
            /*
            -0.5f, -0.5f, 0.0f, // Bottom-left
             0.5f, -0.5f, 0.0f, // Bottom-right
            -0.5f,  0.5f, 0.0f, // Top-left

            
             0.5f, -0.5f, 0.0f, // Bottom-right
            -0.5f,  0.5f, 0.0f, // Top-left
             0.5f,  0.5f, 0.0f  // Top-right
            */

            // T            
            -0.3f,  0.5f, 0.0f,  // Top-left
             0.3f,  0.5f, 0.0f,  // Top-right
            -0.3f,  0.3f, 0.0f,  // Bottom-left

            
             0.3f,  0.5f, 0.0f,  // Top-right
            -0.3f,  0.3f, 0.0f,  // Bottom-left
             0.3f,  0.3f, 0.0f,  // Bottom-right

            
            -0.1f,  0.3f, 0.0f,  // Top-left
             0.1f,  0.3f, 0.0f,  // Top-right
            -0.1f, -0.5f, 0.0f,  // Bottom-left

            
             0.1f,  0.3f, 0.0f,  // Top-right
            -0.1f, -0.5f, 0.0f,  // Bottom-left
             0.1f, -0.5f, 0.0f   // Bottom-right                                    
            

        };


        private int vertexArrayObject;
        private int vertexBufferObject;


        public Game(int width, int height, string title) 
            : base(
                  GameWindowSettings.Default,
                  new NativeWindowSettings() { 
                      Size = (width, height), Title = title 
                  }) {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            //Code goes here
            GL.Enable(EnableCap.DepthTest);

            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);

            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);  
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);


            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.BindVertexArray(0);

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);    

            //Code goes here.
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(vertexArrayObject);            
            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            SwapBuffers();
        }

        protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
        {
            base.OnFramebufferResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }


    }
}
