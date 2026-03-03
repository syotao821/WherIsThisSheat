
public class EventTest: AiDataEventReciverListener
{
    AiData AiData;
    BussChildSet bussChildSet;
    private void Start()
    {
        bussChildSet=new BussChildSet(this.transform);
    }
    public void Update()
    {
      
        AiData = _getAiData.Invoke();

        UnityEngine.Debug.Log(AiData.Name);
    }
}