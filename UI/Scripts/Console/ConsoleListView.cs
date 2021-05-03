public class ConsoleListView : RecyclingListView
{
    private bool _init = false;

    public void Init()
    {
        if (!_init)
        {
            _init = true;

            Awake();
        }
    }
}
