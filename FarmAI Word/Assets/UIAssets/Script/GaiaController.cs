using System.Collections;
using TMPro;
using UnityEngine;

public class GaiaController : MonoBehaviour
{
    public enum States
    {
        Informing,
        Helping
    }
    public States currentState;

    public GameObject painelGaia;
    public TextMeshProUGUI messageText;

    public string[] informations;
    public string[] tips;

    string message;
    public bool painelActivity;
    public int msgIndex;
    float timeByShow;

    public GameObject[] plantacoes;

    private void Start()
    {
        ShowInformation(0);
        plantacoes = GameObject.FindGameObjectsWithTag("Farm");
    }
    private void Update()
    {
        PainelController();
    }

    private void PainelController()
    {
        messageText.text = message;
        painelGaia.SetActive(painelActivity);
        switch (currentState)
        {
            case States.Informing:
                Inform();
                break;
            case States.Helping:
                Help();
                break;
        }
    }

    private void Help()
    {
        painelActivity = HaveProblem();
        if (HaveProblem())
            ScanProblem();
        else
            currentState = States.Informing;
    }

    private void Inform()
    {
        if (!HaveProblem())
        {
            ShowInformation();
        }
        else
            currentState = States.Helping;
    }

    private void ShowInformation()
    {
        if(Time.time > timeByShow)
        {
            timeByShow = Time.time + 5f;
            //ShowInformation(Random.Range(0, informations.Length));
        }
    }

    private bool HaveProblem()
    {
        if (HaveAnyInfestation() || !HaveWater())
            return true;

        return false;
    }

    private void ScanProblem()
    {
        if (!HaveWater())
        {
            ShowTips(1);
        }
        else if (HaveAnyInfestation())
        {
            ShowTips(0);
        }
    }

    private bool HaveWater()
    {
        foreach (GameObject plantacao in plantacoes)
        {
            return plantacao.GetComponent<PlantationStatus>().pWater > 30f;
        }
        return false;   
    }

    private bool HaveAnyInfestation()
    {
        foreach (GameObject plantacao in plantacoes)
        {
            if (plantacao.GetComponent<TaskInsecticide>().HaveInfestation())
            {
                return true;
            }
        }
        return false;
    }

    public void ShowTips(int msg)
    {
        message = tips[msg];
    }

    private void ShowInformation(int m)
    {
        StartCoroutine(ShowPainel());
        msgIndex = m;
        message = informations[msgIndex];
    }
    private IEnumerator ShowPainel()
    {
        painelActivity = true;
        yield return new WaitForSeconds(3f);
        painelActivity = false;
    }
}
