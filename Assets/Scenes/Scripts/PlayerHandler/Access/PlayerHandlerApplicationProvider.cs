public class PlayerHandlerApplicationProvider
{
    ApplicationIntegration applicationIntegration;

    public PlayerHandlerApplicationProvider()
    {
        applicationIntegration=new ApplicationIntegration();
    }


    public ApplicationIntegration GetApplication()
    {
        return applicationIntegration;
    }

}