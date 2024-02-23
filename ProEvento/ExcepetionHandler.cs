namespace ProEvento;

public static class ExcepetionHandler
{   
    public static async Task<T[]> HandleAsync<T>(Func<Task<T[]>> func)
    {
        try 
        {
            return await func();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static async Task<T> HandleAsync<T>(Func<Task<T>> func)
    {
        try 
        {
            return await func();
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}