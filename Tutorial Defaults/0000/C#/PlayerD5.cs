using UnityEngine;
using System.Collections;

public class PlayerD5 : MonoBehaviour {

	public GameObject Player;
	public GameObject Ragdoll;
	[SerializeField] private GameObject Spawn;

	void OnTriggerEnter(Collider other){
		if (other.tag == "D5") {
			Destroy (Player);
			
			Instantiate( Ragdoll,  Spawn.transform.position, Spawn.transform.rotation );
            
		}
	}


}
