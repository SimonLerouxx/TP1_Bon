 using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCast : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject TextInteragir;
    [SerializeField] float distance = 10;
    [SerializeField] GameObject plateforme;
    bool canInteract=false;
    bool isMovingUp = false;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if(hit.transform.tag == "Bouton")
            {
               
                TextInteragir.SetActive(true);
                canInteract= true;

            }
            
        }
        else
        {
            TextInteragir.SetActive(false);
            canInteract = false;
        }
    }

    public void Interagir(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && canInteract &&!isMovingUp)
        {
           
            StartCoroutine(MoveUp());
        }
    }

    IEnumerator MoveUp()
    {
        isMovingUp= true;
        
        while (plateforme.transform.localPosition.y < 23.4f)
        {
            
            plateforme.transform.Translate(Vector3.up*Time.deltaTime*5);
           
            yield return null;
        }
        
    }
}
