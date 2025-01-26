using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    public float stamina;
    public Image staminaBar;
    public float gasto = 0.2f;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            UseStamina(gasto);
        }
        else
        {
            AddStamina(gasto);
        }
    }

    void UseStamina(float gasto)
    {
        stamina -= gasto;
        float staminaTarget = stamina / 100f;
        staminaBar.DOFillAmount(staminaTarget, 0.7f);
    }

    void AddStamina(float add)
    {
        stamina += add;
        float staminaTarget = stamina / 100f;
        staminaBar.DOFillAmount(staminaTarget, 1);
    }

}
