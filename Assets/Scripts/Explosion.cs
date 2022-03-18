using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject BlowUp;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] Hp hp;
    [SerializeField] float HitForce = 100f;
    public void beenHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 0.5f);
        if (hp == null) return;
        hp.takeDamage();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            Debug.Log(collision.gameObject.name);
            foreach (ContactPoint contact in collision.contacts)
                beenHit(contact.point);
        }
    }
    public void AddForce(Vector3 hitPosition, Transform HitSource)
    {
        beenHit(hitPosition);
        if (rigidbody == null) return;
        Debug.Log("hi");
        Vector3 direction = hitPosition-HitSource.position;
        rigidbody.AddForceAtPosition(direction.normalized*HitForce, hitPosition);
    }
    public void blowUp()
    {
       
        Debug.Log("Blow Up");
        GameObject blow = Instantiate(BlowUp, transform.position, Quaternion.identity);
        Destroy(blow, 3f);
        Destroy(gameObject);
        //yield return new WaitForSeconds(2f);
        EventManager.PlayerDeath();
    }
    public void blowUpOthers()
    {
        Debug.Log("Blow Up");
        GameObject blow = Instantiate(BlowUp, transform.position, Quaternion.identity);
        if (transform.tag == "Enemy")
        {
            EventManager.onScorePoint(1);
        }
        Destroy(blow, 3f);
        Destroy(gameObject);
    }
}
