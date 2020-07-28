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
        switch(SceneManager.GetActiveScene().name)
        {
            case "Ring00":
                SceneManager.LoadScene("Ring01");
                m_ResultUI.SetActive(false);
                break;
            case "Ring01":
                SceneManager.LoadScene("Ring02");
                m_ResultUI.SetActive(false);
                break;
        }
        


        if (SceneManager.GetActiveScene().name == "Ring00")
        {
            SceneManager.LoadScene(1);
            
        }                                                     

    }

    void ResetContext()
    { 
        //SceneManager.GetActiveScene()
    }
}
