using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document_GamePlay : MonoBehaviour
{
    
}
/*
           
 Reload lại scence khi vào level  mới
 Tạo prefab init cho từng level

Giới hạn góc


























Draw_Line_Control
                int count_Point_Connect_Max;

                int count_Point_Connect

                list<LinePrefabs> list_Prefabs_Line_use
                list<Player> list_Player_Will_Draw
                LinePrefabs
                    ảnh mũi tên
                
                
                
                
                Init()
                    chọn LinePrefabs
                    Get_Count_Point_Connect_Max()
                
                
                
                
                
                
                Draw()
                     Click ct1 .....   
                        Creat line từ ct1 đễn chuột   
                            trong lúc drag gặp ct2   
                                Kiểm tra:      count_Point_Connect <   count_Point_Connect_Max
                                Kiểm tra ct2 # thằng cuối cùng ở list_Player_Will_Draw[count - 1]  
                                    
                                    creat 1 line trắng nỗi giữa 1 và 2
                                        pool setparent
                                    creat 1 line xanh nỗi giữa 2 và chuột trên màn hình
                                        pool setparent

                                    count_Point_Connect++;
                
                                Kiểm tra:  Fail    count_Point_Connect <   count_Point_Connect_Max
                                    Dừng vẽ và bắt đầu chạy cảnh đá bóng đến các cầu thủ
              
               Check_End_Drawn   
                
                
                
                
                
             Line   
                set_pos_Line
                enum type
                
                
                
                
                
                
                
 
 
 
            Player   
                các ct có hướng sút  
                List<Line_Connect_Befor>
                Check_Colision_Enemy()
                
                
            
                Vẽ các line
                
                
                
                đưa bóng di chuyển
                    ẩn các đường line
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
 
 */