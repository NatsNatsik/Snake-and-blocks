using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    int score;

    public TextMeshPro HealtScore;

     private void Start()
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
            AudioSource HealthAudio = snake.GetComponent<AudioSource>();
            HealthAudio.Play();
            snake.AddLength(score);
            Destroy(gameObject);
        }
    }
}
