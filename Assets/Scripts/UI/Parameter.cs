using UnityEngine;
using UnityEngine.UI;

public class Parameter : MonoBehaviour
{
    public int Rate = 100;//传播概率
    public int Radius = 100;//传播半径
    public int WoekRate = 100;//工作比例
    public int RateLoc1 = 100;//还会去地点一玩的比例
    public int RateLoc2 = 100;//还会去地点一玩的比例
    public int RateLoc3 = 100;//还会去地点一玩的比例
    public int IncubationPeriod = 3000;//潜伏期100/秒
    public int TimeDead = 7000;//感染后死亡时间100/秒
    public int LsolationRate = 100;//发病隔离比例
    public int Bed = 5;//医院床数
    public int TimeAntibody = 2000;//治愈后获得抗体时间
    public int TimeTreatment = 4000;//治愈所需时间
    public int TimeScale = 1;//时间倍率

    private void Start()
    {
        Text numBed = GameObject.Find("Canvas/TextSet/numBed").GetComponent<Text>();
        numBed.text = Bed.ToString();//剩余床位数
        Debug.Log(Bed.ToString());
        Debug.Log(Bed);
    }
}
