using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copadamlar : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
       
            if (other.CompareTag("copadam1"))
            {
                GameObject.FindWithTag("coinsesi").GetComponent<AudioSource>().Play();
                GameObject.FindWithTag("kan1").GetComponent<ParticleSystem>().Play();
                GameObject.FindWithTag("LevelController").GetComponent<LevelController>().ChangeMoney(1);
            }
            if (other.CompareTag("copadam2"))
            {
                GameObject.FindWithTag("kansesi").GetComponent<AudioSource>().Play();
                GameObject.FindWithTag("kan2").GetComponent<ParticleSystem>().Play();
            }
            if (other.CompareTag("copadam3"))
            {
                GameObject.FindWithTag("kansesi").GetComponent<AudioSource>().Play();
                GameObject.FindWithTag("kan3").GetComponent<ParticleSystem>().Play();
            }
            if (other.CompareTag("copadam4"))
            {
                GameObject.FindWithTag("kansesi").GetComponent<AudioSource>().Play();
                GameObject.FindWithTag("kan4").GetComponent<ParticleSystem>().Play();
            }
            if (other.CompareTag("copadam5"))
            {
                GameObject.FindWithTag("coinsesi").GetComponent<AudioSource>().Play();
                GameObject.FindWithTag("kan5").GetComponent<ParticleSystem>().Play();
                GameObject.FindWithTag("LevelController").GetComponent<LevelController>().ChangeMoney(1);
            }
        
    }
}
