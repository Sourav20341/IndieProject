using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class udja : MonoBehaviour
{
    public float wait = 3f;
    public float force = 2f;
    public float arc = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(Vector3.up * force,ForceMode.Force);
            iTween.PunchPosition(this.gameObject,new Vector3(Random.Range(arc,arc),0,Random.Range(arc,arc)),wait*2);
            StartCoroutine(Blow());
        }
    }
    IEnumerator Blow(){
        yield return new WaitForSeconds(wait);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }
}
