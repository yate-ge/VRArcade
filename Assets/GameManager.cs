using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RingHitManager m_RingHitManager;
    public GameObject m_ResultUI;
    public GameObject m_Core;
    public AudioSource winAudio;
    public AudioSource loseAudio;
    public AudioSource newSceneAudio;
    private int currentLevel;
    public GameObject[] levels = new GameObject[10];
    
    // Start is called before the first frame update
    void Start()
    {
        m_RingHitManager.HitTargetEvent += HitSuccessHandler;

        

        if(GameObject.FindGameObjectWithTag("ResultUI"))
        {
            m_ResultUI = GameObject.FindGameObjectWithTag("ResultUI");
            m_ResultUI.SetActive(false);
            Debug.Log("Find result ui");
        }
        else
        {
            Debug.Log("can't find result ui");
        }

        // 进入第一关
        currentLevel = 1;
        EnterLevel(currentLevel);
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitSuccessHandler()
    {
        m_ResultUI.SetActive(true);
        Debug.Log("Success!!!");

        winAudio.Play();
    }

    public void NextChallenge()
    {
        // switch(SceneManager.GetActiveScene().name)
        // {
        //     case "Ring00":
        //         SceneManager.LoadScene("Ring01");
        //         m_ResultUI.SetActive(false);
        //         newSceneAudio.Play();
        //         break;
        //     case "Ring01":
        //         SceneManager.LoadScene("Ring02");
        //         m_ResultUI.SetActive(false);
        //         newSceneAudio.Play();
        //         break;
        // }
        


        // if (SceneManager.GetActiveScene().name == "Ring00")
        // {
        //     SceneManager.LoadScene(1);
            
        // }

        EnterLevel(currentLevel+1);                                                     

    }

    void ResetContext()
    { 
        //SceneManager.GetActiveScene()
    }

    void EnterLevel(int l)
    {
        m_Core.transform.parent = levels[l-1].transform.Find("UserArea");
        m_Core.transform.localPosition = Vector3.zero;
        m_Core.transform.localRotation = Quaternion.identity;

        // 关闭其他level content
        for(var n=0;n<10;n++)
        {
            if(n!=l-1)
            {
                levels[n].SetActive(false);
            }else{
                levels[n].SetActive(true);
            }
        }

        m_ResultUI.SetActive(false);
    }
}
