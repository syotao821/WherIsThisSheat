using UnityEngine;

public class PlayerHandlerApplicationProvider
{
    PlayerHandlerApplicationIntegration applicationIntegration;

    public PlayerHandlerApplicationProvider(GameObject playerHadlerObj)
    {
        applicationIntegration=new PlayerHandlerApplicationIntegration(playerHadlerObj);
    }


    public PlayerHandlerApplicationIntegration GetApplication()
    {
        return applicationIntegration;
    }

}