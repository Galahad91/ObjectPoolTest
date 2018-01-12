using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour {
    [SerializeField]
    public Queue<GameObject> magazine;
    public int capacity;
    public GameObject bullet;
    private GameObject tempBullet;
   

	void Start ()
    {
        magazine = new Queue<GameObject>();
       
            
       

        for (int i = 0; i < capacity; i ++)
        {
            tempBullet = Instantiate(bullet,new Vector3(0,0,-100), Quaternion.identity);
            magazine.Enqueue(tempBullet);
            tempBullet.transform.SetParent(this.transform);
        }
	}
	
   public IEnumerator recharge(float strength, Transform player)
    {
        player.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
        GameObject tempBullet2;
        tempBullet = magazine.Dequeue();
        tempBullet.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        tempBullet2 = tempBullet;
        tempBullet.transform.position = player.GetChild(0).transform.GetChild(0).transform.GetChild(1).transform.position;
        tempBullet.transform.rotation = player.GetChild(0).transform.GetChild(0).transform.GetChild(1).transform.rotation;
        StartCoroutine(tempBullet2.GetComponent<bullets>().shot(strength));
        player.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);


        //tempBullet.transform.rotation = player.rotation;
        yield return new WaitForSeconds(3);
        magazine.Enqueue(tempBullet2);
        tempBullet2.SetActive(false);

    }
	
	void Update ()
    {
		
	}
}
