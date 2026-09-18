using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    /*public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        //rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
*/




   public Camera cam;
   private float xRotation = 0f;

   public float xSensitivity = 30f;
   public float ySensitivity = 30f;

   private void Awake()
   {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;
   }

   public void ProcessLook(Vector2 input)
    {
        float mouseX  = input.x;
        float mouseY = input.y;
        //calculate camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //apply this to our camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        //rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        }


}
