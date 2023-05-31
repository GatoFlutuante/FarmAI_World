using UnityEngine;

public class TaskInsecticide : MonoBehaviour, ITask
{
    public GameObject alert;
    public PlantationStatus integrity;
    GameObject player;

    public float BugTimer;
    public bool Infestation;

    public string infestationType;

    private void Start()
    {
        ResetTimer();
        integrity = GetComponent<PlantationStatus>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        alert.SetActive(HaveInfestation());
        LifeController();
    }
    private void LifeController()
    {
        if (!HaveProblem())
        {
            if (integrity.pHealth < 100)
            {
                integrity.pHealth += Time.deltaTime * 2;
            }
        }
        else
        {
            if (integrity.pHealth > 0)
            {
                integrity.pHealth -= Time.deltaTime * 2;
            }
        }

    }
    private bool HaveInfestation()
    {
        if(BugTimer > 0)
        {
            BugTimer -= Time.deltaTime;
        }
        return BugTimer < 0;
    }
    private bool HaveProblem()
    {
        if(HaveInfestation() || integrity.pWater <= 0.1)
            return true;

        return false;
    }
    private void ResetTimer()
    {
        BugTimer = Random.Range(30f, 60f);
    }
    public void StartTask()
    {
        InventoryController inventory = player.GetComponent<InventoryController>();
        if (inventory.itemInHand != null && HaveInfestation())
        {
            GameObject item = inventory.itemInHand;
            if (item.tag != infestationType)
            {
                print("Errado");
                integrity.pHealth -= 10;
                Destroy(item);
            }
            else
            {
                ResetTimer();
                Infestation = false;
                alert.SetActive(false);
                Destroy(item);
            }     
        }
        else
            print("Você Precisa do inceticida");
    }
}
