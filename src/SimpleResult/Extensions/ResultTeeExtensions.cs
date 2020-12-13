using System;
using System.Threading.Tasks;

namespace SimpleResult.Extensions
{
    public static class ResultTeeExtensions
    {
        public static Result<TSuccess, TFailure> Tee<TSuccess, TFailure>(
            this Result<TSuccess, TFailure> x,
            Action<TSuccess> f)
        {
            if (x.IsSuccess)
            {
                f(x.Success);
            }

            return x;
        }

        public static async Task<Result<TSuccess, TFailure>> TeeAsync<TSuccess, TFailure>(
            this Result<TSuccess, TFailure> x,
            Func<TSuccess, Task> f)
        {
            if (x.IsSuccess)
            {
                await f(x.Success);
            }

            return x;
        }

        public static async Task<Result<TSuccess, TFailure>> TeeAsync<TSuccess, TFailure>(
            this Task<Result<TSuccess, TFailure>> t,
            Action<TSuccess> f)
        {
            var x = await t;

            if (x.IsSuccess)
            {
                f(x.Success);
            }

            return x;
        }
    }
}