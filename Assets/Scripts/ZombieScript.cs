using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite JumpingSprite;
    public Sprite idleSprite;
    public Rigidbody2D myRigidbody;
    [SerializeField] private AudioSource audioSource;
    public float flapStrength;
    public LogicScript logic;
    public bool zombieIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && zombieIsAlive)
        {
            ChangeSprite(JumpingSprite);
            audioSource.Play();
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ChangeSprite(idleSprite);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        logic.gameOver();    
        zombieIsAlive = false;
    }

    public void ChangeSprite(Sprite sprite)
    {
    spriteRenderer.sprite = sprite;
    }
}
