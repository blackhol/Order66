using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldAndHealth : MonoBehaviour
{

    public enum State { ShieldState, HealthState, IdleState };
    public State currentState;

    public float curHealth;
    public float maxHealth;
    public float shield;
    public float maxShield;
    public float shieldRegen;
    public CanvasGroup visualShield;
    public CanvasGroup visualHealth;
    public CanvasGroup visualCrackedShield;
    public bool shieldON;
    public bool healthLow;
    public float fadeInTime;

    public float damage;




    // Use this for initialization
    void Start()
    {
        currentState = State.IdleState;
        curHealth = maxHealth;
        shield = maxShield;

    }

    // Update is called once per frame
    void Update()
    {  
        // switch
        switch (currentState)
        {
            case State.ShieldState:
                Shield();
                break;
            case State.HealthState:
                Health();
                break;
            case State.IdleState:
                // still doubting weither or not i need an idle state 
                // No checks
                break;
        }
    }
    public void Shield()
    {
        if(visualHealth.alpha > 0)
        {
            visualHealth.alpha -= Time.deltaTime / 2;
        }
        if (shield > maxShield / 2)
        {
            shieldON = true;
            if (shieldON == true)
            {
                for (int i = 0; i < fadeInTime; i++)
                {
                    visualShield.alpha += Time.deltaTime / 2;
                    if(visualShield.alpha == 1)
                    {
                        shieldON = false;
                    }
                }
            }
            if (visualCrackedShield.alpha > 0)
            {
                visualCrackedShield.alpha -= Time.deltaTime / 2;
            }
        }
        if (shield < maxShield / 2)
        {
            for (int e = 0; e < fadeInTime; e++)
            {
                visualShield.alpha -= Time.deltaTime / 2;
                visualCrackedShield.alpha += Time.deltaTime / 2; 
            }
            if (shield <= 0)
            {
                shield = 0f;
                visualCrackedShield.alpha = 0f;
                visualShield.alpha = 0f;
                print("shield deactivated");
                currentState = State.HealthState;
            }
        }
    }
    public void Health()
    {
        // disable both shields
        if(visualShield.alpha > 0)
        {
            visualShield.alpha -= Time.deltaTime / 2;
        }
        if(visualCrackedShield.alpha > 0)
        {
            visualCrackedShield.alpha -= Time.deltaTime / 2;
        }
     
        shield += shieldRegen * Time.deltaTime;
        if (shield >= maxShield)
        {
            shield = maxShield;
            visualHealth.alpha -= Time.deltaTime / 2;
            currentState = State.ShieldState;
        }

        if (curHealth < maxHealth / 2)
        {
            if (healthLow == true)
            {
                for (int i = 0; i < fadeInTime; i++)
                {
                    visualHealth.alpha += Time.deltaTime / 2;
                    if (visualHealth.alpha == 1)
                    {
                        healthLow = false;
                    }
                }
            }

            if (healthLow == false)
            {
                for (int o = 0; o < fadeInTime; o++)
                {
                    visualHealth.alpha -= Time.deltaTime / 2;
                    if (visualHealth.alpha == 0)
                    {
                        healthLow = true;
                    }
                }
            }
        }

        if (curHealth > maxHealth / 2)
        {
            for(int i = 0; i < fadeInTime; i++)
            {
                visualHealth.alpha -= Time.deltaTime / 2;
            }      
        }
    }
}

