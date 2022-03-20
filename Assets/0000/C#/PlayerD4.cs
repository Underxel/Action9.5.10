using UnityEngine;
using System.Collections;

public class PlayerD4 : MonoBehaviour {

	public GameObject Player;
	public GameObject Ragdoll;
	[SerializeField] private GameObject Spawn;

	void OnTriggerEnter(Collider other){
		if (other.tag == "D4") {
			Destroy (Player);
			
			Instantiate( Ragdoll,  Spawn.transform.position, Spawn.transform.rotation );
            
		}
	}


}
