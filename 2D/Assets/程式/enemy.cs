using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("速度")]
    public float speed = 5f;
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "狐狸")
        {
            Track(collision.transform.position);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "狐狸")
        {
            collision.gameObject.GetComponent<fox>().Damage(damage);
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //r2d.AddForce(new Vector2(-speed, 0));  // 世界座標
        r2d.AddForce(-transform.right * speed);  // 區域座標，2D transform,right(右方) transform.up(上方)

        //碰撞資訊 = 物理，射線碰撞
        RaycastHit2D hit = Physics2D.Raycast(checkpoint.position, -checkpoint.up, 5, 1 << 8);

        if (hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    /// <summary>
    /// 追蹤
    /// </summary>
    /// <param name="target">玩家座標</param>
    private void Track(Vector3 target)
    {
        // 如果 玩家在左邊 角度 = 0
        // 如果 玩家在右邊 角度 = 180
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;  //new Vector3(0, 0, 0)
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
}
