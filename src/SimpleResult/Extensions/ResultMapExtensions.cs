using System;
using System.Threading.Tasks;

namespace SimpleResult.Extensions
{
    public static class ResultMapExtensions
    {
        public static Result<TSuccessNew, TFailure> Map<TSuccess, TFailure, TSuccessNew>(
            this Result<TSuccess, TFailure> x,
            Func<TSuccess, TSuccessNew> f)
        {
            return x.IsSuccess
                ? Result<TSuccessNew, TFailure>.Succeeded(f(x.Success))
                : Result<TSuccessNew, TFailure>.Failed(x.Failure);
        }

        public static async Task<Result<TSuccessNew, TFailure>> MapAsync<TSuccess, TFailure, TSuccessNew>(
            this Task<Result<TSuccess, TFailure>> t,
            Func<TSuccess, TSuccessNew> f)
        {
            var x = await t;

            return x.IsSuccess
                ? Result<TSuccessNew, TFailure>.Succeeded(f(x.Success))
                : Result<TSuccessNew, TFailure>.Failed(x.Failure);
        }

        public static Result<TSuccess, TFailureNew> MapFailure<TSuccess, TFailure, TFailureNew>(
            this Result<TSuccess, TFailure> x,
            Func<TFailure, TFailureNew> f)
        {
            return x.IsSuccess
                ? Result<TSuccess, TFailureNew>.Succeeded(x.Success)
                : Result<TSuccess, TFailureNew>.Failed(f(x.Failure));
        }

        public static async Task<Result<TSuccess, TFailureNew>> MapFailureAsync<TSuccess, TFailure, TFailureNew>(
            this Task<Result<TSuccess, TFailure>> t,
            Func<TFailure, TFailureNew> f)
        {
            var x = await t;
            return x.IsSuccess
                ? Result<TSuccess, TFailureNew>.Succeeded(x.Success)
                : Result<TSuccess, TFailureNew>.Failed(f(x.Failure));
        }
    }
}