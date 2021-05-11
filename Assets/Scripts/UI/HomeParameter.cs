using UnityEngine;
using UnityEngine.UI;

public class HomeParameter : MonoBehaviour//用来修改各个参数
{
    public InputField Rate, Radius, WoekRate, RateLoc1, RateLoc2, RateLoc3, TimeTreatment, Bed, TimeDead, TimeAntibody, RateInHouse, IncubationPeriod;
    public Button ButtonYes;//确定按钮
    public Parameter parameter;
    void Start()
    {
        parameter = GameObject.Find("Parameter").GetComponent<Parameter>();
        //Debug.Log(parameter);
        ButtonYes.onClick.AddListener(ChangeParameter);
        Rate.text = parameter.Rate + "";
        Radius.text = parameter.Radius + "";
        WoekRate.text = parameter.WoekRate + "";
        RateLoc1.text = parameter.RateLoc1 + "";
        RateLoc2.text = parameter.RateLoc2 + "";
        RateLoc3.text = parameter.RateLoc3 + "";
        TimeTreatment.text = parameter.TimeTreatment + "";
        Bed.text = parameter.Bed + "";
        TimeDead.text = parameter.TimeDead + "";
        TimeAntibody.text = parameter.TimeAntibody + "";
        RateInHouse.text = parameter.RateInHouse + "";
        IncubationPeriod.text = parameter.IncubationPeriod + "";
    }

    private void ChangeParameter()
    {
        parameter.Rate = float.Parse(Rate.text);
        parameter.Radius = float.Parse(Radius.text);
        parameter.WoekRate = int.Parse(WoekRate.text);
        parameter.RateLoc1 = int.Parse(RateLoc1.text);
        parameter.RateLoc2 = int.Parse(RateLoc2.text);
        parameter.RateLoc3 = int.Parse(RateLoc3.text);
        parameter.TimeTreatment = int.Parse(TimeTreatment.text);
        parameter.Bed = int.Parse(Bed.text);
        parameter.TimeDead = int.Parse(TimeDead.text);
        parameter.TimeAntibody = int.Parse(TimeAntibody.text);
        parameter.RateInHouse = float.Parse(RateInHouse.text);
        parameter.IncubationPeriod = int.Parse(IncubationPeriod.text);
    }
}
