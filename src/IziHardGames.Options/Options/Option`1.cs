using System.Diagnostics.CodeAnalysis;
using IziHardGames.Options.Contracts;
using IziHardGames.Options.Errors;

namespace IziHardGames.Options
{
    public struct Option<TSome> : IOption<TSome, Error?>
    {
        public TSome Some { get; }
        public Error? Error { get; }
        public EOptionKind Kind { get; }

        public Option(TSome some)
        {
            Error = null;
            Some = some;
            Kind = EOptionKind.Some;
        }

        public Option(Error? error)
        {
            Error = error;
            Some = default(TSome)!;
            Kind = EOptionKind.Error;
        }

        public Option(EOptionKind kind, TSome some, Error? error)
        {
            Some = some;
            Error = error;
            Kind = kind;
        }

        public bool AsSome([NotNullWhen(true)] out TSome some)
        {
            if (Kind == EOptionKind.Some)
            {
                some = Some!;
                return true;
            }
            some = default!;
            return false;
        }

        public bool AsError([NotNullWhen(true)] out Error? error)
        {
            if (Kind == EOptionKind.Error)
            {
                error = Error!.Value;
                return true;
            }
            error = null;
            return false;
        }

        public bool AsNone()
        {
            return Kind == EOptionKind.None;
        }

        public static Option<TSome> CreateSome(TSome some)
        {
            return new Option<TSome>(some);
        }
        public static Option<TSome> CreateError(Error error)
        {
            return new Option<TSome>(error);
        }
        public static Option<TSome> CreateNone()
        {
            return new Option<TSome>(EOptionKind.None, default!, default);
        }
    }

    public enum EOptionKind
    {
        Default,
        None,
        Some,
        Error,
    }
}
