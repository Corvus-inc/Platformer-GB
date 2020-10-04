using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float timeToDestroy;
    public float speedBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(transform.localScale.x,0,0) * speedBullet*Time.deltaTime;
        Destroy(gameObject, timeToDestroy);
    }
    
    

}
