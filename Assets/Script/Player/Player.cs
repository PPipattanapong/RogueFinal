using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rg2d;
    [SerializeField] private Vector2 velocity;
    [SerializeField] private int score = 0;

    public void AddScore()
    {
        score = score + 1;
    }

    public int GetScore()
    {
        return score;
    }

    [SerializeField] private void Start()
    {
        rg2d = GetComponent <Rigidbody2D>();
    }
    [SerializeField] private void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw
         ("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}

