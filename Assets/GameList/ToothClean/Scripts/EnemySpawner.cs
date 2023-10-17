using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [FormerlySerializedAs("Spawn Enemy")] [SerializeField] GameObject enemyObj;
    [FormerlySerializedAs("Spawn Amount")] [SerializeField] private int spawnAmount = 0;
    private int _nowSpawnedAmount = 0;

    private float _halfWidth;
    private float _halfHeight;

    private Vector3 _posCamera;

    void Start()
    {
        _posCamera = Camera.main.transform.position;

        var spriteRenderer = GetComponent<SpriteRenderer>();
        var bounds = spriteRenderer.bounds;
        _halfWidth = bounds.size.x/2;
        _halfHeight = bounds.size.y/2;

        _nowSpawnedAmount = 0;
    }

    public void SpawnEnemy()
    {
        for (; _nowSpawnedAmount < spawnAmount; ++_nowSpawnedAmount)
        {
            var posX = (Random.value - 0.5f) * _halfWidth + _posCamera.x;
            var posY = (Random.value - 0.5f) * _halfHeight + _posCamera.y;
            
            Instantiate(enemyObj, new Vector3(posX, posY, 0), Quaternion.identity);
        }
    }
}
