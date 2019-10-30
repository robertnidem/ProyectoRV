using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Para el objeto que sera recogido por el jugador
public class PickedObject : MonoBehaviour
{
    public bool isPickable = true;
    public Collider ObjectColider;//El colisionador del objeto que se va a levantar
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickObjet>().ObjectToPickup = this.gameObject;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickObjet>().ObjectToPickup = null;
        }
    }


}
