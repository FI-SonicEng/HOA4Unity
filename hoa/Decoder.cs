using System;

namespace hoa
{
	public class Decoder
	{
		public ulong order;
		public ulong numberOfPlanewaves;
		public ulong vectorsize;

		enum Mode
		{
			RegularMode = 0,
			BinauralMode = 2}

		;


		public Decoder (ulong inputorder, ulong inputnumberOfPlanewaves)
		{
			order = inputorder;
			numberOfPlanewaves = inputnumberOfPlanewaves;
		}

		~Decoder ()
		{
		}

		public void process (T inputs, T outputs)
		{
		}

		public void computeRendering ()
		{
			vectorsize = 64;
		}

		Mode getMode ()
		{
			return Mode;
		}
	}
}