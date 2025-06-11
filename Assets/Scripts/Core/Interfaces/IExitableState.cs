namespace Core.Interfaces
{
    public interface IExitableState
    {
        void Exit();
    }

    public interface IGameState : IExitableState
    {
        void Enter();
    }

    public interface IPayloadedState<TPayload> : IGameState
    {
        void Enter(TPayload payload);
    }
}