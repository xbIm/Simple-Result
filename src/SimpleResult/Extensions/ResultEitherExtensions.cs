using System;
using System.Threading.Tasks;

namespace SimpleResult.Extensions
{
    public static class ResultEitherExtensions
    {
        public static Result<TSuccess, TFailure> Either<TSuccess, TFailure>(
            this Result<TSuccess, TFailure> t,
            Action<TSuccess> ok,
            Action<TFailure> fail)
        {
            var x = t;
            if (x.IsSuccess)
            {
                ok(x.Success);
            }
            else
            {
                fail(x.Failure);
            }

            return x;
        }

        public static async Task<Result<TSuccess, TFailure>> EitherAsync<TSuccess, TFailure>(
            this Task<Result<TSuccess, TFailure>> t,
            Action<TSuccess> ok,
            Action<TFailure> fail)
        {
            var x = await t;
            if (x.IsSuccess)
            {
                ok(x.Success);
            }
            else
            {
                fail(x.Failure);
            }

            return x;
        }

        public static async Task<TExtracted> ExtractAsync<TSuccess, TFailure, TExtracted>(
            this Task<Result<TSuccess, TFailure>> t,
            Func<TSuccess, TExtracted> ok,
            Func<TFailure, TExtracted> fail)
        {
            Result<TSuccess, TFailure> result = await t;
            return result.IsSuccess ? ok(result.Success) : fail(result.Failure);
        }

        public static TExtracted Extract<TSuccess, TFailure, TExtracted>(
            this Result<TSuccess, TFailure> t,
            Func<TSuccess, TExtracted> ok,
            Func<TFailure, TExtracted> fail)
        {
            Result<TSuccess, TFailure> result = t;
            return result.IsSuccess ? ok(result.Success) : fail(result.Failure);
        }

    }
}