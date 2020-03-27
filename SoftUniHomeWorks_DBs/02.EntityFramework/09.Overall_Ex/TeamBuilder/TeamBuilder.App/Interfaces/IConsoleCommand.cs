namespace TeamBuilder.App.Interfaces
{
    public interface IConsoleCommand
    {
        string SucessMessage { get; }

        void Execute(string[] parameters);
    }
}
