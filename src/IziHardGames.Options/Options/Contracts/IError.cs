namespace IziHardGames.Options.Contracts
{

    public interface IError<TError>
    {
        TError Error { get; }
    }
}
