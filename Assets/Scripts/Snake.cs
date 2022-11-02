using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Snake : MonoBehaviour
{

    public Rigidbody _rb;
    public Game Game;

    public int Length = 5;
    public TextMeshPro PointsText;
    private Tail snakeTail;

    private Material material;
    private bool die = false;

    private void Start()
    {
        snakeTail = GetComponent<Tail>();

        for (int i = 0; i < Length; i++)
        {
            snakeTail.AddSphere();
        }
        PointsText.SetText(Length.ToString());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Length++;
            snakeTail.AddSphere();
            PointsText.SetText(Length.ToString());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Length--;
            snakeTail.RemoveSphere();
            PointsText.SetText(Length.ToString());
        }

    }

    public void removeHead()
    {
        Length--;
        PointsText.SetText(Length.ToString());
        snakeTail.RemoveSphere();
        if (Length == 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Cube cube))
        {
            removeHead();
        }
    }

    public void ReachFinish()
    {
        _rb.velocity = Vector3.zero;
        Game.OnPlayerReachedFinish();
    }

   
    public void Die()
    {
        _rb.velocity = Vector3.zero;
        Game.OnPlayerDied();
    }

}
