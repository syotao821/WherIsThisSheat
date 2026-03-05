
public class EventTest: AiDataEventReciverListener
{
    AiData AiData;
    BussChildSet bussChildSet;
    public override void GameInit()
    {
        base.GameInit();
        bussChildSet=new BussChildSet(this.transform);
    }
    public void Update()
    {
      
        AiData = _getAiData.Invoke();

        UnityEngine.Debug.Log(AiData.Name);
    }
}