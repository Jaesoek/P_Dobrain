using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _arrSpawners;
    private int _cntSpawnedEnemies = 0;

    //  - TODO: Audio bind UI

    private void Start()
    {
        Invoke(nameof(GameStart), 0f);
    }

    private void GameStart()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Invoke(nameof(SpawnEnemy), audioSource.clip.length);
    }

    private void EnemyRemoved()
    {
        --_cntSpawnedEnemies;
        if (_cntSpawnedEnemies == 0)
        {
            // TODO: Game Clear Logic
            Debug.Log("Game Clear!!");
        }
    }

    private void SpawnEnemy()
    {
        foreach (var spawner in _arrSpawners)
        {
            _cntSpawnedEnemies += spawner.SpawnEnemy();
            spawner.delegateEnemyRemoved = EnemyRemoved;
        }
    }
}
