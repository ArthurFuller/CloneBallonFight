using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    [SerializeField] GameObject coin;
    [SerializeField] Text coinText;
    [SerializeField] float limiteX = 6.0f;
    [SerializeField] float limiteY = 3.0f;

    public int coinsCount;

    void Start()
    {
        coinsCount = 0;
        StartCoroutine(SpawnCoin());
    }

    private void Update()
    {
        coinText.text = $"COINS: {coinsCount}";
        ResetGame();
    }

    IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(Random.Range(1.0f, 3.0f));
        Vector3 pos = new Vector3(Random.Range(-limiteX, limiteX), Random.Range(-limiteY, limiteY), 0);
        Instantiate(coin, pos, transform.rotation);

        StartCoroutine(SpawnCoin());
    }

    private void ResetGame()
    {
        if (coinsCount >= 10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

}
