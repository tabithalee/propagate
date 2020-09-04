using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : MonoBehaviour {

    public GameObject bbPlant;
    public GameObject motherPlant;

    float growthTime;

    public bool podActivated = false;

    private void Start ()
    {
        growthTime = Random.Range(15f, 25f);
    }

    void Update ()
    {
        if (podActivated)
        {
            podActivated = false;
            StartCoroutine(Grow());
        }
    }

    IEnumerator Grow ()
    {
        yield return new WaitForSeconds(growthTime);

        Instantiate(motherPlant, 
            new Vector3(transform.position.x, motherPlant.transform.position.y, transform.position.z), 
            motherPlant.transform.rotation);
        Destroy(bbPlant);
    }
}
