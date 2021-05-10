using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Op : MonoBehaviour
{
    //批量添加和删除的按钮脚本
    public MysqlManager mysqlManager;
    public Dropdown dDown;
    public InputField inputFieldNum;
    public InputField inputFieldInfectingRate;
    public Button ButtonAdd, ButtonDelete;
    public string SelectedOption;//记录被选中的职业
    public Random rand = new Random(Guid.NewGuid().GetHashCode());

    void Start()
    {
        mysqlManager = new MysqlManager();
        MySqlDataReader reader = mysqlManager.SelectFrom("select type from JobLoc");
        List<string> DropOptions = new List<string>();

        while (reader.Read())//将数据库读取到的每一条加到下拉框里
        {
            int count = reader.FieldCount;
            SelectedOption = reader.GetString(0);//给变量赋初值
            for (int i = 0; i < count; i++)
            {
                string key = reader.GetString(i);
                DropOptions.Add(key);
            }
        }
        dDown.AddOptions(DropOptions);
        //添加监听器,下拉表里选项被点击时触发
        dDown.GetComponent<Dropdown>().onValueChanged.AddListener(ConsoleResult);
        reader.Close();
        mysqlManager.Close();

        ButtonAdd.onClick.AddListener(buttonAdd);
        ButtonDelete.onClick.AddListener(buttonDelete);
    }

    private void buttonDelete()
    {//同时有两个reader或manager或出错，得先close一个，拆开来就会很麻烦
        Debug.Log("buttonDelete");
        mysqlManager = new MysqlManager();
        MySqlDataReader reader = mysqlManager.SelectFrom("select ID from People where type = '" + SelectedOption + "'");
        int i = 0,count = Convert.ToInt32(inputFieldNum.text);
        int[] num = new int[count];//用来保存ID串
        while (reader.Read())
        {
            if (i == count) break;
            num[i++] = reader.GetInt32(0);
        }
        reader.Close();

        mysqlManager = new MysqlManager();
        for(int j = 0; j < i; j++)mysqlManager.DeleteFrom("People", num[j]);
        if (count > i) Debug.Log("输入数字过大，库中删除数据不足");
        //reader.Close();
        mysqlManager.Close();
    }

    private void buttonAdd()
    {
        mysqlManager = new MysqlManager();
        MySqlDataReader reader = mysqlManager.SelectFrom("select home,timeHome,canteen,timeBreakfast,timeLunch,timeDinner,company,timeWork1,timeWork2,loc1,loc2,loc3,time1,time2,time3,rate1,rate2,rate3 from JobLoc where type = '"+SelectedOption+"'");
        int timeHome = 0, timeBreakfast = 0, timeLunch = 0, timeDinner = 0, timeWork1 = 0, timeWork2 = 0, time1 = 0, time2 = 0, time3 = 0, rate1 = 0, rate2 = 0, rate3 = 0, infected = 0;
        String Home = "", canteen = "", company = "", loc1 = "", loc2 = "", loc3 = "";
        while (reader.Read())
        {
            Home = reader.GetString(0);
            timeHome = reader.GetInt32(1);
            canteen = reader.GetString(2);
            timeBreakfast = reader.GetInt32(3);
            timeLunch = reader.GetInt32(4);
            timeDinner = reader.GetInt32(5);
            company = reader.GetString(6);
            timeWork1 = reader.GetInt32(7);
            timeWork2 = reader.GetInt32(8);
            loc1 = reader.GetString(9);
            loc2 = reader.GetString(10);
            loc3 = reader.GetString(11);
            time1 = reader.GetInt32(12);
            time2 = reader.GetInt32(13);
            time3 = reader.GetInt32(14);
            rate1 = reader.GetInt32(15);
            rate2 = reader.GetInt32(16);
            rate3 = reader.GetInt32(17);
        }
        reader.Close();
        mysqlManager.Close();

        Random random = new Random(Guid.NewGuid().GetHashCode());//短时间内也不会重复的随机数，来自https://www.itdaan.com/blog/2017/06/22/aaad227616e68bb20296da02bbce451c.html
        for (int i = 0; i < Convert.ToInt32(inputFieldNum.text); i++)
        {
            string Home_ = change(Home);
            string canteen_ = change(canteen);
            string company_ = change(company);
            string loc1_ = change(loc1);
            string loc2_ = change(loc2);
            string loc3_ = change(loc3);

            //Debug.Log(random.Next(0, 100));
            //Debug.Log(inputFieldInfectingRate.text);
            int rd = random.Next(0, 100);
            if (rd < Convert.ToInt32(inputFieldInfectingRate.text)) infected = 1;
            else infected = 0;
            mysqlManager = new MysqlManager();
            string str="'" + SelectedOption+  "','" + SelectedOption + "','" + Home_ + "','" + timeHome + "','" + canteen_ + "','" + timeBreakfast + "','" + timeLunch + "','" + timeDinner + "','" + company_ + "','" + timeWork1 + "','" + timeWork2 + "','" + loc1_ + "','" + loc2_ + "','" + loc3_ + "','" + time1 + "','" + time2 + "','" + time3 + "','" + rate1 + "','" + rate2 + "','" + rate3 + "','" + infected +"'";
            mysqlManager.InsertInto("People", "name,type,home,timeHome,canteen,timeBreakfast,timeLunch,timeDinner,company,timeWork1,timeWork2,loc1,loc2,loc3,time1,time2,time3,rate1,rate2,rate3,infected", str);
            mysqlManager.Close();
            
        }
    }

    private void ConsoleResult(int value)//下拉框被点击时触发事件
    {
        //Debug.Log(value);
        int count = 0;
        mysqlManager = new MysqlManager();
        MySqlDataReader reader = mysqlManager.SelectFrom("select type from JobLoc");
        while (reader.Read())//将数据库读取到的每一条加到下拉框里
        {
            if (count == value)
            {
                SelectedOption = reader.GetString(0);
                //Debug.Log(SelectedOption + "," + reader.GetString(0));
                break;
            }
            else count++;
        }
        reader.Close();
        mysqlManager.Close();
    }

    private String change(String str)//将输入的建筑类型随机抽取一栋返回
    {
        int count = 0;//记录某种建筑条数等
        
        mysqlManager = new MysqlManager();

        MySqlDataReader reader = mysqlManager.SelectFrom("select count(*) from HouseLoc where type = '" + str + "'");
        while (reader.Read()) count = reader.GetInt32(0);//获取str建筑的个数
        Debug.Log(str + count);
        reader.Close();

        reader = mysqlManager.SelectFrom("select House from HouseLoc where type = '" + str + "'");
        count = rand.Next(0, count);
        while (reader.Read())
        {
            if (count == 0)
            {
                str = reader.GetString(0);
                break;
            }
            else
            {
                count--;
            }
        }
        reader.Close();
        mysqlManager.Close();

        return str;
    }
}
