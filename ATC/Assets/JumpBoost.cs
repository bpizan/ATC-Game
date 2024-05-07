using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    // You can adjust the boost value from the Unity editor if needed
    public float boostAmount = 5.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the Creature component
        Creature creature = collision.GetComponent<Creature>();

        if (creature != null)
        {
            // Increase the Jumpforce by the boostAmount
            creature.jumpForce += boostAmount;
            Debug.Log("Jumpforce increased: " + creature.jumpForce);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reset the Jumpforce when the character leaves the platform
        Creature creature = collision.GetComponent<Creature>();

        if (creature != null)
        {
            // Decrease the Jumpforce by the boostAmount to return to original value
            creature.jumpForce -= boostAmount;
            Debug.Log("jumpForce reset: " + creature.jumpForce);
        }
    }
}
