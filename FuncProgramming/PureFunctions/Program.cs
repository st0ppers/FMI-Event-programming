using static System.Linq.Enumerable;

namespace PureFunctions
{
	public static class Program
	{
		static void Main(string[] args)
		{

			var a = new List<int>() { 1, 2, 3, 4, 5 };
			var b = a.Sum();
			Console.WriteLine(b);
			var c = "name";
			var d = char.ToUpperInvariant(c[0]) + c.ToLower()[1..];// array[Range.StartAt(1)]
			//Console.WriteLine(d);
			var e = a[^2];//starts to count from the end and takes the 'x' element from the end
			var ee = a[^2];// = a[a.count - 2]
			var f = new List<string>() { "one", "two", "three","four","five","six","seven","eight","nine","ten","eleven","twelve","thirteen" ,"fourteen","fifteen"};
			var aa = Format(f);

			aa.ForEach(Console.WriteLine);
		}

		public static List<string> Format(this List<string> list)
		=> list.AsParallel().Zip(Range(1, list.Count).AsParallel(), (s, i) => $"This is string: {s} and {i}").ToList();
	}
}