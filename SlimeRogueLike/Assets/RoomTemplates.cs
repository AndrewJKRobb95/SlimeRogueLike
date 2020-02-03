using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] NorthDoorRooms;
    public GameObject[] EastDoorRooms;
    public GameObject[] SouthDoorRooms;
    public GameObject[] WestDoorRooms;

    public GameObject ClosedRoom;

    public List<GameObject> RoomsInLevel;

    public float roomGenTimer;
    private bool bossRoomSpawned;
    public GameObject boss;

    private void Update()
    {
        if (roomGenTimer <= 0 && !bossRoomSpawned)
        {
            Instantiate(boss, RoomsInLevel[RoomsInLevel.Count - 1].transform.position, Quaternion.identity);
            bossRoomSpawned = true;
        }
        else
        {
            roomGenTimer -= Time.deltaTime;
        }
    }
}
