using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    Animator animator;
    
    public GameObject loadingScreen;
    public GameObject loading;
    public GameObject press;
    public Slider bar;

    [Header("PoisonStaff")]
    public GameObject PStaff;
    public GameObject PSkillj;
    public GameObject PSkillk;
    public GameObject PSkilll;
    public GameObject PSkghost1;
    public GameObject PSkghost2;
    public GameObject PSkghost3;
    public GameObject PLBtn;
    public GameObject PJBtn;

    [Header("IceStaff")]
    public GameObject IStaff;
    public GameObject ISkillj;
    public GameObject ISkillk;
    public GameObject ISkilll;
    public GameObject ISkghost1;
    public GameObject ISkghost2;
    public GameObject ISkghost3;
    public GameObject ILBtn;
    public GameObject IJBtn;

    [Header("WindStaff")]
    public GameObject WStaff;
    public GameObject WSkillj;
    public GameObject WSkillk;
    public GameObject WSkilll;
    public GameObject WSkghost1;
    public GameObject WSkghost2;
    public GameObject WSkghost3;
    public GameObject WLBtn;
    public GameObject WJBtn;

    [Header("FireStaff")]
    public GameObject FStaff;
    public GameObject FSkillj;
    public GameObject FSkillk;
    public GameObject FSkilll;
    public GameObject FSkghost1;
    public GameObject FSkghost2;
    public GameObject FSkghost3;
    public GameObject FLBtn;
    public GameObject FJBtn;

    [Header("Music Effect")]
    public AudioSource PickUpStaff;
    public AudioSource PickUpScroll;
    public AudioSource Coin;
         
    private int score;
    [SerializeField] private Text textScore;
    [SerializeField] private MobAdsSimple _mobAdsSimple;

    private void Start()
    {
        _mobAdsSimple = GetComponent<MobAdsSimple>();
        score = PlayerPrefs.GetInt("coin", score);
        textScore.text = score.ToString();
        animator = GetComponent<Animator>();
        Location.Instance.Load();
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("BronzeCoin"))
        {
            score++;
            PlayerPrefs.SetInt("coin", score);
            Destroy(other.gameObject);
            textScore.text = score.ToString();
            Coin.Play();
        }

        if(other.gameObject.CompareTag("SilverCoin"))
        {
            score+= 2;
            PlayerPrefs.SetInt("coin", score);
            Destroy(other.gameObject);
            textScore.text = score.ToString();
            Coin.Play();
        }

        if(other.gameObject.CompareTag("GoldCoin"))
        {
            score+= 3;
            PlayerPrefs.SetInt("coin", score);
            Destroy(other.gameObject);
            textScore.text = score.ToString();
            Coin.Play();
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
                PLBtn.SetActive(true);
            }
            if(FStaff.activeInHierarchy)
            {
                fmyscript.enabled = true;
                FSkilll.SetActive(true);
                FSkghost3.SetActive(true);
                FLBtn.SetActive(true);                
            }
            if(IStaff.activeInHierarchy)
            {
                imyscript.enabled = true;
                ISkilll.SetActive(true);
                ISkghost3.SetActive(true);
                ILBtn.SetActive(true);                
            }
            if(WStaff.activeInHierarchy)
            {
                wmyscript.enabled = true;
                WSkilll.SetActive(true);
                WSkghost3.SetActive(true);
                WLBtn.SetActive(true);
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
                PJBtn.SetActive(true);
            }
            if(FStaff.activeInHierarchy)
            {
                fmyscript.enabled = true;
                FSkillj.SetActive(true);
                FSkghost1.SetActive(true);
                FJBtn.SetActive(true);
            }
            if(IStaff.activeInHierarchy)
            {
                imyscript.enabled = true;
                ISkillj.SetActive(true);
                ISkghost1.SetActive(true);
                IJBtn.SetActive(true);
            }
            if(WStaff.activeInHierarchy)
            {
                wmyscript.enabled = true;
                WSkillj.SetActive(true);
                WSkghost1.SetActive(true);
                WJBtn.SetActive(true);
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
            _mobAdsSimple.ShowAd();
            
            loadingScreen.SetActive(true);

            Location.Instance.Load();

            Debug.Log("Location.Instance.CurrentLevelNumber = " + Location.Instance.CurrentLevelNumber);
            
            Location.Instance.CurrentLevelNumber++;

            Location.Instance.CheckCurrentLevel();
            
            int nextLevel = Location.Instance.CurrentLevelNumber;

            StartCoroutine(LoadAsync(nextLevel));
        }

        IEnumerator LoadAsync(int sceneIndex)
        {           
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);

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
    
    [ContextMenu("Teleport to Finish")]
    public void TeleportToFinish()
    {
        var finish = GameObject.FindGameObjectWithTag("Finish");
        transform.position = finish.transform.position;
    }

    // void RandomStatePicker()
    // {
    //     int randomState = Random.Range(0, 4);
    //     if (randomState == 0)
    //     {

    //     }
    //     if (randomState == 1)
    //     {
          
    //     }
    //     if (randomState == 2)
    //     {

    //     }
    //     else if (randomState == 3)
    //     {
           
    //     }
    // }
}
