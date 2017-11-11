using UnityEngine;

public class InteractablePresent : InteractableItem
{

    public float rotationSpeed;

    public float floatingFrequency;
    public float floatingAmplitude;

    private float timePassed;

    private bool pickedUp;
	// Use this for initialization
	void Start ()
	{
	    pickedUp = false;
	    gameObject.name = "present";
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!pickedUp)
	    {
	        floatAround();
        }
    }

    public override void Click()
    {
        pickedUp = true;
        MouseItem.Instance.PickupItem(this);
    }

    void floatAround()
    {
        timePassed += Time.deltaTime;
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
        transform.localPosition += Vector3.up * (Mathf.Sin(timePassed * floatingFrequency) * floatingAmplitude);
    }
}
