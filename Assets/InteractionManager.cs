using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 

public class InteractionManager : MonoBehaviour
{


    private bool hasRing;
    public GameObject m_Ring;
    public GameObject m_RingPrefab;
    public GameObject m_VelAnchor;
    public GameObject m_Parent;
    public AudioSource m_ThrowAudio;
    public AudioSource m_FlyAudio;
    public Transform m_RightHandAnchor;
    public GameManager m_manager;

    private int n=8;

    Vector3[] poses;

    Vector3 lastPose;

    
    void Start()
    {
        hasRing = false;
        m_Ring.SetActive(false);
        m_manager = GetComponent<GameManager>();
        poses = new Vector3[n];
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch))
        {
            if(!hasRing&&!m_manager.finishThisLevel)
            {
                // get ring with hand
                GetRing();
            }

        }

        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch))
        {
            OVRInput.SetControllerVibration(0.3f, 0.5f, OVRInput.Controller.RTouch);
        }

        if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            ThrowRing();
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }


        var v = m_Ring.GetComponent<Rigidbody>().velocity;
        //Debug.Log(v);


        var anchorV = m_VelAnchor.GetComponent<Rigidbody>().velocity;
        //lastPose = m_Ring.transform.position;
        // Debug.Log(anchorV);




    }

    private void FixedUpdate() {



        // calculate poses;
        for(var p=n-1; p>0; p--)
        {
            poses[p] = poses[p - 1];
        }
        poses[0] = m_Ring.transform.position;
        // poses[0] = m_RightHandAnchor.localPosition;        
    }

    void GetRing()
    {
        // m_Ring.transform.SetParent(m_Parent.transform);
        // m_Ring.SetActive(true);
        // m_Ring.transform.localPosition = Vector3.zero;
        // m_Ring.transform.localRotation = Quaternion.Euler(0, 0, 0);
        // m_Ring.GetComponent<Rigidbody>().isKinematic = true;

        m_Ring = Instantiate(m_RingPrefab);
        m_Ring.transform.SetParent(m_Parent.transform);
        m_Ring.SetActive(true);
        m_Ring.transform.localPosition = Vector3.zero;
        m_Ring.transform.localRotation = Quaternion.Euler(0, 0, 0);
        m_Ring.GetComponent<Rigidbody>().isKinematic = true;

        m_Ring.transform.GetComponentInChildren<RingHitManager>().m_gameManager = GetComponent<GameManager>();
        m_Ring.transform.GetComponentInChildren<RingHitManager>().m_ColliedAudio = GameObject.Find("ColliedAudio").GetComponent<AudioSource>();        

        m_manager.ringCount -= 1;
        m_manager.m_countUI.SetActive(false);

    }
    void ThrowRing()
    {
        var rig = m_Ring.GetComponent<Rigidbody>();
        rig.isKinematic = false;
        rig.transform.SetParent(null);

        var m_v = poses[0] - poses[7];
        rig.AddForce(m_v/Time.deltaTime/6f, ForceMode.Impulse);

        m_ThrowAudio.Play();
        m_FlyAudio.PlayDelayed(0.3f);

         m_manager.m_countUI.GetComponentInChildren<Text>().text = "剩余环数： " + m_manager.ringCount;
         m_manager.m_countUI.SetActive(true);
    }
}
