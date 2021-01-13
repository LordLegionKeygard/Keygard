using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    [Header("PoisonStaff")]  
    public Image abilityImage1;
    public Image abilityImage2;
    public Image abilityImage3;
    public float cooldown1 = 5;
    public float cooldown2 = 5;
    public float cooldown3 = 5;

    bool isCooldown = false;
    bool isCooldown2 = false;
    bool isCooldown3 = false;
    public KeyCode ability1;
    public KeyCode ability2;
    public KeyCode ability3;

    [Header("FireStaff")]
    public Image fabilityImage1;
    public Image fabilityImage2;
    public Image fabilityImage3;
    public float fcooldown1 = 5;
    public float fcooldown2 = 5;
    public float fcooldown3 = 5;

    bool fisCooldown = false;
    bool fisCooldown2 = false;
    bool fisCooldown3 = false;
    public KeyCode fability1;
    public KeyCode fability2;
    public KeyCode fability3;

    
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        fabilityImage1.fillAmount = 0;
        fabilityImage2.fillAmount = 0;
        fabilityImage3.fillAmount = 0;

    }

    // Update is called once per frame
    private void Update()
    {
        Ability1();
        Ability2();
        Ability3();
        FAbility1();
        FAbility2();
        FAbility3();
    }

    void Ability1()
    {
        if(Input.GetKey(ability1) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }

        if(isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void Ability2()
    {
        if(Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }

        if(isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if(abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Ability3()
    {
        if(Input.GetKey(ability3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
        }

        if(isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if(abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    void FAbility1()
    {
        if(Input.GetKey(fability1) && fisCooldown == false)
        {
            fisCooldown = true;
            fabilityImage1.fillAmount = 1;
        }

        if(isCooldown)
        {
            fabilityImage1.fillAmount -= 1 / fcooldown1 * Time.deltaTime;

            if(fabilityImage1.fillAmount <= 0)
            {
                fabilityImage1.fillAmount = 0;
                fisCooldown = false;
            }
        }
    }

    void FAbility2()
    {
        if(Input.GetKey(fability2) && fisCooldown2 == false)
        {
            fisCooldown2 = true;
            fabilityImage2.fillAmount = 1;
        }

        if(fisCooldown2)
        {
            fabilityImage2.fillAmount -= 1 / fcooldown2 * Time.deltaTime;

            if(fabilityImage2.fillAmount <= 0)
            {
                fabilityImage2.fillAmount = 0;
                fisCooldown2 = false;
            }
        }
    }

    void FAbility3()
    {
        if(Input.GetKey(fability3) && fisCooldown3 == false)
        {
            fisCooldown3 = true;
            fabilityImage3.fillAmount = 1;
        }

        if(fisCooldown3)
        {
            fabilityImage3.fillAmount -= 1 / fcooldown3 * Time.deltaTime;

            if(fabilityImage3.fillAmount <= 0)
            {
                fabilityImage3.fillAmount = 0;
                fisCooldown3 = false;
            }
        }
    }
}
