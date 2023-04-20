namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _player1Score;
        private int _player2Score;

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Score += 1;
            else
                _player2Score += 1;
        }

        public string GetScore()
        {
            string score = "";
            if (IsCurrentResultTied())
            {
                score = GetScoreWhenGameIsTied();
            }
            else if (IsAnyPlayerOnAdvantage())
            {
                var playersScoreDifference = _player1Score - _player2Score;
                score = playersScoreDifference switch
                {
                    1 => "Advantage player1",
                    -1 => "Advantage player2",
                    >= 2 => "Win for player1",
                    _ => "Win for player2"
                };
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    var tempScore = 0;
                    if (i == 1) tempScore = _player1Score;
                    else { score += "-"; tempScore = _player2Score; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }

        protected string GetScoreWhenGameIsTied()
        {
            string score;
            score = _player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
            return score;
        }

        private bool IsAnyPlayerOnAdvantage()
        {
            return _player1Score >= 4 || _player2Score >= 4;
        }

        private bool IsCurrentResultTied()
        {
            return _player1Score == _player2Score;
        }
    }
}

