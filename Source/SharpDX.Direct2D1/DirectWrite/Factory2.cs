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

namespace SharpDX.DirectWrite
{
    /// <summary>	
    /// <p>Creates a rendering parameters object with the specified properties.</p>	
    /// </summary>	
    /// <include file='..\Documentation\CodeComments.xml' path="/comments/comment[@id='IDWriteFactory2']/*"/>	
    /// <msdn-id>Dn894552</msdn-id>	
    /// <unmanaged>IDWriteFactory2</unmanaged>	
    /// <unmanaged-short>IDWriteFactory2</unmanaged-short>	
    public partial class Factory2
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Factory2"/> class with the <see cref="FactoryType.Shared"/> type.
        /// </summary>
        public Factory2()
            : this(FactoryType.Shared)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Factory2"/> class.
        /// </summary>
        /// <param name="factoryType">The factory type.</param>
        public Factory2(FactoryType factoryType)
            : base(IntPtr.Zero)
        {
            DWrite.CreateFactory(factoryType, Utilities.GetGuidFromType(typeof(Factory2)), this);
        }
    }
}