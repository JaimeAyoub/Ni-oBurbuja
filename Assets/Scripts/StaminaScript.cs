using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Threading;

public class StaminaScript : MonoBehaviour
{
    public float stamina;
    public Image staminaBar;
    public float gasto = 0.2f;
    private bool isOutOfStamina = false;
    private float timer = 2;

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

        timer -= 1f;
        if(stamina <= 0)
        {
            isOutOfStamina = true;
        }
        else if (stamina != 0 && timer <= 0)
        {
            isOutOfStamina = false;
        }
    }

    public bool IsOutOfStamina()
    {
        return isOutOfStamina;
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
