using UnityEngine;

public class GeneratorLevel : MonoBehaviour
{
    public GameObject[] WallPrefabs;

    public GameObject[] HealthPrefabs;
    public int MinWalls;
    public int MaxWalls;
    public float DistanceBetweenWalls;

    public Transform FirstWall;


    private void Awake()
    {
        int wallsCount = Random.Range(MinWalls, MaxWalls + 1);
        Debug.Log(wallsCount);

        FirstWall.localPosition = new Vector3(0, 0, 0);
        Vector3 previousWallPosition = FirstWall.position;

        for (int i = 0; i < wallsCount; i++)
        {
            Debug.Log($"Wall {i}");
            int prefabIndex = Random.Range(0, WallPrefabs.Length);
            Vector3 wallPosition = previousWallPosition + Vector3.forward * DistanceBetweenWalls;
            GameObject Wall = Instantiate(WallPrefabs[prefabIndex], wallPosition, Quaternion.identity);
            previousWallPosition = wallPosition;
        }
       
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