using System.Collections;
using TMPro;
using UnityEngine;

public class GaiaController : MonoBehaviour
{
    public GameObject painelGaia;
    public TextMeshProUGUI messageText;
    public string[] message;
    public int msgIndex;

    private void Start()
    {
        ExibirMensagem(0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        messageText.text = message[msgIndex]; 
    }
    private void ExibirMensagem(int m)
    {
        StartCoroutine(ExibirPainel());
        msgIndex = m;
    }

    private IEnumerator ExibirPainel()
    {
        painelGaia.SetActive(true);
        yield return new WaitForSeconds(3f);
        painelGaia.SetActive(false);
    }
}
