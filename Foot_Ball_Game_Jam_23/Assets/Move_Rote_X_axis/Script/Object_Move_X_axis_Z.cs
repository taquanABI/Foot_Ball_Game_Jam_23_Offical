using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Object_Move_X_axis_Z : MonoBehaviour
{
    [Tooltip("tf_local đi theo tf_Focus")]
    public Transform tf;//tf local đi theo tf_Focus
    [Tooltip("tf_Rotate để xoay hình ảnh - anim nhân vật")]
    public Transform tf_Rotate;
    [Tooltip("tf_Focus để tf_local đi theo")]
    public Transform tf_Focus_X;
    public float speed;
    public float speedX;
    public float speedXPlayer;

    public Transform tf_Focus_Path;


    public List<Transform> list_Tf_Path;
    public Vector3[] arr_Path;
    [Header("Gioi han di chuyen")]
    [SerializeField] private InputMouse_Z _mouseInput;
    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public bool isCan_Rote;
    public bool isCan_Move;
    private void Awake()
    {
        Set_Config_Path();
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartPlaying();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCan_Move) return;

        tf_Focus_X.localPosition = new Vector3(tf_Focus_X.localPosition.x + (_mouseInput.MoveFactorX * speedX * 0.001f), tf_Focus_X.localPosition.y + (_mouseInput.MoveFactorY * speedX * 0.001f), tf_Focus_X.localPosition.z);

        tf.localPosition = Vector3.LerpUnclamped(tf.localPosition, tf_Focus_X.localPosition, speedXPlayer * Time.deltaTime);

        Rotate(_mouseInput.MoveFactorX);

        tf_Focus_X.localPosition = new Vector3(Mathf.Clamp(tf_Focus_X.localPosition.x, minX, maxX), Mathf.Clamp(tf_Focus_X.localPosition.y, minY, maxY), tf_Focus_X.localPosition.z);

        tf.localPosition = new Vector3(Mathf.Clamp(tf.localPosition.x, minX, maxX), Mathf.Clamp(tf.localPosition.y, minY, maxY), tf.localPosition.z);

    }


    public void Set_Config_Path()
    {
        arr_Path = new Vector3[list_Tf_Path.Count];
        for (int i = 0; i < list_Tf_Path.Count; i++)
        {
            arr_Path[i] = list_Tf_Path[i].position;
        }
    }

    #region Support
    float rY;
    float _t;
    private void Rotate(float value)
    {
        if (!isCan_Rote) return;
        if (Input.GetMouseButton(0))
        {
            if (value > 0)
            {
                _t = 0;
                if (rY < 0) rY = 0;
                else rY += 300 * Time.deltaTime;
            }
            else if (value < 0)
            {
                _t = 0;
                if (rY > 0) rY = 0;
                else rY -= 300 * Time.deltaTime;
            }
            else
            {
                _t += Time.deltaTime;

                if (_t >= 0f) rY = rY.Lerp(0, 1f);
            }
        }
        else
        {
            rY = rY.Lerp(0, 1f);
        }

        tf_Rotate.localRotation = Quaternion.Euler(new Vector3(0, Mathf.Clamp(rY, -15, 15), 0));
    }
    #endregion Support

    [ContextMenu("Start_Playing")]
    public void StartPlaying()
    {
        tf_Focus_Path.DOPath(arr_Path, speed, PathType.CatmullRom)
            .SetSpeedBased(true)
            .SetLookAt(0)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {

            });
    }
}
/*
tf_Focus_Path 
    tf_Parent
        tf
            tf_Rotate
        tf_Focus_X

 
 
 
 */