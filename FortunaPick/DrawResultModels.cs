namespace FortunaPick
{
    public class LottoResult(string game, DateOnly date, int ball1, int ball2, int ball3, int ball4, int ball5, int ball6, int bonusball)
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

        public override string ToString()
        {
            return $"{Game}|{Date}|-[{Ball1}, {Ball2}, {Ball3}, {Ball4}, {Ball5}, {Ball6}] BONUS-[{BonusBall}]";
        }
    }

    public class ThunderBallResult(string game, DateOnly date, int ball1, int ball2, int ball3, int ball4, int ball5, int thunderball)
    {
        public string? Game { get; } = game;
        public DateOnly? Date { get; } = date;
        public int? Ball1 { get; } = ball1;
        public int? Ball2 { get; } = ball2;
        public int? Ball3 { get; } = ball3;
        public int? Ball4 { get; } = ball4;
        public int? Ball5 { get; } = ball5;
        public int? ThunderBall { get; } = thunderball;

        public override string ToString()
        {
            return $"{Game}|{Date}|-[{Ball1}, {Ball2}, {Ball3}, {Ball4}, {Ball5}] THUNDERBALL-[{ThunderBall}]";
        }

    }

    public class EuroMillionsResult (string game, DateOnly date, int ball1, int ball2, int ball3, int ball4, int ball5, int star1, int star2, string ticket)
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

        public override string ToString()
        {
            string s = $"{Game}|{Date}|-[{Ball1}, {Ball2}, {Ball3}, {Ball4}, {Ball5}] STARS-[{Star1}, {Star2}]\r\n" +
                $"\t\t\t\t\tUK Millionaire Maker code{Ticket}\r\n";
            return s;
        }
    }

    public class SetForLifeResult(string game, DateOnly date, int ball1, int ball2, int ball3, int ball4, int ball5, int lifeball)
    {
        public string? Game { get; } = game;
        public DateOnly? Date { get; } = date;
        public int? Ball1 { get; } = ball1;
        public int? Ball2 { get; } = ball2;
        public int? Ball3 { get; } = ball3;
        public int? Ball4 { get; } = ball4;
        public int? Ball5 { get; } = ball5;
        public int? LifeBall { get; } = lifeball;

        public override string ToString()
        {
            return $"{Game}|{Date}|-[{Ball1}, {Ball2}, {Ball3}, {Ball4}, {Ball5}] LIFEBALL-[{LifeBall}]";
        }
    }

    public enum GameType
    {
        Lotto,
        ThunderBall,
        EuroMillions,
        SetForLife
    }
}
