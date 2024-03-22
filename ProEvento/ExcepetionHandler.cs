namespace ProEvento;

public static class ExcepetionHandler
{
    public static async Task<T[]> HandleAsync<T>(Func<Task<T[]>> func)
    {
        var typeinterface = typeof(T).GetInterfaces();
        try
        {
            return await func();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw new Exception($"tipo: {nameof(typeinterface)} : {typeinterface}");
        }
    }

    public static async Task<T> HandleAsync<T>(Func<Task<T>> func)
    {
        try
        {
            return await func();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}