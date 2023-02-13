namespace delete_me
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var r = new Random();
			r.Next(3);
			var t = new TNT();
			Console.WriteLine(t.type);
		}

		public static int StockPicker(int[] arr)
		{
			int min = arr[0];
			int max = arr[0];
			var result = 0;
			for (int i = 0; i < arr.Length - 1; i++)
			{
				var next = arr[i+1];
				if (max < next)
				{
					max = next;
				}
				if (min > next)
				{
					min = next;
				}
			}
			result = max-min - (arr.Length-1);
			return result;
		}
	}
}