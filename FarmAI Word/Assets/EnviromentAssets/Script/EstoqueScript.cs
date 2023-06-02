using UnityEngine;

public class EstoqueScript : MonoBehaviour
{
    public static int[] values;
    public int[] currentValue;
    public UI_CaixaDeInceticida[] caixaDeInceticida;

    private void Start()
    {
        try
        {
            SetValueCount();
        }
        catch
        {
            print("No Refrence");
        }
    }

    private void Update()
    {
        GetValueCount();
    }

    private void GetValueCount()
    {
        currentValue = new int[caixaDeInceticida.Length];

        for (int i = 0; i < caixaDeInceticida.Length; i++)
        {
            currentValue[i] = caixaDeInceticida[i].currentStockCount;
        }

        values = currentValue;
    }

    private void SetValueCount()
    {
        for (int i = 0; i < caixaDeInceticida.Length; i++)
        {
            caixaDeInceticida[i].currentStockCount = values[i];
        }
    }
}
