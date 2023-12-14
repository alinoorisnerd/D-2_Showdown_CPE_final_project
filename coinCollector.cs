using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    private int apples = 0;
    public TextMeshProUGUI appleText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            apples++;
            appleText.text = "Apples: " + apples.ToString();

            Destroy(other.gameObject);
        }
    }
}
