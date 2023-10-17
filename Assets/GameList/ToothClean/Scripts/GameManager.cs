using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner[] _arrSpawners;

    private void Start()
    {
        Invoke(nameof(GameStart), 1f);
    }

    private void GameStart()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Invoke(nameof(SpawnEnemy), audioSource.clip.length);
    }

    private void SpawnEnemy()
    {
        foreach (var spawner in _arrSpawners)
        {
            spawner.SpawnEnemy();
        }
    }
}
