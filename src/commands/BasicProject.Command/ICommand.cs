namespace BasicProject.Command
{
    public interface ICommand<T1, T2>
    {
        void SetParams(T1 param);

        T2 Execute();
    }
}
