using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ballActions : MonoBehaviour {

    private Rigidbody rb;
    private float moveX, moveZ;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        winText.enabled = false;
        setCountText();
       
    }

    void FixedUpdate()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);

        rb.AddForce(movement * speed);

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
           
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 7)
        {
            winText.enabled = true;
            winText.text = "YOU WIN!!";
        }
    }
 }

