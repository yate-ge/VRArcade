﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RingHitManager m_RingHitManager;
    public GameObject m_ResultUI;
    public GameObject m_loseUI;
    public GameObject m_Core;
    public AudioSource winAudio;
    public AudioSource loseAudio;
    public AudioSource newSceneAudio;
    public int currentLevel = 1;
    public GameObject[] levels = new GameObject[8];
    public int ringCount = 100;
    public GameObject m_countUI;
    public bool finishThisLevel;
    public GameObject theEnd;
    public GameObject m_raycast;
    
    // Start is called before the first frame update
    void Start()
    {
        m_RingHitManager.HitTargetEvent += HitSuccessHandler;

        finishThisLevel = false;
        m_loseUI.SetActive(false);

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
        // currentLevel = 1;
        m_raycast.SetActive(false);
        EnterLevel(currentLevel);
    }

    
    // Update is called once per frame
    void Update()
    {
        if(ringCount==0)
        {
            m_loseUI.SetActive(true);
            loseAudio.Play();
        }
    }
    public void HitSuccessHandler()
    {
        if(currentLevel == 7)
        {
            Debug.Log("tong guang!!!");
            winAudio.Play();
            EnterLevel(8);
            return;  
        }

        m_ResultUI.SetActive(true);
        Debug.Log("Success!!!");

        winAudio.Play();
        finishThisLevel = true;
        m_raycast.SetActive(true);
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
        // if(currentLevel == 7)
        // {

        // }

        currentLevel +=1;
        EnterLevel(currentLevel);                                                     

    }

    void ResetContext()
    { 
        //SceneManager.GetActiveScene()
    }

    void EnterLevel(int l)
    {
        m_raycast.SetActive(true);
        finishThisLevel = false;
        if(l!=5)
        {
            m_Core.GetComponent<MoveTestScript>().enabled = false;
            m_Core.GetComponent<Rigidbody>().useGravity = false;
            m_Core.GetComponent<Rigidbody>().isKinematic = true;
            m_Core.GetComponent<BoxCollider>().enabled = false;
        }else
        {
            m_Core.GetComponent<MoveTestScript>().enabled = true;
            m_Core.GetComponent<Rigidbody>().useGravity = true;
            m_Core.GetComponent<Rigidbody>().isKinematic = false;
            m_Core.GetComponent<BoxCollider>().enabled = true;
        }

        m_Core.transform.parent = levels[l-1].transform.Find("UserArea");
        m_Core.transform.localPosition = Vector3.zero;
        m_Core.transform.localRotation = Quaternion.identity;

        // 关闭其他level content
        for(var n=0;n<7;n++)
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
