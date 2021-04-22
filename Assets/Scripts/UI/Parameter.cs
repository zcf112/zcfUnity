using UnityEngine;

public class Parameter : MonoBehaviour
{
    public int Rate = 100;//传播概率
    public int Radius = 100;//传播半径
    public int WoekRate = 100;//工作比例
    public int RateLoc1 = 100;//还会去地点一玩的比例
    public int RateLoc2 = 100;//还会去地点一玩的比例
    public int RateLoc3 = 100;//还会去地点一玩的比例
    public int IncubationPeriod = 0;//潜伏期/天
    public int LsolationRate = 100;//发病隔离比例
    public int Bed = 0;//医院床数

    public int TimeScale = 1;//时间倍率
}
