namespace Infrastructure
{
    public interface IGameState
    {
        void Enter();
        void Exit();
    }

    public interface IPayloadedState<TPayload> : IGameState
    {
        void Enter(TPayload payload);
    }
}