using UnityEngine;
using UnityEngine.InputSystem;

public class coincollisionscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int score=0;
    GameObject currentCollider;
    void OnCollisionEnter(Collision collision)
    {
            currentCollider = collision.gameObject;
            print($"Collided with {currentCollider.name}");  
    }
        void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="coin")
        { 
            print($"Stopped colliding with {currentCollider.name}");
            currentCollider = null;
        }
    }


    void OnInteract(InputValue value)
    {
        if (currentCollider != null)
        {
            print($"Interacting with a{currentCollider.name}");

            var collectible = currentCollider.GetComponent<Collectible>();
            if (collectible != null)
            {
                print($"Interacting with a Collectible {currentCollider.name}");
                score += collectible.score;
                print($"Score: {score}");
                collectible.Collect();
            }
            var door = currentCollider.GetComponent<Door>();
            if (door != null)
            {
                print($"Interacting with Door {currentCollider.name}");
                door.Interact();
            }
        }
    }
    /// <summary>
    /// Triggers when the player touches the finish platform  
    /// </summary>
    /// <param name="other"></param> Other object that the player collides with
    void OnTriggerEnter(Collider other)
    {
        if (score ==17)
        { print("Congrats!");
            print($"Final Score:{score}");
        }
    }     
}
