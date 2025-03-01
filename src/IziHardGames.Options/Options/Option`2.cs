using System.Diagnostics.CodeAnalysis;
using IziHardGames.Options.Contracts;

namespace IziHardGames.Options
{
    public struct Option<TSome, TError> : IError<TError>, ISome<TSome>, IOption<TSome, TError>
        where TError : struct
        where TSome : class
    {
        public TSome Some { get; }
        public TError Error { get; }
        public EOptionKind Kind { get; }

        public Option(TSome some)
        {
            Error = default(TError);
            Some = some;
            Kind = EOptionKind.Some;
        }

        public Option(TError error)
        {
            Error = error;
            Some = default(TSome)!;
            Kind = EOptionKind.Error;
        }

        public Option(EOptionKind kind, TSome some, TError error)
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

        public bool AsError([NotNullWhen(true)] out TError error)
        {
            if (Kind == EOptionKind.Error)
            {
                error = Error;
                return true;
            }
            error = default(TError);
            return false;
        }

        public bool AsNone()
        {
            return Kind == EOptionKind.None;
        }
        public static Option<TSome, TError> CreateSome(TSome some)
        {
            return new Option<TSome, TError>(some);
        }
        public static Option<TSome, TError> CreateError(TError error)
        {
            return new Option<TSome, TError>(error);
        }
        public static Option<TSome, TError> CreateNone()
        {
            return new Option<TSome, TError>(EOptionKind.None, default(TSome)!, default(TError));
        }
    }
}
