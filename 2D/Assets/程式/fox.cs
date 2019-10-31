using UnityEngine;
using UnityEngine.AI;

public class fox : MonoBehaviour
{
    // 成員：欄位、屬性、方法、事件
    // 修飾詞 類型 名稱 指定 值；
    public int speed = 15;                  // 整數
    public float jump = 2.5f;               // 浮點數
    public string foxName = "狐狸";         // 字串
    public bool pass = false;               // 布林值 - true/false

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
        if (Input.GetKeyDown(KeyCode.D)) TurnRight();
        if (Input.GetKeyDown(KeyCode.A)) TurnLeft();
    }

    //固定更新事件：每禎0.002秒
    private void FixedUpdate()
    {
        //Debug.Log(Input.GetAxis("Horizontal"));
        Walk();
    }
    /// <summary>
    /// 走路
    /// </summary>
    void Walk()
    {
        r2d.AddForce(new Vector2(speed * (Input.GetAxis("Horizontal")), 0));
    }
    /// <summary>
    /// 向右
    /// </summary>
    void TurnRight()
    {
        tra.eulerAngles = new Vector3(0, 0, 0);
    }
    /// <summary>
    /// 向左
    /// </summary>
    void TurnLeft()
    {
        tra.eulerAngles = new Vector3(0, 180, 0);
    }
}
