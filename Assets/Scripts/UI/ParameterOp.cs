using UnityEngine;
using UnityEngine.UI;

public class ParameterOp : MonoBehaviour//用来修改各个参数
{
    public InputField Rate,Radius,WoekRate,RateLoc1,RateLoc2,RateLoc3,IncubationPeriod,LsolationRate,Bed;
    public Button ButtonYes;//确定按钮
    public Parameter parameter;
    void Start()
    {
        parameter = GameObject.Find("Canvas/Parameter").GetComponent<Parameter>();
        Debug.Log(parameter);
        ButtonYes.onClick.AddListener(ChangeParameter);
    }

    private void ChangeParameter()
    {
        parameter.Rate = int.Parse(Rate.text);
        parameter.Radius = int.Parse(Radius.text);
        parameter.WoekRate = int.Parse(WoekRate.text);
        parameter.RateLoc1 = int.Parse(RateLoc1.text);
        parameter.RateLoc2 = int.Parse(RateLoc2.text);
        parameter.RateLoc3 = int.Parse(RateLoc3.text);
        parameter.IncubationPeriod = int.Parse(IncubationPeriod.text);
        parameter.LsolationRate = int.Parse(LsolationRate.text);
        parameter.Bed = int.Parse(Bed.text);
    }
}
