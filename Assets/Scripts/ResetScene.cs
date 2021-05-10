using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetScene : MonoBehaviour
{
    public Button buttonResetScene;
    // Start is called before the first frame update
    void Start()
    {
        buttonResetScene.onClick.AddListener(resetScene);
    }

    private void resetScene()
    {
        SceneManager.LoadScene("Main");//引号内为场景
    }
}
