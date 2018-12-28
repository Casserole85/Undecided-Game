using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour
{

    Player player;
    bool seated;

    private void Start()
    {

        player = FindObjectOfType<Player>();




        if (gameObject.name == "Bench")
        {
           


        }
        else
        {
            Debug.Log("InteractableObject name is invalid : " + gameObject.name);
        }
    }



    void ObjectActions()
    {
        if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Player")) == true) {
            if (gameObject.name == "Bench")
            {
                if (Input.GetKeyDown(KeyCode.E)){
                    if (seated)
                    {
                        player.Allowmovement = true;
                        var X = player.transform.position.x + 1;
                        var Y = player.transform.position.y;
                        Vector2 standing = new Vector2(X,Y );
                        player.transform.position = standing;
                    }
                    else if (!seated)
                    {
                        player.Allowmovement = false;
                        var options = Random.Range(-1, 1);

                        Vector2 Slot = gameObject.transform.GetChild(options).transform.position;
                        player.transform.position = Slot;
                    }
                   
                }

            }



        }
    }



}
