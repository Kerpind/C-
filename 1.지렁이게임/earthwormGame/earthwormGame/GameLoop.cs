using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//화면 크기
//public const int BOARD WIDTH = 60; //세로가 가로의 절반크기임 / 가로 2칸 = 세로 1칸
//public const int BOARD HEIGHT = 30; //const일경우 클래스이름.이름 으로 Main에 불러올 수 있음

//점수 생성
//플레이어 객체 생성
//아이템 객체 생성
//bool형태로 게임오버 생성

//처음 생성시
//Awake 함수
//커서안보이게 Console.CuSorVisiable = false
//Console.BufferWidth = Console.WindowWidth = BOARDWIDTH;
//Console.BufferHeight = Console.WindowHeight = BOARDHEIGHT;
//플레이어 아이템 객체 생성


//초기화
//Start 함수
//플레이어 객체 생성
//플레이어 위치 x = 게임루프.이름 / 2;
//아이템 위치 함수 불러        

//각종 계산
//Update 함수
//프레임 계산
//현재 시간 &Int32.MaxValue;
//이전 시간
//조건문 사용해서 1/10초마다 한번씩 실행
//플레이어 업데이트
//isAlive - 살아있는지 어떻게 체크해
//조건문 안에 새로운 조건문 추가 = 플레이어가 살아있는지 bool형태로 체크
//isGameOver = 참
//return

//입력키처리
//이거 키 사용중이야?
//그럼 키정보 이름 = 콘솔.입력받은 키 (bool)
//switch(객체.키)
//case 출력이동키.방향키 + 함수불러와서 사용

//충돌체크 
//만약 플레이어 위치랑 아이템 위치가 같다면?
//점수 + 
//아이템 위치 바꿔줘 (함수소환)


//화면 출력
//클리어
//Render 함수 
//플레이어, 아이템 객체의 함수 생성
//점수표시(커서포지션, 출력)

//isAlive
//화면 밖으로 나가면 죽음

//isGameOver
//만약 게임오버면
//커서포지션 (중앙위치)
//"게임오버" 출력

//업그레이드 - 2인용 게임
//업그레이드 - 상대방 머리와 부딪히면 게임 오버
//총 점수 계산 출력

namespace earthwormGame
{
    internal class GameLoop
    {
        public const int BOARD_WIDTH = 60; //가로
        public const int BOARD_HEIGHT = 30; //세로  

        bool isGameOver = false;
        public bool NeedRefresh = false;

        int score_player_1 = 0;
        int score_player_2 = 0;

        Player player = null;
        Player player2 = null;
        Item item = null;
        Random random = new Random();
        int oldTime = 0;

        // console 창 크기 설정 및 플레이어1, 플레이어2, 아이템 객체 생성
        public void Awake()
        {
            //커서 안보이게
            Console.CursorVisible = false;
            //버퍼 = 창 = 값
            Console.BufferHeight = Console.WindowHeight = BOARD_HEIGHT;
            Console.BufferWidth = Console.WindowWidth = BOARD_WIDTH;

            player = new Player();
            player2 = new Player();
            item = new Item();
        }

        // 맵 생성
        public void Map_Tile()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(2, 2);
            Console.Write("♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬");
            for (int i = 2; i < 28; i++)
            {
                Console.SetCursorPosition(2, i);
                Console.WriteLine("♬");
                Console.SetCursorPosition(56, i);
                Console.WriteLine("♬");
            }
            Console.SetCursorPosition(2, 28);
            Console.Write("♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬♬");
            Console.ResetColor();
            NeedRefresh = true;
        }

        // 시작 전 세팅
        public void Start()
        {
            if (NeedRefresh == false) { return; }
            player.Start();     // 플레이어 초기 생성 위치 지정
            player.Render();    // 플레이어1 생성
            player.Render2();   // 플레이어2 생성
            item.Awake();       // 아이템 초기 세팅
            //item.Update();      // 아이템 배열값 업데이트(중복되는 숫자 확인... 모르겠어... )
            item.Render();      // 아이템 랜덤 위치 생성
        }

        int px;
        int py;
        int px2;
        int py2;
        int[] ix;
        int[] iy;

        public void Render()
        {
            if (NeedRefresh == false) { return; }
            player.Render();
            player.Render2();
            item.Render();

            Console.SetCursorPosition(2, 0);
            Console.Write("1P : {0}", score_player_1);

            Console.SetCursorPosition(50, 0);
            Console.Write("2P : {0}", score_player_2);

            if (isGameOver)
            {
                Console.Clear();
                Console.SetCursorPosition(BOARD_WIDTH / 2 - 10, BOARD_HEIGHT / 2); //출력 위치
                Console.Write("[ G A M E  O V E R ]");                             //출력할 내용
                Console.ReadKey();

                NeedRefresh = false;
            }
        }

        public void Update()
        {
            // 플레이어1, 플레이어2 이동키 입력에 따른 이동 준비
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo Key = Console.ReadKey();

                switch (Key.Key)
                {
                    //플레이어1
                    case ConsoleKey.RightArrow:
                        player.KeyRight();
                        break;

                    case ConsoleKey.LeftArrow:
                        player.KeyLeft();
                        break;

                    case ConsoleKey.UpArrow:
                        player.KeyUp();
                        break;

                    case ConsoleKey.DownArrow:
                        player.KeyDown();
                        break;

                    //플레이어2
                    case ConsoleKey.D:
                        player.KeyRight2();
                        break;

                    case ConsoleKey.A:
                        player.KeyLeft2();
                        break;

                    case ConsoleKey.W:
                        player.KeyUp2();
                        break;

                    case ConsoleKey.S:
                        player.KeyDown2();
                        break;
                }
            }

            px = player.GetXpos();
            py = player.GetYpos();
            px2 = player.GetXpos2();
            py2 = player.GetYpos2();

            int curTime = System.Environment.TickCount & Int32.MaxValue;

            if (curTime - oldTime > (1000 / 10))                    // 조건문 사용해서 1/10초마다 한번씩 실행
            {
                player.Update();                                    // 플레이어1, 플레이어2 위치 이동
                oldTime = curTime;

                // 플레이어 위치 == 아이템 위치 충돌 체크
                for (int i = 0; i < 10; i++)
                {
                    if ((px == item.arr_xpos[i]) && (py == item.arr_ypos[i]))
                    {
                        //Console.SetCursorPosition(2, 0);
                        score_player_1 += 100;                                      // 점수 추가
                        player.count++;                                             // 꼬리 추가
                        player.newTail();                                           // 꼬리 배열 배치
                        item.NewAwake(i);                                           // 아이템 새로 추가
                    }
                    if ((px2 == item.arr_xpos[i]) && (py2 == item.arr_ypos[i]))
                    {
                        //Console.SetCursorPosition(20, 0);
                        score_player_2 += 100;                                      // 점수 추가
                        player.count2++;                                            // 꼬리 추가
                        player.newTail();                                           // 꼬리 배열 배치
                        item.NewAwake(i);                                           // 아이템 새로 추가
                    }
                }

                // 플레이어1, 플레이어2 충돌 체크(본체 및 꼬리 전체 체크)
                for (int i = 0; i < player.count; i++)
                {
                    if ((px == player.Tail_x_2[i]) && (py == player.Tail_y_2[i]))
                    {
                        isGameOver = true; // 게임오버
                    }
                    if ((px2 == player.Tail_x[i]) && (py2 == player.Tail_y[i]))
                    {
                        isGameOver = true; // 게임오버
                    }
                }

                // 플레이어1 or 플레이어2 벽 충돌 체크
            }
        }
    }
}