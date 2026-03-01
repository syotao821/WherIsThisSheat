

public class NotificationManager : SingletonBehaviour<NotificationManager>, IGameInit
{
    AiNotification _aiNotification;
    public AiNotification AiNotification { get => _aiNotification; set => _aiNotification = value; }

    void IGameInit.GameInit()
    {
        _aiNotification = new AiNotification();
    }
  
}