using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    private List<Player> playerObjects;
    private Player leader;

    private void Awake()
    {
        playerObjects = new List<Player>();
        
    }

    private void Update()
    {
        if (playerObjects.Count != 0)
        {
            leader = playerObjects[0];
            leader.isLeader = true;
            foreach (Player unit in playerObjects)
            {
                if (!unit.isLeader)
                {
                    Vector3 offset = GetRelativePosition(leader.transform, unit.transform.position);
                    unit.relavtivePos = offset;
                }
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (Player unit in playerObjects)
            {
                unit.SelectOnOff();
                unit.isLeader = false;
            }

            playerObjects.Clear();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Player UPlayer = hit.collider.gameObject.GetComponent<Player>();

                
                if (UPlayer != null)
                {
                    UPlayer.SelectOnOff();

                    if (!playerObjects.Contains(UPlayer))
                    {
                        if (playerObjects.Count == 0 )
                        {
                            playerObjects.Add(UPlayer);
                        }
                        else
                        {
                            playerObjects.Add(UPlayer);
                            Vector3 offset = GetRelativePosition(leader.transform, UPlayer.transform.position);
                            UPlayer.relavtivePos = offset;
                        }
                    }
                    else
                    {
                        playerObjects.Remove(UPlayer);
                        UPlayer.isLeader = false;
                    }
                }
            }
        }
    }

    public static Vector3 GetRelativePosition(Transform origin, Vector3 position)
    {
        Vector3 distance = position - origin.position;
        Vector3 relativePosition = Vector3.zero;
        relativePosition.x = Vector3.Dot(distance, origin.right.normalized);
        relativePosition.y = Vector3.Dot(distance, origin.up.normalized);
        relativePosition.z = Vector3.Dot(distance, origin.forward.normalized);

        return relativePosition;
    }
}
