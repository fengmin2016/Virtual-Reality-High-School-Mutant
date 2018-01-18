using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKeyboardPlayer : MonoBehaviour {

    public bool UseMouseKeyboard = false;
    public SteamVR_ControllerManager Manager = null;
    public Shooter[] AllShooters = null;
    private Shooter Current = null;

	// Use this for initialization
	void Start () {
		if (Manager == null)
        {
            this.Manager = GameObject.FindObjectOfType<SteamVR_ControllerManager>();
        }
        this.Current = this.AllShooters[0];
	}

    public float MotionSpeed = 1.0f;
    public float RotateSpeed = 50.0f;
    public float UpCorrectSpeed = 50.0f;
    private Vector3 mLatestMouse = Vector3.zero;
    private bool mHasMouse = false;

    public void ResetCamera()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.Current.Shoot(null, new ClickedEventArgs());
            this.Current = ((this.AllShooters[0] == this.Current) ? this.AllShooters[1] : this.AllShooters[0]);
        }

        bool anyKey = false;
        Vector3 unitMotion = new Vector3(0, 0, 0);
        if (UnityEngine.Input.GetKey(KeyCode.W))
        {
            anyKey = true;
            unitMotion += this.transform.forward;
        }
        if (UnityEngine.Input.GetKey(KeyCode.S))
        {
            anyKey = true;
            unitMotion -= this.transform.forward;
        }
        if (UnityEngine.Input.GetKey(KeyCode.A))
        {
            anyKey = true;
            unitMotion -= this.transform.right;
        }
        if (UnityEngine.Input.GetKey(KeyCode.D))
        {
            anyKey = true;
            unitMotion += this.transform.right;
        }
        if (UnityEngine.Input.GetKey(KeyCode.Q))
        {
            anyKey = true;
            unitMotion += this.transform.up;
        }
        if (UnityEngine.Input.GetKey(KeyCode.Z))
        {
            anyKey = true;
            unitMotion -= this.transform.up;
        }

        if (anyKey && (unitMotion != Vector3.zero))
        {
            var localMotion = Camera.main.transform.worldToLocalMatrix * unitMotion;
            this.transform.Translate(localMotion * (UnityEngine.Time.deltaTime * MotionSpeed));
        }


        if (UnityEngine.Input.GetMouseButton(1))
        {
            if (this.mHasMouse)
            {
                var delta = UnityEngine.Input.mousePosition - this.mLatestMouse;
                delta = (delta * (RotateSpeed / Mathf.Min(Screen.width, Screen.height)));
                var oldCamPos = Camera.main.transform.position;
                this.transform.Rotate(new Vector3(0, delta.x, 0));

                var cameraSide = this.transform.right;
                if (cameraSide.y != 0)
                {
                    //this.transform.Rotate(new Vector3(0, 0, -(cameraSide.y * UpCorrectSpeed * UnityEngine.Time.deltaTime)));
                }
                //this.transform.up = new Vector3(0,1,0);

                this.transform.position += (oldCamPos - Camera.main.transform.position);
            }
            this.mHasMouse = true;
            this.mLatestMouse = UnityEngine.Input.mousePosition;
        }
        else
        {
            this.mHasMouse = false;
        }
    }
}
