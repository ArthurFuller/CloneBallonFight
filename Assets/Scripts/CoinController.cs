using UnityEngine;

public class CoinController : MonoBehaviour
{

    [SerializeField] float destroyTime = 3.0f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }



}
