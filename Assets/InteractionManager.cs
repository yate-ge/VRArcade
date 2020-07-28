using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class InteractionManager : MonoBehaviour
{


    private bool hasRing;
    public GameObject m_Ring;
    public GameObject m_VelAnchor;
    public GameObject m_Parent;

    Vector3[] poses = new Vector3[10];

    Vector3 lastPose;

    
    void Start()
    {
        hasRing = false;
        m_Ring.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {   
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch))
        {
            if(!hasRing)
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


        // calculate poses;
        for(var p=9; p>0; p--)
        {
            poses[p] = poses[p - 1];
        }
        poses[0] = m_Ring.transform.position;

    }

    void GetRing()
    {
        m_Ring.transform.SetParent(m_Parent.transform);
        m_Ring.SetActive(true);
        m_Ring.transform.localPosition = Vector3.zero;
        m_Ring.transform.localRotation = Quaternion.Euler(0, 0, 0);
        m_Ring.GetComponent<Rigidbody>().isKinematic = true;
    }
    void ThrowRing()
    {
        var rig = m_Ring.GetComponent<Rigidbody>();
        rig.isKinematic = false;
        rig.transform.SetParent(null);

        var m_v = poses[0] - poses[9];
        rig.AddForce(m_v/Time.deltaTime/8, ForceMode.Impulse);


    }
}
