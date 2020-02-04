using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticle : MonoBehaviour
{
    public GameObject m_particle;
    public float m_areaSpawn;
    public float m_delaySpawn;
    public float m_forceIntensity;

    private Rigidbody2D _rbParticle;
    private GameObject _particle;

    private Color _gizmoColor;

    void Start()
    {

        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_delaySpawn);
            Vector2 RandomPositionInArea = new Vector2(transform.position.x, transform.position.y) + Random.insideUnitCircle * m_areaSpawn;
            _particle = Instantiate(m_particle, RandomPositionInArea, Quaternion.identity);
            _rbParticle = _particle.GetComponent<Rigidbody2D>();
            _rbParticle.AddForce(new Vector2(1, 1) * m_forceIntensity);

        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = _gizmoColor;
        Gizmos.DrawWireSphere(transform.position, m_areaSpawn);
        //Gizmos.color = Color.blue;
    }
}
