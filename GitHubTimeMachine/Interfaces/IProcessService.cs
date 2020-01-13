namespace GitHubTimeMachine.Interfaces
{
    internal interface IProcessService
    {
        object GetInstance();
        void ResetInstance();
    }
}
