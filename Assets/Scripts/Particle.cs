using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] private ParticleSystem part;
    private ParticleSystem tempObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateParticle(Vector2Int mousepos)
    {
        
        tempObject=Instantiate(part,new Vector3(mousepos.x, mousepos.y, 0),Quaternion.identity);
        part.Play();
        Invoke("Dest", 1.5f);
    }

    private void Dest()
    {
        Destroy(tempObject);
    }
}
