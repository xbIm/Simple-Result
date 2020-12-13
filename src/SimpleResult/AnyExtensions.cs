using System;
using System.Runtime.CompilerServices;

namespace SimpleResult
{
    public static class AnyExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Let<T, TResult>(this T t, Func<T, TResult> func) =>
            func(t);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Let<T>(this T t, Action<T> func) =>
            func(t);
    }
}