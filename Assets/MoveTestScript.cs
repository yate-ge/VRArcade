using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool jumping;
    private Vector3 jumpPoint;
    void Start()
    {
        jumping= false;
        jumpPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.GetComponent<Rigidbody>().AddForce(0,1,0,ForceMode.Impulse);
        // if(transform.position.y>1)
        // {
        //     jumping = true;
        // }
        // if(transform.position.y<0.1&&jumping)
        // {
        //     jumping = false;
        //     Debug.Log("jumping is false");
        // }
        // 如果是蹦床scene的话
        if(transform.position.y<jumpPoint.y)
        {
            transform.position = jumpPoint;
        }
        // var r = transform.localRotation;
        // transform.localRotation = Quaternion.Euler(0,r.y,r.z);
        var level = transform.GetComponentInChildren<GameManager>().currentLevel;
        if(level==5)
        {
            transform.rotation = Quaternion.Euler(0,0,0);

        }
        // transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void Jump()
    {
        jumpPoint = transform.position;

        var r = transform.GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(0,0,0);
        r.AddForce(0,15,0,ForceMode.Impulse);
        // r.useGravity = true;
        // for(var tAll = 0f;tAll<2;tAll+=Time.deltaTime)
        // {
        //     // transform.
        // }
    
    }


}
