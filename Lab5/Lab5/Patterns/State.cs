using System;

namespace Lab5.Patterns
{
    public interface IState
    {
        void Handle();
    }

    public class VisibleState : IState
    {
        public void Handle() => Console.WriteLine("Element is visible.");
    }

    public class HiddenState : IState
    {
        public void Handle() => Console.WriteLine("Element is hidden.");
    }

    public class HTMLComponent
    {
        private IState state;

        public HTMLComponent(IState initialState)
        {
            state = initialState;
        }

        public void SetState(IState newState)
        {
            state = newState;
        }

        public void Render()
        {
            state.Handle();
        }
    }
}
