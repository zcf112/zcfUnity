using UnityEngine;
using UnityEngine.UI;
//一个没用到的脚本，展示多个同层按钮事件单脚本处理
public class menu : MonoBehaviour
{
    void Start()
    {
        Button[] Buttons = FindObjectsOfType<Button>();
        foreach (var item in Buttons)item.onClick.AddListener(() => OnButtonClicked(item));//这不知道什么意思
    }
    private void OnButtonClicked(Button item)
    {
        switch (item.name)
        {
            case "add":
                Debug.Log("add");
                break;
            case "update":
                Debug.Log("update");
                break;
        }
    }
}
