namespace Products.Application.View
{
    public interface IView
    {
        void ShowMessage(string message);
        int ShowMainMenu();
        (string, string) ShowAuthorization();
        (string, string) ShowRegistration();
    }
}