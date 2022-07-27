using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//화면 사이즈
//플레이어는 정가운데 생성
//시작하면 자동으로 오른쪽으로 계속 감
//방향키로 이동
//아이템 - 랜덤하게 생성
//아이템 먹을때마다 속도증가
//화면에 부딪히면 사라짐

//업그레이드
//아이템 하나먹을때마다 꼬리 생성
//꼬리가 머리 따라옴


namespace 지렁이게임_3차
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //게임루프 객체
            GameLoop gl = new GameLoop();
            //bool NeedRefresh;

            //객체에 해당하는 함수 소환
            gl.Awake();
            gl.Start();

            //함수 중 필요한 함수는 반복문 안에
            while (true)
            {                
                gl.Update();                
                gl.Render();
                //NeedRefresh = true;
            }          
        }
    }
}
//필요한 구현
//1.적과 플레이어 충돌체크 - 도움받음
//2.아이템 여러개 생성 - 도움받음
//3.적과 플레이어 시작점 수정 - 해결
//4.플레이어 꼬리가 생성되면 적도 같이 생성되는 문제 - 해결
//5.아이템 재생성
//6.적과 플레이어 충돌시 게임오버
