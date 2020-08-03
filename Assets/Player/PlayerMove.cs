using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    [Header("General")]
    Rigidbody2D Rigid;
    public CinemachineVirtualCamera cam;
    private float camSizeTarget;
    
    [Header("Rotation")]
    public float turnMultipler = 3;
    Vector3 rotate;
    public float maxRotate = 80;
    
    [Header("Force")]
    public Vector2 diveForce;
    public Vector2 flyForce;
    public Vector2 normalForce;
    public float forceCap = 6;
    
    [Header("Rewind")]
    public rewindManager rewind;
    
    [Header("Death")]
    public bool isDead = false;
    public GameObject deathParticle;
    private ParticleSystem death;
    public GameObject featherParticle;
    private ParticleSystem feather;

    [Header("Misc")]
    public Transform forceBar;
    public Transform forceParent;


    [HideInInspector]
    public float forceAmnt = 0;


    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        rewind = FindObjectOfType<rewindManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Rigid.velocity.magnitude > 5)
        {
            camSizeTarget = Rigid.velocity.magnitude * 1.5f;
            if(camSizeTarget > 30)
            {
                camSizeTarget = 30;
            }
        }
        else
        {
            camSizeTarget = 5;
        }
        if(cam.m_Lens.OrthographicSize > camSizeTarget)
        {
            cam.m_Lens.OrthographicSize -= Time.deltaTime * Mathf.Abs(camSizeTarget - cam.m_Lens.OrthographicSize) / 2;
            
        }
        else if(cam.m_Lens.OrthographicSize < camSizeTarget)
        {
            cam.m_Lens.OrthographicSize += Time.deltaTime * Mathf.Abs(camSizeTarget - cam.m_Lens.OrthographicSize) / 2;
        }
        if (Input.GetKey(KeyCode.Space) && !FindObjectOfType<changeScore>().hasControl)
        {
            if(Rigid.velocity.x > 40)
            {
                Rigid.AddForce(new Vector2(0, diveForce.y));
            }
            else
            {
                Rigid.AddForce(diveForce);
            }
            
            forceAmnt += Time.deltaTime;
            if(forceAmnt > forceCap)
            {
                forceAmnt = forceCap;
            }
        }
        else if(forceAmnt > 0 && !Input.GetKey(KeyCode.Space))
        {
            if (Rigid.velocity.x < 2)
            {
                Rigid.AddForce(new Vector2(diveForce.x / 4, flyForce.y));
            }
            else
            {
                Rigid.AddForce(flyForce);
            }
            forceAmnt -= Time.deltaTime * 1.5f;
        }
        else
        {
            Rigid.AddForce(normalForce);
        }
       if(Rigid.velocity.y > 50)
        {
            Rigid.velocity = new Vector3(Rigid.velocity.x, 50, 0);
        }

        

        rotate = new Vector3(0, 0, Rigid.velocity.y * 1.5f);
        if(rotate.z > maxRotate)
        {
            rotate.z = maxRotate;
        }else if(rotate.z < -maxRotate)
        {
            rotate.z = -maxRotate;
        }
        transform.rotation = Quaternion.Euler(rotate);
        if (isDead)
        {

            death = Instantiate(deathParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            feather = Instantiate(featherParticle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            death.Play();
            death.loop = false;
            feather.Play();
            feather.loop = false;
            Rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            Rigid.gravityScale = 0;
            gameObject.SetActive(false);
            FindObjectOfType<CameraShake>().ShakeIt();
            
        }
        else
        {
            Rigid.constraints = RigidbodyConstraints2D.None;
            if (death != null)
            {
                Destroy(death.gameObject);
            }
            if (feather != null)
            {
                Destroy(feather.gameObject);
            }
            Rigid.gravityScale = 1;
        }
        forceBar.localScale = new Vector3(forceAmnt / forceCap,1,1);
        forceParent.localScale = new Vector3(cam.m_Lens.OrthographicSize / 3f, cam.m_Lens.OrthographicSize / 30, cam.m_Lens.OrthographicSize / 3);
        forceParent.gameObject.SetActive(!isDead);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Juice"))
        {
            rewind.juice += 0.3f;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("death"))
        {
            isDead = true;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            isDead = true;
        }
        forceAmnt = 0;
    }
}

