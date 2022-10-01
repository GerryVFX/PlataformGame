using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public float speedMove;
    public float speedTurn;
    public bool canJump;
    public float forceJump;

    public Transform _initialPos;

    public GameObject[] plataforms;
    public bool isInGround;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        MoveController();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            transform.position = _initialPos.position;
        }

        if (other.CompareTag("PowerUpJump"))
        {
            canJump = true;

            plataforms[0].GetComponent<Rigidbody>().useGravity = true;
            plataforms[0].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            plataforms[1].GetComponent<Rigidbody>().useGravity = true;
            plataforms[1].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            Destroy(other.gameObject);
        }

        if (other.CompareTag("Ground")) isInGround = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground")) isInGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground")) isInGround = false;
    }


    //Este metodo es para controlar el moviento
    void MoveController()
    {
        float moveV = Input.GetAxis("Vertical");
        float moveH = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, moveV * speedMove * Time.deltaTime);
        transform.Rotate(0, moveH, 0 * speedTurn * Time.deltaTime);

        //Este es para saltar
        if (canJump && isInGround) // || or   && and ==  <  >  !=  
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * forceJump, ForceMode.Impulse); //(0,1,0)
            }
        }
    }
}
