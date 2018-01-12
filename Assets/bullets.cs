using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour {

    public GameObject player;
    public float force;

	public IEnumerator shot (float strength)
    {
        float push = strength * force;
        Debug.Log(push);
        this.GetComponent<Rigidbody>().AddForce(player.transform.GetChild(0).transform.forward * push);

        yield return new WaitForSeconds(0.1f);
    }
}
