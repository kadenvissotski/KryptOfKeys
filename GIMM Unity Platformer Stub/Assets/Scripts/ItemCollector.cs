using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int countKeys = 5;
    [SerializeField] private Text keysText;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            if (countKeys > 0)
            {
                Destroy(collision.gameObject);
                countKeys--;
                keysText.text = "Keys Left: " + countKeys;
            }

            if (countKeys == 0) {
                    keysText.text = "All Keys Found: EXIT UNLOCKED";

                GameObject lockedObject = GameObject.Find("locked");
                GameObject unlockedObject = GameObject.Find("unlocked");
                if (unlockedObject != null)
                {
                    SpriteRenderer spriteRenderer1 = unlockedObject.GetComponent<SpriteRenderer>();
                    SpriteRenderer spriteRenderer2 = lockedObject.GetComponent<SpriteRenderer>();
                    BoxCollider2D bx = unlockedObject.GetComponent<BoxCollider2D>();

                    spriteRenderer1.enabled = true;
                    spriteRenderer2.enabled = false;
                    bx.enabled = true;
                    

                }
             
            }
        }
    }


}
