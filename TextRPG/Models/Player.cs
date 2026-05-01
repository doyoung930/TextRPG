namespace TextRPG.Models;



public class Player : Character
{
    #region 프로퍼티
    // 직업
    public JobType Job { get; protected set; }
    // 골드
    public int Gold { get; protected set; }
    // 장착무기
    // 장착방어구
    #endregion
    
    #region 생성자
    public Player(string name, JobType job) : base(
        name:name, 
        maxHp: GetInitHp(job), 
        maxMp: GetInitMp(job), 
        attackPower: GetInitAttack(job), 
        defence: GetInitDefence(job), 
        level:1)
    {
        Job = job;
        Gold = 1000;
    }
    #endregion
        
    #region 직업별 초기 스탯

    private static int GetInitHp(JobType job)
    {
        switch (job)
        {
            case  JobType.Worrior: return 150;
            case  JobType.Archer: return 100;
            case  JobType.Wizard: return 80;
            default: return 100;
        }
    }

    private static int GetInitMp(JobType job)
    {
        switch (job)
        {
            case  JobType.Worrior: return 30;
            case  JobType.Archer: return 50;
            case  JobType.Wizard: return 100;
            default: return 30;
        }
    }

    private static int GetInitAttack(JobType job) =>
        job switch
        {
            JobType.Worrior => 20,
            JobType.Archer => 30,
            JobType.Wizard => 40,
            _ => 20
        };
    
    private static int GetInitDefence(JobType job) =>
        job switch
        {
            JobType.Worrior => 15,
            JobType.Archer => 10,
            JobType.Wizard => 5,
            _ => 15
        };
    #endregion

    #region 메서드
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine(($"골드: {Gold}"));
    }
    #endregion
}