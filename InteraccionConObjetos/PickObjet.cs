using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PickObjet : MonoBehaviour
{
    public GameObject ObjectToPickup;//No incluir nada, se asigna dependiendo de lo que tenga enfrente
    private GameObject pickedObject;//Se manipula en el codigo
    public Transform interactionZone;//Un Empty, llamado InteractionZone, con tag PlayerInteractionZone, con un BoxCollider
    public int fuerza=3;
    public double Y;
    public float Y2;
    public float dirx;
    public float dirz;
    InventarioHand inventario;

    private void Start()
    {
        inventario = GetComponent<InventarioHand>();
    }

    // Update is called once per frame
    void Update()
    {
        Y = Math.PI*GetComponent<Transform>().eulerAngles.y/180.0;
        //Y2 = interactionZone.GetComponentInParent<Transform>().rotation.y;
        dirx = (float)Math.Cos(Y);
        dirz = (float)Math.Sin(Y);
        if (ObjectToPickup != null && ObjectToPickup.GetComponent<PickedObject>().isPickable == true && pickedObject==null )
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                pickedObject = ObjectToPickup;
                pickedObject.GetComponent<PickedObject>().isPickable = false;
                pickedObject.transform.SetParent(interactionZone);
                pickedObject.GetComponent<Rigidbody>().useGravity = false;
                pickedObject.GetComponent<Rigidbody>().isKinematic = true;
                pickedObject.transform.position = interactionZone.transform.position;
                pickedObject.GetComponent<BoxCollider>().isTrigger = true;
                //inventario.AddObject(pickedObject);

                
            }
        }
       
        else if (pickedObject != null)
        {

            
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                //inventario.RemoveObject(pickedObject);
                pickedObject.GetComponent<PickedObject>().isPickable = true;
                pickedObject.GetComponent<BoxCollider>().isTrigger = false;
                pickedObject.transform.SetParent(null);
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                
                pickedObject = null;
                

            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                
                pickedObject.GetComponent<PickedObject>().isPickable = true;
                pickedObject.GetComponent<BoxCollider>().isTrigger = false;
                pickedObject.transform.SetParent(null);
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.GetComponent<Rigidbody>().AddForce(new Vector3((float)dirz,0,(float)dirx)*fuerza, ForceMode.Impulse);
                pickedObject = null;
                
            }
                    
        }
        
    }
    
}
