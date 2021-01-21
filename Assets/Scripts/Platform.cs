using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public Transform Begin;
    public Transform End;
    
    private Vector3 direction;
    public bool visible = false;

    void Awake()
    {
        direction = new Vector3(0, 0, -1);
        
    }
    void Start()
    {
       
        
    }

    void Update()
    {
        transform.Translate(direction* 5* Time.deltaTime);
        
    }

    void OnBecameInvisible()
    {
        Debug.Log("Текст");
        Destroy(gameObject);
    }

   
}
