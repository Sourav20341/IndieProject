using UnityEngine;

public class MouseClick : MonoBehaviour
{
    Animator anim;
    public Camera cam;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Debug.Log(hit);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.tag == "Player")
                {
                    anim = hit.transform.gameObject.GetComponent<Animator>();
                    anim.SetTrigger("click");
                }
            }
        }
    }
}
