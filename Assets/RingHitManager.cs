using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingHitManager : MonoBehaviour
{
    public delegate void Handler();
    public event Handler HitTargetEvent;
    public GameManager m_gameManager;

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
        if(other.gameObject.tag=="HitTarget")
        {
            HitTargetEvent();
        }
    }
}
