using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private ConfigurableJoint hipjoint;
    [SerializeField] private Rigidbody hip;

    [SerializeField] private Animator targetAnimator;

    private bool walk = false;
    private bool grab = false;
    [SerializeField] private GameObject walkParticleSystem;
    [SerializeField] private GameObject[] Hands;
    private float tempSpeed;

    [SerializeField] private int hp = 5;
    [SerializeField] private TextMeshProUGUI hpText;


    void Start()
    {
        tempSpeed = speed;
        hpText.text = hp + "";
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

            this.hipjoint.targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

            this.hip.AddForce(direction * this.speed);

            this.walk = true;
        }
        else
        {
            this.walk = false;
        }

        if (walk)
        {
            walkParticleSystem.SetActive(true);
        }
        else
        {
            walkParticleSystem.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            grab = true;
            speed = speed / 10;
        }
        else
        {
            grab = false;
            speed = tempSpeed;
        }

        if (this.hp <= 0)
        {
            Destroy(gameObject);
        }

        this.targetAnimator.SetBool("Walk", this.walk);
        this.targetAnimator.SetBool("Grab", this.grab);
    }

    public bool getGrab()
    {
        return this.grab;
    }

    public void takeDamage(int damage)
    {
        hp -= damage;
        hpText.text = hp + "";
    }


}
