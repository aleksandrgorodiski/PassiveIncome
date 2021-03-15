using System;

public abstract class Singleton<T> : IDisposable where T : class
{
    public static T Instance
    {
        get;
        private set;
    }

    protected Singleton()
    {
        Instance = this as T;
    }

    public void Dispose()
    {
        OnReleaseResources();
        Instance = null;
    }

    protected abstract void OnReleaseResources();
}