using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool jumping;
    void Start()
    {
        jumping= false;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.GetComponent<Rigidbody>().AddForce(0,1,0,ForceMode.Impulse);
        if(transform.position.y>1)
        {
            jumping = true;
        }
        if(transform.position.y<0.1&&jumping)
        {
            jumping = false;
            Debug.Log("jumping is false");
        }
        if(transform.position.y<0)
        {
            var p = transform.position;
            transform.position = new Vector3(p.x,0,p.z);
        }
        
        transform.rotation = Quaternion.Euler(0,0,0);
        
    }

    public void Jump()
    {
        var r = transform.GetComponent<Rigidbody>();
        r.AddForce(0,15,0,ForceMode.Impulse);
        // r.useGravity = true;
        // for(var tAll = 0f;tAll<2;tAll+=Time.deltaTime)
        // {
        //     // transform.
        // }
    
    }


}
