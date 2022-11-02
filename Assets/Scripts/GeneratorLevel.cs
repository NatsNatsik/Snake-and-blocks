using UnityEngine;

public class GeneratorLevel : MonoBehaviour
{
    public GameObject[] WallPrefabs;

    public GameObject[] HealthPrefabs;
    public int MinWalls;
    public int MaxWalls;
    public float DistanceBetweenWalls;

    public Transform LastWall;


    private void Awake()
    {
        int wallsCount = Random.Range(MinWalls, MaxWalls + 1);

        for(int i = 0; i < wallsCount; i++)
        {
            int prefabIndex = Random.Range(0, WallPrefabs.Length);
            GameObject Wall = Instantiate(WallPrefabs[prefabIndex], transform);
            Wall.transform.localPosition = CalculatePosition(i);
        }
        LastWall.localPosition = CalculatePosition(wallsCount);
       
        for (int i = 0; i < wallsCount; i++)
        {
            int prefabIndex = Random.Range(0, HealthPrefabs.Length);
            GameObject Healht = Instantiate(HealthPrefabs[prefabIndex], transform);
            Healht.transform.localPosition = new Vector3(0, 0.5f, DistanceBetweenWalls * i + DistanceBetweenWalls / 2);
        }
    }
    
    Vector3 CalculatePosition(int wallIndex)
    {
        return new Vector3(0, 0, DistanceBetweenWalls * wallIndex + DistanceBetweenWalls);
    }

}      