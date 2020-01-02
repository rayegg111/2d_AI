using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    // 插值：取兩個值的中間值
    // 例：取0與10的中間值 = 5;
    // 插值(0, 10, 0.5f) = 5;

    public Vector2 a = new Vector2(0, 0);     // Vector3 用法也相同
    public Vector2 b = new Vector2(10, 10);

    public Transform A, B;

    public float speed = 10;

    private void Start()
    {
        print(Vector2.Lerp(a, b, 0.4f));
    }

    private void Update()
    {
        A.position = Vector3.Lerp(A.position, B.position, 0.3f * Time.deltaTime * speed);
    }
}
