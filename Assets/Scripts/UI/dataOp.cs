using System;
using UnityEngine;
using UnityEngine.UI;

//增删查改数据库
public class dataOp : MonoBehaviour
{
    public Button add_btn, update_btn, delete_btn;
    public Text id,peo_name,type,home,company,loc1,loc2,loc3;
    public MysqlManager mysqlManager;
    void Start()//给按钮挂方法
    {
        add_btn.onClick.AddListener(add_op);
        update_btn.onClick.AddListener(update_op);
        delete_btn.onClick.AddListener(delete_op);
    }
    void add_op()//增
    {
        mysqlManager = new MysqlManager();
        string str = "'" + peo_name.text + "','" + type.text + "','" + home.text + "','" + company.text + "','" + loc1.text + "','" + loc2.text + "','" + loc3.text+"','0'";
        mysqlManager.InsertInto("People", "name,type,home,company,loc1,loc2,loc3,infected", str);
        mysqlManager.Close();
    }
    private void update_op()//改
    {
        mysqlManager = new MysqlManager();
        String str = "set `name`='" + peo_name.text + "',`type`='" + type.text + "',`home`='" + home.text + "',`company`='" + company.text + "',`loc1`='" + loc1.text + "',`loc2`='" + loc2.text + "',`loc3`='" + loc3.text+"'";
        mysqlManager.UpdateSet("People", str, int.Parse(id.text));
        mysqlManager.Close();
    }
    private void delete_op()//删
    {
        mysqlManager = new MysqlManager();
        mysqlManager.DeleteFrom("People", int.Parse(id.text));
        mysqlManager.Close();
    }
}
