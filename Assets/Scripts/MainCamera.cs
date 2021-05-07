using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
//生成房子（子对象）

public class MainCamera : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;//导航烘焙
    public MysqlManager mysqlManager = new MysqlManager();

    void Start()
    {
        //从数据库中载入房子
        MySqlDataReader reader = mysqlManager.SelectFrom("select House,type,lx,ly,lz,rx,ry,rz,sx,sy,sz from HouseLoc");
        while (reader.Read())
        {
            GameObject h_Clone = (GameObject)Resources.Load("Prefabs/House");//载入预制体
            GameObject h_Clone_copy = (GameObject)Resources.Load("Prefabs/House");//
            h_Clone.transform.localScale = new Vector3(reader.GetFloat(10), reader.GetFloat(9), reader.GetFloat(8));//两参数交换，再加rotation改九十，相当于旋转九十度，更好看清建筑
            h_Clone_copy.transform.localScale = new Vector3(reader.GetFloat(10), reader.GetFloat(9), reader.GetFloat(8));//
            //Debug.Log(reader.GetFloat(2)+","+ reader.GetFloat(3)+","+ reader.GetFloat(4));
            h_Clone = Instantiate(h_Clone, new Vector3(reader.GetFloat(2), reader.GetFloat(3), reader.GetFloat(4)), Quaternion.Euler(reader.GetFloat(5), reader.GetFloat(6), reader.GetFloat(7)), GameObject.Find("Homes").transform);
            h_Clone_copy = Instantiate(h_Clone_copy, new Vector3(reader.GetFloat(2), reader.GetFloat(3)-200, reader.GetFloat(4)), Quaternion.Euler(reader.GetFloat(5), reader.GetFloat(6), reader.GetFloat(7)), GameObject.Find("Homes_copy").transform);//
            h_Clone.name = reader.GetString(0);//改名
            h_Clone_copy.name = reader.GetString(0)+ "_copy";//
            TextMesh textMesh = (TextMesh)GameObject.Find("Homes/" + reader.GetString(0) + "/HouseName").transform.GetComponent(typeof(TextMesh));//设置房子text值
            //TextMesh textMesh_copy = (TextMesh)GameObject.Find("Homes_copy/" + reader.GetString(0) + "_copy/HouseName").transform.GetComponent(typeof(TextMesh));//加了会因为透视杂乱无章
            textMesh.text = reader.GetString(0);
            //textMesh_copy.text = reader.GetString(0);//
        }//实例化房子
        reader.Close();
        
        reader = mysqlManager.SelectFrom("select name,home,timeHome,canteen,timeBreakfast,timeLunch,timeDinner,company,timeWork1,timeWork2,loc1,loc2,loc3,time1,time2,time3,rate1,rate2,rate3,infected from People");
        while (reader.Read())
        {
            GameObject s_Clone = (GameObject)Resources.Load("Prefabs/People");
            GameObject s_Clone_copy = (GameObject)Resources.Load("Prefabs/People_copy");//
            s_Clone = Instantiate(s_Clone, new Vector3(0, 2, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), GameObject.Find("Peoples").transform); //二合一
            s_Clone_copy = Instantiate(s_Clone_copy, new Vector3(0, -198, 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), GameObject.Find("Peoples_copy").transform); //
            s_Clone.name = reader.GetString(0);//改名
            s_Clone_copy.name = reader.GetString(0)+"_copy";//
            people peo = s_Clone.GetComponent<people>();
            people_copy peo_copy = s_Clone_copy.GetComponent<people_copy>();
            //Debug.Log(reader.GetString(0) + reader.GetString(1) + reader.GetString(2) + reader.GetString(3) + reader.GetString(4) + reader.GetString(5) + reader.GetString(6) + 
            //reader.GetString(7) + reader.GetString(8) + reader.GetString(9) + reader.GetString(10) + reader.GetString(11) + reader.GetString(12) + reader.GetString(13) + reader.GetString(14));
            peo.home = GameObject.Find("Homes/" + reader.GetString(1) + "/HTrigger");
            peo.timeHome = reader.GetInt32(2);
            peo.canteen = GameObject.Find("Homes/" + reader.GetString(3) + "/HTrigger");
            peo.timeBreakfast = reader.GetInt32(4);
            peo.timeLunch = reader.GetInt32(5);
            peo.timeDinner = reader.GetInt32(6);
            peo.company = GameObject.Find("Homes/" + reader.GetString(7) + "/HTrigger");
            peo.timeWork1 = reader.GetInt32(8);
            peo.timeWork2 = reader.GetInt32(9);
            peo.Dest1 = GameObject.Find("Homes/" + reader.GetString(10) + "/HTrigger");
            peo.Dest2 = GameObject.Find("Homes/" + reader.GetString(11) + "/HTrigger");
            peo.Dest3 = GameObject.Find("Homes/" + reader.GetString(12) + "/HTrigger");
            peo.time1 = reader.GetInt32(13);
            peo.time2 = reader.GetInt32(14);
            peo.time3 = reader.GetInt32(15);
            peo.rate1 = reader.GetInt32(16);
            peo.rate2 = reader.GetInt32(17);
            peo.rate3 = reader.GetInt32(18);
            peo.isInfecting = reader.GetInt32(19);
            //peo.happy1 = reader.GetInt32(12);
            //peo.happy2 = reader.GetInt32(13);
            //peo.happy3 = reader.GetInt32(14);
            //peo.happy4 = reader.GetInt32(15);

            peo_copy.home = GameObject.Find("Homes_copy/" + reader.GetString(1) + "_copy/HTrigger");
            peo_copy.timeHome = reader.GetInt32(2);
            peo_copy.canteen = GameObject.Find("Homes_copy/" + reader.GetString(3) + "_copy/HTrigger");
            peo_copy.timeBreakfast = reader.GetInt32(4);
            peo_copy.timeLunch = reader.GetInt32(5);
            peo_copy.timeDinner = reader.GetInt32(6);
            peo_copy.company = GameObject.Find("Homes_copy/" + reader.GetString(7) + "_copy/HTrigger");
            peo_copy.timeWork1 = reader.GetInt32(8);
            peo_copy.timeWork2 = reader.GetInt32(9);
            peo_copy.Dest1 = GameObject.Find("Homes_copy/" + reader.GetString(10) + "_copy/HTrigger");
            peo_copy.Dest2 = GameObject.Find("Homes_copy/" + reader.GetString(11) + "_copy/HTrigger");
            peo_copy.Dest3 = GameObject.Find("Homes_copy/" + reader.GetString(12) + "_copy/HTrigger");
            peo_copy.time1 = reader.GetInt32(13);
            peo_copy.time2 = reader.GetInt32(14);
            peo_copy.time3 = reader.GetInt32(15);
            peo_copy.rate1 = reader.GetInt32(16);
            peo_copy.rate2 = reader.GetInt32(17);
            peo_copy.rate3 = reader.GetInt32(18);
            peo_copy.isInfecting = reader.GetInt32(19);
            //peo.happy1 = reader.GetInt32(12);
            //peo.happy2 = reader.GetInt32(13);
            //peo.happy3 = reader.GetInt32(14);
            //peo.happy4 = reader.GetInt32(15);

            peo.hospital = GameObject.Find("Homes/Hospital/HTrigger");//医院地址
            peo.parameter = GameObject.Find("Canvas/Parameter").GetComponent<Parameter>();//参数对象
            peo.txtNumInfecting = GameObject.Find("Canvas/TextSet/numInfecting").GetComponent<Text>();//感染人数
            peo.txtNumInfected = GameObject.Find("Canvas/TextSet/numInfected").GetComponent<Text>();//发病人数
            peo.txtNumBed = GameObject.Find("Canvas/TextSet/numBed").GetComponent<Text>();//剩余床位数
            peo.txtNumDead = GameObject.Find("Canvas/TextSet/numDead").GetComponent<Text>();//死亡人数

            peo_copy.hospital = GameObject.Find("Homes_copy/Hospital/HTrigger");//医院地址
            peo_copy.parameter = GameObject.Find("Canvas_copy/Parameter_copy").GetComponent<Parameter>();//参数对象
            peo_copy.txtNumInfecting = GameObject.Find("Canvas_copy/TextSet_copy/numInfecting").GetComponent<Text>();//感染人数
            peo_copy.txtNumInfected = GameObject.Find("Canvas_copy/TextSet_copy/numInfected").GetComponent<Text>();//发病人数
            peo_copy.txtNumBed = GameObject.Find("Canvas_copy/TextSet_copy/numBed").GetComponent<Text>();//剩余床位数
            peo_copy.txtNumDead = GameObject.Find("Canvas_copy/TextSet_copy/numDead").GetComponent<Text>();//死亡人数
        }

        navMeshSurface.BuildNavMesh();//每次添加后，重新烘焙
        reader.Close();
    }

        void Update()//已经用不到的按键添加对象
    {
        //isShow = GameObject.Find("Homes/Home").GetComponent<Transform>();//查找并获取子物体
        //isShow.Translate(Vector3.forward,Space.World);//测试 移动
        /*按键，查找物体Home，克隆，设为子物体
        GameObject gO = GameObject.Find("Homes/Home");
        if(Input.GetKeyDown(KeyCode.S)){
            GameObject gg=Instantiate(gO,isShow.position,isShow.rotation);
            gg.name="House(clone)";
            gg.GetComponent<Transform>().parent=GameObject.Find("Homes").transform;//设为子物体
        }*/
        /*
        //按键，载入预制体，生成副本，设为子物体
        if(Input.GetKeyDown(KeyCode.S)){
            GameObject h_Clone = (GameObject)Resources.Load("Prefabs/House");//载入预制体
                                                                             //Transform trans = h_Clone.GetComponent<Transform>();//获取预制体数据
                                                                             //Debug.Log(trans.transform.position);//测试

            //h_Clone = Instantiate(h_Clone,new Vector3(-10,2,10*count-20),Quaternion.Euler(0.0f,0.0f,0.0f)); //自己设定位置和角度的数据结构
            //h_Clone.GetComponent<Transform>().parent=GameObject.Find("Homes").transform;//设为子物体
            int x = Random.Range(-15, 15) * 10;
            int z = Random.Range(-20, 15) * 10;
            //h_Clone = Instantiate(h_Clone,new Vector3(-10,2,10*count-30),Quaternion.Euler(0.0f,0.0f,0.0f),GameObject.Find("Homes").transform); //二合一
            h_Clone = Instantiate(h_Clone, new Vector3(x, 2,z), Quaternion.Euler(0.0f, 0.0f, 0.0f), GameObject.Find("Homes").transform);
            h_Clone.name = "Home("+count+")";//改名
            

            GameObject s_Clone = (GameObject)Resources.Load("Prefabs/Student");
            //s_Clone = Instantiate(s_Clone,new Vector3(-10,2,10*count-20),Quaternion.Euler(0.0f,0.0f,0.0f)); //自己设定位置和角度的数据结构
            //s_Clone.GetComponent<Transform>().parent=GameObject.Find("Students").transform;//设为子物体
            s_Clone = Instantiate(s_Clone,new Vector3(x,2,z),Quaternion.Euler(0.0f,0.0f,0.0f),GameObject.Find("Students").transform); //二合一
		    s_Clone.name = "student("+count+")";//改名
            student std=s_Clone.GetComponent<student>();
            std.Dest2=GameObject.Find("School/STrigger");
            std.Dest1=GameObject.Find("Homes/Home("+count+")/HTrigger");
            //Debug.Log(GameObject.Find("School/STrigger"));
            //Debug.Log(GameObject.Find("Homes/Home("+count+")/HTrigger"));
            count++;
            */

            
            //Debug.Log(std);

    }
}