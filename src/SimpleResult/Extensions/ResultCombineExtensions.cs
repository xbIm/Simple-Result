using System.Threading.Tasks;

namespace SimpleResult.Extensions
{
    public class ResultCombineExtensions
    {
        public static Result<(T1, T2), TFailure> Combine<T1, T2, TFailure>(
            Result<T1, TFailure> t1,
            Result<T2, TFailure> t2) =>
            t1.Bind(v1 => t2.Map(v2 => (v1, v2)));

        public static async Task<Result<(T1, T2), TFailure>> CombineAsync<T1, T2, TFailure>(
            Task<Result<T1, TFailure>> t1,
            Task<Result<T2, TFailure>> t2)
        {
            await Task.WhenAll(t1, t2);

            var r1 = t1.Result;
            var r2 = t2.Result;

            return Combine(r1, r2);
        }


        public static async Task<Result<(T1, T2, T3), TFailure>> CombineAsync<T1, T2, T3, TFailure>(
            Task<Result<T1, TFailure>> t1,
            Task<Result<T2, TFailure>> t2,
            Task<Result<T3, TFailure>> t3)
        {
            await Task.WhenAll(t1, t2, t3);

            var r1 = t1.Result;
            var r2 = t2.Result;
            var r3 = t3.Result;

            return Combine(r1, r2)
                .Bind(vt => r3.Map(v3 => (vt.Item1, vt.Item2, v3)));
        }

        public static async Task<Result<(T1, T2, T3, T4), TFailure>> CombineAsync<T1, T2, T3, T4, TFailure>(
            Task<Result<T1, TFailure>> t1,
            Task<Result<T2, TFailure>> t2,
            Task<Result<T3, TFailure>> t3,
            Task<Result<T4, TFailure>> t4)
        {
            await Task.WhenAll(t1, t2, t3, t4);

            var r1 = t1.Result;
            var r2 = t2.Result;
            var r3 = t3.Result;
            var r4 = t4.Result;

            return Combine(r1, r2)
                .Bind(vt => r3.Map(v3 => (vt.Item1, vt.Item2, v3)))
                .Bind(vt => r4.Map(v4 => (vt.Item1, vt.Item2, vt.Item3, v4)));
        }
    }
}