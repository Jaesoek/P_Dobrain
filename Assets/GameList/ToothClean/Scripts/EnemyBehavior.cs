using UnityEngine;
using UnityEngine.Serialization;

public class EnemyBehavior : MonoBehaviour
{
    [FormerlySerializedAs("EnemyHp")] [SerializeField] private float enemyHp = 10;

    private GameObject _player;
    private SpriteRenderer _spriteRenderer;

    private Vector3 _beforePos;
    private float _minimumMove;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _minimumMove = _spriteRenderer.bounds.size.x;
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
            enemyHp -= 1;
            _spriteRenderer.color -= new Color(0, 0, 0, 1f / enemyHp);
            _beforePos = nowPos;

            if (enemyHp <= 0) Destroy(this.gameObject);
        }
    }
}