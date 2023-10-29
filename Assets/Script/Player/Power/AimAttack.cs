using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AimAttack : MonoBehaviour
{
    public  GameObject aim;
    public GameObject bullet;
    public GameObject firepoint;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        float angle = Mathf.Atan2((mousePos.y - screenPoint.y), (mousePos.x - screenPoint.x)) * Mathf.Rad2Deg;

        aim.transform.rotation = Quaternion.Euler( 0,0,angle);



        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, firepoint.transform.position, aim.transform.rotation);
        }
        
        
    }

 
}
