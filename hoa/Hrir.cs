// =======================================================================
// Author:	Miguel Félix
// Date:	Feb 2016
//
// This file is part of HOA4Unity.
//
// HOA4Unity is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// HOA4Unity is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with HOA4Unity.  If not, see <http://www.gnu.org/licenses/>.
// =======================================================================

using System;

namespace hoa
{
	/// <summary>
	/// The Hrir class gives the impulse responses to decode in binaural mode.
	/// </summary>
	/// <remarks>
	/// The impulse response can be simple or double precision.
	/// </remarks>
	public class Hrir
	{
		
		/// <summary>
		/// Gets the order of decomposition used to compute the matrices.
		/// </summary>
		/// <returns>The order of decomposition.</returns>
		public static ulong getOrderOfDecomposition ()
		{
			return 3ul;
		}

		/// <summary>
		/// Gets the number rows of the matrices (the size of the responses used to compute the matrices).
		/// </summary>
		/// <returns>The number of rows.</returns>
		public static ulong getNumberOfRows ()
		{
			return 512ul;
		}

		/// <summary>
		/// Gets the number columns of the matrices (the number of harmonics used to compute the matrices).
		/// </summary>
		/// <returns>The number of columns.</returns>
		public static ulong getNumberOfColumns ()
		{
			return 16ul;
		}

		/// <summary>
		/// Gets the size of the matrices (rows * columns).
		/// </summary>
		/// <returns>The matrices size.</returns>
		public static ulong getMatricesSize ()
		{
			return 8192ul;
		}

		/// <summary>
		/// Get the HRIR matrix for the left ear.
		/// </summary>
		/// <returns>The HRIR matrix for the left ear (float type).</returns>
		public static float[] getLeftMatrixFloat ()
		{
			return HrirIrc.Irc1002C_float_3d_left;
		}

		/// <summary>
		/// Get the HRIR matrix for the right ear.
		/// </summary>
		/// <returns>The HRIR matrix for the right ear (float type).</returns>
		public static float[] getRightMatrixFloat ()
		{
			return HrirIrc.Irc1002C_float_3d_right;
		}

		/// <summary>
		/// Get the HRIR matrix for the left ear.
		/// </summary>
		/// <returns>The HRIR matrix for the left ear (double type).</returns>
		public static double[] getLeftMatrixDouble ()
		{
			return HrirIrc.Irc1002C_double_3d_left;
		}

		/// <summary>
		/// Get the HRIR matrix for the right ear.
		/// </summary>
		/// <returns>The HRIR matrix for the right ear (double type).</returns>
		public static double[] getRightMatrixDouble ()
		{
			return HrirIrc.Irc1002C_double_3d_right;
		}
	}
}

