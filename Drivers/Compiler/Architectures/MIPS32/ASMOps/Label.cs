﻿#region LICENSE

// ---------------------------------- LICENSE ---------------------------------- //
//
//    Fling OS - The educational operating system
//    Copyright (C) 2015 Edward Nutting
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 2 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//  Project owner: 
//		Email: edwardnutting@outlook.com
//		For paper mail address, please contact via email for details.
//
// ------------------------------------------------------------------------------ //

#endregion

using Drivers.Compiler.ASM;
using Drivers.Compiler.ASM.ASMOps;

namespace Drivers.Compiler.Architectures.MIPS32.ASMOps
{
    public class Label : ASMLabel
    {
        public Label()
        {
        }

        public Label(bool methodLabel)
            : base(methodLabel)
        {
        }

        public Label(int anILPosition, string anExtension)
            : base(anILPosition, anExtension)
        {
        }

        /// <summary>
        ///     Generates the label itself (using the ASM block) and the line of assembly for the label.
        /// </summary>
        /// <param name="TheBlock">The block for which the comment is to be generated.</param>
        /// <returns>The complete line of assembly code.</returns>
        public override string Convert(ASMBlock TheBlock)
        {
            if (MethodLabel)
            {
                return TheBlock.GenerateMethodLabel() + ":\r\nnop";
            }
            return TheBlock.GenerateMethodLabel() + TheBlock.GenerateILOpLabel(ILPosition, Extension) + ":\r\nnop";
        }
    }
}