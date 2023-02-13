using static FuncProgramming.Funcs;
namespace FuncProgramming
{
	internal class Program
	{
		static void Main(string[] args)
		{
			static int fun(int a) => a * a;
			//Console.WriteLine(fun(3));

			var a = "EURUSD".splitAt(3);
			Console.WriteLine(a);
			int[] asdf = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
			Console.WriteLine(asdf[^asdf.Length]);
			Console.WriteLine(Sqared(4));

			var adres = new Adress<string>();
			var mis = adres.get(Guid.NewGuid(), "sega ne sum",() => "vleznah v on miss");
			Console.WriteLine(mis);
		}
	}
	public static class Funcs
	{
		public static (string Base, string Quote) splitAt(this string s, int position) => (s.Substring(0, position), s.Substring(position));

		public static decimal Val(string adres)
			=> adres switch
			{
				"ca" => 123m,
				"de" => 20m,
				_ => throw new NotImplementedException()
			};

		public static int Sqared(int i) => i * i;
	}
	public class Adress<T> where T : class
	{
		public string City { get; set; }
		public T get(Guid id, T type) => type;
		// ако гет се провали и ни върне нъл ще направим onMiss
		public T get(Guid id, T type, Func<T> onMiss)
			=> get(id, type) ?? onMiss();
	}
	public class Order
	{
		public int Price { get; set; }
	}
}