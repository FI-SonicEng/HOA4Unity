using System;


namespace hoa
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var decoder = new decoder(1, 4);
			Console.WriteLine (decoder.getorder ());
			Console.WriteLine(decoder.getnumberOfPlanewaves ());
		}
	}
}
