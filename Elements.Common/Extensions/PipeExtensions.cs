using System;
using System.Threading.Tasks;

namespace Elements.Common.Extensions;

public static class PipeExtensions
{
    public static Func<A,A> Tap<A>(Action<A> act)
        => x => { act(x); return x; };

    public static B Pipe<A,B>(this A input, Func<A,B> func)
        => func(input);

    public static A Pipe<A>(this A input, Action<A> act)
        => Tap(act)(input);

    public static async Task PipeAsync(this Task task, Func<Task> asyncFunc)
    {
        await task;
        await asyncFunc();
    }

    public static async Task<A> PipeAsync<A>(this Task task, Func<Task<A>> asyncFunc)
    {
        await task;
        return await asyncFunc();
    }

    public static async Task PipeAsync<A>(this Task<A> input, Func<A,Task> asyncFunc)
        => await asyncFunc(await input);

    public static async Task<B> PipeAsync<A,B>(this Task<A> input, Func<A,B> asyncFunc)
        => asyncFunc(await input);

    public static async Task<B> PipeAsync<A,B>(this Task<A> input, Func<A,Task<B>> asyncFunc)
        => await asyncFunc(await input);

}