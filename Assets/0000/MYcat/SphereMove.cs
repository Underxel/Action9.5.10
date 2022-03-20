using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SphereMove : MonoBehaviour
{ 
    [Header("Скорость движения")]
    [SerializeField] private float Speed;
    [Header("Радиус поиска игрока")]
    [SerializeField] private float Radius;

    private NavMeshAgent Agent;

    private Transform m_Target = null;
    private Queue<Transform> m_Queue = new Queue<Transform>();

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.speed = Speed;
        GetComponent<SphereCollider>().radius = Radius;
        GetComponent<SphereCollider>().isTrigger = true;
    }

    void Update()
    {
        if (m_Target != null)
		{
            Agent.SetDestination(m_Target.position);

            Vector3 dir = m_Target.position - transform.position;
            dir.y = 0;

            if (dir.magnitude <= 1.1 && m_Queue.Count > 0)
            {
				//этот код выполняется при близком расстоянии до цели - кот переключается на новую цель
				//именно здесь можно добавить удаление предмета к которому шел кот:
				//Destroy(m_Target.gameObject);

				m_Target = m_Queue.Dequeue();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NAV"))
        {
            if (m_Target)
			{
                m_Queue.Enqueue(other.transform);
            }
            else
			{
                m_Target = other.transform;
			}
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
	{
		if (m_Target)
		{
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(m_Target.position, 1);
		}
	}
#endif
}
