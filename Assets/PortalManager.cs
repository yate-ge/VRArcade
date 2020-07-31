using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public Transform m_portal1;
    public Transform m_portal2;
    public Transform m_UserCamera;
    public Transform m_portalCamera;
    public Transform Render;
    public Transform m_cameraProp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var usercpos = m_UserCamera.position;
        var trans = usercpos - m_portal1.position;

        // m_portalCamera.LookAt(m_portal2);
        // m_portalCamera.localPosition = trans;

        m_cameraProp.position = m_UserCamera.position;
        m_cameraProp.rotation = m_UserCamera.rotation;

        m_portalCamera.localPosition = m_cameraProp.localPosition;
        m_portalCamera.localRotation = m_cameraProp.localRotation;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");
        // other.transform.root.rotation = other.transform.root.rotation * m_portal2.rotation * m_portal1.rotation;
        // other.transform.root.position = m_portal2.position - new Vector3(0, 1.5f, 0);
        other.transform.root.position = m_portal2.position;       
        // other.transform.root.parent = m_portal2; 
    }
}
