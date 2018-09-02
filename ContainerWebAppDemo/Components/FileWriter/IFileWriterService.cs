namespace ContainerWebAppDemo.Components.FileWriter
{
    public interface IFileWriterService
    {
        string GetSavedString();
        void SaveString(string text);
        void Clear();
    }
}