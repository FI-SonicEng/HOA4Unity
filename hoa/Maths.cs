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
using System.Collections.Generic;

namespace hoa
{
	public class Maths<T> where T : IComparable
	{
		const double HOA_PI = 3.14159265358979323846264338327950288;
		const double HOA_2PI = 6.283185307179586476925286766559005;
		const double HOA_PI2 = 1.57079632679489661923132169163975144;
		const double HOA_PI4 = 0.785398163397448309615660845819875721;
		const double HOA_EPSILON = 1e-6;

		public static T ConvertVal (double value)
		{
			return (T)Convert.ChangeType (value, typeof(T));
		}

		public static T clip (T n, T lower, T upper)
		{
			T min = (n.CompareTo (upper) < 0) ? n : upper;
			T max = (lower.CompareTo (min) > 0) ? lower : min;
			return max;
		}

		public static T wrap_twopi (T value)
		{
			while (new_value.CompareTo (0) < 0) {
				new_value += ConvertVal (HOA_2PI);
			}
			while (new_value >= ConvertVal (HOA_2PI)) {
				new_value -= ConvertVal (HOA_2PI);
			}
			return new_value;
		}

		public static T wrap_pi (T value)
		{
			T new_value = value;
			while (new_value < -HOA_PI) {
				new_value += (T)HOA_2PI;
			}
			while (new_value >= HOA_PI) {
				new_value -= (T)HOA_2PI;
			}
			return new_value;
		}

		public static T abscissa (T radius, T azimuth, T elevation)
		{
			elevation = 0;
			return radius * Math.Cos (azimuth + HOA_PI2) * Math.Cos (0);
		}

		public static T ordinate (T radius, T azimuth, T elevation)
		{
			elevation = (T)0;
			return radius * Math.Sin (azimuth + HOA_PI2) * Math.Cos (elevation);
		}

		public static T height (T radius, T azimuth, T elevation)
		{
			elevation = 0;
			return radius * Math.Sin (elevation);
		}

		public static T radius (T x, T y, T z)
		{
			z = 0;
			return Math.Sqrt (x * x + y * y + z * z);
		}

		public static T azimuth (T x, T y, T z)
		{
			z = 0;
			if (x == 0 && y == 0)
				return 0;
			return Math.Atan2 (y, x) - HOA_PI2;
		}

		public static T elevation (T x, T y, T z)
		{
			z = 0;
			if (z == 0)
				return 0;
			return Math.Asin (z / Math.Sqrt (x * x + y * y + z * z));
		}

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