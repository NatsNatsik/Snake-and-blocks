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

    private bool die = false;

    private void Start()
    {
        Length = PlayerPrefs.GetInt("SnakeLenght");

        snakeTail = GetComponent<Tail>();

        for (int i = 0; i < Length; i++)
        {
            snakeTail.AddSphere();
            var collider = GetComponent<Collider>();
            collider.transform.SetPositionAndRotation(snakeTail.SnakeHead.position, Quaternion.identity);
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

    public void AddLength(int length)
    {
        for(int i = 0; i < length; i++)
        {
            Length++;
            snakeTail.AddSphere();
            PointsText.SetText(Length.ToString());
        }
    }

    public void removeHead()
    {
        Length--;
        PointsText.SetText(Length.ToString());
        snakeTail.RemoveSphere();
        transform.position = Vector3.Lerp(transform.position, snakeTail.positions[1], snakeTail.SphereDiameter/2);
        if (Length < 1)
        {
            Length = 0;
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
        Game.SnakeLenght = Length;
        Game.OnPlayerReachedFinish();
    }

   
    public void Die()
    {
         die = true;
        _rb.velocity = Vector3.zero;
        Game.OnPlayerDied();
    }

}
