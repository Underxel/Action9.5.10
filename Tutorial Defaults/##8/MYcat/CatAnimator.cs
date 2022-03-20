using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatAnimator : MonoBehaviour
{
    [SerializeField] private Animator m_Animator = null;
	[SerializeField] private NavMeshAgent m_Agent = null;

	private void Start()
	{
		if (!m_Animator || !m_Agent)
		{
			Debug.LogError("bruh dude, заполни компоненты в инспекторе");
		}
	}

	private void Update()
	{
		float percentage01 = m_Agent.velocity.magnitude / m_Agent.speed;
		m_Animator.SetFloat("Walking", percentage01);
	}
}
