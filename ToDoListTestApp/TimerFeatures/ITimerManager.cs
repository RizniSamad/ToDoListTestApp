namespace ToDoListTestApp.TimerFeatures
{
    public interface ITimerManager
    {
        DateTime TimerStarted { get; set; }
        bool IsTimerStarted { get; set; }

        void Execute(object stateInfo);
        void PrepareTimer(Action action);
    }
}
