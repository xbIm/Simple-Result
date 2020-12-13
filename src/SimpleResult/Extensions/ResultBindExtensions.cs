using System;
using System.Threading.Tasks;

namespace SimpleResult.Extensions
{
    public static class ResultBindExtension
    {
        public static Result<TSuccessNew, TFailure> Bind<TSuccess, TFailure, TSuccessNew>(
            this Result<TSuccess, TFailure> x,
            Func<TSuccess, Result<TSuccessNew, TFailure>> f)
        {
            return x.IsSuccess
                ? f(x.Success)
                : Result<TSuccessNew, TFailure>.Failed(x.Failure);
        }

        public static async Task<Result<TSuccessNew, TFailure>> BindAsync<TSuccess, TFailure, TSuccessNew>(
            this Result<TSuccess, TFailure> x,
            Func<TSuccess, Task<Result<TSuccessNew, TFailure>>> f)
        {
            return x.IsSuccess
                ? await f(x.Success)
                : Result<TSuccessNew, TFailure>.Failed(x.Failure);
        }

        public static async Task<Result<TSuccessNew, TFailure>> BindAsync<TSuccess, TFailure, TSuccessNew>(
            this Task<Result<TSuccess, TFailure>> x,
            Func<TSuccess, Task<Result<TSuccessNew, TFailure>>> f)
        {
            var xResult = await x;
            return xResult.IsSuccess
                ? await f(xResult.Success)
                : Result<TSuccessNew, TFailure>.Failed(xResult.Failure);
        }

        public static async Task<Result<TSuccessNew, TFailure>> BindAsync<TSuccess, TFailure, TSuccessNew>(
            this Task<Result<TSuccess, TFailure>> x,
            Func<TSuccess, Result<TSuccessNew, TFailure>> f)
        {
            var xResult = await x;
            return xResult.IsSuccess
                ? f(xResult.Success)
                : Result<TSuccessNew, TFailure>.Failed(xResult.Failure);
        }

    }
}