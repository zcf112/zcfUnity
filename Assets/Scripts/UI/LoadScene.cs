using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{//载入场景并赋予初始值
    public Button buttonLoadScene;
    void Start()
    {
        buttonLoadScene.onClick.AddListener(loadScene);
    }

    private void loadScene()
    {
        SceneManager.LoadScene("Main");//引号内为场景
    }
}
