using System.Collections;
using UnityEngine;
public class LevelManager6 : MonoBehaviour
{
    public GameObject CurrentCheckpoint; //we can update the current checkpoint from within Unity
    public Transform player;
    public Transform Enemy;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void RespawnPlayer()
    {
        FindObjectOfType<PlayerAnimatorController>().transform.position = CurrentCheckpoint.transform.position;
        //Search for the asset/object called Controller (ur player's script code name whatever it is).
        //once u've found it, change its player game object's position to be at the last checkpoint the
        //player passed through before s/he died ..
 }
    public void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}