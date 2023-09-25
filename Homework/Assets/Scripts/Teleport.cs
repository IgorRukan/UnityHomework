using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject prefab;

    private GameObject instance;

    public int pause;
    private float time;

    void Update()
    {

        if (pause <= time)
        {

            if (instance != null)
            {
                Destroy(instance);
            }

            var rotation = Quaternion.identity;
            var position = new Vector3(Random.Range(-5f, 5f), Random.Range(5f, 7f), Random.Range(-5f, 5f));
            instance = Instantiate(prefab, position, rotation);

            time = 0;
        }
        time += Time.deltaTime;
    }
}
