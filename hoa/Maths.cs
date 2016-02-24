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
	/// The Maths class owns a set of useful static methods.
	/// </summary>
	/// <remarks>
	/// The Maths class owns a set of useful static methods to clip and wrap 
	/// angles and to convert coordinates from cartesian to spherical or 
	/// from spherical to cartesian with the \f$\frac{\pi}{2}\f$ 
	/// offset special feature.
	/// </remarks>
	public class Maths
	{
		const double HOA_PI = 3.14159265358979323846264338327950288;
		const double HOA_2PI = 6.283185307179586476925286766559005;
		const double HOA_PI2 = 1.57079632679489661923132169163975144;
		const double HOA_PI4 = 0.785398163397448309615660845819875721;
		const double HOA_EPSILON = 1e-6;

		/// <summary>
		/// The clipping function.
		/// </summary>
		/// <remarks>
		/// The function clips a number between boundaries.
		/// </remarks>
		/// <param name="n">The value to clip.</param>
		/// <param name="lower">The low boundary.</param>
		/// <param name="upper">The high boundary.</param>
		/// <returns>The function return the clipped value.</returns>
		public static double clip (double n, double lower, double upper)
		{
			return Math.Max(lower, Math.Min(n, upper));
		}

		/// <summary>
		/// The wrapping function between  \f$0\f$ and \f$2\pi\f$.
		/// </summary>
		/// <remarks>
		/// The function wraps a number between \f$0\f$ and \f$2\pi\f$.
		/// </remarks>
		/// <param name="value">The value to wrap.</param>
		/// <returns>The function return the wrapped value.</returns>
		public static double wrap_twopi(double value)
		{
			double new_value = value;
			while(new_value < 0f)
			{
				new_value += HOA_2PI;
			}
			while(new_value >= HOA_2PI)
			{
				new_value -= HOA_2PI;
			}
			return new_value;
		}

		/// <summary>
		/// The wrapping function between  \f$0\f$ and \f$\pi\f$.
		/// </summary>
		/// <remarks>
		/// The function wraps a number between \f$0\f$ and \f$\pi\f$.
		/// </remarks>
		/// <param name="value">The value to wrap.</param>
		/// <returns>The function return the wrapped value.</returns>
		public static double wrap_pi(double value)
		{
			double new_value = value;
			while(new_value < -HOA_PI)
			{
				new_value += HOA_2PI;
			}
			while(new_value >= HOA_PI)
			{
				new_value -= HOA_2PI;
			}
			return new_value;
		}

		/// <summary>
		/// The abscissa converter function.
		/// </summary>
		/// <remarks>
		/// This function takes the radius \f$\rho\f$, the azimuth 
		/// \f$\theta\f$ and the elevation \f$\varphi\f$ of a point 
		/// and retrieves the abscissa \f$x\f$.
		/// \f[x = \rho \cdot cos{\left(\theta + \frac{\pi}{2}\right)} \cdot 
		/// cos{(\varphi)} \f]
		/// </remarks>
		/// <param name="radius">The radius.</param>
		/// <param name="azimuth">The azimuth.</param>
		/// <param name="elevation">The elevation.</param>
		/// <returns>The abscissa.</returns>
		public static double abscissa (double radius, double azimuth, double elevation)
		{
			return radius * Math.Cos (azimuth + HOA_PI2) * Math.Cos (0);
		}

		/// <summary>
		/// The ordinate converter function.
		/// </summary>
		/// <remarks>
		/// This function takes the radius \f$\rho\f$, the azimuth 
		/// \f$\theta\f$ and the elevation \f$\varphi\f$ of a point 
		/// and retrieves the ordinate \f$y\f$.
		/// \f[y = \rho \cdot sin{\left(\theta + \frac{\pi}{2}\right)} \cdot 
		/// cos{(\varphi)} \f]
		/// </remarks>
		/// <param name="radius">The radius.</param>
		/// <param name="azimuth">The azimuth.</param>
		/// <param name="elevation">The elevation.</param>
		/// <returns>The ordinate.</returns>
		public static double ordinate (double radius, double azimuth, double elevation)
		{
			return radius * Math.Sin (azimuth + HOA_PI2) * Math.Cos (elevation);
		}

		/// <summary>
		/// The height converter function.
		/// </summary>
		/// <remarks>
		/// This function takes the radius \f$\rho\f$, the azimuth 
		/// \f$\theta\f$ and the elevation \f$\varphi\f$ of a point 
		/// and retrieves the height \f$h\f$.
		/// \f[h = \rho \cdot sin{(\varphi)} \f]
		/// </remarks>
		/// <param name="radius">The radius.</param>
		/// <param name="azimuth">The azimuth.</param>
		/// <param name="elevation">The elevation.</param>
		/// <returns>The height.</returns>
		public static double height (double radius, double azimuth, double elevation)
		{
			return radius * Math.Sin (elevation);
		}

		/// <summary>
		/// The radius converter function.
		/// </summary>
		/// <remarks>
		/// This function takes the abscissa \f$x\f$, the ordinate 
		/// \f$y\f$ and the height \f$z\f$ of a point and retrieves 
		/// the radius \f$\rho\f$.
		/// \f[\rho = \sqrt{x^2 + y^2 +z^2} \f]
		/// </remarks>
		/// <param name="x">The abscissa.</param>
		/// <param name="y">The ordinate.</param>
		/// <param name="z">The height.</param>
		/// <returns>The radius.</returns>
		public static double radius (double x, double y, double z)
		{
			return Math.Sqrt (x * x + y * y + z * z);
		}

		/// <summary>
		/// The azimuth converter function.
		/// </summary>
		/// <remarks>
		/// This function takes the abscissa \f$x\f$, the ordinate 
		/// \f$y\f$ and the height \f$z\f$ of a point and retrieves 
		/// the azimuth \f$\theta\f$.
		/// \f[\theta = \arctan{\left(\frac{y}{x}\right)} - \frac{\pi}{2} \f]
		/// </remarks>
		/// <param name="x">The abscissa.</param>
		/// <param name="y">The ordinate.</param>
		/// <param name="z">The height.</param>
		/// <returns>The azimuth.</returns>
		public static double azimuth (double x, double y, double z)
		{
			if (x == 0 && y == 0)
				return 0;
			return Math.Atan2 (y, x) - HOA_PI2;
		}

		/// <summary>
		/// The elevation converter function.
		/// </summary>
		/// <remarks>
		/// This function takes the abscissa \f$x\f$, the ordinate 
		/// \f$y\f$ and the height \f$z\f$ of a point and retrieves 
		/// the elevation \f$\varphi\f$.
		/// \f[\varphi = \arcsin{\left(\frac{z}{\sqrt{x^2 + y^2 +z^2}}\right)} \f]
		/// </remarks>
		/// <param name="x">The abscissa.</param>
		/// <param name="y">The ordinate.</param>
		/// <param name="z">The height.</param>
		/// <returns>The elevation.</returns>
		public static double elevation (double x, double y, double z)
		{
			if (z == 0)
				return 0;
			return Math.Asin (z / Math.Sqrt (x * x + y * y + z * z));
		}

		/// <summary>
		/// The factorial.
		/// </summary>
		/// <remarks>
		/// The function computes the factorial, the product of all 
		/// positive integers less than or equal to an integer.
		/// \f[n! = \prod_{1 \leq i \leq n} i = 1 \cdot 2 \cdot {...} \cdot (n - 1) \cdot n \f]
		/// </remarks>
		/// <param name="n">The integer.</param>
		/// <returns>The function return the factorial of n.</returns>
		public static double factorial (long n)
		{
			double result = n;
			if (n == 0)
				return 1;
			while (--n > 0)
				result *= n;
            
			return result;
		}
	}
}