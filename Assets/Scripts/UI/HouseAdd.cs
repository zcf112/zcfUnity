using System;
using UnityEngine;
using UnityEngine.UI;

public class HouseAdd : MonoBehaviour
{
    public Button houseAdd;
    public InputField House, Type, Lx, Ly, Px, Py, Hx, Hy;
    public MysqlManager mysqlManager;
    void Start()
    {
        houseAdd.onClick.AddListener(addHouse);
    }

    private void addHouse()
    {
        mysqlManager = new MysqlManager();
        double x = Convert.ToDouble(Lx.text); //地图长，默认（学校地图）33.73
        double y = Convert.ToDouble(Ly.text);//地图宽，默认（学校地图）36.34
        double x1 = Convert.ToDouble(Px.text);//房子左上角坐标（对角线起点）
        double y1 = Convert.ToDouble(Py.text);
        double w = Convert.ToDouble(Hx.text);//地图上房子长宽
        double h = Convert.ToDouble(Hy.text);

        //中心点位置坐标
        double X = (x1 + w / 2) / x * 300 - 150;
        double Y = (y - y1 - h / 2) / y * 300 - 150;

        string str = "'" + House.text + "','" + Type.text + "','" + Convert.ToString(X) + "','2','" + Convert.ToString(Y) + "','0','0','0','" + Convert.ToString(w) + "','1','" + Convert.ToString(h) + "'";
        mysqlManager.InsertInto("HouseLoc", "House,type,lx,ly,lz,rx,ry,rz,sx,sy,sz", str);
        mysqlManager.Close();
    }
}
