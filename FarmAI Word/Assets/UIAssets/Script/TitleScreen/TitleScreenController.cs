using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public Button btnStart;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
