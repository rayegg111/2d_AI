using UnityEngine;

public class playerfold : MonoBehaviour
{
    public int damage = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "狐狸")
        {
            collision.gameObject.GetComponent<fox>().Damage(damage);

            print("123");
        }
    }
}
