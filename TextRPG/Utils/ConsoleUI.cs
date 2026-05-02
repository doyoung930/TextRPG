using System;
namespace TextRPG.Utils;

// 콘솔 관련 UI 유틸리티를 담당하는 클래스
public class ConsoleUI
{
    // Title: 표시 메서드
    public static void ShowTitle()
    {
        Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════════════╗
║                                                                       ║
║  ████████╗███████╗██╗  ██╗████████╗    ██████╗ ██████╗  ██████╗       ║
║  ╚══██╔══╝██╔════╝╚██╗██╔╝╚══██╔══╝    ██╔══██╗██╔══██╗██╔════╝       ║
║     ██║   █████╗   ╚███╔╝    ██║       ██████╔╝██████╔╝██║  ███╗      ║
║     ██║   ██╔══╝   ██╔██╗    ██║       ██╔══██╗██╔═══╝ ██║   ██║      ║
║     ██║   ███████╗██╔╝ ██╗   ██║       ██║  ██║██║     ╚██████╔╝      ║
║     ╚═╝   ╚══════╝╚═╝  ╚═╝   ╚═╝       ╚═╝  ╚═╝╚═╝      ╚═════╝       ║
║                                                                       ║
║                    턴제 전투 텍스트 RPG 게임                          ║
║                                                                       ║
╚═══════════════════════════════════════════════════════════════════════╝
");
    }
    // 아무키나 누르면 계속 메시지 출력
    public static void PressAnyKey()
    {
        Console.WriteLine("\n아무 키나 누르면 계속 합니다...");
        Console.ReadKey(true);
    }

    public static void ShowGameOver()
    {
        Console.Clear();
        Console.WriteLine("\n╔══════════════════════════════════════════╗");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("║            GAME OVER                     ║");
        Console.WriteLine("║                                          ║");
        Console.WriteLine("╚══════════════════════════════════════════╝\n");
        Console.WriteLine("게임을 종료합니다...");
    }
}