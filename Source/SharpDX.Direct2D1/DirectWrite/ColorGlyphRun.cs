// Copyright (c) 2010-2014 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Runtime.InteropServices;

using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
    public partial class ColorGlyphRun : IDisposable
    {
        public GlyphRunDescription GlyphRunDescription { get; set; }

        // Internal native struct used for marshalling
        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        internal struct __Native
        {
            public GlyphRun.__Native glyphRun;
            public IntPtr glyphRunDescriptionPointer;
            public float baselineOriginX;
            public float baselineOriginY;
            public RawColor4 runColor;
            public short paletteIndex;

            // Method to free native struct
            internal unsafe void __MarshalFree()
            {
                glyphRun.__MarshalFree();
                if (this.glyphRunDescriptionPointer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(this.glyphRunDescriptionPointer);
                }
            }
        }

        internal unsafe void __MarshalFree(ref __Native @ref)
        {
            @ref.__MarshalFree();
        }

        // Method to marshal from native to managed struct
        internal unsafe void __MarshalFrom(ref __Native @ref)
        {
            this.GlyphRun = new GlyphRun();
            this.GlyphRun.__MarshalFrom(ref @ref.glyphRun);
            this.GlyphRunDescriptionPointer = @ref.glyphRunDescriptionPointer;
            if (@ref.glyphRunDescriptionPointer != IntPtr.Zero)
            {
                this.GlyphRunDescription = new GlyphRunDescription();
                this.GlyphRunDescription.__MarshalFrom(ref *(GlyphRunDescription.__Native*)@ref.glyphRunDescriptionPointer);
            }

            this.BaselineOriginX = @ref.baselineOriginX;
            this.BaselineOriginY = @ref.baselineOriginY;
            this.RunColor = @ref.runColor;
            this.PaletteIndex = @ref.paletteIndex;
        }

        // Method to marshal from managed struct to native
        internal unsafe void __MarshalTo(ref __Native @ref)
        {
            this.GlyphRun.__MarshalTo(ref @ref.glyphRun);
            @ref.glyphRunDescriptionPointer = this.GlyphRunDescription == null ? IntPtr.Zero : this.GlyphRunDescriptionPointer;
            @ref.baselineOriginX = this.BaselineOriginX;
            @ref.baselineOriginY = this.BaselineOriginY;
            @ref.runColor = this.RunColor;
            @ref.paletteIndex = this.PaletteIndex;
        }

        public void Dispose()
        {
            if (this.GlyphRun != null)
            {
                this.GlyphRun.Dispose();
                this.GlyphRun = null;
            }
        }
    }
}