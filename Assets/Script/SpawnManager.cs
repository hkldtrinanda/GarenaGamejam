using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform spawnPoint;
    public float initialDelay = 5f;
    public float spawnInterval = 5f;

    private int currentIndex = 0;
    private GameObject currentSpawnedObject;

    private void Start()
    {
        // Memanggil fungsi InvokeRepeating dengan initialDelay untuk menunda pemanggilan pertama.
        InvokeRepeating("SpawnObject", initialDelay, spawnInterval);
    }

    private void SpawnObject()
    {
        // Hancurkan objek yang sebelumnya dihasilkan, jika ada.
        if (currentSpawnedObject != null)
        {
            Destroy(currentSpawnedObject);
        }

        // Memilih objek dari array objectsToSpawn.
        GameObject objectToInstantiate = objectsToSpawn[currentIndex];

        // Membuat objek pada posisi spawnPoint.
        currentSpawnedObject = Instantiate(objectToInstantiate, spawnPoint.position, Quaternion.identity);

        // Menambahkan index untuk memilih objek selanjutnya dalam array.
        currentIndex = (currentIndex + 1) % objectsToSpawn.Length;
    }
}
