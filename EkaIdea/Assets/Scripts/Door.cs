using UnityEngine;

public class Door : MonoBehaviour
{
    public StoneHead[] stoneHeads; // Reference to an array of StoneHead script components.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Log a message to check if the OnTriggerEnter2D method is being called.
            Debug.Log("Player entered the door trigger.");

            // Toggle the isActive variable for each StoneHead script in the array.
            foreach (var stoneHead in stoneHeads)
            {
                stoneHead.isActive = !stoneHead.isActive;
                Debug.Log("StoneHead script is now active: " + stoneHead.isActive);
            }
        }
    }
}
