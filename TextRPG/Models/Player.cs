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
        maxHp: 100, 
        maxMp: 50, 
        attackPower:20, 
        defence:10, 
        level:1)
    {
        Job = job;
        Gold = 1000;
    }
    #endregion
}