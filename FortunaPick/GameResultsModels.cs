namespace FortunaPick
{
    public class LottoResults(string game, DateOnly date, int ball1, int ball2, int ball3, int ball4, int ball5, int ball6, int bonusball) : IGameResults
    {
        public string? Game { get; } = game;
        public DateOnly? Date { get; } = date;
        public int? Ball1 { get; } = ball1;
        public int? Ball2 { get; } = ball2;
        public int? Ball3 { get; } = ball3;
        public int? Ball4 { get; } = ball4;
        public int? Ball5 { get; } = ball5;
        public int? Ball6 { get; } = ball6;
        public int? BonusBall { get; } = bonusball;
    }

    public class ThunderBallResults(string game, DateOnly date, int ball1, int ball2, int ball3, int ball4, int ball5, int thunderball) : IGameResults
    {
        public string? Game { get; } = game;
        public DateOnly? Date { get; } = date;
        public int? Ball1 { get; } = ball1;
        public int? Ball2 { get; } = ball2;
        public int? Ball3 { get; } = ball3;
        public int? Ball4 { get; } = ball4;
        public int? Ball5 { get; } = ball5;
        public int? ThunderBall { get; } = thunderball;
    }

    public class EuroMillionsResults (string game, DateOnly date, int ball1, int ball2, int ball3, int ball4, int ball5, int star1, int star2, string ticket) : IGameResults
    {
        public string? Game { get; } = game;
        public DateOnly? Date { get; } = date;
        public int? Ball1 { get; } = ball1;
        public int? Ball2 { get; } = ball2;
        public int? Ball3 { get; } = ball3;
        public int? Ball4 { get; } = ball4;
        public int? Ball5 { get; } = ball5;
        public int? Star1 { get; } = star1;
        public int? Star2 { get; } = star2;
        public string? Ticket { get; } = ticket;
    }

    public class SetforlifeResults(string game, DateOnly date, int ball1, int ball2, int ball3, int ball4, int ball5, int lifeball) : IGameResults
    {
        public string? Game { get; } = game;
        public DateOnly? Date { get; } = date;
        public int? Ball1 { get; } = ball1;
        public int? Ball2 { get; } = ball2;
        public int? Ball3 { get; } = ball3;
        public int? Ball4 { get; } = ball4;
        public int? Ball5 { get; } = ball5;
        public int? LifeBall { get; } = lifeball;
    }

    public enum GameType
    {
        Lotto,
        ThunderBall,
        EuroMillions,
        SetForLife
    }
}
