using static HOF.Exercise;

namespace HOF
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(int.TryParse("",out _));
			//var devide = (int x, int y) => x / y;

			//Console.WriteLine(devide(10, 2));

			//var auth = new Author() { Name = "Toshkata" };

			//var DbLogger = new DbLogger();

			//DbLogger.Log(auth);

			Func<int, bool> b = x => 10 % 5 == 0;
			var normal = b(10);
			var rev = b.Reverse();
			Console.WriteLine($"Normal: {normal}\nreverse: {rev(10)}");


			var lis = new List<int>() { 8, 2, 5, 3, 9, 4, 7, 6, 1 };
			var newlist = lis.QuickSort();
			foreach (var num in newlist)
			{
				Console.WriteLine(num);
			}

			//SortMe(lis, 0, lis.Count - 1);
			//foreach (var num in lis)
			//{
			//	Console.WriteLine(num);
			//}
		}
	}
	public static class Exercise
	{
		public static Func<T, bool> Reverse<T>(this Func<T, bool> func)
			=> t => !func(t);

		public static List<int> QuickSort(this List<int> list)
		{
			if (list.Count == 0) return new List<int>();

			var pivot = list[0];
			var rest = list.Skip(1);

			var small = from item in rest where item <= pivot select item;
			var large = from item in rest where pivot < item select item;

			return small.ToList().QuickSort()
			   .Append(pivot)
			   .Concat(large.ToList().QuickSort())
			   .ToList();
		}

		//public static void SortMe(List<int> list, int start, int end)
		//{
		//	if (end <= start) return;// best case
		//	var pivot = list[0];
		//	var rest = list.Skip(1);

		//	var small = from item in rest where item <= pivot select item;
		//	var large = from item in rest where pivot < item select item;

		//}
		//public static int partition(List<int> list, int start, int end)
		//{
		//	int pivot = list[end];
		//	int i = start - 1;
		//	for (int j = start; j <= end - 1; j++)
		//	{
		//		if (list[j] < pivot)
		//		{
		//			i++;
		//			var temp = list[i];
		//			list[i] = list[j];
		//			list[j] = temp;
		//		}
		//	}
		//	i++;
		//	var temp2 = list[i];
		//	list[i] = list[end];
		//	list[end] = temp2;
		//	return i;
		//}
	}
}