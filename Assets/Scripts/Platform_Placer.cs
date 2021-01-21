using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Placer : MonoBehaviour
{
    public Transform Player;
    public Platform[] Platform_Prefabs;
    public Platform First_Platform;
    private List<Platform> spawned_Platforms = new List<Platform>();


    void Start()
    {
        spawned_Platforms.Add(First_Platform);
    }   

    void Update()
    {
        if(Player.position.z> spawned_Platforms[spawned_Platforms.Count-1].End.position.z-25)
        {
            Spawn_Platform();
            
        }
        if(spawned_Platforms[0].transform.position.z - Player.position.z <= -8)
        {
            Destroy(spawned_Platforms[0].gameObject);
            Debug.Log(spawned_Platforms[0].transform.position.z - Player.position.z);
            spawned_Platforms.RemoveAt(0);
        }
    }

    private void Spawn_Platform()
    {
        Platform New_Platform = Instantiate(Platform_Prefabs[Random.Range(0,Platform_Prefabs.Length)]);
        New_Platform.transform.position = spawned_Platforms[spawned_Platforms.Count-1].End.position - New_Platform.Begin.position;
        New_Platform.transform.position = new Vector3(New_Platform.transform.position.x, New_Platform.transform.position.y, (New_Platform.transform.position.z - 0.1f));
        spawned_Platforms.Add(New_Platform);


    }
    
    
}
