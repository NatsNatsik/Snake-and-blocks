using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{

    public Transform SnakeHead;

    private List<Transform> SnakeSpheres = new List<Transform>();
    public List<Vector3> positions = new List<Vector3>();

    public float SphereDiameter;

    private void Awake()
    {
        positions.Add(SnakeHead.position);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = ((Vector3)SnakeHead.position - positions[0]).magnitude;

        if(distance > SphereDiameter/2)
        {
            Vector3 direction = ((Vector3) SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction*SphereDiameter/2);
            positions.RemoveAt(positions.Count - 1);

            distance -= SphereDiameter/2;
        }

        for (int i = 0; i < SnakeSpheres.Count; i++)
        {
            SnakeSpheres[i].position = Vector3.Lerp(positions[i], positions[i+1], distance/SphereDiameter/2);
        }
    }

    public void AddSphere()
    {
        if(positions.Count < 1)
        {
            return;
        }
        Vector3 position = new Vector3(positions[positions.Count - 1].x, positions[positions.Count - 1].y, positions[positions.Count - 1].z - SphereDiameter);
        Transform Spheres = Instantiate(SnakeHead, position, Quaternion.identity, transform);
        SnakeSpheres.Add(Spheres);
        positions.Add(Spheres.position);
    }

    public void RemoveSphere()
    {
        //Destroy(SnakeHead.gameObject);
        //SnakeHead = SnakeSpheres[0];
        //SnakeHead.position = positions[0];
        //SnakeSpheres.RemoveAt(0);
        //positions.RemoveAt(1);

        Destroy(SnakeSpheres[0].gameObject);
        SnakeSpheres.RemoveAt(0);
        positions.RemoveAt(1);
    }

}
