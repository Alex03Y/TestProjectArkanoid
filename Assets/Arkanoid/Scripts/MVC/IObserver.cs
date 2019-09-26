namespace Arkanoid.MVC
{
    public interface IObserver
    {
        void AddObserver(IObservable observable);
        void RemoveObserver(IObservable observable);
        void SetChanged();
    }
}
