using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{

    Animator animator;

    public GameObject _triangle;
    public GameObject loadingScreen;
    public GameObject loading;
    public GameObject press;
    public Slider bar; 

    [Header("WindStaff")]
    public GameObject WStaff;
    public GameObject WSkillj;
    public GameObject WSkillk;
    public GameObject WSkilll;
    public GameObject WSkghost1;
    public GameObject WSkghost2;
    public GameObject WSkghost3;

    [Header("IceStaff")]
    public GameObject IStaff;
    public GameObject ISkillj;
    public GameObject ISkillk;
    public GameObject ISkilll;
    public GameObject ISkghost1;
    public GameObject ISkghost2;
    public GameObject ISkghost3;

    [Header("FireStaff")]
    public GameObject FStaff;
    public GameObject FSkillj;
    public GameObject FSkillk;
    public GameObject FSkilll;
    public GameObject FSkghost1;
    public GameObject FSkghost2;
    public GameObject FSkghost3;


    [Header("PoisonStaff")]
    public GameObject PStaff;
    public GameObject PSkillj;
    public GameObject PSkillk;
    public GameObject PSkilll;
    public GameObject PSkghost1;
    public GameObject PSkghost2;
    public GameObject PSkghost3;

    [Header("Music Effect")]
    public AudioSource PickUpStaff;
    public AudioSource PickUpScroll;
    public AudioSource PickUpPotion;
    public AudioSource Gw;
         
    private GameObject finish;

    private void Start()
    {
        animator = GetComponent<Animator>();
        finish = GameObject.FindGameObjectWithTag("Finish");
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Potion1")
        {
            PickUpPotion.Play();
            _triangle.SetActive(true);
            Destroy(other.gameObject);
        } 
        if(other.gameObject.name == "GhostWall1")
        {
            Destroy(other.gameObject);
            Gw.Play();
        }  
        if(other.gameObject.name == "GhostWall")
        {
            Destroy(other.gameObject);
            Gw.Play();
        }     
        if(other.gameObject.name == "RandomStaff")
        {
            PickUpStaff.Play();           
            Destroy(other.gameObject);
            RandomStatePicker();            
        }
        
        if(other.gameObject.name == "LScroll")
        {
            PickUpScroll.Play();           
            Destroy(other.gameObject);
            var myscript = gameObject.GetComponent<Weapon1>();
            var fmyscript = gameObject.GetComponent<FireWeapon1>();
            var imyscript = gameObject.GetComponent<IceWeapon1>();
            var wmyscript = gameObject.GetComponent<WindWeapon1>();
            if(PStaff.activeInHierarchy)
            {      
                myscript.enabled = true;
                PSkilll.SetActive(true);
                PSkghost3.SetActive(true);
            }
            if(FStaff.activeInHierarchy)
            {
                fmyscript.enabled = true;
                FSkilll.SetActive(true);
                FSkghost3.SetActive(true);
            }
            if(IStaff.activeInHierarchy)
            {
                imyscript.enabled = true;
                ISkilll.SetActive(true);
                ISkghost3.SetActive(true);
            }
            if(WStaff.activeInHierarchy)
            {
                wmyscript.enabled = true;
                WSkilll.SetActive(true);
                WSkghost3.SetActive(true);
            }
        }

        if(other.gameObject.name == "JScroll")
        {
            PickUpScroll.Play();           
            Destroy(other.gameObject);
            var myscript = gameObject.GetComponent<Weapon2>();
            var fmyscript = gameObject.GetComponent<FireWeapon2>();
            var imyscript = gameObject.GetComponent<IceWeapon2>();
            var wmyscript = gameObject.GetComponent<WindWeapon2>();
            if(PStaff.activeInHierarchy)
            {      
                myscript.enabled = true;
                PSkillj.SetActive(true);
                PSkghost1.SetActive(true);
            }
            if(FStaff.activeInHierarchy)
            {
                fmyscript.enabled = true;
                FSkillj.SetActive(true);
                FSkghost1.SetActive(true);
            }
            if(IStaff.activeInHierarchy)
            {
                imyscript.enabled = true;
                ISkillj.SetActive(true);
                ISkghost1.SetActive(true);
            }
            if(WStaff.activeInHierarchy)
            {
                wmyscript.enabled = true;
                WSkillj.SetActive(true);
                WSkghost1.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = collision.transform;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            loadingScreen.SetActive(true);
            StartCoroutine(LoadAsync());
        }

        IEnumerator LoadAsync()
        {
            Scene scene = SceneManager.GetActiveScene();
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene.buildIndex + 1);

            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                bar.value = asyncLoad.progress;
                if(asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
                {
                    loading.SetActive(false);
                    press.SetActive(true);
                    if (Input.anyKeyDown)
                    {
                        asyncLoad.allowSceneActivation = true;
                    }
                }
                yield return null;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }     
    }

    void RandomStatePicker()
    {
        int randomState = Random.Range(0, 4);
        if (randomState == 0)
        {
            var myscript = gameObject.GetComponent<Weapon>();       
            myscript.enabled = true;
            PStaff.SetActive(true);
            PSkillk.SetActive(true);
            PSkghost2.SetActive(true);
        }
        if (randomState == 1)
        {
            var myscript = gameObject.GetComponent<FireWeapon>();
            myscript.enabled = true;
            FStaff.SetActive(true);
            FSkillk.SetActive(true);
            FSkghost2.SetActive(true);            
        }
        if (randomState == 2)
        {
            var myscript = gameObject.GetComponent<IceWeapon>();
            myscript.enabled = true;
            IStaff.SetActive(true);
            ISkillk.SetActive(true);
            ISkghost2.SetActive(true);
        }
        else if (randomState == 3)
        {
            var myscript = gameObject.GetComponent<WindWeapon>();
            myscript.enabled = true;
            WStaff.SetActive(true);
            WSkillk.SetActive(true);
            WSkghost2.SetActive(true);            
        }
    }
}
