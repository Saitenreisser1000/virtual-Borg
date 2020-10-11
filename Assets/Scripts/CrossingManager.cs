using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossingManager : MonoBehaviour
{
    GameObject[] crossings;
    GameObject player;

    GameObject targetCrossing;
    GameObject nextToPlayerCrossing;

    GameObject tar;

    LineRenderer lRenderer;

    //Pathes
    List<GameObject> shortestPath;
    List<List<GameObject>> possiblePaths = new List<List<GameObject>>();
    
    //avoid Stack overflow
    int counter = 0;

    void Start()
    {
        crossings = GameObject.FindGameObjectsWithTag("Crossing");
        player = GameObject.FindGameObjectWithTag("Player");
        tar = GameObject.Find("cTurnsaalBoys");
        lRenderer = GetComponent<LineRenderer>();

        FindRoute(tar);

        CalcEffectivePath();
    }

    public void UpdateRoute()
    {
        possiblePaths.Clear();
        FindRoute(tar);
        
    }

    // Update is called once per frame
    void Update()
    {
        lRenderer.SetPosition(shortestPath.Count, player.transform.position);
    }

    void FindRoute(GameObject target)
    {
        //two main crossing points
        targetCrossing = target;
        nextToPlayerCrossing = crossings[0];

        //find crossing next to player
        float dist = Vector3.Distance(nextToPlayerCrossing.transform.position, player.transform.position);
        foreach (GameObject cross in crossings)
        {
            if (Vector3.Distance(cross.transform.position, player.transform.position) < dist)
            {
                nextToPlayerCrossing = cross;
                dist = Vector3.Distance(nextToPlayerCrossing.transform.position, player.transform.position);
            }
        }
        List<GameObject> visited = new List<GameObject>();
        //calc all possible paths from
        counter = 0;
        RecursiveSearcher(targetCrossing, visited, nextToPlayerCrossing);
        //calc the shortest path
        CalcEffectivePath();
    }

    //Recursion stores all possible paths -> possible path
    void RecursiveSearcher(GameObject start, List<GameObject> visited, GameObject target)
    {
        if(start == null) { return; } //if neighbour is not assigned in inspector
        counter++;
        List<GameObject> newVisited = new List<GameObject>(visited);
        newVisited.Add(start);
        if (start == target)
        {
            possiblePaths.Add(newVisited);
            return;
        }
        //iterate through all neighbours in start
        
        foreach (GameObject neigh in start.GetComponent<crossingCollider>().neighbours)
        {
            bool foundVisited = false;
            foreach (GameObject visitedBefore in newVisited)
            {
                //avoid stack-overflow
                if (counter >= 100)
                {
                    throw new System.Exception("Couldn't find path");
                }
                if (neigh == visitedBefore)
                {
                    foundVisited = true;
                }
            }
            if (!foundVisited)
            {
                RecursiveSearcher(neigh, newVisited, target);
            }
        }
    }

    //calculates the shortes path -> shortest path
    void CalcEffectivePath()
    {
        shortestPath = possiblePaths[0];
        float rememberPrevLength = 100000f;

        //check if other path is shorter
        foreach (List<GameObject> path in possiblePaths)
        {
            float length = 0;
            //calc dist for path
            for (int i = 1; i < path.Count; i++)
            {
                length += Vector3.Distance(path[i - 1].transform.position, path[i].transform.position);
            }

            if (length < rememberPrevLength)
            {
                shortestPath = path;
                rememberPrevLength = length;
            }
        }

        //Player has position 0 therefor Count+1;
        lRenderer.positionCount = shortestPath.Count + 1;

        for (int i = 0; i < shortestPath.Count; i++)
        {
            lRenderer.SetPosition(i, new Vector3(shortestPath[i].transform.position.x, shortestPath[i].transform.position.y - 1.5f, shortestPath[i].transform.position.z));
        }
    }

    private List<GameObject> lastRemoved;


    /**
     * recalculation when player interacts with crossing collider
     */

    public void LeaveCrossingCollider(GameObject col, string direction)
    {
        UpdateRoute();
        //wenn player näher zu count - 2 ist, dann remove count - 1
        float distPlayerCol = Vector3.Distance(player.transform.position, shortestPath[shortestPath.Count - 2].transform.position);
        float distColliders = Vector3.Distance(shortestPath[shortestPath.Count - 1].transform.position, shortestPath[shortestPath.Count - 2].transform.position);

        if (distPlayerCol < distColliders)
        {
            lRenderer.positionCount -= 1;
            print(shortestPath[shortestPath.Count - 1]);
            shortestPath.Remove(shortestPath[shortestPath.Count - 1]);

        }
    }

    public void TriggerCrossingCollider(GameObject col, string direction)
    {
        shortestPath.Remove(col);
    }
}
