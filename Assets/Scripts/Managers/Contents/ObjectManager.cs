using Protocol;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager
{
    public MyPlayer MyPlayer { get; set; }
    Dictionary<ulong, GameObject> _objects = new Dictionary<ulong, GameObject>();
    Dictionary<ulong, GameObject> _monsters = new Dictionary<ulong, GameObject>();

    public void Add(ObjectInfo info, bool myPlayer = false)
    {
        if (myPlayer)
        {
            GameObject go = Managers.Resource.Instantiate("MyPlayer");
            go.name = info.Name;
            _objects.Add(info.ObjectId, go);

            MyPlayer = go.GetComponent<MyPlayer>();
            MyPlayer.Id = info.ObjectId;
            MyPlayer.SetHealth(info.Health);
            MyPlayer.PosInfo = info.PosInfo;
        }
        else
        {
            GameObject go = Managers.Resource.Instantiate("Player");
            go.name = info.Name;
            _objects.Add(info.ObjectId, go);

            Player player = go.GetComponent<Player>();
            player.Id = info.ObjectId;
            player.SetHealth(info.Health);
            player.PosInfo = info.PosInfo;
        }
    }
    public void AddMonster(ObjectInfo info)
    {
        GameObject go = Managers.Resource.Instantiate("Monster");
        go.name = info.Name;
        _monsters.Add(info.ObjectId, go);

        Monster monster = go.GetComponent<Monster>();
        monster.Id = info.ObjectId;
        monster.SetHealth(info.Health);
        monster.PosInfo = info.PosInfo;
    }
    public void Add(ulong id, GameObject go)
    {
        _objects.Add(id, go);
    }

    public void RemoveMyPlayer()
    {
        if (MyPlayer == null)
            return;

        Remove(MyPlayer.Id);
        MyPlayer = null;
    }
    public void Remove(ulong id)
    {
        GameObject go = FindById(id);
        if (go == null)
            return;

        _objects.Remove(id);
        Managers.Resource.Destroy(go);
    }

    public GameObject FindById(ulong id)
    {
        GameObject go = null;
        _objects.TryGetValue(id, out go);
        return go;
    }
    public GameObject FindByMonsterId(ulong id)
    {
        GameObject go = null;
        _monsters.TryGetValue(id, out go);
        return go;
    }
}
