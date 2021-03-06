using UnityEngine;
using UnityEngine.UI;

public class Parameter : MonoBehaviour
{
    public float Rate;//传播概率/h
    public float Radius;//传播半径，新冠病毒最主要的传播途径为:近距离接触导致的飞沫传播。飞沫的有效传播距离为≤2米：https://kns.cnki.net/KXReader/Detail?TIMESTAMP=637562562109414063&DBCODE=CCND&TABLEName=CCNDLAST2021&FileName=BJKJ202101250220&RESULT=1&SIGN=r6vbsGU4CEO72H14PeQ4g8zTzns%3d#
    public int WoekRate;//工作比例
    public int RateLoc1;//还会去地点一玩的比例
    public int RateLoc2;//还会去地点一玩的比例
    public int RateLoc3;//还会去地点一玩的比例
    public int IncubationPeriod;//潜伏期/秒
    public int TimeDead;//感染后死亡时间/秒
    public int Bed;//医院床数
    public int TimeAntibody;//治愈后获得抗体时间
    public int TimeTreatment;//治愈所需时间
    public int TimeScale;//时间倍率
    public float RateInHouse;//室内传播倍率

    private void Start()//在上面（类）中赋值的话，修改数据的时候已挂载脚本的数据不会变，要reset才会变（即在unity中手动修改会覆盖脚本数据）
    {
        GameObject.DontDestroyOnLoad(gameObject);//跨场景时不会销毁

        Rate = 10;
        Radius = 1;
        WoekRate = 100;
        RateLoc1 = 100;
        RateLoc2 = 100;
        RateLoc3 = 100;
        IncubationPeriod = 30;
        TimeDead = 70;
        RateInHouse = 2;
        Bed = 5;
        TimeAntibody = 20;
        TimeTreatment = 40;
        TimeScale = 1;
    }
}
