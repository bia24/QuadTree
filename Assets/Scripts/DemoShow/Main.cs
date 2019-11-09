using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public int gameObjNum = 10000;
   

    private QuadTree tree;

    private Player player;

    private void Awake()
    {
        tree = new QuadTree();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
        for(int i = 0; i < gameObjNum; i++)
        {
            tree.Insert(CreateOneGameObj());
        }
    }

    void Update () {
        tree.UpdateObjState(new Bounds(player.transform.position, Vector3.one * player.playerBoundRange));
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (tree != null)
        {
            tree.DrawNodeBound();
        }
    }

    private GameObjData CreateOneGameObj()
    {
        int type = Random.Range(0,3);

        string path=null;
        switch (type)
        {
            case 0:
                path = "Cube";
                break;
            case 1:
                path = "Capsule";
                break;
            case 2:
                path = "Sphere";
                break;
        }

        Vector3 position = new Vector3(Random.Range(-QuadTree.MAX_RANGE, QuadTree.MAX_RANGE),
            0.5f,
            Random.Range(-QuadTree.MAX_RANGE, QuadTree.MAX_RANGE));

        Quaternion rotation = Quaternion.Euler(Random.onUnitSphere*Random.Range(0,360));

        return new GameObjData(path, position, rotation);
    }
}
