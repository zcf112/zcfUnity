using MySql.Data.MySqlClient;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//下拉框显示数据库内容
public class dropdown : MonoBehaviour
{
    public MysqlManager mysqlManager = new MysqlManager();
    public Dropdown dDown;
    public InputField id;
    public InputField peo_name;
    public InputField type;
    public InputField home;
    public InputField company;
    public InputField loc1;
    public InputField loc2;
    public InputField loc3;
  
    void Start()
    {
        MySqlDataReader reader=mysqlManager.SelectFrom("select id,name from People");
        List<string> DropOptions=new List<string>();
        
        while (reader.Read())//将数据库读取到的每一条加到下拉框里
        {
            int count = reader.FieldCount;
            for (int i = 0; i < count; i++)
            {
                string key = reader.GetValue(i)+" "+ reader.GetValue(++i);
                DropOptions.Add(key);
            }    
        }
        dDown.AddOptions(DropOptions);
        //添加监听器,下拉表里选项被点击时触发
        dDown.GetComponent<Dropdown>().onValueChanged.AddListener(ConsoleResult);
        reader.Close();
    }

    public void ConsoleResult(int value)//下拉框中某一选项被点击时，在文本框中加字
    {
        MySqlDataReader reader = mysqlManager.SelectFrom("select id,name,type,home,company,loc1,loc2,loc3 from People");
        Debug.Log(value);
        int count = 0;
        while (reader.Read())
        {
            //Debug.Log("count");
            if (count == value)
            {
                //Debug.Log("if");
                id.text= reader.GetString(0);
                peo_name.text = reader.GetString(1);
                type.text = reader.GetString(2);
                home.text = reader.GetString(3);
                company.text = reader.GetString(4);
                loc1.text = reader.GetString(5);
                loc2.text = reader.GetString(6);
                loc3.text = reader.GetString(7);
                break;
            }
            count++;
        }
        reader.Close();
    }
}
