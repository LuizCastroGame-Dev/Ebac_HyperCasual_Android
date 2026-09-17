using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Publics
    [Header("Lerp controller")]
    public Transform target;
    public float lerpSpeed = 1f;
    public float speed = 1f;

    [Header("Enemy identified")]
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";


    [Header("Game Screen")]
    public GameObject endScreen;

    //Privates
    private bool _canRun;
    private Vector3 _pos;

    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            endGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            endGame();
        }
    }

    private void endGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }
}
