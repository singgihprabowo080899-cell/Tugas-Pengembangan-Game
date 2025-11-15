using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float _maxtime = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;

    private float _timer;

    private void Start()
    {
        SpawnObstacle();
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _maxtime)
        {
            SpawnObstacle();
            _timer = 0;
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
       GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        
        Destroy(obstacle, 10f); // Hapus obstacle setelah 10 detik
    }
}
