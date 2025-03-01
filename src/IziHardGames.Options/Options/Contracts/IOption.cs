namespace IziHardGames.Options.Contracts
{
    public interface IOption<TSome, TError>
    {
        bool AsSome(out TSome some);
        bool AsError(out TError error);
        bool AsNone();
    }
}
