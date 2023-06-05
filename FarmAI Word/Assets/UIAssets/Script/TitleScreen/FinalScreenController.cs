using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreenController : MonoBehaviour
{
    public static int money;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void BackToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToNextDay()
    {
        SceneManager.LoadScene(1);
    }
}
