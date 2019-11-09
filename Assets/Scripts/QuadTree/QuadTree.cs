/**
 * 四叉树的数据结构
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadTree {
    //四叉树包含的地图范围最大值。
    public static readonly int MAX_RANGE = 320;
    public static readonly int MAX_Y = 30;

    public static readonly int TREE_DEPTH = 5;
    public static readonly int CHILDS_COUNT = 4;

    private QTNode root;

    public QuadTree()
    {
        root = new QTNode(new Bounds(Vector3.zero,new Vector3(MAX_RANGE,MAX_Y,MAX_RANGE)),0);
    }

    public void Insert(GameObjData go)
    {
        root.Insert(go);
    }

    public void DrawNodeBound()
    {
        root.DrawNodeBound();
    }

    public void UpdateObjState(Bounds playerBound)
    {
        root.UpdateObjState(playerBound);
    }

}


public class QTNode:INode
{
    private Bounds bound;
    private int depth;
    private List<INode> childs;

    public QTNode(Bounds bound,int depth)
    {
        this.bound = bound;
        this.depth = depth;
    }

    public void CreateChild()
    {
        childs = new List<INode>();
        if (depth < QuadTree.TREE_DEPTH - 1)
        {
            for (int i = 0; i < QuadTree.CHILDS_COUNT; i++)
            {
                childs.Add(new QTNode(BoundUtils.GetChildBound(bound, (Quadrant)i), depth + 1));
            }
        }
        else
        {
            for (int i = 0; i < QuadTree.CHILDS_COUNT; i++)
            {
                childs.Add(new QTLeaf(BoundUtils.GetChildBound(bound, (Quadrant)i)));
            }
        }

    }

    public void DrawNodeBound()
    {

        if (childs != null)
        {
            foreach(var child in childs)
            {
                child.DrawNodeBound();
            }
        }
    }

    public void Insert(GameObjData data)
    {
        if (!BoundUtils.Constains(bound, data.position))
            return;

        if (childs == null)
        {
            CreateChild();
        }
        foreach(var child in childs)
        {
            child.Insert(data);
        }
    }

    public void UpdateObjState(Bounds playerBound)
    {

        if (childs == null)
            return;

        foreach(var child in childs)
        {
            child.UpdateObjState(playerBound);
        }
    }
}

public class QTLeaf: INode
{
    private Bounds bound;
    private List<GameObjData> gameObjs;
    private bool isActive;

    public QTLeaf(Bounds bound)
    {
        this.bound = bound;
        isActive = false;
    }

    public void CreateChild()
    {
        return;
    }

    public void  DrawNodeBound()
    {
        if (isActive)
        {
            Gizmos.DrawWireCube(bound.center, bound.size);
        }
    }

    public void Insert(GameObjData data)
    {
        if (!BoundUtils.Constains(bound, data.position))
            return;

        if (gameObjs == null)
        {
            gameObjs = new List<GameObjData>();
        }
        gameObjs.Add(data);
    }

    public void UpdateObjState(Bounds playerBound)
    {
        if (gameObjs == null)
            return;

        if (!BoundUtils.Intersects(bound, playerBound))
        {
            if (isActive)
            {
                foreach (var gameObj in gameObjs)
                {
                    gameObj.UnActiveObj();
                }
                isActive = false;
            }
        }
        else {
            if (!isActive)
            {
                foreach(var gameObj in gameObjs)
                {
                    if (gameObj.isUnInstantiate())
                    {
                        gameObj.Instantiate();
                    }
                    else
                    {
                        gameObj.ActiveObj();
                    }
                }
                isActive = true;
            }
        }

        
    }
}

//因结点和叶子节点略不同，用接口来统一操作
public interface INode
{
    void CreateChild();
    void Insert(GameObjData data);
    void UpdateObjState(Bounds playerBound);

    void DrawNodeBound();
}
