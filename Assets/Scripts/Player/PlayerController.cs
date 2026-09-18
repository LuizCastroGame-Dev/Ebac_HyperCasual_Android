using Unity.VisualScripting;
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

    public static PlayerController Instance;

    [Header("Game Screen")]
    public GameObject endScreen;

    //Privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _startPosition = transform.position;
        ResetSpeed();
    }

    void Update()
    {
        if (!_canRun) return;
        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
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

    #region Power-up
    public void SetPowerUpText(string s)
    {
        //uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    #endregion
}
