using UnityEngine;
using UnityEngine.UI;

/*
 * 时间控制，数字键012控制时间倍率，但只会控制事件相关函数如Update和 LateUpdate，无法控制帧函数（fixupdate）等
 * 
 */
public class time : MonoBehaviour
{
    public Button TimeManager;
    public InputField InputTime;
    private float timer = 0f;
    void Start()
    {
        timer = Time.realtimeSinceStartup;
        InputTime.text = "1";
        TimeManager.onClick.AddListener(ChangeTime);
    }

    void ChangeTime()//修改时间倍率
    {
        Time.timeScale = int.Parse(InputTime.text);
        Parameter parameter = GameObject.Find("Canvas/Parameter").GetComponent<Parameter>();
        parameter.TimeScale = int.Parse(InputTime.text);
    }
}
