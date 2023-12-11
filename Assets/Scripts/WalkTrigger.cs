using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTrigger : MonoBehaviour
{
    public GameObject redLight;
    public GameObject greenLight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(redLight.GetComponent<Light>().enabled == true)
        {
            if (other.CompareTag("NPCWalk"))
            {
                Animator animator = other.GetComponent<Animator>();
                animator.SetBool("StartWalking", false);

            }
        }
         
    }

    public void OnTriggerStay(Collider other)
    {
        if(greenLight.GetComponent<Light>().enabled == true)
        {
            if (other.CompareTag("NPCWalk"))
            {
                Animator animator = other.GetComponent<Animator>();
                animator.SetBool("StartWalking", true);
            }
        }
    }
}
