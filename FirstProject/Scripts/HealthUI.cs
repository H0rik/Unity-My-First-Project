using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image [] healthImages = new Image[5];
    public int healthCount = 5;


    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().SetHealthUI(this);
        for (int i = 0; i <=healthCount-1; i++)
        {
            healthImages[i] = transform.GetChild(i).GetComponent<Image>();
        }

    }
    public void RestartGame(int HP)
    {
        healthCount = HP;
        for(int i = 0;i <=healthCount-1;i++)
        {
            healthImages[i].enabled = true;
        }
    }

    public void ChangeHealth(int HP)
    {
        if(HP!=healthCount)
        {
            if (HP < healthCount)
                DecreaseHealth();
            else
                IncreaseHealth();

        }
    }


    public void IncreaseHealth()
    {
        healthCount++;
        healthImages[healthCount-1].enabled = true;

    }
    public void DecreaseHealth()
    {
        healthImages[healthCount-1].enabled = false;
        healthCount--;
    }
}
