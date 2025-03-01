using System;
using System.Diagnostics.CodeAnalysis;
using IziHardGames.Options.Contracts;
using IziHardGames.Options.Errors;

namespace IziHardGames.Options
{
    public struct Option : IOption<object?, Error?>
    {
        public object? Some { get; }
        public Error? Error { get; }
        public EOptionKind Kind { get; }

        public Option(object some)
        {
            if (some == null) throw new ArgumentNullException(nameof(some));
            Error = null;
            Some = some;
            Kind = EOptionKind.Some;
        }

        public Option(Error error)
        {
            Error = error;
            Some = null;
            Kind = EOptionKind.Error;
        }

        public Option(EOptionKind kind, object? some, Error? error)
        {
            Some = some;
            Error = error;
            Kind = kind;
        }

        public bool AsSome([NotNullWhen(true)] out object? some)
        {
            if (Kind == EOptionKind.Some)
            {
                some = Some!;
                return true;
            }
            some = null;
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

        public static Option CreateSome(object some)
        {
            return new Option(some);
        }
        public static Option CreateError(Error error)
        {
            return new Option(error);
        }
        public static Option CreateNone()
        {
            return new Option(EOptionKind.None, default!, default);
        }
    }
}
