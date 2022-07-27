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
namespace earthwormGame
{
    internal class Item
    {
        Random random = new Random();

        const int count_x = 10;
        const int count_y = 10;

        public int[] arr_xpos = new int[count_x];
        public int[] arr_ypos = new int[count_y];

        // 아이템 초기 세팅
        public void Awake()
        {
            for (int i = 0; i < count_x; i++)
            {
                arr_xpos[i] = random.Next(4, 58); // x 배열에 4~58 중 랜덤의 숫자 넣기
            }
            for (int j = 0; j < count_y; j++)
            {
                arr_ypos[j] = random.Next(4, 28); // y 배열에 4~28 중 랜덤의 숫자 넣기
            }
        }

        // 아이템 배열값 업데이트(중복되는 숫자 확인... 모르겠어... )
        public void Update()
        {

        }

        // 아이템 랜덤 위치 생성
        public void Render()
        {
            for (int i = 0; i < count_x; i++) //카운트만큼 i 증가
            {
                Console.SetCursorPosition(arr_xpos[i], arr_ypos[i]);
                Console.Write("○");
            }
        }

        // 아이템 신규 세팅(배열 i의 랜덤값 새로 세팅)
        public void NewAwake(int i)
        {
            arr_xpos[i] = random.Next(4, 58); // x 배열에 4~58 중 랜덤의 숫자 넣기
            arr_ypos[i] = random.Next(4, 28); // y 배열에 4~28 중 랜덤의 숫자 넣기
        }
    }
}