using GameGuruDevChallange.Abstract.Patterns;

namespace GameGuruDevChallange.Patterns.StateMachine
{
    public class StateMachine
    {
        IState _currentState;
        public IState CurrentState => _currentState;

        public void ChangeState(IState newState)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = newState;
            _currentState.Enter();
        }

        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.Update();
            }
        }
    }
}