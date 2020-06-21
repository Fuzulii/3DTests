using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollisionDedector : MonoBehaviour
{
    public CylinderSpawner csRef;
    public ParticleSystem ps;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cylinder")
        {
            Destroy(other.gameObject);
        }
        var psGO = Instantiate(ps,transform);
        psGO.transform.position = other.transform.position;
        psGO.gameObject.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            int x = i;
            DOVirtual.DelayedCall(0.2f * x, () => {
                csRef.SpawnRandomCylinder();
            }).SetUpdate(false);
        }
    }
}
