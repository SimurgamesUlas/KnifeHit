
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeController : MonoBehaviour
{
  private KnifeManager knifemanager;
  private Rigidbody2D KnifeRigidBody;
  [SerializeField] private float moveSpeed;
  private bool CanShoot;
  private void Start(){
        GetComponentValues();
  }
  private void Update(){
    HandleShootInput();
  }

  private void FixedUpdate(){
    Shoot();
  }
  private void HandleShootInput(){
    if(Input.touchCount > 0 || Input.GetMouseButtonDown(0)){
        knifemanager.SetDisableKnifeIconColor();
        CanShoot = true;
    }
  }
  private void Shoot(){
    if(CanShoot){
        KnifeRigidBody.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime);
    }
  }
  
  private void OnCollisionEnter2D(Collision2D other){
    if(other.gameObject.CompareTag("Circle")){
        knifemanager.SetActiveKnife();
        CanShoot = false;
        transform.SetParent(other.transform);
        KnifeRigidBody.velocity = new Vector3(0, 0, 0);//eklenti
        KnifeRigidBody.angularVelocity = 0;//eklenti
        KnifeRigidBody.isKinematic = true;
        PlayerPrefs.SetInt("Child",other.transform.childCount);
        PlayerPrefs.Save();
  
    }
    if(other.gameObject.CompareTag("Knife")){
        SceneManager.LoadScene(0);
    }
  }
  private void GetComponentValues(){
    KnifeRigidBody = GetComponent<Rigidbody2D>();
    knifemanager = GameObject.FindObjectOfType<KnifeManager>();
  }
}
