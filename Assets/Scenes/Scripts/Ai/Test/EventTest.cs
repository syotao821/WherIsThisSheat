
public class EventTest: AiDataEventReciverListener
{
    AiData AiData;
    BussChildSet bussChildSet;
    public override void GameInit()
    {
        base.GameInit();
        bussChildSet=new BussChildSet(this.transform);
        UnityEngine.Debug.Log(3);
    }
    public void Update()
    {
      
        AiData = _getAiData.Invoke();

        UnityEngine.Debug.Log(AiData.Name);
    }
}