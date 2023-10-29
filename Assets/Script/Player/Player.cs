using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    private Rigidbody2D rg2d;
    private Vector2 velocity;
    [SerializeField] private int score = 0;

    public void AddScore()
    {
        score = score + 1;
    }

    public int GetScore()
    {
        return score;
    }

    void Start()
    {
        rg2d = GetComponent <Rigidbody2D>();
    }
    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw
         ("Horizontal"), Input.GetAxisRaw("Vertical"));

    }
}
