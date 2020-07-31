using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPoseScript : MonoBehaviour
{
    private GameObject m_centerEye;
    
    // Start is called before the first frame update
    void Start()
    {
        m_centerEye = GameObject.Find("CenterEyeAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        var e = m_centerEye.transform.position;
        transform.position = new Vector3(e.x,transform.position.y,e.z);
        // var e = transform.localRotation;
        // transform.localRotation = Quaternion.Euler(0,e.y,0);
        // Debug.Log("user pose :" + transform.position);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        if(other.tag == "JumpArea")
        {
            transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.parent.GetComponent<MoveTestScript>().Jump();
        }
    }
    // private void OnTriggerStay(Collider other) {
    //     if(transform.parent.GetComponent<MoveTestScript>().jumping==false)
    //     {
    //         transform.parent.GetComponent<MoveTestScript>().Jump();
    //     }
    // }

}
