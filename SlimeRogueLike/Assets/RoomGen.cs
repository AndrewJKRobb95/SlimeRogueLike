using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{
    public doorLocation doorLocations;

    public enum doorLocation
    {
        North = 1,
        East = 2,
        South = 3,
        West = 4
    }

    private RoomTemplates roomTemplates;
    private int randomRoom;
    public bool spawned = false;

    public float waitTime = 4f;

    void Start()
    {
        Destroy(gameObject, waitTime);

        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (!spawned)
        {
            switch (doorLocations)
            {
                case doorLocation.North:
                    randomRoom = Random.Range(0, roomTemplates.SouthDoorRooms.Length);
                    Instantiate(roomTemplates.SouthDoorRooms[randomRoom], transform.position, roomTemplates.SouthDoorRooms[randomRoom].transform.rotation);
                    break;

                case doorLocation.East:
                    randomRoom = Random.Range(0, roomTemplates.WestDoorRooms.Length);
                    Instantiate(roomTemplates.WestDoorRooms[randomRoom], transform.position, roomTemplates.WestDoorRooms[randomRoom].transform.rotation);
                    break;

                case doorLocation.South:
                    randomRoom = Random.Range(0, roomTemplates.NorthDoorRooms.Length);
                    Instantiate(roomTemplates.NorthDoorRooms[randomRoom], transform.position, roomTemplates.NorthDoorRooms[randomRoom].transform.rotation);
                    break;

                case doorLocation.West:
                    randomRoom = Random.Range(0, roomTemplates.EastDoorRooms.Length);
                    Instantiate(roomTemplates.EastDoorRooms[randomRoom], transform.position, roomTemplates.EastDoorRooms[randomRoom].transform.rotation);
                    break;
            }

            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.CompareTag("SpawnPoint"))
        {
            //creates walls blocking openings
            if (!hitObject.GetComponent<RoomGen>().spawned && !spawned)
            {
                Instantiate(roomTemplates.ClosedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            spawned = true;
        }
    }
}
