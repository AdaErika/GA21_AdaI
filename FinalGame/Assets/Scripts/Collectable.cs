
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int collectableValue = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(collectableValue);
            Destroy(gameObject);
        }
    }
}
