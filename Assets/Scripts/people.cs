using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class people : MonoBehaviour
{
    public GameObject home, canteen, company,Dest1,Dest2,Dest3;//寻路到目标物体
    public GameObject hospital;//医院地址
    public int timeHome, timeBreakfast, timeLunch, timeDinner, timeWork1, timeWork2, time1, time2, time3, rate1, rate2, rate3;
    //public float time1, time2, rate1, rate2, rate3,value, happy1, happy2, happy3, happy4;//时间，概率，工作价值，幸福度

    private NavMeshAgent agent;//导航
    public System.Random rd = new System.Random();

    public int isInfected = 0;//发病者
    public int isInfecting=0;//感染者
    public int isDead=0;//死亡者
    public int inHospital = 0;//在医院或去的路上

    public int TimeIncubation = 99999999;//发病天数
    public int TimeDead = 99999999;//死亡天数
    public int TimeTreatment = 8000;//治疗需要的天数
    public int TimeAntibody = 0;//感染后获得的抗体天数

    public int timeUse = 0;//做某件事的剩余时间，例如吃饭要一个小时，出去玩要三四个小时，归零才做下一件事或回家，与定时做事（七点去上学）同时存在（？？优先级）

    public GameObject peo;//people对象
    public Parameter parameter;//参数对象
    public Text txtNumInfecting;//感染人数
    public Text txtNumInfected;//发病人数
    public Text txtNumBed;//剩余床位数
    public Text txtNumDead;//死亡人数
    //public  这是什么？？？ 

    // 寻路
    void Start(){
        peo.GetComponent<Renderer>().material.color = Color.white;//初始未感染者设为白色

        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(home.transform.position);//寻路，先回家

        if (isInfecting==1)//如果被感染了，变黄，计数加一
        {
            peo.GetComponent<Renderer>().material.color = Color.yellow;
            txtNumInfecting.text=(Int32.Parse(txtNumInfecting.text)+1)+"";
            TimeIncubation = parameter.IncubationPeriod;
            isInfecting = 1;
        }

        StartCoroutine(Timer());
    }

    void Update()
    {
        if (isDead == 0)//活着的时候
        {
            if (inHospital == 1)//在医院了，时间到了就出院
            {
                if (TimeDead <= 0)//死亡：变黑，死亡人数加一，床位加一，
                {
                    isDead = 1;
                    peo.GetComponent<Renderer>().material.color = Color.black;
                    txtNumBed.text = (Int32.Parse(txtNumBed.text) + 1) + "";
                    txtNumDead.text = (Int32.Parse(txtNumDead.text) + 1) + "";
                    txtNumInfected.text = (Int32.Parse(txtNumInfected.text) - 1) + "";
                    txtNumInfecting.text = (Int32.Parse(txtNumInfecting.text) - 1) + "";
                }
                else if (TimeTreatment <= 0)//治愈：感染人数减一，感染flag=0，变白，出院=0，床数加一，获得抗体时间，重置死亡时间和感染时间
                {
                    isInfected = 0;
                    inHospital = 0;
                    peo.GetComponent<Renderer>().material.color = Color.white;
                    txtNumInfected.text = (Int32.Parse(txtNumInfected.text) - 1) + "";
                    txtNumBed.text = (Int32.Parse(txtNumBed.text) + 1) + "";
                    txtNumInfecting.text = (Int32.Parse(txtNumInfecting.text) - 1) + "";
                    TimeAntibody = parameter.TimeAntibody;
                    TimeDead = parameter.TimeDead;
                    TimeIncubation = parameter.IncubationPeriod;
                    agent.SetDestination(home.transform.position);//病愈回家
                }
                else//减少治愈时间和死亡时间
                {
                    Debug.Log("减少治愈时间和死亡时间");
                    TimeDead--;
                    TimeTreatment--;
                }
            }
            else if (isInfected == 1 && Int32.Parse(txtNumBed.text) > 0)//发病且有空余床位且不在医院->床位减一,前往医院，在医院flag变一
            {
                inHospital = 1;
                txtNumBed.text = Int32.Parse(txtNumBed.text) - 1 + "";
                agent.SetDestination(hospital.transform.position);
                Debug.Log("去医院");
            }
            else if (isInfected == 1)//发病且没空余床位,死亡时间减少
            {
                TimeDead--;
                Debug.Log(TimeDead);
                if (TimeDead == 0)//死亡，停止运动
                {
                    isDead = 1;
                    peo.GetComponent<Renderer>().material.color = Color.black;
                    txtNumDead.text = (Int32.Parse(txtNumDead.text) + 1) + "";
                    txtNumInfected.text = (Int32.Parse(txtNumInfected.text) - 1) + "";
                    agent.SetDestination(peo.transform.position);
                }
                Activity();//定时定点活动
            }
            else if (isInfecting == 1)//未发病时,发病天数减少，少到零时潜伏为零，已感染为一，获取死亡时间，变红色
            {
                Debug.Log("未发病时");
                TimeIncubation--;
                if(TimeIncubation == 0)
                {
                    isInfecting = 0;
                    isInfected = 1;
                    peo.GetComponent<Renderer>().material.color = Color.red;
                    TimeDead = parameter.TimeDead;
                    TimeTreatment = parameter.TimeTreatment;
                    //txtNumInfecting.text = (Int32.Parse(txtNumInfecting.text) - 1) + "";
                    txtNumInfected.text = (Int32.Parse(txtNumInfected.text) + 1) + "";
                }
                Activity();//定时定点活动
            }
            else//没病，有抗体则每天减一
            {
                Debug.Log("没病");
                Activity();//定时定点活动
                if (TimeAntibody > 0) TimeAntibody--;
            }
        }
        else//死亡，停止活动
        {
            Debug.Log("死亡");
        }
    }

    private void Activity()
    {
        System.Random ran = new System.Random();
        int RandKey = ran.Next(0, 24);
        //Debug.Log(Time.time);//显示时间
        if (Time.time % 24 == time1)
        {
            agent.SetDestination(company.transform.position);
        }
        if (Time.time % 24 == time2)
        {
            agent.SetDestination(home.transform.position);
        }

        //if ((Time.time % 24 < time1) || (Time.time % 24 > time2))//上班时间外可以出去玩？晚班呢？
        //{
            if (ran.Next(0, 100000) < rate1)
            {
                agent.SetDestination(Dest1.transform.position);
            }
            if (ran.Next(0, 100000) < rate2)
            {
                agent.SetDestination(Dest2.transform.position);
            }
            if (ran.Next(0, 100000) < rate3)
            {
                agent.SetDestination(Dest3.transform.position);
            }
        //}
    }

    void OnTriggerStay(Collider coll)//与其他个体接触时，感染判断代码
    {
        if (coll.gameObject.CompareTag("peopletag") && (coll.gameObject.GetComponent<Renderer>().material.color == Color.red || coll.gameObject.GetComponent<Renderer>().material.color == Color.yellow))//遇到感染者或发病者，概率感染变黄色并加一计数
        {
            if ( peo.GetComponent<Renderer>().material.color == Color.white && TimeAntibody==0)
            {
                if (rd.Next(0, 3000) == 1)//改颜色，改潜伏期，感染计数加一，感染flag变一
                {
                    Debug.Log("感染");
                    isInfecting = 1;
                    peo.GetComponent<Renderer>().material.color = Color.yellow;
                    txtNumInfecting.text = (Int32.Parse(txtNumInfecting.text) + 1) + "";
                    TimeIncubation = parameter.IncubationPeriod;
                }
            }
        }

        /*没有把两个if交换的代码（为了能够加入抗体时间才交换）
        if (coll.gameObject.CompareTag("peopletag") && coll.gameObject.GetComponent<Renderer>().material.color == Color.white)//遇到感染者或发病者，概率感染变黄色并加一计数
        {
            Debug.Log("render的");
            if (peo.GetComponent<Renderer>().material.color==Color.red|| peo.GetComponent<Renderer>().material.color == Color.yellow)
            {
                if (rd.Next(0,3000) == 1)
                {
                    Debug.Log("感染");
                    coll.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    txtNumInfecting.text = (Int32.Parse(txtNumInfecting.text) + 1) + "";
                    TimeIncubation = parameter.IncubationPeriod;//还需修改，天数和time之间的转换？？？？？
                }
            }
        }*/
    }

    IEnumerator Timer()//获取时间倍率并赋值（问题：activity为false时出错，且只在开始执行，不会更新） 
    {
        float timescale = parameter.TimeScale+0.0f;
        while (true) {
            yield return new WaitForSeconds(1.0f/timescale);
            //Debug.Log(string.Format("Timer2 is up !!! time=${0}", Time.time%24));
        }
    }

    /*
    isShow = GameObject.Find("Homes/Home").GetComponent<Transform>();//查找并获取子物体
        //isShow.Translate(Vector3.forward,Space.World);//测试 移动

        GameObject gO = GameObject.Find("Homes/Home");
        if(Input.GetKeyDown(KeyCode.S)){
            GameObject gg=Instantiate(gO,isShow.position,isShow.rotation);
            gg.name="House(clone)";
            gg.GetComponent<Transform>().parent=GameObject.Find("Homes").transform;//设为子物体
        }
    */
}
