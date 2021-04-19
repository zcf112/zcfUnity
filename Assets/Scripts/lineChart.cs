using System;
using UnityEngine;
using UnityEngine.UI;
using XCharts;
public class lineChart : MonoBehaviour
{
    public GameObject lChart,Txt;//XChart插件里的LineChart对象
    public LineChart chart;//LineChart组件
    public int i = 1;
    void Start()
    {
        chart = lChart.GetComponent<LineChart>();
        chart.AddSerie(SerieType.Line, "感染人数");//添加一条折线
    }
    void Update()//每100帧(？)添加一次记录点
    {
        if (i % 100 == 0)
        {
            Text txt = Txt.GetComponent<Text>();//从显示感染人数的text上获取感染人数
            chart.series.AddData("感染人数", Int32.Parse(txt.text));
            chart.xAxis0.AddData((int)Time.time + "");
        }
        i++;
    }
}
