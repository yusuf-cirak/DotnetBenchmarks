using BenchmarkDotNet.Attributes;

namespace Exceptions;

[MemoryDiagnoser]
public class ExceptionVsReturn
{
    const string Message = "Message";
    
    public Func<string> GetFunc()
    {
        return delegate
        {
            var exception = new Exception(Message);
            return exception.Message;
        };
    }

    [Benchmark]
    public string ReturnString_WithoutThrowingException()
    {
        var func = GetFunc();
        return func();
    }

    [Benchmark]
    public string ReturnString_WithThrowingException()
    {
        try
        {
            throw new Exception(Message);
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }


}