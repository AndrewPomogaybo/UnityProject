using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    public InputField speedInput;
    public InputField distanceInput;
    public InputField spawnTimeInput;
    public GameObject cubePrefab;
    public Transform spawnPoint;

    private int speed;
    private int distance;
    private float spawnTime;


    private void Start()
    {
        speed = int.Parse(speedInput.text);
        distance = int.Parse(distanceInput.text);
        spawnTime = float.Parse(spawnTimeInput.text);
        StartCoroutine(SpawnAndMoveCubes());
    }

    private void FixedUpdate()
    {


        speed = int.Parse(speedInput.text);
        distance = int.Parse(distanceInput.text);
        spawnTime = float.Parse(spawnTimeInput.text);
        
    }

    private void MoveCubes()
    {
        // Перемещение всех кубов по оси Z на заданное расстояние
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cube"))
        {
            cube.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

 

    private IEnumerator SpawnAndMoveCubes()
    {
        while (true)
        {
            GameObject cube = Instantiate(cubePrefab, spawnPoint.position, Quaternion.identity);
            // Уничтожение куба через время, равное интервалу спавна
            Destroy(cube, spawnTime);

            float currentDistance = 0;
            while (currentDistance < distance)
            {
                currentDistance += speed * Time.deltaTime;
                MoveCubes();
                yield return null;
            }
        }
    }
}
