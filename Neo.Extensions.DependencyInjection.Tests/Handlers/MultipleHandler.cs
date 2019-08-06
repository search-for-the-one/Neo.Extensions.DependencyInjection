namespace Neo.Extensions.DependencyInjection.Tests.Handlers
{
    public class MultipleHandler : IHandler, IHandler2
    {
        void IHandler.Handle()
        {
            throw new System.NotImplementedException();
        }

        void IHandler2.Handle()
        {
            throw new System.NotImplementedException();
        }
    }
}