using UnityEngine;

public class AIBase 
{
    AiProvider aiProvider;

   public AIBase(GameObject thisObj)
   {
        aiProvider=new AiProvider(thisObj);
   }
 

}