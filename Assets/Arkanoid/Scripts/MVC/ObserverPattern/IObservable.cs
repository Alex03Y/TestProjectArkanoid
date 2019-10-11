namespace Arkanoid.MVC
{
    public interface IObservable
    {
        void OnObjectChanged(IObserver observer);
    }
}
