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

namespace 지렁이게임_3차
{
    internal class Player
    {
        int player_xpos = 0;                     //플레이어1
        int player_ypos = 0;
        int player_xpos2 = 0;                    //플레이어2
        int player_ypos2 = 0;
        int[,] P_1;
        int[,] P_2;
        GameLoop gl = new GameLoop();

        bool isAlive;

        public int count = 0;                       //플레이어 카운트함수 생성
        public int count2 = 0;

        int[] Tail_x;                               //꼬리 배열 선언 2개
        int[] Tail_y;
        int[] Tail_x_2;
        int[] Tail_y_2;

        int dir = 0;                                //0.오른  1.위  2.왼  3.아래
        int dir2 = 2;

        public void SetAlive()                      //죽음체크
        {
            int[,] P_1 = new int[player_xpos, player_ypos];
            int[,] P_2 = new int[player_xpos2, player_ypos2];

            if (player_xpos == GameLoop.BOARD_WIDTH || player_xpos == 0 || player_ypos == GameLoop.BOARD_HEIGHT || player_ypos == 0)
                isAlive = false;
            if (player_xpos2 == GameLoop.BOARD_WIDTH || player_xpos2 == 0 || player_ypos2 == GameLoop.BOARD_HEIGHT || player_ypos2 == 0)
                isAlive = false;
            /*if (P_1 == P_2)
                isAlive = false;*/
            else
                isAlive = true;
        }
        public bool GetAlive() { return isAlive; }  //bool값 형태의 함수 반환값을 bool형태로
        public int GetXpos() { return player_xpos; }
        public int GetYpos() { return player_ypos; }
        public int GetXpos2() { return player_xpos2; }
        public int GetYpos2() { return player_ypos2; }
        public void Awake()
        {
            //꼬리 배열 
            /*Tail_x = new int[10];
            Tail_y = new int[10];
            Tail_x_2 = new int[10];
            Tail_y_2 = new int[10];*/
            
        }
        public void Start()
        {
            player_xpos = GameLoop.BOARD_WIDTH / 2 + 10; //플레이어 위치 
            player_ypos = GameLoop.BOARD_HEIGHT / 2;
            player_xpos2 = GameLoop.BOARD_WIDTH / 2 - 10;
            player_ypos2 = GameLoop.BOARD_HEIGHT / 2;
        }
        //플레이어1
        public void KeyRight()
        {
            dir = 0;
        }
        public void KeyLeft()
        {
            dir = 2;
        }
        public void KeyUp()
        {
            dir = 1;
        }
        public void KeyDown()
        {
            dir = 3;
        }
        //플레이어2
        public void KeyRight2()
        {
            dir2 = 0;
        }
        public void KeyLeft2()
        {
            dir2 = 2;
        }
        public void KeyUp2()
        {
            dir2 = 1;
        }
        public void KeyDown2()
        {
            dir2 = 3;
        }
        public void Update()
        {
            // 꼬리 갯수 범위 지정
            // 머리 뒤에 있는 애
            // 1보다 클 경우 꼬리 위치
            // 0이거나 0보다 작을때 머리 값 받아오기
            if (count > 0 && count <= 100)
            {
                for (int i = count; i > 0; i--)
                {
                    if (i > 1)
                    {
                        Tail_x[i] = Tail_x[i - 1];
                        Tail_y[i] = Tail_y[i - 1];
                    }
                    else
                    {
                        Tail_x[i] = player_xpos;
                        Tail_y[i] = player_ypos;
                    }
                }
            }
            if (count2 > 0 && count2 <= 1000)
            {
                for (int i = count2; i > 0; i--)
                {
                    if (i > 1)
                    {
                        Tail_x_2[i] = Tail_x_2[i - 1];
                        Tail_y_2[i] = Tail_y_2[i - 1];
                    }
                    else
                    {
                        Tail_x_2[i] = player_xpos2;
                        Tail_y_2[i] = player_ypos2;
                    }
                }
            }

            //프로그램에서 매프레임마다 그려주기 때문에 Console.Clear는 안 넣어도 됨
            //플레이어1
            switch (dir)
            {
                case 0: //0. 오른 1. 위 2. 왼 3. 아래

                    player_xpos += 2;
                    if (player_xpos > GameLoop.BOARD_WIDTH - 6)
                    {
                        player_xpos = GameLoop.BOARD_WIDTH - 6;
                        isAlive = false; // 벽에 닿으면 죽음 판정 -> 게임오버
                    }
                    break;

                case 1:
                    player_ypos--;
                    if (player_ypos < 3)
                    {
                        player_ypos = 3;
                        isAlive = false;
                    }
                    break;

                case 2:
                    player_xpos -= 2;
                    if (player_xpos < 4)
                    {
                        player_xpos = 4;
                        isAlive = false;
                    }
                    break;

                case 3:
                    player_ypos++;
                    if (player_ypos > GameLoop.BOARD_HEIGHT - 3)
                    {
                        player_ypos = GameLoop.BOARD_HEIGHT - 3;
                        isAlive = false;
                    }
                    break;

            }
            switch (dir2)
            {
                //플레이어2
                case 0:
                    player_xpos2 += 2;
                    if (++player_xpos2 > GameLoop.BOARD_WIDTH - 6)
                    {
                        player_xpos2 = GameLoop.BOARD_WIDTH - 6;
                        isAlive = false; // 벽에 닿으면 죽음 판정 -> 게임오버
                    }
                    break;

                case 1:
                    player_ypos2--;
                    if (player_ypos2 < 3)
                    {
                        player_ypos2 = 3;
                        isAlive = false;
                    }

                    break;

                case 2:
                    player_xpos2 -= 2;
                    if (player_xpos2 <= 4)
                    {
                        player_xpos2 = 4;
                        isAlive = false;
                    }
                    break;

                case 3:
                    player_ypos2++;
                    if (player_ypos2 > GameLoop.BOARD_HEIGHT - 3)
                    {
                        player_ypos2 = GameLoop.BOARD_HEIGHT - 3;
                        isAlive = false;
                    }
                    break;
            }
        }
        public void Render()
        {
            Console.SetCursorPosition(player_xpos, player_ypos);
            Console.ForegroundColor = ConsoleColor.Magenta; //색 넣어줌
            Console.Write("★");
            Console.ResetColor(); //색 초기화

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
        public void Render2()
        {
            Console.SetCursorPosition(player_xpos2, player_ypos2);
            Console.ForegroundColor = ConsoleColor.Cyan; //색 넣어줌
            Console.Write("★");
            Console.ResetColor(); //색 초기화

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
    }
}
//Render
//꼬리 배열출력하기 위한 조건 : 카운트가 0보다 크고 10보다 같거나 작은조건
//i = 카운트, i가 0보다 클때, i는 --
//커서포지션 = 꼬리 배열 x[i], y[i]
//꼬리출력 ""

// 입력이 되는 곳마다 NeedRefresh = true;
// Console.Clear();는 각 계산에 넣지말고 GameLoop 클래스 안에서 사용하는게 더 깔끔

/*//죽음체크 시도해보려고 했던 애
public void SetAlive()                      //죽음체크
{
    if (player_xpos == GameLoop.BOARD_WIDTH - 4 || player_xpos == 4 || player_ypos == GameLoop.BOARD_HEIGHT || player_ypos == 4)
    {
        isAlive = false;
        Console.Write("[ 1 P  W I N ]");
    }

    if (player_xpos2 == GameLoop.BOARD_WIDTH - 4 || player_xpos2 == 4 || player_ypos2 == GameLoop.BOARD_HEIGHT || player_ypos2 == 4)
    {
        isAlive = false;
        Console.Write("[ 2 P  W I N ]");
    }

    if (player_xpos == player_xpos2 || player_ypos == player_ypos2)
    {
        isAlive = false;
        Console.Write("[ G A M E  O V E R ]");
    }

    else
        isAlive = true;
}*/