using UnityEngine;
using UnityEngine.Events;

public class fox : MonoBehaviour
{
    // 成員：欄位、屬性、方法、事件
    // 修飾詞 類型 名稱 指定 值；
    public int speed = 15;                  // 整數
    public float jump = 2.5f;               // 浮點數
    public string foxName = "狐狸";         // 字串
    public bool pass = false;               // 布林值 - true/false
    public bool isGround = false;
    public float hp = 100;

    public UnityEvent onEat;

    private Rigidbody2D r2d;
    private Transform tra;

    // 事件：在特定時間點會以指定頻率執行的方法
    // 開始事件：遊戲開始時執行一次
    private void Start()
    {
        // 泛型 <T>
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>();
    }

    //更新事件：每秒約執行60次
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }

    //固定更新事件：每禎0.002秒
    private void FixedUpdate()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));

        Walk();   //呼叫方法
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log("碰到" + collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "鑽石")
        {
            Destroy(collision.gameObject);
            onEat.Invoke();
        }
    }

    /// <summary>
    /// 走路
    /// </summary>
    void Walk()
    {
        r2d.AddForce(new Vector2(speed * (Input.GetAxis("Horizontal")), 0));
    }
    /// <summary>
    /// 跳躍
    /// </summary>
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true) 
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
        }
    }
    /// <summary>
    /// 轉向
    /// </summary>
    /// <param name="direction">控制方向，左：180，右：0 </param>
    void Turn(int direction)
    {
        tra.eulerAngles = new Vector3(0, direction, 0);
    }

    public void Damage(float damage)
    {
        hp -= damage;
    }
}
