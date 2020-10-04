using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int heals;

    void Start()
    {
        heals = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (heals <=0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
          var go = collision.gameObject;
        if (9 == go.layer)
        {
            heals -= 35;
            Destroy(go);
        }
        if( go.tag == "Player")
        {
            Destroy(go);
        }
    }
   
}
