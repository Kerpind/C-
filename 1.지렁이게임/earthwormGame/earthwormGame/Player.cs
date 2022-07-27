using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//생성자
//겟함수생성(반환값)
//bool 형태의 isAlive 생성
//isAlive 함수 (반환값)

// dir 변수 생성 //0.오른  1.위  2.왼  3.아래

//처음 생성시
//Awake 함수
//플레이어 아이템 객체 생성


//초기화
//Start 함수
//플레이어 아이템 객체 생성

//방향키에 따라 이동하는 것의 각 함수 생성
//dir 사용해서 값을 넣으면?

//각종 계산
//Update 함수 
//switch를 사용해서 -> 0.오른  1.위  2.왼  3.아래 case 생성
//case안의 조건도 생성
//만약 화면 범위를 벗어나면? (죽는거 추가)
//화면 범위를 벗어 나기 전에 멈춰주려면? (증가연산자 , 비교, x-1)

//화면 출력
//Render 함수 
//커서포지션
//출력 "P"

namespace earthwormGame
{
    internal class Player
    {
        int player_xpos = 0;                        // 플레이어1 x값
        int player_ypos = 0;                        // 플레이어1 y값


        int player_xpos2 = 0;                       // 플레이어2 x값
        int player_ypos2 = 0;                       // 플레이어2 y값

        int player_xpos_back = 0;                   // 플레이어1 이전 x값(잔상제거)
        int player_ypos_back = 0;                   // 플레이어1 이전 y값(잔상제거)


        int player_xpos2_back = 0;                  // 플레이어2 이전 x값(잔상제거)
        int player_ypos2_back = 0;                  // 플레이어2 이전 y값(잔상제거)

        public int count = 0;                       //플레이어 카운트함수 생성
        public int count2 = 0;

        public int[] Tail_x = new int[100];          //꼬리 배열 선언(최대 10개)
        public int[] Tail_y = new int[100];          
        public int[] Tail_x_2 = new int[100];
        public int[] Tail_y_2 = new int[100];

        int dir = 0;                                //0.오른  1.위  2.왼  3.아래
        int dir2 = 2;
        internal object arr_xpos;

        // 플레이어 초기 생성 위치 지정
        public void Start()
        {
            player_xpos = GameLoop.BOARD_WIDTH / 2 + 10; //플레이어 위치 
            player_ypos = GameLoop.BOARD_HEIGHT / 2;
            player_xpos2 = GameLoop.BOARD_WIDTH / 2 - 10;
            player_ypos2 = GameLoop.BOARD_HEIGHT / 2;
        }

        //플레이어1 생성
        public void Render()
        {
            Console.SetCursorPosition(player_xpos, player_ypos);
            Console.ForegroundColor = ConsoleColor.Magenta; //색 넣어줌
            Console.Write("★");
            Console.ResetColor(); //색 초기화

            // 초기엔 count가 0값이니 안그려집니다.
            if (count > 0 && count <= 100)
            {
                for (int i = count; i > 0; i--)
                {
                    Console.SetCursorPosition(Tail_x[i], Tail_y[i]);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("*");
                    Console.ResetColor();
                }
            }

        }

        //플레이어2 생성
        public void Render2()
        {
            Console.SetCursorPosition(player_xpos2, player_ypos2);
            Console.ForegroundColor = ConsoleColor.Cyan; //색 넣어줌
            Console.Write("★");
            Console.ResetColor(); //색 초기화

            // 초기엔 count가 0값이니 안그려집니다.
            if (count2 > 0 && count2 <= 100)
            {
                for (int i = count2; i > 0; i--)
                {
                    Console.SetCursorPosition(Tail_x_2[i], Tail_y_2[i]);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("*");
                    Console.ResetColor();
                }
            }

        }

        // 플레이어1 키 입력
        public void KeyRight() { dir = 0; }
        public void KeyLeft() { dir = 2; }
        public void KeyUp() { dir = 1; }
        public void KeyDown() { dir = 3; }

        // 플레이어1 좌표값
        public int GetXpos() { return player_xpos; }
        public int GetYpos() { return player_ypos; }

        // 플레이어2  키 입력
        public void KeyRight2() { dir2 = 0; }
        public void KeyLeft2() { dir2 = 2; }
        public void KeyUp2() { dir2 = 1; }
        public void KeyDown2() { dir2 = 3; }

        // 플레이어2 좌표값
        public int GetXpos2() { return player_xpos2; }
        public int GetYpos2() { return player_ypos2; }

        // 플레이어1, 플레이어2 위치 이동
        public void Update()
        {

            player_xpos_back = player_xpos;
            player_ypos_back = player_ypos;

            // 플레이어1 위치 이동
            switch (dir)
            {
                case 0: //0. 오른 1. 위 2. 왼 3. 아래

                    player_xpos += 2;

                    // if 이유 찾지 못하였음..
                    if (player_xpos > GameLoop.BOARD_WIDTH - 6)
                    {
                        player_xpos = GameLoop.BOARD_WIDTH - 6;
                    }

                    break;

                case 1:

                    player_ypos--;

                    // if 이유 찾지 못하였음..
                    if (player_ypos < 3)
                    {
                        player_ypos = 3;
                    }

                    break;

                case 2:

                    player_xpos -= 2;

                    // if 이유 찾지 못하였음..
                    if (player_xpos < 4)
                    {
                        player_xpos = 4;
                    }

                    break;

                case 3:

                    player_ypos++;

                    // if 이유 찾지 못하였음..
                    if (player_ypos > GameLoop.BOARD_HEIGHT - 3)
                    {
                        player_ypos = GameLoop.BOARD_HEIGHT - 3;
                    }

                    break;

            }

            player_xpos2_back = player_xpos2;
            player_ypos2_back = player_ypos2;

            // 이전 플레이어 위치 삭제
            // 플레이어1
            Console.SetCursorPosition(player_xpos_back, player_ypos_back);
            Console.Write("　");                             // 비우는 방법 확인..
            Console.ResetColor();                           // 색 초기화
            // 플레이어2
            Console.SetCursorPosition(player_xpos2_back, player_ypos2_back);
            Console.Write("　");                             // 비우는 방법 확인..
            Console.ResetColor();                           // 색 초기화

            // 플레이어2 위치 이동
            switch (dir2)
            {
                case 0:

                    player_xpos2 += 2;

                    // if 이유 찾지 못하였음..
                    if (++player_xpos2 > GameLoop.BOARD_WIDTH - 6)
                    {
                        player_xpos2 = GameLoop.BOARD_WIDTH - 6;
                    }

                    break;

                case 1:

                    player_ypos2--;

                    // if 이유 찾지 못하였음..
                    if (player_ypos2 < 3)
                    {
                        player_ypos2 = 3;
                    }

                    break;

                case 2:

                    player_xpos2 -= 2;

                    // if 이유 찾지 못하였음..
                    if (player_xpos2 <= 4)
                    {
                        player_xpos2 = 4;
                    }

                    break;

                case 3:

                    player_ypos2++;

                    // if 이유 찾지 못하였음..
                    if (player_ypos2 > GameLoop.BOARD_HEIGHT - 3)
                    {
                        player_ypos2 = GameLoop.BOARD_HEIGHT - 3;
                    }

                    break;
            }


        }

        public void newTail()
        {
            // 꼬리 위치 지정(머리 뒤에 있어야 합니다.)
            if (count > 0 && count <= 10)
            {
                for (int i = 0; i < count; i++)
                {
                    // 꼬리가 1개보다 클 경우 이전 배열값의 숫자에 꼬리 생성
                    if (i > 1)
                    {
                        Tail_x[i] = Tail_x[i - 1];
                        Tail_y[i] = Tail_y[i - 1];
                    }
                    // 꼬리가 0개인 경우엔 머릿값에 꼬리 생성
                    else
                    {
                        Tail_x[i] = player_xpos;
                        Tail_y[i] = player_ypos;
                    }
                }
            }

            // 꼬리 위치 지정(머리 뒤에 있어야 합니다.)
            if (count2 > 0 && count2 <= 10)
            {
                for (int i = 0; i < count2; i++)
                {
                    // 꼬리가 1개보다 클 경우 이전 배열값의 숫자에 꼬리 생성
                    if (i > 1)
                    {
                        Tail_x_2[i] = Tail_x_2[i - 1];
                        Tail_y_2[i] = Tail_y_2[i - 1];
                    }
                    // 꼬리가 0개인 경우엔 머릿값에 꼬리 생성
                    else
                    {
                        Tail_x_2[i] = player_xpos2;
                        Tail_y_2[i] = player_ypos2;
                    }
                }
            }
        }
    }
}