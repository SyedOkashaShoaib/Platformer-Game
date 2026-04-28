using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // This is a Mock script. It exists solely to prove the Player's sword works.
    public void TakeDamage(int damage)
    {
        Debug.Log("<color=red>SUCCESS! You just hit the cutest panda ever for a " + damage + " damage!</color>");
    }
}