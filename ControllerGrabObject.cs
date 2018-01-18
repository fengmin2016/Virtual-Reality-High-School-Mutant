using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
	public bool isGrabbing;
    private GameObject collidingObject; //Stores the GameObject that the trigger is colliding with, so you can grab it
    private GameObject objectInHand; //Reference to the GameObject the player is currently grabbings

    private Rigidbody KeepMovingNow = null;
    private Rigidbody KeepMoving = null;
    private Vector3 KeepMovingVel = Vector3.zero;
    private Vector3 PrevHandPos;
    private Vector3 PrevHandVel;
   


    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
		isGrabbing = false;
       
        trackedObj = GetComponent<SteamVR_TrackedObject>();
}

    //This method accepts a collider as a parameter and uses its GameObject as the collidingObject for grabbing and releasing
    private void SetCollidingObject(Collider col)
    {
        //Doesn't make the GameObject a potential grab target if the player is already holding something or the object has no rigid body
        //Assigns the object as a potential grab target

        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    //When the tirgger collider enters another, this sets up the other collider as a potential grab target
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    //Similar to OnTriggerEnter, but it ensures that the target is set when the player holds a controller over an object for a while
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    //When the collider exits an object, abandoning an ungrabbed target, this code removes its target by setting it to null
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
        //isGrabbing = false;
    }

    private void GrabObject()
    {
        if(objectInHand != null)
        {
            return;
        }
        //1 Move the GameObject inside the player's hand and remove it from the collidingObject variable
        objectInHand = collidingObject;
        collidingObject = null;

        //2 Add a new joint that connects the controller to the object using the AddFixedJoint method
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        isGrabbing = true;

        if (objectInHand.GetComponent<LogAllCollisions>() == null)
        {
            objectInHand.AddComponent<LogAllCollisions>();
        }
    }

    private FixedJoint AddFixedJoint()
    {
        //3 Make a new fixed joint, add it to the controller, and then set it up so that it doesn't break easily
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        //1 Make sure there's a fixed joint attached to the controller
        if(GetComponent<FixedJoint>())
        {
            //2 Remove the connection to the object held by the joint and destroy the joint
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            //3 Add the speed and rotation of the controller when the player releases the object, so the result is a realistic arc
            //objectInHand.GetComponent<Rigidbody>().velocity += PrevHandVel * 2.0f;
            objectInHand.GetComponent<Rigidbody>().angularVelocity *= 1.6f;
            KeepMoving = objectInHand.GetComponent<Rigidbody>();
            KeepMovingVel = PrevHandVel * 1.65f;
            //objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;

        }

        //4 Remove the reference to the formerly attached object
        objectInHand = null;

        isGrabbing = false;
    }

    // Update is called once per frame
    void Update () {

        var curPos = this.transform.position;
        this.PrevHandVel = ((curPos - this.PrevHandPos) / Time.deltaTime);
        this.PrevHandPos = curPos;

        //1 When the player squeezes the trigger and there's a potential grab target, this grabs it
        //if(Controller.GetHairTriggerDown())
        if (this.KeepMoving != null)
        {
            KeepMovingNow = this.KeepMoving;
            this.KeepMoving = null;
        } else if (this.KeepMovingNow != null) { 
            this.KeepMovingNow.velocity += this.KeepMovingVel;
            this.KeepMovingNow = null;
        }


        //use grip button to pick up balloons

        if(Controller.GetPressDown(EVRButtonId.k_EButton_Grip))
        {
            if(collidingObject)
            {
                GrabObject();

                
            }
        }

        //2 If the player erleases the trigger and there's an object attached to the controller, this releases it
        if(Controller.GetPressUp(EVRButtonId.k_EButton_Grip))
        {
            if(objectInHand)
            {
                ReleaseObject();
               
            }
        }
	}
}
