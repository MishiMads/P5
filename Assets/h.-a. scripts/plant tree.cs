using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planttree : MonoBehaviour
{

    public GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void OnCollisionEnter(Collision collider)
    {
        // Check if the collided object has the correct tag
        if (collider.gameObject.CompareTag("seed"))
        {
            // Destroy the object
            Destroy(collider.gameObject);
            planting();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void planting()
    {
        tree.gameObject.SetActive(true);
    }
}
