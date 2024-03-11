using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace Graphics
{
    class GPU
    {
        static public uint GenerateBuffer(float[] data)
        {
            //1
            //uint BufferID = 0;
            uint[] vbo = { 0 };
            Gl.glGenBuffers(1, vbo);
            //BufferID = vbo[0];
            //2
            Gl.glBindBuffer(Gl.GL_ARRAY_BUFFER, vbo[0]);
            //3
            GCHandle Handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            IntPtr Ptr = Handle.AddrOfPinnedObject();
            var size = Marshal.SizeOf(typeof(float)) * data.Length;
            
            Gl.glBufferData(Gl.GL_ARRAY_BUFFER, 
                (IntPtr)size, Ptr, Gl.GL_STATIC_DRAW);
            Handle.Free();
            return vbo[0];
        }

        static public uint GenerateElementBuffer(ushort[] data)
        {
            uint BufferID = 0;
            uint[] vbo = { 0 };
            Gl.glGenBuffers(1, vbo);
            BufferID = vbo[0];
            Gl.glBindBuffer(Gl.GL_ELEMENT_ARRAY_BUFFER, BufferID);
            GCHandle Handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            IntPtr Ptr = Handle.AddrOfPinnedObject();
            var size = Marshal.SizeOf(typeof(ushort)) * data.Length;
            Gl.glBufferData(Gl.GL_ELEMENT_ARRAY_BUFFER, (IntPtr)size, Ptr, Gl.GL_STATIC_DRAW);
            Handle.Free();
            return BufferID;
        }

    }
}
