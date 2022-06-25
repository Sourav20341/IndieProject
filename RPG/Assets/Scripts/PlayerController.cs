using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public float moveSpeed;
    public Animator anim;
    public string TransitionName;
    public bool canMove = true;
    public static PlayerController instance;

    private float MoveSpeed;
    private Vector3 bottomleft;
    private Vector3 topright;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MoveSpeed = moveSpeed;
        }
        else
        {
            MoveSpeed = 0;
        }
        rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * MoveSpeed;
        anim.SetFloat("W_MoveX", rigidbody2D.velocity.x);
        anim.SetFloat("W_MoveY", rigidbody2D.velocity.y);
        if ((Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) && canMove)
        {
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomleft.x, topright.x), Mathf.Clamp(transform.position.y, bottomleft.y, topright.y), transform.position.z);
    }

    public void setBounds(Vector3 botlimit,Vector3 toplimit)
    {
        bottomleft = botlimit + new Vector3(1f,1f,0f);
        topright = toplimit + new Vector3(-1f, -1f, 0f);
    }
}
