using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    int score;

    public TextMeshPro HealtScore;
    void Start()
    {
        score = Random.Range(1, 9);
        HealtScore.SetText(score.ToString());
    }

    void Update()
    {
        transform.Rotate(Vector3.up, 10);
    }


    private void OnTriggerEnter(Collider other)
    {
        var snake = other.gameObject.GetComponent<Snake>();
        if (snake != null)
        {
            snake.AddLength(score);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Snake snakeHead))
        {
            snakeHead.AddLength(score);
            Destroy(gameObject);
        }
    }
}
