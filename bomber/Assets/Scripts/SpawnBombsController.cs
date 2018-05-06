using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBombsController : MonoBehaviour {

    public GameObject bombPrefab;
    public GameObject applePrefab;

    private float minX = -2.5f;
    private float maxX = 2.5f;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnBombs());
        InvokeRepeating("spawnApples", 3.5f, 3.5f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnBombs()
    {
        yield return new WaitForSeconds(Random.Range(0f,1.5f));
        Instantiate(bombPrefab, new Vector2(Random.Range(minX, maxX), this.gameObject.transform.position.y), Quaternion.identity);

        StartCoroutine(SpawnBombs());
    }

    private void spawnApples()
    {
        Instantiate(applePrefab, new Vector2(Random.Range(minX, maxX), this.gameObject.transform.position.y), Quaternion.identity);
    }
}
