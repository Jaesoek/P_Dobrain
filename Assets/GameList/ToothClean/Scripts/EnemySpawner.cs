using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    [FormerlySerializedAs("Spawn Enemy")] [SerializeField] GameObject enemyObj;
    [FormerlySerializedAs("Spawn Amount")] [SerializeField] private int spawnAmount = 0;
    private int _nowSpawnedAmount = 0;

    private Vector3 _posCamera;
    private float _halfWidth;
    private float _halfHeight;

    public delegate void OnEnemyRemoved();
    public OnEnemyRemoved delegateEnemyRemoved { get; set; }

    void Awake()
    {
        _posCamera = Camera.main.transform.position;

        var spriteRenderer = GetComponent<SpriteRenderer>();
        var bounds = spriteRenderer.bounds;
        _halfWidth = bounds.size.x/2;
        _halfHeight = bounds.size.y/2;
    }

    public int SpawnEnemy()
    {
        _nowSpawnedAmount = 0;

        for (; _nowSpawnedAmount < spawnAmount; ++_nowSpawnedAmount)
        {
            var posX = (Random.value - 0.5f) * _halfWidth + _posCamera.x;
            var posY = (Random.value - 0.5f) * _halfHeight + _posCamera.y;
            
            var createdObject = Instantiate(enemyObj, new Vector3(posX, posY, 0), Quaternion.identity);
            createdObject.GetComponent<EnemyBehavior>()
                .eventEnemyDead.AddListener(delegate { delegateEnemyRemoved(); });
        }

        return _nowSpawnedAmount;
    }
}
