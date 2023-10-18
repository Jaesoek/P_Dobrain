using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class EnemyBehavior : MonoBehaviour
{
    [FormerlySerializedAs("Enemy HP Amount")] [SerializeField] private int enemyHp = 10;
    private int _currentEnemyHp;

    private GameObject _player;
    private SpriteRenderer _spriteRenderer;

    private Vector3 _beforePos;
    private float _minimumMove;
 
    public UnityEvent eventEnemyDead;

    private void Start()
    {
        _currentEnemyHp = enemyHp;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _minimumMove = _spriteRenderer.bounds.size.x;
    }

    private void OnDestroy()
    {
        eventEnemyDead.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _player = other.gameObject;
        _beforePos = _player.transform.position;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        _player = null;
    }

    private void Update()
    {
        if (!_player) return;

        var nowPos = _player.transform.position;
        if ((nowPos - _beforePos).magnitude > _minimumMove)
        {
            _currentEnemyHp -= 1;
            if (_currentEnemyHp % 4 == 0)
                _spriteRenderer.color -= new Color(0, 0, 0, 1f / enemyHp * 4);
            _beforePos = nowPos;

            if (_currentEnemyHp <= 0) Destroy(this.gameObject);
        }
    }
}