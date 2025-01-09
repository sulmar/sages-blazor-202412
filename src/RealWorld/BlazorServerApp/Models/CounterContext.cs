namespace BlazorServerApp.Models;

public class CounterContext
{
    public int CurrentCount { get; set; } = 5;

    private static object _syncLock = new object();


    // Wzorzec projektowy Singleton
    private static CounterContext _instance;
    public static CounterContext Instance
    {
        get
        {
            lock (_syncLock)
            {
                if (_instance == null)
                    _instance = new CounterContext();

                return _instance;
            }

        }
    }

   protected CounterContext() { }
}
