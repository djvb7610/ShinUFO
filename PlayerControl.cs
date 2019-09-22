using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{

    public float speed;                
    public Text countText;           
    public Text winText;           

    private Rigidbody2D rb2d;        
    private int count;                
 public GameObject enemyPrefab;
    public GameObject enemy;
     
    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();

       
        count = 0;

        
        winText.text = "";

       
        SetCountText();
    }

    
    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");

        
        float moveVertical = Input.GetAxis("Vertical");

        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        
        rb2d.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.CompareTag("PickUp"))
{
            
            other.gameObject.SetActive(false);

        
        count = count + 1;

        
        SetCountText();
        }
     else if (other.gameObject.CompareTag("enemy"))
     {
          other.gameObject.SetActive(false);
          count = count - 1;  
          SetCountText();
     }
     if (count == 12) 
{
    transform.position = new Vector2(.37f, 46.43f); 
}
} 





    void SetCountText()
    {
       
        countText.text = "Count: " + count.ToString();

        
        if (count >= 20)
           
            winText.text = "You win! Game created by Daniel Vanderbrink";
    }
}