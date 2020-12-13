using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SimpleResult
{
    public static class Wrappers
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TSuccess, TError> ToSuccess<TSuccess, TError>(this TSuccess t) =>
            Result<TSuccess, TError>.Succeeded(t);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Result<TSuccess, TFailure> ToFailure<TSuccess, TFailure>(this TFailure t) =>
            Result<TSuccess, TFailure>.Failed(t);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Result<TSuccess, TError>> ToSuccessTask<TSuccess, TError>(this TSuccess t) =>
            Result<TSuccess, TError>.Succeeded(t).Let(Task.FromResult);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<Result<TSuccess, TFailure>> ToFailureTask<TSuccess, TFailure>(this TFailure t) =>
            Result<TSuccess, TFailure>.Failed(t).Let(Task.FromResult);

    }
}