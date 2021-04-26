using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossManager : MonoBehaviour
{

    public GameObject m_RingPrefab;
    Vector4 RingEmissionValue;
    public GameObject m_leftHand;
    public GameObject m_rightHand;
    GameObject ringInHand;

    public AudioSource m_TossAudio;
    public AudioSource m_FlyAudio;

    private bool hasRing = false;

    int n_pose = 8;
    Vector3[] poses;
    Vector3 lastPose;
    Vector3 m_v;

    

    private void Start() {
        m_RingPrefab.SetActive(false);
        poses = new Vector3[n_pose];
        RingEmissionValue = m_RingPrefab.GetComponentInChildren<MeshRenderer>().material.GetColor("_EmissionColor");
    }

    // 激活一个手中的环

    void FixedUpdate() {

        if(ringInHand)
        {
            // 利用连续帧的位置算出运动向量
            for(var p = n_pose - 1; p >0 ; p--)
            {
                poses[p] = poses[p - 1];
            }
            poses[0] = ringInHand.transform.position;
            m_v = poses[0] - poses[7]; 

            // 通过改变环的亮度来可视化速率
            var l = Vector3.Magnitude(m_v);
            var a = 1f;
            var max_a = 5.5f; // 倍数
            if (l > 2f)
            {
                a = max_a;
            }
            else
            {
                a = (l / 2f) * (max_a - 1) + 1;
            }                         
        }    
                                  
    }
    void GetRing(GameObject hand)
    {
        ringInHand = Instantiate(m_RingPrefab);
        ringInHand.transform.SetParent(hand.transform.Find("RingAnchor"));

        // 初始化速度
        ringInHand.GetComponent<Rigidbody>().isKinematic = true;
        for(var p = n_pose - 1; p >0 ; p--)
        {
            poses[p] = ringInHand.transform.position;
        }
        m_v =  Vector3.zero;


        

        ringInHand.SetActive(true);

    }

    void TossRing()
    {
        // 准备抛出
        var rig = ringInHand.GetComponent<Rigidbody>();
        rig.isKinematic = false;
        rig.transform.SetParent(null);

        // 设定抛出的速度
        rig.AddForce(m_v / Time.deltaTime/6f, ForceMode.Impulse);

        // 设定抛出的音乐
        m_TossAudio.Play();
        m_FlyAudio.PlayDelayed(0.3f);

        

        
    }




}
