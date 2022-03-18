using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]float minscale=0.8f;
    [SerializeField] float maxscale = 3.6f;
    [SerializeField] float rotationOffset = 100f;
  
    Transform myT;
    Vector3 randomRotation;
    // Start is called before the first frame update
    private void Awake()
    {
        myT = transform;
    }
    void Start()
    {
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minscale, maxscale);
        scale.y = Random.Range(minscale, maxscale);
        scale.z = Random.Range(minscale, maxscale);
        myT.localScale = scale;

        randomRotation.x = Random.Range(-rotationOffset,rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
      
    }

    // Update is called once per frame
    void Update()
    {
        myT.Rotate(randomRotation * Time.deltaTime);
    }
  
}
