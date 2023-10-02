using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public Transform tf_Ball_In;

    [Tooltip("Speed của cầu thủ sút")]
    public float force_Kick;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
    #region Emoji Display

    [Header("Component for Emoji Display")]

    public List<GameObject> blewEmjs;

    int curEmjIndex;

    public void DisplayEmj()
    {
        List<GameObject> curEmjList;
        curEmjList = blewEmjs;

        curEmjIndex = UnityEngine.Random.Range(0, curEmjList.Count - 1);

        var emjPrefab = curEmjList[curEmjIndex];
        if (emjPrefab)
        {
            var emj = Instantiate(emjPrefab);
            emj.transform.SetParent(emjHolder);
            emj.transform.localPosition = Vector3.zero;
        }
    }

    #endregion

}
