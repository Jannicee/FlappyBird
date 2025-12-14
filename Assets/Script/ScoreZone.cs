using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Add Score!");
            ScoreManager.Instance.AddScore(1);
            GetComponent<Collider2D>().enabled = false;
        }
       
    }
}
