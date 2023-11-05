using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnicon : MonoBehaviour
{
    //[SerializeField] private int healthPoint = 2;
    //private void OnTriggerEnter(Collider other)
    //{
    //if (other.CompareTag("Player"))
    //{
    //animator.SetBool("death", true);
    //}
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //if (collision.gameObject.CompareTag("Player"))
    //{
    //healthPoint = -3;
    //}
    //if (healthPoint <= 0)
    //{
    //Death();
    //}

    //Debug.Log("Hit");
    //}
    [SerializeField] private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Run();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Run();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Run();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Run();
        }
        //if (Input.GetKeyDown(KeyCode.V))
        //{
        //Death();
        //}
        //else if (Input.GetKeyDown(KeyCode.L))
        //{
        //animator.SetBool("death", false);
        //}
    }
    private void Run()
    {
        animator.SetTrigger("Playerrun");
    }
    //private void Death()
    //{
    //animator.SetBool("death", true);
    //Destroy(gameObject);
    //}
}