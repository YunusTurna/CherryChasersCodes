using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryBomb : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float throwPower;
    public GameObject whoGotHit;
    private bool isExplosionActive = false;
    private bool explosion = false;
    private bool ignoreCollision;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E) & transform.parent != null) && transform.parent.tag == "Character")
        {
            Throwing();
        }
    }
    private void OnCollisionEnter(Collision other)
    {

        if (isExplosionActive == true)
        {
            StartCoroutine(Explosion());
            CharacterExplosion(other);
        }
        if (other.gameObject.tag == "Character")
        {
            DoesHaveBomb(other);
        }
        if ((other.gameObject.tag == "Character" & this.gameObject.tag != "ExplosiveCherry") & ignoreCollision == false)
        {
            BombWithCharacter(other);

        }
    }
    IEnumerator Explosion()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

    }
    void Throwing()
    {
        this.gameObject.transform.parent.GetComponent<CherryBombCharacter>().activateSparkle = false;
        rb.constraints = RigidbodyConstraints.None;
        this.gameObject.transform.parent.tag = "Character";
        this.gameObject.tag = "ExplosiveCherry";
        for (int i = this.gameObject.transform.childCount - 1; i > 0; i--)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(true);
            
        }
        rb.useGravity = true;
        rb.isKinematic = false;
        rb.AddForce(this.gameObject.transform.parent.forward * throwPower, ForceMode.Impulse);
        this.gameObject.transform.parent = null;
        this.gameObject.GetComponent<SphereCollider>().enabled = true;
        isExplosionActive = true;

    }
    void BombWithCharacter(Collision other)
    {
        other.gameObject.GetComponent<CherryBombCharacter>().activateSparkle = true;
        this.gameObject.transform.parent = other.gameObject.transform;
        this.gameObject.transform.position = other.gameObject.transform.GetChild(0).transform.position;
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        for (int i = 1; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
            
        }
        rb.isKinematic = true;
        Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), other.gameObject.GetComponent<Collider>(), true);

    }
    void DoesHaveBomb(Collision other)
    {
        Transform collidingObjectTransform = other.transform;
        string childName = this.gameObject.name;
        foreach (Transform child in collidingObjectTransform)
        {
            if (child.name == childName)
            {
                Debug.Log(this.gameObject.name);

                ignoreCollision = true;
                return;
            }
            else
            {
                ignoreCollision = false;
            }
        }

    }
    void CharacterExplosion(Collision other)
    {
        if (other.gameObject.tag == "Character")
            {
                whoGotHit = other.gameObject;
                Debug.Log(whoGotHit.name);
                other.gameObject.GetComponent<CherryBombCharacter>().hitCounter++;
            }

    }
}