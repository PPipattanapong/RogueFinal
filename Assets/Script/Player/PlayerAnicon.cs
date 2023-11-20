using UnityEngine;

public class PlayerAnicon : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        InitializeComponents();
    }

    private void Update()
    {
        CheckInputForRun();
    }

    private void InitializeComponents()
    {
        animator = GetComponent<Animator>();
    }

    private void CheckInputForRun()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Run();
        }
    }
    private void Run()
    {
        animator.SetTrigger("Playerrun");
    }
}
