public abstract record Command(DateTime datetime);
namespace PureFunctions
{
	public record MakeTransfer
	(Guid DebitId, string Beneficiary, string Iban, string Bic, DateTime DateTime, decimal Amount, string Reference, DateTime Timestamp = default) : Command(Timestamp)
	{
		internal static MakeTransfer Dummy
			=> new(default, default, default, default, default, default, default);
	}
}
