using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingHitManager : MonoBehaviour
{
    public delegate void Handler();
    public event Handler HitTargetEvent;
    public GameManager m_gameManager;
    public AudioSource m_ColliedAudio;

    void Start()
    {
        HitTargetEvent += m_gameManager.HitSuccessHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        m_ColliedAudio.Play();
        if(other.gameObject.tag=="HitTarget")
        {
            HitTargetEvent();
        }

        if(other.gameObject.tag=="portal1")
        {
            HitTargetEvent();
        }
    }


}
