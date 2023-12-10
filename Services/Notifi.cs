namespace LibraryApp.Services
{

    public class Notifi
    {
        public event Action OnChange;

        private string Title = "";
        public void change_title()
        {
            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
