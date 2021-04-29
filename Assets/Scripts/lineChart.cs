﻿using System;
using UnityEngine;
using UnityEngine.UI;
using XCharts;
public class lineChart : MonoBehaviour
{
    public GameObject lChart,TxtInfecting,TxtInfected,TxtDead;//XChart插件里的LineChart对象
    public GameObject lChart_copy, TxtInfecting_copy, TxtInfected_copy, TxtDead_copy;//
    public LineChart chart;//LineChart组件
    public LineChart chart_copy;//
    public int i = 1;
    void Start()
    {
        chart = lChart.GetComponent<LineChart>();
        chart.AddSerie(SerieType.Line, "感染人数");//添加一条折线
        chart.AddSerie(SerieType.Line, "发病人数");//添加一条折线
        chart.AddSerie(SerieType.Line, "死亡人数");//添加一条折线

        chart_copy = lChart_copy.GetComponent<LineChart>();
        chart_copy.AddSerie(SerieType.Line, "感染人数");//添加一条折线
        chart_copy.AddSerie(SerieType.Line, "发病人数");//添加一条折线
        chart_copy.AddSerie(SerieType.Line, "死亡人数");//添加一条折线
    }
    void Update()//每100帧(？)添加一次记录点
    {
        if (i % 100 == 0)
        {
            Text txtInfecting = TxtInfecting.GetComponent<Text>();//从显示感染人数的text上获取感染人数
            chart.series.AddData("感染人数", Int32.Parse(txtInfecting.text));
            Text txtInfected = TxtInfected.GetComponent<Text>();//从显示发病人数的text上获取感染人数
            chart.series.AddData("发病人数", Int32.Parse(txtInfected.text));
            Text txtDead = TxtDead.GetComponent<Text>();//从显示死亡人数的text上获取感染人数
            chart.series.AddData("死亡人数", Int32.Parse(txtDead.text));
            chart.xAxis0.AddData((int)Time.time + "");

            Text txtInfecting_copy = TxtInfecting_copy.GetComponent<Text>();//
            chart_copy.series.AddData("感染人数", Int32.Parse(txtInfecting_copy.text));//
            Text txtInfected_copy = TxtInfected_copy.GetComponent<Text>();//
            chart_copy.series.AddData("发病人数", Int32.Parse(txtInfected_copy.text));//
            Text txtDead_copy = TxtDead_copy.GetComponent<Text>();//
            chart_copy.series.AddData("死亡人数", Int32.Parse(txtDead_copy.text));//
            chart_copy.xAxis0.AddData((int)Time.time + "");//
        }
        i++;
    }
}
