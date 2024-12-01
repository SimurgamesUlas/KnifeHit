using Unity.VisualScripting;
using UnityEngine;

public class CircleController : MonoBehaviour
{
  [SerializeField] private float rotateSpeed;
  

   private void Update(){

    SetCircleRotate();
   }

    private void SetCircleRotate(){
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

    }
}
