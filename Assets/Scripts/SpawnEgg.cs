using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEgg : MonoBehaviour {

	public GameObject bbPlant;
    public GameObject healingPod;

    public Vector3 healPodPos = new Vector3(0.34f, 0.85f, -1.1f);

	float timeToSpawn = 8f;
    int genHealingPodRandom;

	// Use this for initialization
	void Start () {
		timeToSpawn = Random.Range(1.5f, 3f);

        // randomly generate a healing pod
        genHealingPodRandom = Random.Range(1, healingPod.GetComponent<Heal>().probability + 1);
        //genHealingPodRandom = 1;

        StartCoroutine(SpawnBB());
	}

    IEnumerator SpawnBB()
    {
     
        yield return new WaitForSeconds(timeToSpawn);

        Instantiate(bbPlant,
            new Vector3(transform.position.x, 0.22f, transform.position.z),
            Quaternion.identity);

        if (genHealingPodRandom == 1)
        {
            Instantiate(healingPod, transform.position + healPodPos, Quaternion.identity);
        }
    }
}
