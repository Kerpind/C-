using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//위치 초기화
//겟함수생성(x, y반환값)

//위치를 랜덤하게 만들어주는 함수 생성
//x,y를 임의의 위치로 할당
//RefreshPos 함수
//랜덤값
//x = 랜덤위치 (x, y좌표값); - 클래스.이름 호출해서 사용가능


//화면 출력
//Render 함수 
//커서포지션
//출력"i"

//추가할것 아이템 배열로 여러개 생성

//0727
/*아이템이 꼬리가 생기면 잘리는 문제
 점수랑 맵이 번쩍댐
 죽었는지 체크하는 것 넣어야 함
 적과 플레이어 충돌체크
 */
namespace 지렁이게임_3차
{
    internal class Item
    {
        Random random = new Random();

        const int count_x = 10;
        const int count_y = 10;
        public int x;
        public int y;
        //public int[,] I_arr = new int[count_x, count_y];
        int[] arr_xpos = new int[count_x];
        int[] arr_ypos = new int[count_y];
        public int GetXpos() { return x; }        
        public int GetYpos() { return y; }
        public int[] aGetXpos()
        {
            return arr_xpos;
        }
        public void aSetXpos(int[] a)
        {
            arr_xpos = a;
        }
        public int[] aGetYpos()
        {
            return arr_ypos;
        }
        
        //public int[,] Getpos_I_arr() { return I_arr; }
        public int GetCountXpos() { return count_x; }
        public int GetCountYpos() { return count_y; }

        public void Awake()
        {
            for (int i = 0; i < count_x; i++)
            {
                while (true) 
                {
                    x = random.Next(4, 58); // x가 10개

                    if (x % 2 == 0)
                    { break; }
                }
                arr_xpos[i] = x;
            }
            for (int j = 0; j < count_y; j++)
            {
                y = random.Next(4, 28); // y가 10개 
                arr_ypos[j] = y;
            }
        }
        public void Update()
        {
            for (int i = 0; i < count_x; i++)
            {
                while (true)
                {
                    x = random.Next(4, 56);                   
                    if (x % 2 == 0) break;                    
                }
                x = -i / 10;                
            }
            for (int i = 0; i < count_y; i++)
            {
                while (true)
                {
                    y = random.Next(4, 28);                   
                    if (y % 2 == 0) break;
                }                
                y = -i / 10; //배열 y 위치값 초기화 -> 2개 넘기면 위치를 -1값을 주기 위함
            }
        }
        public void Render()
        {
            for (int i = 0; i < count_x; i++) //카운트만큼 i 증가
            {              
                Console.SetCursorPosition(arr_xpos[i], arr_ypos[i]);
                Console.Write("○");
            }
        }
    }
}

/*public void Init()
{
    heigth_x = random.Next(0, GameLoop.BOARD_WIDTH - 1);
    width_y = random.Next(0, GameLoop.BOARD_HEIGHT - 1);

    // 아이템의 갯수를 배열로 생성 
    int[,] items = new int[heigth_x, width_y];
}*/

/*bool IsAlive = false; //bool값 형태의 IsAlive 생성 = false일때 죽음
public bool GetIsAlive() { return IsAlive; }
//반환값 형태 {반환할애 이름}
public void SetIsAlive(bool alive) { IsAlive = alive; }
//대입값에 넣을 형태 {대입해줄 값 = 대입해줄 대상}*/


//Render
/*for (int i = 0; i < count; i++) // count 만큼 생성
{
    if (arr_ypos[i] < 0) { continue; } //조건이 맞으면 다시 for문
    Console.SetCursorPosition(arr_xpos[i], arr_ypos[i]);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("○");
    Console.ResetColor();
}*/
