﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    public static class tag {
        public static string enemy = "enemy";
        public static string player = "player";
    }
    public static class anim_str {
        public static string slide = "slide";
        public static string keepGoal = "keepGoal";
        public static string keepGoal_2 = "keepGoal_2";
        public static string xoac = "xoac";
        public static string idle = "idle";
        public static string kick = "kick";
        public static string keepGoal_Fail = "keepGoal_Fail";
        public static string lose = "lose";
        public static string take_ball = "take_ball";
        public static string happy_1 = "happy_1";
        public static string happy_2 = "happy_2";
        public static string happy_3 = "happy_3";
        public static string happy_4 = "happy_4";
        public static string run = "run";
    }
    public static class Cons_Value {
        public static float time_Rote_Character = 0.3f;
        public static float time_anim_Character_Kick = 0.3f;
        public static float time_Enemy_Move_Loop = 1f;
        public static float time_Enemy_Rote_Loop = 0.1f;
        public static float time_To_Complete_cam1 = 0.6f;
        public static float time_To_Complete_cam1_Big = 0.7f;// dư dư ra 1 tí để camera đến hẳn điểm offset
    }
    
}
