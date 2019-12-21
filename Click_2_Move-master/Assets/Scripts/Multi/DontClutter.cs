using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontClutter : MonoBehaviour
{
    public SelectController selectedObjects;
    public float radius;
    private void Awake()
    {
        selectedObjects = GetComponent<SelectController>();
    }

    //private List<Player> players;

    //private void Awake()
    //{
    //    players = new List<Player>();
    //}
    //private void Update()
    //{
    //    //Player thisPlayer = GetComponent<Player>()
    //    //if (true)
    //    //{

    //    //}
    //    foreach (Player unit in players)
    //    {
    //        if (unit.disFromDestination <= 2.5)
    //        {
    //            unit.StopMovements();
    //        }
    //    }

    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    Player UPlayer = other.gameObject.GetComponent<Player>();
    //    if (UPlayer != null)
    //    {
    //        //UPlayer.SelectOnOff();

    //        if (!players.Contains(UPlayer))
    //        {
    //            Debug.Log("In");
    //            players.Add(UPlayer);
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Player UPlayer = other.gameObject.GetComponent<Player>();
    //    if (UPlayer != null)
    //    {
    //        //UPlayer.SelectOnOff();

    //        if (players.Contains(UPlayer))
    //        {
    //            Debug.Log("Out");
    //            players.Remove(UPlayer);
    //        }
    //    }
    //}
}
