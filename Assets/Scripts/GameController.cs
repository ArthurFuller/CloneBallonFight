using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject coin;
    [SerializeField] float limiteX = 6.0f;
    [SerializeField] float limiteY = 3.0f;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
        Vector3 pos = new Vector3(Random.Range(-limiteX, limiteX), Random.Range(-limiteY, limiteY), 0);
        Instantiate(coin, pos, transform.rotation);

        StartCoroutine(Start());
    }

}
