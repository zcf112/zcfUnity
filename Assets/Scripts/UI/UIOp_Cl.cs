using UnityEngine;
using UnityEngine.UI;

//显示和关闭菜单
public class UIOp_Cl : MonoBehaviour
{
    public GameObject UIObject;
    public Button UIBtn;
    void Update()
    {
        UIBtn.onClick.AddListener(delegate () {
            if (UIBtn.tag.Equals("open")) UIObject.SetActive(true);
            else UIObject.SetActive(false);
        });

    }
}
