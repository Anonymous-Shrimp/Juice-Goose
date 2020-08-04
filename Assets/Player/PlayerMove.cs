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
    public Animator deathAnimation;

    [Header("Force Bar")]
    public Transform forceBar;
    public Transform forceParent;
    public Transform barColor;

    [Header("Misc")]
    public Animator rewindAnimation;
    public GameObject slurp;
    private ParticleSystem slurpParticle;
    public bool hardMode = true;
    


    [HideInInspector]
    public float forceAmnt = 0;


    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody2D>();
        rewind = FindObjectOfType<rewindManager>();
        if (hardMode)
        {
            Rigid.mass = 0.1f;
        }
        else
        {
            Rigid.mass = 0.25f;
            forceParent.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        print(Rigid.velocity);
        if (!FindObjectOfType<changeScore>().hasControl)
        {
            forceParent.GetComponent<SpriteRenderer>().color = new Color(forceParent.GetComponent<SpriteRenderer>().color.r, forceParent.GetComponent<SpriteRenderer>().color.b, forceParent.GetComponent<SpriteRenderer>().color.g,1);
            barColor.GetComponent<SpriteRenderer>().color = new Color(forceParent.GetComponent<SpriteRenderer>().color.r, forceParent.GetComponent<SpriteRenderer>().color.b, forceParent.GetComponent<SpriteRenderer>().color.g, 1);
        }
        
        if(cam.m_Lens.OrthographicSize > camSizeTarget)
        {
            cam.m_Lens.OrthographicSize -= Time.deltaTime * Mathf.Abs(camSizeTarget - cam.m_Lens.OrthographicSize) / 2;
            
        }
        else if(cam.m_Lens.OrthographicSize < camSizeTarget)
        {
            cam.m_Lens.OrthographicSize += Time.deltaTime * Mathf.Abs(camSizeTarget - cam.m_Lens.OrthographicSize) / 2;
        }
        if (hardMode)
        {
            if (Input.GetKey(KeyCode.Space) && !FindObjectOfType<changeScore>().hasControl)
            {
                if (Rigid.velocity.x > 40)
                {
                    Rigid.AddForce(new Vector2(0, diveForce.y));
                }
                else
                {
                    Rigid.AddForce(diveForce);
                }

                forceAmnt += Time.deltaTime;
                if (forceAmnt > forceCap)
                {
                    forceAmnt = forceCap;
                }
            }
            else if (forceAmnt > 0 && !Input.GetKey(KeyCode.Space))
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
            if (Rigid.velocity.y > 50)
            {
                Rigid.velocity = new Vector3(Rigid.velocity.x, 50, 0);
            }
            rotate = new Vector3(0, 0, Rigid.velocity.y * 1.5f);
            if (rotate.z > maxRotate)
            {
                rotate.z = maxRotate;
            }
            else if (rotate.z < -maxRotate)
            {
                rotate.z = -maxRotate;
            }
            transform.rotation = Quaternion.Euler(rotate);
            if (Rigid.velocity.magnitude > 5)
            {
                camSizeTarget = Rigid.velocity.magnitude * 1.5f;
                if (camSizeTarget > 30)
                {
                    camSizeTarget = 30;
                }
            }
            else
            {
                camSizeTarget = 5;
            }
            forceParent.gameObject.SetActive(!isDead);
        }
        /*
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && !FindObjectOfType<changeScore>().hasControl)
            {
                Rigid.AddForce(new Vector2(0, flyForce.y *  2f));
            }
            Rigid.AddForce(new Vector2(1f, 0));
            if(Rigid.velocity.x > 100)
            {
                Rigid.velocity = new Vector2(100, Rigid.velocity.y);
            }
            rotate = new Vector3(0, 0, Rigid.velocity.y * 3f);
            if (rotate.z > maxRotate)
            {
                rotate.z = maxRotate;
            }
            else if (rotate.z < -maxRotate)
            {
                rotate.z = -maxRotate;
            }
            transform.rotation = Quaternion.Euler(rotate);
            if (Rigid.velocity.magnitude > 1)
            {
                camSizeTarget = (Rigid.velocity.magnitude + 4) * 3f;
                if (camSizeTarget > 30)
                {
                    camSizeTarget = 30;
                }
            }
            else
            {
                camSizeTarget = 5;
            }
            */
        else
        {
            forceParent.gameObject.SetActive(false);
            if (Input.GetKey(KeyCode.LeftShift) && !FindObjectOfType<changeScore>().hasControl)
            {
                if (Rigid.velocity.x > 40)
                {
                    Rigid.AddForce(new Vector2(0, diveForce.y * 2f));
                }
                else
                {
                    Rigid.AddForce(new Vector2(diveForce.x * 2, diveForce.y * 2f));
                }
            }
            else if (Input.GetKey(KeyCode.Space) && !FindObjectOfType<changeScore>().hasControl)
            {
                if (Rigid.velocity.x < 2)
                {
                    Rigid.AddForce(new Vector2(diveForce.x / 2, flyForce.y * 2f));
                }
                else
                {
                    Rigid.AddForce(new Vector2(flyForce.x, flyForce.y * 2f));
                }
            }
            else
            {
                Rigid.AddForce(new Vector2(normalForce.x,0));
            }
            if (Rigid.velocity.y > 25)
            {
                Rigid.velocity = new Vector3(Rigid.velocity.x, 25, 0);
            }
            else if (Rigid.velocity.y < -25)
            {
                Rigid.velocity = new Vector3(Rigid.velocity.x, -25, 0);
            }
            rotate = new Vector3(0, 0, Rigid.velocity.y * 1.5f);
            if (rotate.z > maxRotate)
            {
                rotate.z = maxRotate;
            }
            else if (rotate.z < -maxRotate)
            {
                rotate.z = -maxRotate;
            }
            transform.rotation = Quaternion.Euler(rotate);
            if (Rigid.velocity.magnitude > 5)
            {
                camSizeTarget = Rigid.velocity.magnitude * 1.5f;
                if (camSizeTarget > 30)
                {
                    camSizeTarget = 30;
                }
            }
            else
            {
                camSizeTarget = 5;
            }
        
        }

        

        
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
            
            if (rewind.juice <= 0)
            {
                deathAnimation.SetTrigger("Open");
            }
            else
            {
                rewindAnimation.SetBool("RewindFadedIn", true);
            }
            
        }
        else
        {
            if (rewindAnimation.GetBool("RewindFadedIn"))
            {
                rewindAnimation.SetBool("RewindFadedIn", isDead);
            }
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
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Juice"))
        {
            rewind.juice += 0.3f;
            slurpParticle = Instantiate(slurp, collision.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            slurpParticle.Play();
            slurpParticle.loop = false;
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

