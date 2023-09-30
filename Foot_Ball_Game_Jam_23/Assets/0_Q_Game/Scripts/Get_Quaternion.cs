using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Get_Quaternion
{
    /// <summary>
    /// Gọi ở vòng for dùng biến Ref Transform thay đổi n bị lỗi
    /// </summary>
    /// <param name="tf_Start"></param>
    /// <param name="tf_End"></param>
    /// <returns></returns>
    public static Quaternion Get_Get_Quaternion_To_Target(Transform tf_Start, Transform tf_End)
    {
        // Tính toán vector hướng từ vật thể tới mục tiêu
        Vector3 directionToTarget = tf_End.position - tf_Start.position;

        // Tính toán góc giữa vector hướng và vector bên phải (1, 0, 0)
        float targetAngle = Mathf.Atan2(directionToTarget.z, directionToTarget.x) * Mathf.Rad2Deg;

        // Tạo một góc quay mới để xoay dần về mục tiêu
        return Quaternion.Euler(new Vector3(0, targetAngle, 0));

        /*
        // Tạo một góc quay mới để xoay dần về mục tiêu
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle)); 
        
        // Sử dụng phương thức Lerp để xoay dần về góc mục tiêu
        tf.rotation = Quaternion.Lerp(tf.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        */

    }





    /// <summary>
    /// Cake lại n ko bị lỗi nữa
    /// </summary>
    /// <param name="tf_Start"></param>
    /// <param name="tf_End"></param>
    /// <returns></returns>
    public static Quaternion Get_Get_Quaternion_To_Target(Vector3 tf_Start, Vector3 tf_End)
    {
        // Tính toán vector hướng từ vật thể tới mục tiêu
        Vector3 directionToTarget = tf_End - tf_Start;

        // Tính toán góc giữa vector hướng và vector bên phải (1, 0, 0)
        float targetAngle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;

        // Tạo một góc quay mới để xoay dần về mục tiêu
        return Quaternion.Euler(new Vector3(0, targetAngle, 0));

        /*
        // Tạo một góc quay mới để xoay dần về mục tiêu
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, targetAngle)); 
        
        // Sử dụng phương thức Lerp để xoay dần về góc mục tiêu
        tf.rotation = Quaternion.Lerp(tf.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        */

    }
}
