using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalController : MonoBehaviour
{
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (ps != null)
        {
            StartCoroutine(DestroyAfterParticles(ps));
        }
    }

    IEnumerator DestroyAfterParticles(ParticleSystem ps)
    {
        // 파티클 시스템이 끝날 때까지 대기
        yield return new WaitForSeconds(ps.main.duration + ps.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
