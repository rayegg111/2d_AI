using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("速度")]
    public float speed = 1f;
    [Header("傷害")]
    public int damage = 10;

    private Rigidbody2D r2d;
    public Transform checkpoint;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(checkpoint.position, -checkpoint.up * 5);
    }
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        r2d.AddForce(new Vector2(-speed, 0));
    }

    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {

    }
}
