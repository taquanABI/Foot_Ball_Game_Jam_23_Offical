using UnityEngine;
using System.Collections.Generic;
using System;

public class Cache
{

    private static Dictionary<float, WaitForSeconds> m_WFS = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds GetWFS(float key)
    {
        if(!m_WFS.ContainsKey(key))
        {
            m_WFS[key] = new WaitForSeconds(key);
        }

        return m_WFS[key];
    }

    //------------------------------------------------------------------------------------------------------------


    private static Dictionary<Collider, Plane_Drawn_Arrow> m_Plane_Drawn_Arrow = new Dictionary<Collider, Plane_Drawn_Arrow>();

    public static Plane_Drawn_Arrow Get_Plane(Collider key)
    {
        if (!m_Plane_Drawn_Arrow.ContainsKey(key))
        {
            m_Plane_Drawn_Arrow.Add(key, key.GetComponent<Plane_Drawn_Arrow>());
        }

        return m_Plane_Drawn_Arrow[key];
    }
    
    //------------------------------------------------------------------------------------------------------------


    private static Dictionary<Collider, Colider_Merge> m_Colider_Merge = new Dictionary<Collider, Colider_Merge>();

    public static Colider_Merge Get_Colider_Merge(Collider key)
    {
        if (!m_Colider_Merge.ContainsKey(key))
        {
            m_Colider_Merge.Add(key, key.GetComponent<Colider_Merge>());
        }

        return m_Colider_Merge[key];
    }
    
    //------------------------------------------------------------------------------------------------------------


    private static Dictionary<Collider, Goal> m_Colider_Goal = new Dictionary<Collider, Goal>();

    public static Goal Get_Colider_Goal(Collider key)
    {
        if (!m_Colider_Goal.ContainsKey(key))
        {
            m_Colider_Goal.Add(key, key.GetComponent<Goal>());
        }

        return m_Colider_Goal[key];
    }

    //private static Dictionary<Collider, Character> m_Character = new Dictionary<Collider, Character>();

    //public static Character GetCharacter(Collider key)
    //{
    //    if (!m_Character.ContainsKey(key))
    //    {
    //        m_Character.Add(key, key.GetComponent<Character>());
    //    }

    //    return m_Character[key];
    //}


}
