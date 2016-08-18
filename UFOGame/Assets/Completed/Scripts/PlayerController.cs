using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float speed;
    private int count = 0;
    public Text countText;
    public Text winText;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        setCountText();
        winText.text = "";
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
            //
        }
            
            
    }
    void setCountText()
    {
        countText.text = "count:" + count.ToString();
        if (count >= 13)
        {
            winText.text = "You Win!!!!";
        }
    }
}
