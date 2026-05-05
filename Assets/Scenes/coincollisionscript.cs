using UnityEngine;

public class coincollisionscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score=0;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("coin"))
        { score++;
            print($"Current Score:{score}");
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("finish"))
        { print("You win!");
            print($"Final Score:{score}");
        }
    }
}
