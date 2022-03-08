using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public bool oleada1 = false;
    public bool oleada2 = false;
    public bool oleada3 = false;

    
    IEnumerator Start()
    {
        if(oleada1)
        {
            foreach (GameObject enemigo in SpawnManager.instance.oleada1)
            {
                NuevoEnemigo(enemigo);
            }
        }
        yield return new WaitForSeconds(SpawnManager.instance.timer1);

        if (oleada2)
        {
            foreach (GameObject enemigo in SpawnManager.instance.oleada2)
            {
                NuevoEnemigo(enemigo);
            }
        }
        yield return new WaitForSeconds(SpawnManager.instance.timer2);

        if (oleada3)
        {
            foreach (GameObject enemigo in SpawnManager.instance.oleada3)
            {
                NuevoEnemigo(enemigo);
            }
        }
        yield return new WaitForSeconds(SpawnManager.instance.timer3);
    }

    void NuevoEnemigo(GameObject enemigo)
    {
        Instantiate(enemigo, transform.position + new Vector3(Random.Range(-6,6), Random.Range(-6, 6)), transform.rotation);
        SpawnManager.instance.orcos++;
    }
}
