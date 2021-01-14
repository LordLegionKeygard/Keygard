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

    [Header("IceStaff")]
    public Image iabilityImage1;
    public Image iabilityImage2;
    public Image iabilityImage3;
    public float icooldown1 = 5;
    public float icooldown2 = 5;
    public float icooldown3 = 5;

    bool iisCooldown = false;
    bool iisCooldown2 = false;
    bool iisCooldown3 = false;
    public KeyCode iability1;
    public KeyCode iability2;
    public KeyCode iability3;

    [Header("WindStaff")]
    public Image wabilityImage1;
    public Image wabilityImage2;
    public Image wabilityImage3;
    public float wcooldown1 = 5;
    public float wcooldown2 = 5;
    public float wcooldown3 = 5;

    bool wisCooldown = false;
    bool wisCooldown2 = false;
    bool wisCooldown3 = false;
    public KeyCode wability1;
    public KeyCode wability2;
    public KeyCode wability3;

    
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
        IAbility1();
        IAbility2();
        IAbility3();
        WAbility1();
        WAbility2();
        WAbility3();
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

        if(fisCooldown)
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

    void IAbility1()
    {
        if(Input.GetKey(iability1) && iisCooldown == false)
        {
            iisCooldown = true;
            iabilityImage1.fillAmount = 1;
        }

        if(iisCooldown)
        {
            iabilityImage1.fillAmount -= 1 / icooldown1 * Time.deltaTime;

            if(iabilityImage1.fillAmount <= 0)
            {
                iabilityImage1.fillAmount = 0;
                iisCooldown = false;
            }
        }
    }

    void IAbility2()
    {
        if(Input.GetKey(iability2) && iisCooldown2 == false)
        {
            iisCooldown2 = true;
            iabilityImage2.fillAmount = 1;
        }

        if(iisCooldown2)
        {
            iabilityImage2.fillAmount -= 1 / icooldown2 * Time.deltaTime;

            if(iabilityImage2.fillAmount <= 0)
            {
                iabilityImage2.fillAmount = 0;
                iisCooldown2 = false;
            }
        }
    }

    void IAbility3()
    {
        if(Input.GetKey(iability3) && iisCooldown3 == false)
        {
            iisCooldown3 = true;
            iabilityImage3.fillAmount = 1;
        }

        if(iisCooldown3)
        {
            iabilityImage3.fillAmount -= 1 / icooldown3 * Time.deltaTime;

            if(iabilityImage3.fillAmount <= 0)
            {
                iabilityImage3.fillAmount = 0;
                iisCooldown3 = false;
            }
        }
    }

    void WAbility1()
    {
        if(Input.GetKey(wability1) && wisCooldown == false)
        {
            wisCooldown = true;
            wabilityImage1.fillAmount = 1;
        }

        if(wisCooldown)
        {
            wabilityImage1.fillAmount -= 1 / wcooldown1 * Time.deltaTime;

            if(wabilityImage1.fillAmount <= 0)
            {
                wabilityImage1.fillAmount = 0;
                wisCooldown = false;
            }
        }
    }

    void WAbility2()
    {
        if(Input.GetKey(wability2) && wisCooldown2 == false)
        {
            wisCooldown2 = true;
            wabilityImage2.fillAmount = 1;
        }

        if(wisCooldown2)
        {
            wabilityImage2.fillAmount -= 1 / wcooldown2 * Time.deltaTime;

            if(wabilityImage2.fillAmount <= 0)
            {
                wabilityImage2.fillAmount = 0;
                wisCooldown2 = false;
            }
        }
    }

    void WAbility3()
    {
        if(Input.GetKey(wability3) && wisCooldown3 == false)
        {
            wisCooldown3 = true;
            wabilityImage3.fillAmount = 1;
        }

        if(wisCooldown3)
        {
            wabilityImage3.fillAmount -= 1 / wcooldown3 * Time.deltaTime;

            if(wabilityImage3.fillAmount <= 0)
            {
                wabilityImage3.fillAmount = 0;
                wisCooldown3 = false;
            }
        }
    }
}
